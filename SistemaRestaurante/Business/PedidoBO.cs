using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using SistemaRestaurante.DAO;
using SistemaRestaurante.Entity;

namespace SistemaRestaurante.Business
{
    public class PedidoBO
    {
        public bool FinalizaPedido(Pedido pedido)
        {
            try
            {
                return PedidoDAO.Instance.IncluiPedido(pedido);
            }
            catch
            {
                throw;
            }
        }
    }
}
