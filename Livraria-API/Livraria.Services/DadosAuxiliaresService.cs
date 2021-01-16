using Livraria.Domain.Exceptions;
using Livraria.Domain;
using Livraria.Domain.Repositories;
using Livraria.Infra.Extentions;
using System;
using System.Threading.Tasks;
using Livraria.Domain.Services;
using Livraria.Domain.Models;
using Livraria.Domain.Enums;
using System.Collections.Generic;

namespace Livraria.Services
{
    public class DadosAuxiliaresService : IDadosAuxiliaresService
    {
        private readonly ICidadeRepository _cidadeRepository;
        private readonly IEstadoRepository _estadoRepository;

        public DadosAuxiliaresService(ICidadeRepository cidadeRepository, IEstadoRepository estadoRepository)
        {
            _cidadeRepository = cidadeRepository;
            _estadoRepository = estadoRepository;
        }

        public async Task<IEnumerable<Cidade>> ObterCidadesPorEstadoAsync(int estadoId)
        {
            return await _cidadeRepository.ObterCidadesPorEstadoAsync(estadoId);
        }

        public async Task<IEnumerable<Estado>> ObterTodosEstadosAsync()
        {
            return await _estadoRepository.ObterTodosAsync();
        }
    }
}
