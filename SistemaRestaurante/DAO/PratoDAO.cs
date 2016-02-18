using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data;
using System.Data.SqlClient;
using SistemaRestaurante.Entity;

namespace SistemaRestaurante.DAO
{
    public class PratoDAO
    {

        #region "Instance"
        private static PratoDAO instance;

        public static PratoDAO Instance
        {
            get
            {
                if (instance == null)
                {
                    instance = new PratoDAO();
                }
                return instance;
            }
        }
        #endregion

        /// <summary>
        /// Lista os pratos por categoria
        /// </summary>
        /// <returns>DataSet com o resultado do retorno da consulta</returns>
        public DataSet ListaPratosPorCategoria(Prato prato)
        {
            DataSet resultado = null;

            try
            {
                SqlCommand objCMD = new SqlCommand();
                objCMD.CommandType = CommandType.Text;
                objCMD.CommandText = "select idPrato, nomePrato * from Prato where idCategoria =" + prato.idCategoria;
                resultado = Connection.Instance.ExecutaConsulta(objCMD);
            }
            catch (Exception ex)
            {
                throw ex;
            }

            return resultado;
        }

        /// <summary>
        /// Inclui uma novo prato
        /// </summary>
        /// <param name="categoria">Objeto com as informações do prato</param>
        /// <returns>retorno true se a inclusão ocorrer com sucesso.</returns>
        public bool IncluiPrato(Prato prato)
        {
            bool resultado;

            try
            {
                SqlCommand objCMD = new SqlCommand();
                objCMD.CommandType = CommandType.Text;
                objCMD.CommandText = "insert into Prato values('" + prato.nomePrato + "', "
                                     + prato.precoPrato + ", '" + prato.descricaoPrato + "',"
                                     + prato.idCategoria + ")";
                resultado = Connection.Instance.ExecutaComando(objCMD);
            }
            catch (Exception ex)
            {
                throw ex;
            }

            return resultado;
        }

    }
}
