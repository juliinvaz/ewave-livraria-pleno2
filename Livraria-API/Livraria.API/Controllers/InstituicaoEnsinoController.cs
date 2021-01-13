using Livraria.Domain.DTOs;
using Livraria.Domain.Services;
using Livraria.Infra.Data;
using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;

namespace Livraria.API.Controllers
{

    [Route("api/instituicoes-ensino")]
    [ApiController]
    public class InstituicaoEnsinoController : LivrariaController
    {
        private readonly IInstituicaoEnsinoService _instituicaoEnsinoService;
        public InstituicaoEnsinoController(IUnitOfWork unitOfWork, IInstituicaoEnsinoService instituicaoEnsinoService) : base(unitOfWork)
        {
            _instituicaoEnsinoService = instituicaoEnsinoService;
        }

        /// <summary>
        ///  Criar instituição de ensino
        /// </summary>
        /// <returns></returns>
        [HttpPost("")]
        public async Task<IActionResult> CriarAsync([FromBody] InstituicaoEnsinoDTO dto)
        {
            await _instituicaoEnsinoService.CriarAsync(dto.Nome, dto.CNPJ, dto.Telefone, dto.CidadeId, dto.Logradouro, dto.CEP, dto.Numero);
            await UnitOfWork.CommitAsync();
            return Ok();
        }

    }
}