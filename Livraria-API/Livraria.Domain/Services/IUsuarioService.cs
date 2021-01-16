using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Livraria.Domain.Services
{
    public interface IUsuarioService
    {
        Task CriarAsync(string nome, string cpf, string telefone, string email, int instituicaoId);
        Task AlterarAsync(int id, string nome, string cpf, string telefone, string email, int instituicaoId);
        Task AtivarAsync(int id);
        Task InativarAsync(int id);
        Task InformarEnderecoAsync(int id, string logradouro, string numero, string cep, int cidadeId);
    }
}
