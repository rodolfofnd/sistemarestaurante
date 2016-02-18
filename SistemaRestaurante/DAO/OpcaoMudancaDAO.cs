using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using SistemaRestaurante.Entity;

namespace SistemaRestaurante.DAO
{
    public class OpcaoMudancaDAO
    {
        #region "Instance"
        private static OpcaoMudancaDAO instance;

        public static OpcaoMudancaDAO Instance
        {
            get
            {
                if (instance == null)
                {
                    instance = new OpcaoMudancaDAO();
                }
                return instance;
            }
        }
        #endregion

        /// <summary>
        /// Inclui uma nova Opção de Mudança do prato
        /// </summary>
        /// <param name="categoria">Objeto com as informações da OpcaoMudanca</param>
        /// <returns>retorno true se a inclusão ocorrer com sucesso.</returns>
        public bool IncluiOpcaoMudanca(OpcaoMudanca opcao)
        {
            bool resultado;

            try
            {
                SqlCommand objCMD = new SqlCommand();
                objCMD.CommandType = CommandType.Text;
                objCMD.CommandText = "insert into OpcaoMudanca values('" + opcao.descricao + "')";
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
