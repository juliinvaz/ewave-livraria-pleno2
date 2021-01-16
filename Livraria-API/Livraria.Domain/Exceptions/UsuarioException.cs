using Livraria.Infra.Exeptions;
using System;
using System.Collections.Generic;
using System.Text;

namespace Livraria.Domain.Exceptions
{
    public class UsuarioNaoEncontradoException : LivrariaException
    {
        public UsuarioNaoEncontradoException() : base("Usuário não encontrado.") { }
    }

    public class UsuarioCPFJaInformadoException : LivrariaException
    {
        public UsuarioCPFJaInformadoException() : base("Já existe usuário com o CPF informado.") { }
    }

    public class UsuarioInvalidoParaAlterarException : LivrariaException
    {
        public UsuarioInvalidoParaAlterarException() : base($"A situação atual do usuário não permite alteração.") { }
    }

}
