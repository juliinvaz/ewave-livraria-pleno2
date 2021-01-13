using Livraria.API.Filters;
using Livraria.Infra.Data;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Livraria.API.Controllers
{
    [ExceptionLivrariaFilter]
    public class LivrariaController : ControllerBase
    {
        protected readonly IUnitOfWork UnitOfWork;

        public LivrariaController(IUnitOfWork unitOfWork)
        {
            UnitOfWork = unitOfWork;
        }
    }
}
