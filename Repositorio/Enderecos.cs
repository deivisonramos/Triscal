using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using Triscal.Entities;

namespace Triscal.Repositorio
{
    public class Enderecos : IEnderecos
    {
        private readonly string cn = @"Data Source=(localdb)\MSSQLLocalDB;AttachDbFilename=C:\Users\Deivi\Desktop\Triscal\Database\TriscalBase.mdf;Initial Catalog=triscal;Integrated Security=True;";


        public void InseriEndereco(Endereco Endereco)
        {
            try
            {
                using (SqlConnection con = new SqlConnection(cn))
                {
                    con.Open();

                    using (SqlCommand cmd = new SqlCommand())
                    {
                        cmd.CommandType = CommandType.StoredProcedure;
                        cmd.CommandText = "PR_INSERIR_ENDERECO";
                        cmd.Connection = con;

                        cmd.Parameters.Add(new SqlParameter("@LOGRADOURO", Endereco.Logradouro));
                        cmd.Parameters.Add(new SqlParameter("@BAIRRO", Endereco.Bairro));
                        cmd.Parameters.Add(new SqlParameter("@CIDADE", Endereco.Cidade));
                        cmd.Parameters.Add(new SqlParameter("@ESTADO", Endereco.Estado));

                        cmd.ExecuteNonQuery();

                    }
                }
            }
            catch (Exception ex)
            {
                throw;
            }
        }


    public void ExcluiEndereco(int? id)
        {
            try
            {
                using (SqlConnection con = new SqlConnection(cn))
                {
                    con.Open();

                    using (SqlCommand cmd = new SqlCommand())
                    {
                        cmd.CommandType = CommandType.StoredProcedure;
                        cmd.CommandText = "PR_EXCLUIR_ENDERECO";
                        cmd.Connection = con;

                        cmd.Parameters.Add(new SqlParameter("@ID", id));

                        cmd.ExecuteNonQuery();

                    }
                }
            }
            catch (Exception ex)
            {
                throw;
            }

        }

        public IEnumerable<Endereco> BuscaTodosEnderecos()
        {
            List<Endereco> lstEndereco = new List<Endereco>();

            try
            {
                using (SqlConnection con = new SqlConnection(cn))
                {
                    con.Open();

                    using (SqlCommand cmd = new SqlCommand())
                    {
                        cmd.CommandType = CommandType.StoredProcedure;
                        cmd.CommandText = "PR_BUSCAR_TODOS_ENDERECOS";
                        cmd.Connection = con;
                        SqlDataReader rdr = cmd.ExecuteReader();

                        while (rdr.Read())
                        {
                            Endereco Endereco = new Endereco();
                            Endereco.Logradouro = rdr["Logradouro"].ToString();
                            Endereco.Bairro = rdr["Bairro"].ToString();
                            Endereco.Cidade = rdr["Cidade"].ToString();
                            Endereco.Estado = rdr["Estado"].ToString();
                            lstEndereco.Add(Endereco);
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                throw;
            }

            return lstEndereco;

        }

        public Endereco BuscaEndereco(int? id)
        {
            Endereco Endereco = new Endereco();

            try
            {
                using (SqlConnection con = new SqlConnection(cn))
                {
                    con.Open();

                    using (SqlCommand cmd = new SqlCommand())
                    {
                        cmd.CommandType = CommandType.StoredProcedure;
                        cmd.CommandText = "PR_BUSCAR_ENDERECOS";

                        cmd.Parameters.Add(new SqlParameter("@ID", id));

                        cmd.Connection = con;
                        SqlDataReader rdr = cmd.ExecuteReader();

                        if (rdr.Read())
                        {
                            Endereco.Logradouro = rdr["Logradouro"].ToString();
                            Endereco.Bairro = rdr["Bairro"].ToString();
                            Endereco.Cidade = rdr["Cidade"].ToString();
                            Endereco.Estado = rdr["Estado"].ToString();
                        }

                    }
                }
            }
            catch (Exception ex)
            {
                throw;
            }

            return Endereco;
        }

        public void AtualizaEndereco(Endereco Endereco)
        {
            try
            {
                using (SqlConnection con = new SqlConnection(cn))
                {
                    con.Open();

                    using (SqlCommand cmd = new SqlCommand())
                    {
                        cmd.CommandType = CommandType.StoredProcedure;
                        cmd.CommandText = "PR_ATUALIZAR_ENDERECO";
                        cmd.Connection = con;

                        cmd.Parameters.Add(new SqlParameter("@LOGRADOURO", Endereco.Logradouro));
                        cmd.Parameters.Add(new SqlParameter("@BAIRRO", Endereco.Bairro));
                        cmd.Parameters.Add(new SqlParameter("@CIDADE", Endereco.Cidade));
                        cmd.Parameters.Add(new SqlParameter("@ESTADO", Endereco.Estado));
                        cmd.Parameters.Add(new SqlParameter("@ID", Endereco.IdEndereco));

                        cmd.ExecuteNonQuery();

                    }
                }
            }
            catch (Exception ex)
            {
                throw;
            }
        }
    }
}