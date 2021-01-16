using Livraria.Domain.DTOs;
using Livraria.Domain.Services;
using Livraria.Infra.Data;
using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;

namespace Livraria.API.Controllers
{

    [Route("api/dados-auxiliares")]
    [ApiController]
    public class DadosAuxiliaresController : LivrariaController
    {
        private readonly IDadosAuxiliaresService _dadosAuxiliaresService;
        public DadosAuxiliaresController(IUnitOfWork unitOfWork, IDadosAuxiliaresService dadosAuxiliaresService) : base(unitOfWork)
        {
            _dadosAuxiliaresService = dadosAuxiliaresService;
        }

        /// <summary>
        /// Retorna todos estados
        /// </summary>
        /// <returns></returns>
        [HttpGet("estados")]
        public async Task<IActionResult> ObterTodosEstadosAsync()
        {
            var estados = await _dadosAuxiliaresService.ObterTodosEstadosAsync();
            return Ok(estados);
        }


        /// <summary>
        /// Retorna cidades por estado
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        [HttpGet("estados/{id:int}/cidades")]
        public async Task<IActionResult> ObterCidadePorEstadoAsync(int id)
        {
            var cidades = await _dadosAuxiliaresService.ObterCidadesPorEstadoAsync(id);
            return Ok(cidades);
        }
    }
}