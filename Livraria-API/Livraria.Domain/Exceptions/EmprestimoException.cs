using Livraria.Infra.Exeptions;
using System;
using System.Collections.Generic;
using System.Text;

namespace Livraria.Domain.Exceptions
{
    public class EmprestimoNaoEncontradoException : LivrariaException
    {
        public EmprestimoNaoEncontradoException() : base("Emprestimo não encontrado.") { }
    }

    public class EmprestimoJaDevolvidoException : LivrariaException
    {
        public EmprestimoJaDevolvidoException() : base($"Emprestimo já devolvido.") { }
    }

    public class EmprestimoLimiteExcedidoPorUsuarioException : LivrariaException
    {
        public EmprestimoLimiteExcedidoPorUsuarioException() : base($"Usuário pode ter no máximo 2 empréstimos em andamento.") { }
    }

    public class EmprestimoDataExcedidoPorUsuarioException : LivrariaException
    {
        public EmprestimoDataExcedidoPorUsuarioException() : base($"Emprestimo do usuário excedeu os 30 dias limite.") { }
    }

    public class EmprestimoLivroSituacaoIvalidaParaEmprestarException : LivrariaException
    {
        public EmprestimoLivroSituacaoIvalidaParaEmprestarException() : base($"O livro informado não está disponível para empréstimo.") { }
    }
    public class EmprestimoUsuarioSituacaoIvalidaParaEmprestarException : LivrariaException
    {
        public EmprestimoUsuarioSituacaoIvalidaParaEmprestarException() : base($"O usuário informado está inativo.") { }
    }

    public class EmprestimoUsuarioPossuiAtrasoException : LivrariaException
    {
        public EmprestimoUsuarioPossuiAtrasoException() : base($"O usuário informado está impossibilitado de fazer emprestimo, pois o mesmo possui devolução atrasada. O mesmo deve tentar novamente após 30 dias da data da devolução atrasada.") { }
    }
}
