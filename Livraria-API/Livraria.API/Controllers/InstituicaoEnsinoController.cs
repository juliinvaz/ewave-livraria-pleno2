using Livraria.Infra.Data;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Livraria.API.Controllers
{
    [Route("api/instituicoes-ensino")]
    [ApiController]
    public class InstituicaoEnsinoController : LivrariaController
    {
        public InstituicaoEnsinoController(IUnitOfWork unitOfWork) : base(unitOfWork)
        {

        }

        /// <summary>
        ///  Testando Controller
        /// </summary>
        /// <returns></returns>
        [HttpGet("teste")]
        public async Task<IActionResult> TesteAsync()
        {

            return Ok(new { msg = "Ok"});
        }

    }
}