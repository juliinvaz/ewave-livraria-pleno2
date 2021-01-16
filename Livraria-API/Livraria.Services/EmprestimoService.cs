using Livraria.Domain.Exceptions;
using Livraria.Domain;
using Livraria.Domain.Repositories;
using Livraria.Infra.Extentions;
using System;
using System.Threading.Tasks;
using Livraria.Domain.Services;
using Livraria.Domain.Models;
using Livraria.Domain.Enums;

namespace Livraria.Services
{
    public class EmprestimoService : IEmprestimoService
    {
        private readonly IEmprestimoRepository _repository;
        private readonly ILivroRepository _livroRepository;
        private readonly IUsuarioRepository _usuarioRepository;

        private readonly int LIMITE_EMPRESTIMOS_ATIVO = 2;

        public EmprestimoService(IEmprestimoRepository repository, ILivroRepository livroRepository, IUsuarioRepository usuarioRepository)
        {
            _repository = repository;
            _livroRepository = livroRepository;
            _usuarioRepository = usuarioRepository;
        }   

        public async Task CriarAsync(int usuarioId, int livroId)
        {

            if (usuarioId.IsLessThanZero()) throw new ArgumentNullException(nameof(usuarioId));
            if (livroId.IsLessThanZero()) throw new ArgumentNullException(nameof(livroId));

            var usuario = await _usuarioRepository.GetByAsync(usuarioId);
            if (usuario.IsNull()) throw new UsuarioNaoEncontradoException();
            if (usuario.SituacaoId != (int)EUsuarioSituacao.Ativo) throw new EmprestimoUsuarioSituacaoIvalidaParaEmprestarException();


            var livro = await _livroRepository.GetByAsync(livroId);
            if (livro.IsNull()) throw new LivroNaoEncontradoException();
            if (livro.SituacaoId != (int)ELivroSituacao.Disponivel) throw new EmprestimoLivroSituacaoIvalidaParaEmprestarException();

            var qtdEmprestimosEmAndamento = await _repository.ObterQuantidadeDeEmpestimosEmAndamentoPorUsuarioAsync(usuarioId);
            if (qtdEmprestimosEmAndamento >= LIMITE_EMPRESTIMOS_ATIVO) throw new EmprestimoLimiteExcedidoPorUsuarioException();

            var possuiEmprestimosAtrasado = await _repository.VerificarEmprestimosAtrasadosPorUsuarioAsync(usuarioId);
            if (possuiEmprestimosAtrasado) throw new EmprestimoDataExcedidoPorUsuarioException();

            var possuiEmprestimosAtrasadDevolvidoComMenosDe30Dias = await _repository.VerificarEmprestimosDevolvidoAtrasadoPorUsuarioAsync(usuarioId);
            if (possuiEmprestimosAtrasadDevolvidoComMenosDe30Dias) throw new EmprestimoUsuarioPossuiAtrasoException();

            var emprestimo = new Emprestimo
            {
                Data = DateTime.Now,
                UsuarioId = usuarioId,
                LivroId = livroId                
            };

            livro.SituacaoId = (int)ELivroSituacao.Emprestado;

            await _livroRepository.UpdateAsync(livro);
            await _repository.CreateAsync(emprestimo);
        }

        public async Task DevolverAsync(int id)
        {

            if (id.IsLessThanZero()) throw new ArgumentNullException(nameof(id));

            var emprestimo = await _repository.GetByAsync(id);
            if (emprestimo.IsNull()) throw new EmprestimoNaoEncontradoException();

            if (emprestimo.DataDevolucao.IsNotNull()) throw new EmprestimoJaDevolvidoException();

            emprestimo.DataDevolucao = DateTime.Now;
            emprestimo.Livro.SituacaoId = (int)ELivroSituacao.Disponivel;

            await _repository.UpdateAsync(emprestimo);            
        }
    }
}
