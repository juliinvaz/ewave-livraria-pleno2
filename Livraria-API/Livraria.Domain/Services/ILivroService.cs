using Livraria.Domain.Models;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Livraria.Domain.Services
{
    public interface ILivroService
    {
        Task CriarAsync(string titulo, string genero, string autor, string sinopse, string capa);
        Task AlterarAsync(int id, string titulo, string genero, string autor, string sinopse, string capa);
        Task AtivarAsync(int id);
        Task InativarAsync(int id);

        Task<Livro> ObterPorIdAsync(int id);
        Task<IEnumerable<Livro>> ObterTodosAsync();
        Task<IEnumerable<Livro>> ObterPorSituacaoAsync(int situacaoId);
    }
}
