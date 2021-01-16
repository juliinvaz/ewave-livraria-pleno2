using Livraria.Domain.Models;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Livraria.Domain.Services
{
    public interface IReservaService
    {
        Task CriarAsync(int usuarioId, int livroId);
        Task InativarAsync(int id);

        Task<Reserva> ObterPorIdAsync(int id);
        Task<IEnumerable<Reserva>> ObterTodosAsync();

    }
}
