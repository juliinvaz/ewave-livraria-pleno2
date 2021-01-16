using System;
using System.Collections.Generic;
using System.Text;

namespace Livraria.Domain.DTOs
{
    public class LivroDTO
    {
        public string Titulo { get; set; }
        public string Genero { get; set; }
        public string Autor { get; set; }
        public string Sinopse { get; set; }
        public string Capa { get; set; }

    }
}
