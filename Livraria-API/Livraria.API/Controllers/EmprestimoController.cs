using Livraria.Domain.DTOs;
using Livraria.Domain.Services;
using Livraria.Infra.Data;
using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;

namespace Livraria.API.Controllers
{

    [Route("api/emprestimo")]
    [ApiController]
    public class EmprestimoController : LivrariaController
    {
        private readonly IEmprestimoService _emprestimoService;
        public EmprestimoController(IUnitOfWork unitOfWork, IEmprestimoService emprestimoService) : base(unitOfWork)
        {
            _emprestimoService = emprestimoService;
        }

        /// <summary>
        /// Cria emprestimo de livro
        /// </summary>
        /// <param name="dto"></param>
        /// <returns></returns>
        [HttpPost("")]
        public async Task<IActionResult> CriarAsync([FromBody] EmprestimoDTO dto)
        {
            await _emprestimoService.CriarAsync(dto.UsuarioId, dto.LivroId);
            await UnitOfWork.CommitAsync();
            return Ok();
        }

        /// <summary>
        /// Retorna todos os emprestimos
        /// </summary>
        /// <returns></returns>
        [HttpGet("")]
        public async Task<IActionResult> ObterTodosAsync()
        {
            var emprestimo = await _emprestimoService.ObterTodosAsync();
            return Ok(emprestimo);
        }


        /// <summary>
        /// Devolve um emprestimo.
        /// </summary>
        /// <param name="id">Id do Emprestimo/param>
        /// <returns></returns>
        [HttpPut("{id:int}/devolver")]
        public async Task<IActionResult> DevolverAsync(int id)
        {
            await _emprestimoService.DevolverAsync(id);
            await UnitOfWork.CommitAsync();
            return Ok();
        }
    }
}