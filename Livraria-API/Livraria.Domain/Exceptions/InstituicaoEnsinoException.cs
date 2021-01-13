using Livraria.Infra.Exeptions;
using System;
using System.Collections.Generic;
using System.Text;

namespace Livraria.Domain.Exceptions
{
    public class InstituicaoEnsinoNaoEncontradaException : LivrariaException
    {
        public InstituicaoEnsinoNaoEncontradaException() : base("Instituição de ensino não encontrada.") { }
    }

    public class InstituicaoEnsinoCNPJJaInformadoException : LivrariaException
    {
        public InstituicaoEnsinoCNPJJaInformadoException() : base("Já existe insituição de ensino com o CNPJ informado.") { }
    }

    public class InstituicaoEnsinoSituacaoInvalidaParaAlterarException : LivrariaException
    {
        public InstituicaoEnsinoSituacaoInvalidaParaAlterarException() : base($"A situação atual da instituição de ensino não permite alteração.") { }
    }

}
