using Livraria.Infra.Data;
using System;
using System.Collections.Generic;
using System.Text;

namespace Livraria.Domain.Models
{
    public class Usuario : IEntity
    {
        public int Id { get; set; }
        public string Nome { get; set; }
        public string CPF { get; set; }
        public string Telefone { get; set; }
        public string Email { get; set; }
        public int SituacaoId { get; set; }
        public virtual UsuarioSituacao Situacao { get; set; }
        public int? EnderecoId { get; set; }
        public virtual Endereco Endereco { get; set; }
        public int InstituicaoId { get; set; }
        public virtual InstituicaoEnsino InstituicaoEnsino { get; set; }


        public virtual ICollection<Emprestimo> Emprestimos { get; set; } = new HashSet<Emprestimo>();
    }
}
