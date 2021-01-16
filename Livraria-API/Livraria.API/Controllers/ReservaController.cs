using Livraria.Domain.DTOs;
using Livraria.Domain.Services;
using Livraria.Infra.Data;
using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;

namespace Livraria.API.Controllers
{

    [Route("api/reservas")]
    [ApiController]
    public class ReservaController : LivrariaController
    {
        private readonly IReservaService _reservaService;
        public ReservaController(IUnitOfWork unitOfWork, IReservaService reservaService) : base(unitOfWork)
        {
            _reservaService = reservaService;
        }

        /// <summary>
        ///  Cria uma reserva
        /// </summary>
        /// <param name="dto"></param>
        /// <returns></returns>
        [HttpPost("")]
        public async Task<IActionResult> CriarAsync([FromBody] ReservaDTO dto)
        {
            await _reservaService.CriarAsync(dto.UsuarioId, dto.LivroId);
            await UnitOfWork.CommitAsync();
            return Ok();
        }

        /// <summary>
        /// Inativa um reserva
        /// </summary>
        /// <param name="id"> id reserva</param>
        /// <returns></returns>
        [HttpPut("{id:int}/inativar")]
        public async Task<IActionResult> InativarAsync(int id)
        {
            await _reservaService.InativarAsync(id);
            await UnitOfWork.CommitAsync();
            return Ok();
        }

        /// <summary>
        /// Retorna todos as reservas
        /// </summary>
        /// <returns></returns>
        [HttpGet("")]
        public async Task<IActionResult> ObterTodosAsync()
        {
            var reservas = await _reservaService.ObterTodosAsync();
            return Ok(reservas);
        }

        /// <summary>
        /// Retorna reserva por Id
        /// </summary>
        /// <returns></returns>
        [HttpGet("{id:int}")]
        public async Task<IActionResult> ObterPorIdAsync(int id)
        {
            var reservas = await _reservaService.ObterPorIdAsync(id);
            return Ok(reservas);
        }
    }
}