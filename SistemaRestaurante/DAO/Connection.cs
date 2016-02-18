using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SistemaRestaurante.DAO
{
    public class Connection
    {
        #region "Instance"
        private static Connection instance;
        public static Connection Instance
        {
            get
            {
                if (instance == null)
                {
                    instance = new Connection();
                }
                return instance;
            }
        }
        #endregion

        /// <summary>
        /// Executa o comando "Open" para abertura da conexão com banco de dados.
        /// </summary>
        /// <returns>classe SqlConnection</returns>
        public SqlConnection Open()
        {
            SqlConnection objConexao = new SqlConnection();
            string sConexao = null;

            try
            {
                sConexao = ConfigurationManager.ConnectionStrings["ConexaoLocal"].ConnectionString;

                if (objConexao != null)
                {
                    objConexao = new SqlConnection();
                    objConexao.ConnectionString = sConexao;
                    objConexao.Open();
                }
                return objConexao;
            }
            catch (SqlException exSql)
            {
                throw new Exception("Erro na abertura do banco de dados: " + exSql.Message);
            }
            catch(Exception ex)
            {
                throw ex;
            }
        }

        /// <summary>
        /// Encerra a conexão com o banco de dados
        /// </summary>
        /// <param name="objConexao">classe de connection com o banco</param>
        /// <returns>retorna true se o banco foi encerrado corretamente.</returns>
        public bool Close(SqlConnection objConexao)
        {
            bool ret = false;
            try
            {
                if (objConexao != null) objConexao.Close();

                ret = true;
            }
            catch (SqlException exSql)
            {
                throw new Exception("Erro ao fechar o banco de dados: " + exSql.Message);
            }
            catch (Exception ex)
            {
                throw ex;
            }
            return ret;
        }
        
        /// <summary>
        /// Executa um comando SQL
        /// </summary>
        /// <param name="pComando">classe de connection com o banco</param>
        /// <returns>retorna true se o comando foi executado corretamente</returns>
        public bool ExecutaComando(SqlCommand pComando)
        {
            SqlConnection conn = null;
            bool ret = false;
            try
            {
                conn = Open();
                pComando.Connection = conn;
                pComando.ExecuteNonQuery();
                ret = true;
            }
            catch (SqlException exSql)
            {
                throw new Exception("Erro ao executar o comando Sql: " + exSql.Message);
            }
            catch (Exception ex)
            {
                throw ex;
            }
            finally
            {
                Close(conn);
            }

            return ret;
        }

        /// <summary>
        /// Executa um comando SQL
        /// </summary>
        /// <param name="pComando">classe de connection com o banco</param>
        /// <returns>retorna true se o comando foi executado corretamente</returns>
        public DataSet ExecutaConsulta(SqlCommand pComando)
        {
            SqlConnection conn = new SqlConnection();
            DataSet objDS = new DataSet();
            try
            {
                conn = Open();
                objDS = new DataSet();
                pComando.Connection = conn;
                SqlDataAdapter objDA = new SqlDataAdapter(pComando);
                objDA.Fill(objDS);
            }
            catch (SqlException exSql)
            {
                throw new Exception("Erro ao executar o comando Sql: " + exSql.Message);
            }
            catch (Exception ex)
            {
                throw ex;
            }
            finally
            {
                Close(conn);
            }

            return objDS;
        }
    }
}
