using System;

namespace Corrida.Domain.Entity
{
    public class Participante
    {
        public string Nome { get; private set; }
        public string BaseOperacional { get; private set; }
        public int Matricula { get; private set; }
        public string TamanhoCamiseta { get; private set; }
        public string Cpf { get; private set; }
        public DateTime DataNascimento { get; private set; }
        public char Sexo { get; private set; }
        public string Telefone { get; private set; }
        public string Email { get; private set; }
        public string RespostaP1 { get; private set; }
        public string RespostaP2 { get; private set; }
        public string RespostaP3 { get; private set; }


        public Participante(string nome, string baseOperacional, int matricula, string tamanhoCamiseta,
            string cpf, DateTime dataNascimento, char sexo, string telefone, string email, string respostaP1,
            string respostaP2, string respostaP3)
        {
            Nome = nome;
            BaseOperacional = baseOperacional;
            Matricula = matricula;
            TamanhoCamiseta = tamanhoCamiseta;
            Cpf = cpf;
            DataNascimento = dataNascimento;
            Sexo = sexo;
            Telefone = telefone;
            Email = email;
            RespostaP1 = respostaP1;
            RespostaP2 = respostaP2;
            RespostaP3 = respostaP3;
        }
    }
}
