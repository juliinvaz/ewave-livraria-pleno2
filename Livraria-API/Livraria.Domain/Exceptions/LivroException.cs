using Livraria.Infra.Exeptions;
using System;
using System.Collections.Generic;
using System.Text;

namespace Livraria.Domain.Exceptions
{
    public class LivroNaoEncontradoException : LivrariaException
    {
        public LivroNaoEncontradoException() : base("Livro não encontrado.") { }
    }
       
    public class LivroInvalidoParaAlterarException : LivrariaException
    {
        public LivroInvalidoParaAlterarException() : base($"A situação atual do livro não permite alteração.") { }
    }

    public class LivroSituacaoInvalidaParaInativarException : LivrariaException
    {
        public LivroSituacaoInvalidaParaInativarException() : base($"A situação atual do livro não permite inativação.") { }
    }
    

}
