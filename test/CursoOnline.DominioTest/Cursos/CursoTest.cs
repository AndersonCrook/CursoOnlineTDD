using System;
using Bogus;
using CursoOnline.Dominio.Cursos;
using CursoOnline.DominioTest._Biulder;
using CursoOnline.DominioTest._Util;
using ExpectedObjects;
using Xunit;
using Xunit.Abstractions;
using Curso = CursoOnline.Dominio.Cursos.Curso;

namespace CursoOnline.DominioTest.Cursos
{
    public class CursoTest : IDisposable
    {
        private readonly ITestOutputHelper _output;
        private readonly string _nome;
        private readonly double _cargaHoraria;
        private readonly PublicoAlvo _publicoAlvo;
        private readonly double _valor;
        private readonly string _descricao;

        public CursoTest(ITestOutputHelper output)
        {
            _output = output;
            var faker = new Faker();

            _nome = faker.Random.Word();
            _cargaHoraria = faker.Random.Double(50, 100);
            _publicoAlvo = faker.Random.Enum<PublicoAlvo>();
            _valor = faker.Random.Double(1, 1000);
            _descricao = faker.Lorem.Paragraph();
        }

        public void Dispose()
        {
            _output.WriteLine("acabo");
        }
        
        [Fact (DisplayName = "CriarCurso")]
        public void CriarCurso()
        {
            //organização
            var cursoEsperado = new
            {
                Nome = _nome,
                CargaHoraria = _cargaHoraria,
                PublicoAlvo = _publicoAlvo,
                Valor = _valor,
                Descricao = _descricao
            };

            //ação
            var curso = new Curso(cursoEsperado.Nome, cursoEsperado.CargaHoraria, cursoEsperado.PublicoAlvo, cursoEsperado.Valor, cursoEsperado.Descricao);

            //Assert
            cursoEsperado.ToExpectedObject().ShouldMatch(curso);
        }

        [Theory (DisplayName = "Nome Não deve ser invalido")]
        [InlineData("")]
        [InlineData(null)]
        public void NomeNaoDeveSerInvalido(string nomeInvalido)
        {
           Assert.Throws<ArgumentException>(() =>
               CursoBuilder.Novo().ComNome(nomeInvalido).Build())
               .ComMensagem("Nome invalido!");
        }

        [Theory (DisplayName = "Carga horaria deve ser maior que 1")]
        [InlineData(0)]
        [InlineData(-1)]
        public void CargaHorariaDeveSerMaiorQue1(double cargaHorariaInvalida)
        {
            Assert.Throws<ArgumentException>(() =>
              CursoBuilder.Novo().ComCargaHoraria(cargaHorariaInvalida).Build())
                .ComMensagem("Carga horária invalida!");
        }

        [Theory(DisplayName = "Valor deve ser maior que 1")]
        [InlineData(0)]
        [InlineData(-1)]
        public void ValorDeveSerMaiorQue1(double valorInvalido)
        {
            Assert.Throws<ArgumentException>(() =>
                CursoBuilder.Novo().ComValor(valorInvalido).Build())
                .ComMensagem("Valor invalido");
        }
    }
}