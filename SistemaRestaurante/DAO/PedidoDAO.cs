using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using SistemaRestaurante.Entity;

namespace SistemaRestaurante.DAO
{
    public class PedidoDAO
    {
        #region "Instance"
        private static PedidoDAO instance;

        public static PedidoDAO Instance
        {
            get
            {
                if (instance == null)
                {
                    instance = new PedidoDAO();
                }
                return instance;
            }
        }
        #endregion

        /// <summary>
        /// Inclui um novo pedido
        /// </summary>
        /// <param name="categoria">Objeto com as informações do pedido</param>
        /// <returns>retorno true se a inclusão ocorrer com sucesso.</returns>
        public bool IncluiPedido(Pedido pedido)
        {
            bool resultado;

            try
            {
                SqlCommand objCMD = new SqlCommand();
                objCMD.CommandType = CommandType.Text;
                objCMD.CommandText = "insert into Pedido values(" + pedido.numeroMesa + ", "
                                     + pedido.idPrato + ", " + pedido.idOpcao + ", '"+ pedido.status + "', "
                                     + pedido.ordem + ")";
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
