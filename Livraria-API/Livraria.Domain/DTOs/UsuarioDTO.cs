using System;
using System.Collections.Generic;
using System.Text;

namespace Livraria.Domain.DTOs
{
    public class UsuarioDTO
    {
        
        public string Nome { get; set; }
        public string CPF { get; set; }
        public string Telefone { get; set; }
        public string Email { get; set; }
        public int SituacaoId { get; set; }
        public int? EnderecoId { get; set; }
        public int InstituicaoId { get; set; }

    }
}
