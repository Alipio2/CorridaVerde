using Corrida.Domain.Contracts.Repositories;
using Corrida.Domain.Entity;
using System;
using System.Data;
using System.Data.SqlClient;

namespace Corrida.Infra
{
    public class ParticipanteRepository : IParticipanteRepository
    {
        public Participante GetCpf(string pCpf)
        {
            string nome = string.Empty, baseOperacional= string.Empty, tamanhoCamiseta = string.Empty, cpf = string.Empty, telefone = string.Empty, email = string.Empty, respostaP1 = string.Empty, respostaP2 = string.Empty, respostaP3 = string.Empty;
            int matricula =0;
            DateTime dataNascimento= new DateTime();
            char sexo = ' ';

            using (var cn = new SqlConnection(Settings.ConnectionStringAlp))
            {
                using (SqlCommand cmd = new SqlCommand())
                {
                    cn.Open();
                    cmd.Connection = cn;
                    cmd.CommandType = CommandType.Text;
                    cmd.CommandText = "SELECT * FROM dbo.Participantes WHERE cpf = @Cpf";
                    cmd.Parameters.AddWithValue("@Cpf", pCpf);

                    using (SqlDataReader dr = cmd.ExecuteReader())
                    {
                        if (dr.HasRows)
                        {
                            while (dr.Read())
                            {
                                nome= dr["Nome"].ToString();
                                baseOperacional= dr["BaseOperacional"].ToString();
                                matricula = Convert.ToInt32(dr["Matricula"]);
                                tamanhoCamiseta= dr["TamanhoCamiseta"].ToString();
                                cpf = dr["Cpf"].ToString();
                                dataNascimento = Convert.ToDateTime(dr["DataNascimento"]);
                                sexo= Convert.ToChar(dr["Sexo"].ToString());
                                telefone= dr["Telefone"].ToString();
                                email = dr["Email"].ToString();
                                respostaP1 = dr["RespostaP1"].ToString();
                                respostaP2 = dr["RespostaP2"].ToString();
                                respostaP3 = dr["RespostaP3"].ToString();
                            }
                        }
                    }
                }
            }
          
            var participante = new Participante(nome, baseOperacional, matricula, 
                tamanhoCamiseta, cpf, dataNascimento, sexo, telefone, email, respostaP1,
                respostaP2, respostaP3);

            return participante;
        }

        public void Insert(Participante pObjeto)
        {
            using (var cn = new SqlConnection(Settings.ConnectionStringAlp))
            {
                using (SqlCommand cmd = new SqlCommand())
                {
                    cn.Open();
                    cmd.Connection = cn;
                    cmd.CommandType = CommandType.Text;
                    cmd.CommandText = "INSERT INTO dbo.Participantes (Nome, BaseOperacional, Matricula, TamanhoCamiseta, Cpf, DataNascimento, Sexo, Telefone," +
                                                            " Email, RespostaP1, RespostaP2, RespostaP3) " +
                                                            "VALUES (@Nome, @BaseOperacional, @Matricula, @TamanhoCamiseta, @Cpf, @DataNascimento, @Sexo, @Telefone," +
                                                            " @Email, @RespostaP1, @RespostaP2, @RespostaP3)";

                    cmd.Parameters.Add("@Nome", SqlDbType.VarChar, 40).Value = pObjeto.Nome;
                    cmd.Parameters.Add("@BaseOperacional", SqlDbType.VarChar, 30).Value = pObjeto.BaseOperacional;
                    cmd.Parameters.Add("@Matricula", SqlDbType.Int).Value = pObjeto.Matricula;
                    cmd.Parameters.Add("@TamanhoCamiseta", SqlDbType.VarChar, 5).Value = pObjeto.TamanhoCamiseta;
                    cmd.Parameters.Add("@Cpf", SqlDbType.VarChar, 20).Value = pObjeto.Cpf;
                    cmd.Parameters.Add("@DataNascimento", SqlDbType.DateTime).Value = pObjeto.DataNascimento;
                    cmd.Parameters.Add("@Sexo", SqlDbType.Char, 1).Value = pObjeto.Sexo;
                    cmd.Parameters.Add("@Telefone", SqlDbType.VarChar, 20).Value = pObjeto.Telefone;
                    cmd.Parameters.Add("@Email", SqlDbType.VarChar, 20).Value = pObjeto.Email;
                    cmd.Parameters.Add("@RespostaP1", SqlDbType.VarChar, 30).Value = pObjeto.RespostaP1;
                    cmd.Parameters.Add("@RespostaP2", SqlDbType.VarChar, 30).Value = pObjeto.RespostaP2;
                    cmd.Parameters.Add("@RespostaP3", SqlDbType.VarChar, 30).Value = pObjeto.RespostaP3;

                    cmd.ExecuteNonQuery();
                }
            }
        }
    }
}
