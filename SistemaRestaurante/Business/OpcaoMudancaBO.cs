using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using SistemaRestaurante.DAO;
using SistemaRestaurante.Entity;

namespace SistemaRestaurante.Business
{
    public class OpcaoMudancaBO
    {
        public bool IncluiOpcaoMudanca(OpcaoMudanca opcao)
        {
            try
            {
                return OpcaoMudancaDAO.Instance.IncluiOpcaoMudanca(opcao);
            }
            catch
            {
                throw;
            }
        }
    }
}
