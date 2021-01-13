using Livraria.Infra.Exeptions;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Filters;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Threading.Tasks;

namespace Livraria.API.Filters
{
    public class ExceptionLivrariaFilter : ExceptionFilterAttribute
    {
        public override void OnException(ExceptionContext context)
        {
            var response = context.HttpContext.Response;
            response.ContentType = "application/json; charset=utf-8";

            if (context.Exception is LivrariaException || context.Exception is ArgumentException)
            {
                response.StatusCode = (int)HttpStatusCode.BadRequest;
            }
            else
            {
                response.StatusCode = (int)HttpStatusCode.InternalServerError;
            }

            context.Result = new JsonResult(context.Exception.Message);
        }
    }
}
