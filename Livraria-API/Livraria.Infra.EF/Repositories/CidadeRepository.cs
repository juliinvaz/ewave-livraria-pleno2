using Livraria.Domain.Models;
using Livraria.Domain.Repositories;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Livraria.Infra.EF.Repositories
{
    public class CidadeRepository : Repository<Cidade>, ICidadeRepository
    {
        private readonly DataContext Context;
        public CidadeRepository(DataContext dataContext) : base(dataContext)
        {
            Context = dataContext;
        }

        public async Task<IEnumerable<Cidade>> ObterCidadesPorEstadoAsync(int estadoId)
        {
            var cidades = await Context.Set<Cidade>().IgnoreAutoIncludes().Where(x => x.EstadoId == estadoId).ToListAsync();
            return cidades;
        }
    }
}
