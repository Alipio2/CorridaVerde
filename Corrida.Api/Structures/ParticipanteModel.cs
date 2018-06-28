using System;
namespace Corrida.Api.Structures
{
    public class ParticipanteModel
    {
        public string Nome { get; set; }
        public string BaseOperacional { get; set; }
        public int Matricula { get; set; }
        public string TamanhoCamiseta { get; set; }
        public string Cpf { get; set; }
        public string DataNascimento { get; set; }//vai dar merda melhor string
        public char Sexo { get; set; }
        public string Telefone { get; set; }
        public string Email { get; set; }
        public string RespostaP1 { get; set; }
        public string RespostaP2 { get; set; }
        public string RespostaP3 { get; set; }
    }
}