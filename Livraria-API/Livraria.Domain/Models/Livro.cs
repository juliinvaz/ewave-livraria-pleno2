﻿using Livraria.Infra.Data;

namespace Livraria.Domain.Models
{
    public class Livro : IEntity
    {
        public int Id { get; set; }
        public string Titulo { get; set; }
        public string Genero { get; set; }
        public string Autor { get; set; }
        public string Sinopse { get; set; }
        public string Capa { get; set; }
        public int SituacaoId { get; set; }
        public virtual LivroSituacao Situacao { get; set; }
    }
}
