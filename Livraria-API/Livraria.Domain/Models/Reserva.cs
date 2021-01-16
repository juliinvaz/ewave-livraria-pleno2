using Livraria.Infra.Data;
using System;
using System.Collections.Generic;
using System.Text;

namespace Livraria.Domain.Models
{
    public class Reserva : IEntity
    {
        public int Id { get; set; }
        public DateTime Data { get; set; }
        public int SituacaoId { get; set; }
        public virtual ReservaSituacao Situacao { get; set; }
        public int UsuarioId { get; set; }
        public virtual Usuario Usuario { get; set; }
        public int LivroId { get; set; }
        public virtual Livro Livro { get; set; }

    }
}
