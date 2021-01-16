using System;
using System.Collections.Generic;
using System.Text;

namespace Livraria.Domain.DTOs
{
    public class EnderecoDTO
    {
        public int CidadeId { get; set; }
        public string Logradouro { get; set; }
        public string CEP { get; set; }
        public string Numero { get; set; }

    }
}
