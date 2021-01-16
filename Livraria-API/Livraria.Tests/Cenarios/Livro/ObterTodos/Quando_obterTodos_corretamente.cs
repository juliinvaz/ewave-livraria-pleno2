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
    public class Quando_obterTodos_corretamente
    {
        private readonly LivroService _service;
        private readonly Mock<ILivroRepository> _mockRepository = new Mock<ILivroRepository>();
        private readonly IEnumerable<Domain.Models.Livro> _livros;

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
        private readonly int _situacaoId2 = (int)ELivroSituacao.Emprestado;

        private readonly int _id3 = 22;
        private readonly string _titulo3 = "Neve no deserto";
        private readonly string _genero3 = "Comedia";
        private readonly string _autor3 = "Maria Ninguem";
        private readonly string _sinopse3 = "era uma vez .... nevou no deserto e fim.";
        private readonly string _capa3 = "https://media.fstatic.com/Jbi83dhbCZdMVjd2p3QVfaBOq1I=/290x478/smart/media/movies/covers/2011/03/a13d3df4f66386987fdfea49e5654a14.jpg";
        private readonly int _situacaoId3 = (int)ELivroSituacao.Reservado;     


        public Quando_obterTodos_corretamente()
        {

            var livro = new Domain.Models.Livro
            {
                Id = _id,
                Titulo = _titulo,
                Genero = _genero,
                Autor = _autor,
                Sinopse = _sinopse,
                Capa = _capa,
                SituacaoId = _situacaoId
            };

            var livro2 = new Domain.Models.Livro
            {
                Id = _id2,
                Titulo = _titulo2,
                Genero = _genero2,
                Autor = _autor2,
                Sinopse = _sinopse2,
                Capa = _capa2,
                SituacaoId = _situacaoId2
            };

            var livro3 = new Domain.Models.Livro
            {
                Id = _id3,
                Titulo = _titulo3,
                Genero = _genero3,
                Autor = _autor3,
                Sinopse = _sinopse3,
                Capa = _capa3,
                SituacaoId = _situacaoId3
            };

            _livros = new List<Domain.Models.Livro> { livro, livro2, livro3 };

            _mockRepository.Setup(x => x.ObterTodosLivrosAsync()).Returns(Task.FromResult(_livros));

            _service = new LivroService(_mockRepository.Object);
        }


        [Fact]
        public void Quando_rodar_funcao()
        {
            var livros = _service.ObterTodosAsync().GetAwaiter().GetResult();

            livros.Should().BeEquivalentTo(_livros);
        }
    }
}
