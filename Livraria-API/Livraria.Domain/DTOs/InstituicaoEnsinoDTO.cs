using System;
using System.Collections.Generic;
using System.Text;

namespace Livraria.Domain.DTOs
{
    public class InstituicaoEnsinoDTO
    {
        public string Nome { get; set; }
        public string CNPJ { get; set; }
        public string Telefone { get; set; }
        public int CidadeId { get; set; }
        public string Logradouro { get; set; }
        public string CEP { get; set; }
        public string Numero { get; set; }

    }
}
