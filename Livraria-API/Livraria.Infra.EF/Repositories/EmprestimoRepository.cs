using Livraria.Domain.Models;
using Livraria.Domain.Repositories;
using Livraria.Infra.Extentions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Livraria.Infra.EF.Repositories
{
    public class EmprestimoRepository : Repository<Emprestimo>, IEmprestimoRepository
    { 
        public EmprestimoRepository(DataContext dataContext) : base(dataContext) 
        {       
        }

        public Task<int> ObterQuantidadeDeEmpestimosEmAndamentoPorUsuarioAsync(int usuarioId)
        {
            var quantidade = Context.Set<Emprestimo>().Count(x => x.UsuarioId == usuarioId && !x.DataDevolucao.HasValue);
                        
            return Task.FromResult(quantidade);
        }

        public Task<bool> VerificarEmprestimosAtrasadosPorUsuarioAsync(int usuarioId)
        {
            var possuiEmprestimoAtrasado = Context.Set<Emprestimo>().Any(x => x.UsuarioId == usuarioId && !x.DataDevolucao.HasValue && x.Data.Date.AddDays(30) < DateTime.Now.Date);

            return Task.FromResult(possuiEmprestimoAtrasado);
        }

        public Task<bool> VerificarEmprestimosDevolvidoAtrasadoPorUsuarioAsync(int usuarioId)
        {
            var possuiEmprestimoAtrasado = Context.Set<Emprestimo>().Any(x => x.UsuarioId == usuarioId && x.DataDevolucao.HasValue && x.Data.Date.AddDays(30) < x.DataDevolucao.Value.Date && x.DataDevolucao.Value.Date.AddDays(30) > DateTime.Now.Date);

            return Task.FromResult(possuiEmprestimoAtrasado);
        }
    }
}
