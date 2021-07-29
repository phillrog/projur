using ProJur.Cadastros.Aplication.Commands;
using System;
using Xunit;

namespace ProJur.Cadastros.Domain.Test
{
    public class UsuarioTests
    {
        private readonly string _email;
        private readonly string _nome;
        private readonly string _sobrenome;
        private readonly DateTime _dataNascimento;
        private readonly int _escolaridade;

        public UsuarioTests()
        {
            _nome = "Phillipe";
            _sobrenome = "Roger Souza";
            _dataNascimento = DateTime.Parse("09/12/1999");
            _escolaridade = 3;
            _email = "phillrog@hotmail.com";
        }

        [Fact]
        public void Deve_Retornar_Erro_Nome_Vazio()
        {
            var novoUsuario = new AdicionarUsuarioCommand(string.Empty, _sobrenome, _email, _dataNascimento, _escolaridade);

            var erros = novoUsuario.EhValido();

            Assert.False(erros);
        }

        [Fact]
        public void Deve_Retornar_Erro_Sobrenome_Vazio()
        {
            var novoUsuario = new AdicionarUsuarioCommand(_nome, string.Empty, _email, _dataNascimento, _escolaridade);

            var erros = novoUsuario.EhValido();

            Assert.False(erros);
        }

        [Fact]
        public void Deve_Retornar_Erro_Email_Vazio()
        {
            var novoUsuario = new AdicionarUsuarioCommand(_nome, _sobrenome,string.Empty, _dataNascimento, _escolaridade);

            var erros = novoUsuario.EhValido();

            Assert.False(erros);
        }

        [Fact]
        public void Deve_Retornar_Erro_Email_Invlido()
        {
            var emailInvalido = "phillipe";
            var novoUsuario = new AdicionarUsuarioCommand(_nome, _sobrenome, emailInvalido, _dataNascimento, _escolaridade);

            var erros = novoUsuario.EhValido();

            Assert.False(erros);
        }

        [Fact]
        public void Deve_Retornar_Erro_DataNascimento_Invalida()
        {
            var dataInvalida = DateTime.Parse("01/01/0001");
            var novoUsuario = new AdicionarUsuarioCommand(_nome, _sobrenome, _email, dataInvalida, _escolaridade);

            var erros = novoUsuario.EhValido();

            Assert.False(erros);
        }

        [Fact]
        public void Deve_Retornar_Erro_DataNascimento_MaiorQueHoje()
        {
            var dataMaiorQueHoje = DateTime.Now.AddDays(1);
            var novoUsuario = new AdicionarUsuarioCommand(_nome, _sobrenome, _email, dataMaiorQueHoje, _escolaridade);

            var erros = novoUsuario.EhValido();

            Assert.False(erros);
        }

        [Theory(DisplayName ="Indice invalido")]
        [InlineData(-1)]
        [InlineData(-4)]
        [InlineData(1000)]
        public void Deve_Retornar_Erro_Escolaridade_Invalida(int escolaridadeInvalida)
        {
            var novoUsuario = new AdicionarUsuarioCommand(_nome, _sobrenome, _email, _dataNascimento, escolaridadeInvalida);

            var erros = novoUsuario.EhValido();

            Assert.False(erros);
        }
    }
}
