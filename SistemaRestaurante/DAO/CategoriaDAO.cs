using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using SistemaRestaurante.Entity;

namespace SistemaRestaurante.DAO
{
    public class CategoriaDAO
    {
        #region "Instance"
        private static CategoriaDAO instance;

        public static CategoriaDAO Instance
        {
            get
            {
                if (instance == null)
                {
                    instance = new CategoriaDAO();
                }
                return instance;
            }
        }
        #endregion

        /// <summary>
        /// Lista categorias
        /// </summary>
        /// <returns>DataSet com o resultado do retorno da consulta</returns>
        public DataSet ListaCategoria()
        {
            DataSet resultado = null;

            try
            {
                SqlCommand objCMD = new SqlCommand();
                objCMD.CommandType = CommandType.Text;
                objCMD.CommandText = "select idCategoria, nomeCategoria from Categoria";
                resultado = Connection.Instance.ExecutaConsulta(objCMD);
            }
            catch (Exception ex)
            {
                throw ex;
            }

            return resultado;
        }

        /// <summary>
        /// Inclui uma nova categoria
        /// </summary>
        /// <param name="categoria">Objeto com as informações da categoria</param>
        /// <returns>retorno true se a inclusão ocorrer com sucesso.</returns>
        public bool IncluiCategoria(Categoria categoria)
        {
            bool resultado;

            try
            {
                SqlCommand objCMD = new SqlCommand();
                objCMD.CommandType = CommandType.Text;
                objCMD.CommandText = "insert into Categoria values('" + categoria.nomeCategoria +"', '" 
                                     + categoria.descricaoCategoria + "')";
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
