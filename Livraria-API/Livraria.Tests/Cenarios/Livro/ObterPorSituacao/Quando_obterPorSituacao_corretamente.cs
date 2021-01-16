using FluentAssertions;
using Livraria.Domain.Enums;
using Livraria.Domain.Repositories;
using Livraria.Services;
using Moq;
using System.Collections.Generic;
using System.Threading.Tasks;
using Xunit;

namespace Livraria.Tests.Cenarios.Livro.Alterar
{
    public class Quando_obterPorSituacao_corretamente
    {
        private readonly LivroService _service;
        private readonly Mock<ILivroRepository> _mockRepository = new Mock<ILivroRepository>();
        private readonly IEnumerable<Domain.Models.Livro> _livrosDisponiveis;
        private readonly IEnumerable<Domain.Models.Livro> _livrosEmprestados;
        private readonly IEnumerable<Domain.Models.Livro> _livrosReservados;
        private readonly IEnumerable<Domain.Models.Livro> _livrosInativos;

        private readonly int _id = 14;
        private readonly string _titulo = "A era do dragão";
        private readonly string _genero = "Ação";
        private readonly string _autor = "Cleber";
        private readonly string _sinopse = "era uma vez ....";
        private readonly string _capa = "https://media.fstatic.com/Jbi83dhbCZdMVjd2p3QVfaBOq1I=/290x478/smart/media/movies/covers/2011/03/a13d3df4f66386987fdfea49e5654a14.jpg";
        private readonly int _situacaoId = (int)ELivroSituacao.Disponivel;

        private readonly int _id2 = 15;
        private readonly string _titulo2 = "Poeira em Alto Mar";
        private readonly string _genero2 = "Ficção Cientifica";
        private readonly string _autor2 = "Ze Ninguem";
        private readonly string _sinopse2 = "era uma vez .... uma poeira no mar";
        private readonly string _capa2 = "https://media.fstatic.com/Jbi83dhbCZdMVjd2p3QVfaBOq1I=/290x478/smart/media/movies/covers/2011/03/a13d3df4f66386987fdfea49e5654a14.jpg";
        private readonly int _situacaoId2 = (int)ELivroSituacao.Disponivel;

        private readonly int _id3 = 22;
        private readonly string _titulo3 = "Neve no deserto";
        private readonly string _genero3 = "Comedia";
        private readonly string _autor3 = "Maria Ninguem";
        private readonly string _sinopse3 = "era uma vez .... nevou no deserto e fim.";
        private readonly string _capa3 = "https://media.fstatic.com/Jbi83dhbCZdMVjd2p3QVfaBOq1I=/290x478/smart/media/movies/covers/2011/03/a13d3df4f66386987fdfea49e5654a14.jpg";
        private readonly int _situacaoId3 = (int)ELivroSituacao.Emprestado;

        private readonly int _id4 = 17;
        private readonly string _titulo4 = "A era do dragão";
        private readonly string _genero4 = "Ação";
        private readonly string _autor4 = "Cleber";
        private readonly string _sinopse4 = "era uma vez ....";
        private readonly string _capa4 = "https://media.fstatic.com/Jbi83dhbCZdMVjd2p3QVfaBOq1I=/290x478/smart/media/movies/covers/2011/03/a13d3df4f66386987fdfea49e5654a14.jpg";
        private readonly int _situacaoId4 = (int)ELivroSituacao.Reservado;

        private readonly int _id5 = 18;
        private readonly string _titulo5 = "Poeira em Alto Mar";
        private readonly string _genero5 = "Ficção Cientifica";
        private readonly string _autor5 = "Ze Ninguem";
        private readonly string _sinopse5 = "era uma vez .... uma poeira no mar";
        private readonly string _capa5 = "https://media.fstatic.com/Jbi83dhbCZdMVjd2p3QVfaBOq1I=/290x478/smart/media/movies/covers/2011/03/a13d3df4f66386987fdfea49e5654a14.jpg";
        private readonly int _situacaoId5 = (int)ELivroSituacao.Emprestado;

        private readonly int _id6 = 29;
        private readonly string _titulo6 = "Neve no deserto";
        private readonly string _genero6 = "Comedia";
        private readonly string _autor6 = "Maria Ninguem";
        private readonly string _sinopse6 = "era uma vez .... nevou no deserto e fim.";
        private readonly string _capa6 = "https://media.fstatic.com/Jbi83dhbCZdMVjd2p3QVfaBOq1I=/290x478/smart/media/movies/covers/2011/03/a13d3df4f66386987fdfea49e5654a14.jpg";
        private readonly int _situacaoId6 = (int)ELivroSituacao.Inativo;


        public Quando_obterPorSituacao_corretamente()
        {

            var livroDisponivel = new Domain.Models.Livro
            {
                Id = _id,
                Titulo = _titulo,
                Genero = _genero,
                Autor = _autor,
                Sinopse = _sinopse,
                Capa = _capa,
                SituacaoId = _situacaoId
            };

            var livroDisponivel2 = new Domain.Models.Livro
            {
                Id = _id2,
                Titulo = _titulo2,
                Genero = _genero2,
                Autor = _autor2,
                Sinopse = _sinopse2,
                Capa = _capa2,
                SituacaoId = _situacaoId2
            };

            var livroEmprestado = new Domain.Models.Livro
            {
                Id = _id3,
                Titulo = _titulo3,
                Genero = _genero3,
                Autor = _autor3,
                Sinopse = _sinopse3,
                Capa = _capa3,
                SituacaoId = _situacaoId3
            };

            var livroReservado = new Domain.Models.Livro
            {
                Id = _id4,
                Titulo = _titulo4,
                Genero = _genero4,
                Autor = _autor4,
                Sinopse = _sinopse4,
                Capa = _capa4,
                SituacaoId = _situacaoId4
            };

            var livroEmprestado2 = new Domain.Models.Livro
            {
                Id = _id5,
                Titulo = _titulo5,
                Genero = _genero5,
                Autor = _autor5,
                Sinopse = _sinopse5,
                Capa = _capa5,
                SituacaoId = _situacaoId5
            };


            var livroInativo = new Domain.Models.Livro
            {
                Id = _id6,
                Titulo = _titulo6,
                Genero = _genero6,
                Autor = _autor6,
                Sinopse = _sinopse6,
                Capa = _capa6,
                SituacaoId = _situacaoId6
            };

            _livrosDisponiveis = new List<Domain.Models.Livro> { livroDisponivel, livroDisponivel2 };
            _livrosEmprestados = new List<Domain.Models.Livro> { livroEmprestado, livroEmprestado2 };
            _livrosReservados = new List<Domain.Models.Livro> { livroReservado };
            _livrosInativos = new List<Domain.Models.Livro> { livroInativo };

            _mockRepository.Setup(x => x.ObterLivrosPorSituacaoAsync((int)ELivroSituacao.Disponivel)).Returns(Task.FromResult(_livrosDisponiveis));
            _mockRepository.Setup(x => x.ObterLivrosPorSituacaoAsync((int)ELivroSituacao.Emprestado)).Returns(Task.FromResult(_livrosEmprestados));
            _mockRepository.Setup(x => x.ObterLivrosPorSituacaoAsync((int)ELivroSituacao.Reservado)).Returns(Task.FromResult(_livrosReservados));
            _mockRepository.Setup(x => x.ObterLivrosPorSituacaoAsync((int)ELivroSituacao.Inativo)).Returns(Task.FromResult(_livrosInativos));

            _service = new LivroService(_mockRepository.Object);
        }


        [Theory]
        [InlineData((int)ELivroSituacao.Disponivel)]
        [InlineData((int)ELivroSituacao.Emprestado)]
        [InlineData((int)ELivroSituacao.Reservado)]
        [InlineData((int)ELivroSituacao.Inativo)]
        public void Quando_rodar_funcao(int situacaoId)
        {
            var livros = _service.ObterPorSituacaoAsync(situacaoId).GetAwaiter().GetResult();

            switch (situacaoId)
            {
                case (int)ELivroSituacao.Disponivel:
                    livros.Should().BeEquivalentTo(_livrosDisponiveis);
                    break;
                case (int)ELivroSituacao.Emprestado:
                    livros.Should().BeEquivalentTo(_livrosEmprestados);
                    break;
                case (int)ELivroSituacao.Reservado:
                    livros.Should().BeEquivalentTo(_livrosReservados);
                    break;
                case (int)ELivroSituacao.Inativo:
                    livros.Should().BeEquivalentTo(_livrosInativos);
                    break;
            }
        }
    }
}
