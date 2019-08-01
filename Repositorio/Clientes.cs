using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using Triscal.Entities;

namespace Triscal.Repositorio
{
    public class Clientes : IClientes
    {
        private readonly string cn = @"Data Source=(localdb)\MSSQLLocalDB;AttachDbFilename=C:\Users\Deivi\Desktop\Triscal\Database\TriscalBase.mdf;Initial Catalog=triscal;Integrated Security=True;";

        public void InseriCliente(Cliente Cliente)
        {
            try
            {
                using (SqlConnection con = new SqlConnection(cn))
                {
                    con.Open();

                    using (SqlCommand cmd = new SqlCommand())
                    {
                        cmd.CommandType = CommandType.StoredProcedure;
                        cmd.CommandText = "PR_INSERIR_CLIENTE";
                        cmd.Connection = con;

                        cmd.Parameters.Add(new SqlParameter("@NOME", Cliente.Nome));
                        cmd.Parameters.Add(new SqlParameter("@IDADE", Cliente.Idade));
                        cmd.Parameters.Add(new SqlParameter("@CPF", Cliente.Cpf));

                        cmd.ExecuteNonQuery();

                    }
                }
            }
            catch (Exception ex)
            {
                throw;
            }
        }


    public void ExcluiCliente(int? id)
        {
            try
            {
                using (SqlConnection con = new SqlConnection(cn))
                {
                    con.Open();

                    using (SqlCommand cmd = new SqlCommand())
                    {
                        cmd.CommandType = CommandType.StoredProcedure;
                        cmd.CommandText = "PR_EXCLUIR_CLIENTE";
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

        public IEnumerable<Cliente> BuscaTodosClientes()
        {
            List<Cliente> lstCliente = new List<Cliente>();

            try
            {
                using (SqlConnection con = new SqlConnection(cn))
                {
                    con.Open();

                    using (SqlCommand cmd = new SqlCommand())
                    {
                        cmd.CommandType = CommandType.StoredProcedure;
                        cmd.CommandText = "PR_BUSCAR_TODOS_CLIENTES";
                        cmd.Connection = con;
                        SqlDataReader rdr = cmd.ExecuteReader();

                        while (rdr.Read())
                        {
                            Cliente Cliente = new Cliente();
                            Cliente.IdCliente = Convert.ToInt32(rdr["IdCliente"]);
                            Cliente.Nome = rdr["Nome"].ToString();
                            Cliente.Idade = Convert.ToInt32(rdr["Idade"]);
                            Cliente.Cpf = rdr["CPF"].ToString();
                            lstCliente.Add(Cliente);
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                throw;
            }

            return lstCliente;

        }

        public Cliente BuscaCliente(int? id)
        {
            Cliente Cliente = new Cliente();

            try
            {
                using (SqlConnection con = new SqlConnection(cn))
                {
                    con.Open();

                    using (SqlCommand cmd = new SqlCommand())
                    {
                        cmd.CommandType = CommandType.StoredProcedure;
                        cmd.CommandText = "PR_BUSCAR_CLIENTE";

                        cmd.Parameters.Add(new SqlParameter("@ID", id));

                        cmd.Connection = con;
                        SqlDataReader rdr = cmd.ExecuteReader();

                        if (rdr.Read())
                        {
                            Cliente.IdCliente = Convert.ToInt32(rdr["IdCliente"]);
                            Cliente.Nome = rdr["Nome"].ToString();
                            Cliente.Idade = Convert.ToInt32(rdr["Idade"]);
                            Cliente.Cpf = rdr["CPF"].ToString();
                        }

                    }
                }
            }
            catch (Exception ex)
            {
                throw;
            }

            return Cliente;
        }

        public void AtualizaCliente(Cliente Cliente)
        {
            try
            {
                using (SqlConnection con = new SqlConnection(cn))
                {
                    con.Open();

                    using (SqlCommand cmd = new SqlCommand())
                    {
                        cmd.CommandType = CommandType.StoredProcedure;
                        cmd.CommandText = "PR_ATUALIZAR_CLIENTE";
                        cmd.Connection = con;

                        cmd.Parameters.Add(new SqlParameter("@NOME", Cliente.Nome));
                        cmd.Parameters.Add(new SqlParameter("@IDADE", Cliente.Idade));
                        cmd.Parameters.Add(new SqlParameter("@CPF", Cliente.Cpf));
                        cmd.Parameters.Add(new SqlParameter("@ID", Cliente.IdCliente));

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