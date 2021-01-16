using Livraria.Infra.Data;
using System;
using System.Collections.Generic;
using System.Text;

namespace Livraria.Domain.Models
{
    public class Estado : IEntity
    {
        public int Id { get; set; }
        public string Nome { get; set; }
        public string Uf { get; set; }
    }
}
