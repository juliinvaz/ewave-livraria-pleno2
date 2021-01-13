using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Livraria.Domain.Services
{
    public interface IInstituicaoEnsinoService
    {
        Task CriarAsync(string nome, string cnpj, string telefone, int cidadeId, string logadouro, string cep, string numero);
        Task AlterarAsync(int id, string nome, string cnpj, string telefone, int cidadeId, string logadouro, string cep, string numero);
        Task AtivarAsync(int id);
        Task InativarAsync(int id);
    }
}
