using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using SistemaRestaurante.DAO;
using SistemaRestaurante.Entity;

namespace SistemaRestaurante.Business
{
    public class CategoriaBO
    {
        public List<Categoria> ListaCategoria()
        {
            DataTable resultado = null;

            try
            {
                resultado = CategoriaDAO.Instance.ListaCategoria().Tables[0];

                var categorias = (from a in resultado.AsEnumerable()
                             select new Categoria
                             {
                                 idCategoria = a.Field<int>("idCategoria"),
                                 nomeCategoria = a.Field<string>("nomeCategoria")
                             }).ToList<Categoria>();

                return categorias;
            }
            catch
            {
                throw;
            }
        }

        public bool IncluiCategoria(Categoria categoria)
        {
            try
            {
                return CategoriaDAO.Instance.IncluiCategoria(categoria);
            }
            catch
            {
                throw;
            }
        }
    }
}
