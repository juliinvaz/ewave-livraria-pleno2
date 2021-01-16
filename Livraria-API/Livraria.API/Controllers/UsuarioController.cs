using Livraria.Domain.DTOs;
using Livraria.Domain.Services;
using Livraria.Infra.Data;
using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;

namespace Livraria.API.Controllers
{

    [Route("api/usuarios")]
    [ApiController]
    public class UsuarioController : LivrariaController
    {
        private readonly IUsuarioService _usuarioService;
        public UsuarioController(IUnitOfWork unitOfWork, IUsuarioService usuarioService) : base(unitOfWork)
        {
            _usuarioService = usuarioService;
        }

        /// <summary>
        ///  Cria um usuário
        /// </summary>
        /// <param name="dto"></param>
        /// <returns></returns>
        [HttpPost("")]
        public async Task<IActionResult> CriarAsync([FromBody] UsuarioDTO dto)
        {
            await _usuarioService.CriarAsync(dto.Nome, dto.CPF, dto.Telefone, dto.Email, dto.InstituicaoId);
            await UnitOfWork.CommitAsync();
            return Ok();
        }


        /// <summary>
        /// Altera um usuário
        /// </summary>
        /// <param name="id"> Id da Instituição de Ensino</param>
        /// <param name="dto"></param>
        /// <returns></returns>
        [HttpPut("{id:int}")]
        public async Task<IActionResult> AlterarAsync(int id, [FromBody] UsuarioDTO dto)
        {
            await _usuarioService.AlterarAsync(id, dto.Nome, dto.CPF, dto.Telefone, dto.Email, dto.InstituicaoId);
            await UnitOfWork.CommitAsync();
            return Ok();
        }


        /// <summary>
        ///  Informa endereço de um Usuario.
        /// </summary>
        /// <param name="id"> Id do Usuario</param>
        /// <param name="dto"></param>
        /// <returns></returns>
        [HttpPut("{id:int}/informar-endereco")]
        public async Task<IActionResult> InformarEnderecoAsync(int id, [FromBody] EnderecoDTO dto)
        {
            await _usuarioService.InformarEnderecoAsync(id, dto.Logradouro, dto.Numero, dto.CEP, dto.CidadeId);
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
            await _usuarioService.AtivarAsync(id);
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
            await _usuarioService.InativarAsync(id);
            await UnitOfWork.CommitAsync();
            return Ok();
        }
    }
}