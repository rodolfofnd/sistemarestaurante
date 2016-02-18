using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace SistemaRestaurante.Entity
{
    public class Prato
    {
        public int idPrato { get; set; }
        public string nomePrato { get; set; }
        public decimal precoPrato { get; set; }
        public string descricaoPrato { get; set; }

        public int idCategoria { get; set; }
        public List<OpcaoMudanca> opcoesMudanca { get; set; }
    }
}
