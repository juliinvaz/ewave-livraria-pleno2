using Livraria.Domain.Models;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Livraria.Domain.Services
{
    public interface IEmprestimoService
    {
        Task CriarAsync(int usuarioId, int livroId);
        Task DevolverAsync(int id);
        Task<IEnumerable<Emprestimo>> ObterTodosAsync();
    }
}
