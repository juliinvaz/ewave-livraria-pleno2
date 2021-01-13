using Livraria.Infra.Data;
using System;
using System.Collections.Generic;
using System.Text;

namespace Livraria.Domain.Models
{
    public class InstituicaoEnsino : IEntity
    {
        public int Id { get; set; }
        public string Nome { get; set; }
        public string CNPJ { get; set; }
        public string Telefone { get; set; }
        public int SituacaoId { get; set; }
        public virtual InstituicaoEnsinoSituacao Situacao { get; set; }
        public int EnderecoId { get; set; }
        public virtual Endereco Endereco { get; set; }
    }
}
