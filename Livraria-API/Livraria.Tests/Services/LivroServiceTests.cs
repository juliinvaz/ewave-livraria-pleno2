using FluentAssertions;
using Livraria.Services;
using System;
using Xunit;

namespace Livraria.Tests.Services
{
    public class LivroServiceTests
    {
        private readonly LivroService _service;

        private readonly int _id = 14;
        private readonly string _titulo = "A era do dragão";
        private readonly string _genero = "Ação";
        private readonly string _autor = "Cleber";
        private readonly string _sinopse = "era uma vez ....";
        private readonly string _capa = "https://media.fstatic.com/Jbi83dhbCZdMVjd2p3QVfaBOq1I=/290x478/smart/media/movies/covers/2011/03/a13d3df4f66386987fdfea49e5654a14.jpg";

        public LivroServiceTests()
        {
            _service = new LivroService(null);
        }

        [Fact]
        public void Quando_criar_com_titulo_invalido()
        {
            var action = new Action(() => _service.CriarAsync(null, _genero, _autor, _sinopse, _capa).GetAwaiter().GetResult());

            action.Should().Throw<ArgumentNullException>().And.ParamName.Should().Be("titulo");
        }

        [Fact]
        public void Quando_criar_com_genero_invalido()
        {
            var action = new Action(() => _service.CriarAsync(_titulo, null, _autor, _sinopse, _capa).GetAwaiter().GetResult());

            action.Should().Throw<ArgumentNullException>().And.ParamName.Should().Be("genero");
        }

        [Fact]
        public void Quando_criar_com_autor_invalido()
        {
            var action = new Action(() => _service.CriarAsync(_titulo, _genero, null, _sinopse, _capa).GetAwaiter().GetResult());

            action.Should().Throw<ArgumentNullException>().And.ParamName.Should().Be("autor");
        }

        [Fact]
        public void Quando_criar_com_sinopse_invalido()
        {
            var action = new Action(() => _service.CriarAsync(_titulo, _genero, _autor, null, _capa).GetAwaiter().GetResult());

            action.Should().Throw<ArgumentNullException>().And.ParamName.Should().Be("sinopse");
        }

        [Fact]
        public void Quando_criar_com_capa_invalido()
        {
            var action = new Action(() => _service.CriarAsync(_titulo, _genero, _autor, _sinopse, null).GetAwaiter().GetResult());

            action.Should().Throw<ArgumentNullException>().And.ParamName.Should().Be("capa");
        }


        [Theory]
        [InlineData(0)]
        [InlineData(-1)]
        public void Quando_alterar_com_id_invalido(int id)
        {
            var action = new Action(() => _service.AlterarAsync(id, _titulo, _genero, _autor, _sinopse, _capa).GetAwaiter().GetResult());

            action.Should().Throw<ArgumentNullException>().And.ParamName.Should().Be("id");
        }

        [Fact]
        public void Quando_alterar_com_titulo_invalido()
        {
            var action = new Action(() => _service.AlterarAsync(_id, null, _genero, _autor, _sinopse, _capa).GetAwaiter().GetResult());

            action.Should().Throw<ArgumentNullException>().And.ParamName.Should().Be("titulo");
        }

        [Fact]
        public void Quando_alterar_com_genero_invalido()
        {
            var action = new Action(() => _service.AlterarAsync(_id, _titulo, null, _autor, _sinopse, _capa).GetAwaiter().GetResult());

            action.Should().Throw<ArgumentNullException>().And.ParamName.Should().Be("genero");
        }

        [Fact]
        public void Quando_alterar_com_autor_invalido()
        {
            var action = new Action(() => _service.AlterarAsync(_id, _titulo, _genero, null, _sinopse, _capa).GetAwaiter().GetResult());

            action.Should().Throw<ArgumentNullException>().And.ParamName.Should().Be("autor");
        }

        [Fact]
        public void Quando_alterar_com_sinopse_invalido()
        {
            var action = new Action(() => _service.AlterarAsync(_id, _titulo, _genero, _autor, null, _capa).GetAwaiter().GetResult());

            action.Should().Throw<ArgumentNullException>().And.ParamName.Should().Be("sinopse");
        }

        [Fact]
        public void Quando_alterar_com_capa_invalido()
        {
            var action = new Action(() => _service.AlterarAsync(_id, _titulo, _genero, _autor, _sinopse, null).GetAwaiter().GetResult());

            action.Should().Throw<ArgumentNullException>().And.ParamName.Should().Be("capa");
        }

        [Theory]
        [InlineData(0)]
        [InlineData(-1)]
        public void Quando_ativar_com_id_invalido(int id)
        {
            var action = new Action(() => _service.AtivarAsync(id).GetAwaiter().GetResult());

            action.Should().Throw<ArgumentNullException>().And.ParamName.Should().Be("id");
        }

        [Theory]
        [InlineData(0)]
        [InlineData(-1)]
        public void Quando_inativar_com_id_invalido(int id)
        {
            var action = new Action(() => _service.InativarAsync(id).GetAwaiter().GetResult());

            action.Should().Throw<ArgumentNullException>().And.ParamName.Should().Be("id");
        }

    }
}
