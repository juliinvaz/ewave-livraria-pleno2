using Livraria.Infra.Exeptions;
using System;
using System.Collections.Generic;
using System.Text;

namespace Livraria.Domain.Exceptions
{
    public class CidadeNaoEncontradaException : LivrariaException
    {
        public CidadeNaoEncontradaException() : base("Cidade não encontrada.") { }
    }

    public class CidadeSituacaoInvalidaParaAlterarException : LivrariaException
    {
        public CidadeSituacaoInvalidaParaAlterarException() : base($"A situação atual da cidade não permite alteração.") { }
    }

}
