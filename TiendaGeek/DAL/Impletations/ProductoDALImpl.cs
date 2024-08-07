using DAL.Implementations;
using DAL.Interfaces;
using Entities.Entities;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL.Impletations
{
    public class ProductoDALImpl : DALGenericoImpl<Producto>, IProductoDAL
    {
        private TiendaGeekContext _tiendaContext;

        public ProductoDALImpl(TiendaGeekContext tiendaContext) : base(tiendaContext)
        {
            this._tiendaContext = tiendaContext;
        }

        public IEnumerable<Producto> GetByCategories(List<int> categoryIds)
        {
            return _tiendaContext.Set<Producto>().Where(p => p.CodigoCategoria.HasValue && categoryIds.Contains(p.CodigoCategoria.Value)).ToList();
        }
    }
}
