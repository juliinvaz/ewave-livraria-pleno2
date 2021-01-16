using Livraria.Domain.Models;
using Livraria.Domain.Repositories;
using Livraria.Infra.Extentions;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Livraria.Infra.EF.Repositories
{
    public class EstadoRepository : Repository<Estado>, IEstadoRepository
    {
        private readonly DataContext Context;
        public EstadoRepository(DataContext dataContext) : base(dataContext)
        {
            Context = dataContext;
        }

        public async Task<IEnumerable<Estado>> ObterTodosAsync()
        {
            var estados = await Context.Set<Estado>().ToListAsync();
            return estados;

        }
    }
}
