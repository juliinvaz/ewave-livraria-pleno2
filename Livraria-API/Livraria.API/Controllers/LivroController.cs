using Livraria.Domain.DTOs;
using Livraria.Domain.Services;
using Livraria.Infra.Data;
using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;

namespace Livraria.API.Controllers
{

    [Route("api/livros")]
    [ApiController]
    public class LivroController : LivrariaController
    {
        private readonly ILivroService _livroService;
        public LivroController(IUnitOfWork unitOfWork, ILivroService livroService) : base(unitOfWork)
        {
            _livroService = livroService;
        }

        /// <summary>
        /// Cria um livro
        /// </summary>
        /// <param name="dto"></param>
        /// <returns></returns>
        [HttpPost("")]
        public async Task<IActionResult> CriarAsync([FromBody] LivroDTO dto)
        {
            await _livroService.CriarAsync(dto.Titulo, dto.Genero, dto.Autor, dto.Sinopse, dto.Capa, dto.SituacaoId);
            await UnitOfWork.CommitAsync();
            return Ok();
        }


        /// <summary>
        /// Retorna todos os livros
        /// </summary>
        /// <returns></returns>
        [HttpGet("")]
        public async Task<IActionResult> ObterTodosAsync()
        {
            var livros = await _livroService.ObterTodosAsync();
            return Ok(livros);
        }

        /// <summary>
        /// Retorna livro por Id
        /// </summary>
        /// <returns></returns>
        [HttpGet("{id:int}")]
        public async Task<IActionResult> ObterLivroPorIdAsync(int id)
        {
            var livro = await _livroService.ObterPorIdAsync(id);
            return Ok(livro);
        }

        /// <summary>
        /// Retorna livros por SituacaoId
        /// </summary>
        /// <param name="situacaoId"> Id da Situação</param>
        /// <returns></returns>
        [HttpGet("por-situacao/{situacaoId:int}")]
        public async Task<IActionResult> ObterLivroPorSituacaoIdAsync(int situacaoId)
        {
            var livros = await _livroService.ObterPorSituacaoAsync(situacaoId);
            return Ok(livros);
        }

        /// <summary>
        /// Altera dados de um livro
        /// </summary>
        /// <param name="id"></param>
        /// <param name="dto"></param>
        /// <returns></returns>
        [HttpPut("{id:int}")]
        public async Task<IActionResult> AlterarAsync(int id, [FromBody] LivroDTO dto)
        {
            await _livroService.AlterarAsync(id, dto.Titulo, dto.Genero, dto.Autor, dto.Sinopse, dto.Capa, dto.SituacaoId);
            await UnitOfWork.CommitAsync();
            return Ok();
        }


        /// <summary>
        /// Ativa um livro
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        [HttpPut("{id:int}/ativar")]
        public async Task<IActionResult> AtivarAsync(int id)
        {
            await _livroService.AtivarAsync(id);
            await UnitOfWork.CommitAsync();
            return Ok();
        }


        /// <summary>
        /// Dessativa um livro
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        [HttpPut("{id:int}/inativar")]
        public async Task<IActionResult> InativarAsync(int id)
        {
            await _livroService.InativarAsync(id);
            await UnitOfWork.CommitAsync();
            return Ok();
        }
    }
}