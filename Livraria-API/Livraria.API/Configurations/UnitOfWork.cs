using Livraria.Infra.Data;
using Livraria.Infra.EF;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Livraria.API.Configurations
{
    public class UnitOfWork : IUnitOfWork 
    {
        private readonly DataContext DataContext;

        public UnitOfWork(DataContext dataContext)
        {
            DataContext = dataContext;
        }

        public async Task CommitAsync()
        {
            try
            {
                await DataContext.SaveChangesAsync().ConfigureAwait(false);
            }
            catch (Exception e)
            {
                throw new Exception(e.Message);
            }
            finally
            {
                DataContext.Dispose();
            }
        }
    }
}
