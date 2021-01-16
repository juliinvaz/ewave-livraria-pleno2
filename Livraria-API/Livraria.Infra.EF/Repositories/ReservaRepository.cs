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
    public class ReservaRepository : Repository<Reserva>, IReservaRepository
    {
        public ReservaRepository(DataContext dataContext) : base(dataContext)
        {
        }

        public async Task<IEnumerable<Reserva>> ObterTodosAsync()
        {
            var reservas = await Context.Set<Reserva>().IgnoreAutoIncludes().ToListAsync();
            return reservas;

        }
    }
}
