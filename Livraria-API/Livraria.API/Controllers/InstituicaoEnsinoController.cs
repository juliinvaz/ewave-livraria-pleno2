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
        ///  Cria uma instituição de ensino
        /// </summary>
        /// <param name="dto"></param>
        /// <returns></returns>
        [HttpPost("")]
        public async Task<IActionResult> CriarAsync([FromBody] InstituicaoEnsinoDTO dto)
        {
            await _instituicaoEnsinoService.CriarAsync(dto.Nome, dto.CNPJ, dto.Telefone, dto.CidadeId, dto.Logradouro, dto.CEP, dto.Numero);
            await UnitOfWork.CommitAsync();
            return Ok();
        }

        /// <summary>
        /// Retorna todas as instituicões de ensino
        /// </summary>
        /// <returns></returns>
        [HttpGet("")]
        public async Task<IActionResult> ObterTodosAsync()
        {
            var instituicaoEnsino = await _instituicaoEnsinoService.ObterTodosAsync();
            return Ok(instituicaoEnsino);
        }

        /// <summary>
        /// Retorna usuarios por SituacaoId
        /// </summary>
        /// <param name="situacaoId"> Id da Situação</param>
        /// <returns></returns>
        [HttpGet("por-situacao/{situacaoId:int}")]
        public async Task<IActionResult> ObterUsuarioPorSituacaoIdAsync(int situacaoId)
        {
            var instituicaoEnsino = await _instituicaoEnsinoService.ObterPorSituacaoAsync(situacaoId);
            return Ok(instituicaoEnsino);
        }

        /// <summary>
        /// Altera um instituição de ensino
        /// </summary>
        /// <param name="id"> Id da Instituição de Ensino</param>
        /// <param name="dto"></param>
        /// <returns></returns>
        [HttpPut("{id:int}")]
        public async Task<IActionResult> AlterarAsync(int id, [FromBody] InstituicaoEnsinoDTO dto)
        {
            await _instituicaoEnsinoService.AlterarAsync(id, dto.Nome, dto.CNPJ, dto.Telefone, dto.CidadeId, dto.Logradouro, dto.CEP, dto.Numero);
            await UnitOfWork.CommitAsync();
            return Ok();
        }


        /// <summary>
        /// Ativa uma instituição de ensino
        /// </summary>
        /// <param name="id"> Id da Instituição de Ensino</param>
        /// <returns></returns>
        [HttpPut("{id:int}/ativar")]
        public async Task<IActionResult> AtivarAsync(int id)
        {
            await _instituicaoEnsinoService.AtivarAsync(id);
            await UnitOfWork.CommitAsync();
            return Ok();
        }


        /// <summary>
        /// Inativa uma instituição de ensino
        /// </summary>
        /// <param name="id"> Id da Instituição de Ensino</param>
        /// <returns></returns>
        [HttpPut("{id:int}/inativar")]
        public async Task<IActionResult> InativarAsync(int id)
        {
            await _instituicaoEnsinoService.InativarAsync(id);
            await UnitOfWork.CommitAsync();
            return Ok();
        }
    }
}