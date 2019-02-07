using System;

namespace CursoOnline.Dominio.Cursos
{
    public class Curso
    {
        public string Nome { get; set; }
        public double CargaHoraria { get; set; }
        public PublicoAlvo PublicoAlvo { get; set; }
        public double Valor { get; set; }
        public string Descricao { get; set; }

        public Curso(string nome, double cargaHoraria, PublicoAlvo publicoAlvo, double valor, string descricao)
        {
            if (string.IsNullOrEmpty(nome))
                throw new ArgumentException("Nome invalido!");

            if (cargaHoraria < 1)
                throw new ArgumentException("Carga horária invalida!");

            if (valor < 1)
                throw new ArgumentException("Valor invalido");

            Nome = nome;
            CargaHoraria = cargaHoraria;
            PublicoAlvo = publicoAlvo;
            Valor = valor;
            Descricao = descricao;
        }
    }
}
