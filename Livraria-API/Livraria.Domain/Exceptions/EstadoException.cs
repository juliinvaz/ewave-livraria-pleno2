using Livraria.Infra.Exeptions;
using System;
using System.Collections.Generic;
using System.Text;

namespace Livraria.Domain.Exceptions
{
    public class EstadoNaoEncontradoException : LivrariaException
    {
        public EstadoNaoEncontradoException() : base("Estado não encontrado.") { }
    }
        
}
