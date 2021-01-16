using Livraria.Infra.Exeptions;
using System;
using System.Collections.Generic;
using System.Text;

namespace Livraria.Domain.Exceptions
{
    public class ReservaNaoEncontradaException : LivrariaException
    {
        public ReservaNaoEncontradaException() : base("Reserva não encontrada.") { }
    }   

    public class ReservaLivroSituacaoIvalidaParaEmprestarException : LivrariaException
    {
        public ReservaLivroSituacaoIvalidaParaEmprestarException() : base($"O livro informado não está disponível para reservar.") { }
    }
    public class ReservaUsuarioSituacaoIvalidaParaEmprestarException : LivrariaException
    {
        public ReservaUsuarioSituacaoIvalidaParaEmprestarException() : base($"O usuário informado está inativo.") { }
    }

    
}
