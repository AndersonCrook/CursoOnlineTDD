using Bogus;
using CursoOnline.Dominio.Cursos;
using Curso = CursoOnline.Dominio.Cursos.Curso;

namespace CursoOnline.DominioTest._Biulder
{
    public class CursoBuilder
    {
        private static readonly Faker Faker = new Faker();

        private string _nome = Faker.Random.Word();
        private double _cargaHoraria = Faker.Random.Double(50, 100);
        private PublicoAlvo _publicoAlvo = Faker.Random.Enum<PublicoAlvo>();
        private double _valor = Faker.Random.Double(1, 1000);
        private string _descricao = Faker.Lorem.Paragraph();

        public static CursoBuilder Novo()
        {
            return new CursoBuilder();
        }

        public  CursoBuilder ComNome(string nome)
        {
            _nome = nome;
            return this;
        }

        public CursoBuilder ComCargaHoraria(double cargaHoraria)
        {
            _cargaHoraria = cargaHoraria;
            return this;
        }

        public CursoBuilder ComPublicoAlvo(PublicoAlvo publicoAlvo)
        {
            _publicoAlvo = publicoAlvo;
            return this;
        }

        public CursoBuilder ComValor(double valor)
        {
            _valor = valor;
            return this;
        }

        public CursoBuilder ComDescricao(string descricao)
        {
            _descricao = descricao;
            return this;
        }

        public Curso Build()
        {
            return  new Curso(_nome, _cargaHoraria, _publicoAlvo, _valor, _descricao );
        }
    }
}