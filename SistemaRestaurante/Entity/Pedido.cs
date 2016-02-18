using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace SistemaRestaurante.Entity
{
    public class Pedido
    {
        public int idPedido { get; set; }
        public int numeroMesa { get; set; }
        public int idPrato { get; set; }
        public int? idOpcao { get; set; }
        public string status { get; set; }
        public int ordem { get; set; }

        public List<Prato> pratos { get; set; }
    }
}
