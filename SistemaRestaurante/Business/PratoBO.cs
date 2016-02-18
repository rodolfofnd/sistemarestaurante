using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using SistemaRestaurante.DAO;
using SistemaRestaurante.Entity;

namespace SistemaRestaurante.Business
{
    public class PratoBO
    {
        public List<Prato> ListaPratosPorCategoria(Prato prato)
        {
            DataTable resultado = null;

            try
            {
                resultado = PratoDAO.Instance.ListaPratosPorCategoria(prato).Tables[0];

                var query = (from a in resultado.AsEnumerable()
                             select new Prato
                             {
                                 idPrato = a.Field<int>("idPrato"),
                                 nomePrato = a.Field<string>("nomePrato")
                             }).ToList<Prato>();

                return query;
            }
            catch
            {
                throw;
            }
        }
    }
}
