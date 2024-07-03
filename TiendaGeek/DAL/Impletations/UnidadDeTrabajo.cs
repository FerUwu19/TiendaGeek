using DAL.Interfaces;
using Entities.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL.Implementations
{
    public class UnidadDeTrabajo : IUnidadDeTrabajo
    {
        public IProductoDAL ProductoDAL { get; set; }
        private TiendaGeekContext _tiendaContext;

        public UnidadDeTrabajo(TiendaGeekContext tiendaContext,
                        IProductoDAL productoDAL
            ) 
        {
                this._tiendaContext = tiendaContext;
                this.ProductoDAL = productoDAL; 
        }
       

        public bool Complete()
        {
            try
            {
                _tiendaContext.SaveChanges();
                return true;
            }
            catch (Exception)
            {

                return false;
            }
        }

        public void Dispose()
        {
            this._tiendaContext.Dispose();
        }
    }
}
