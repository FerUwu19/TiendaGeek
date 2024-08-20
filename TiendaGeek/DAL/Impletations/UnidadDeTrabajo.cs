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
        public ICategoriumDAL CategoriumDAL { get; set; }
        public IImagenProductoDAL ImplImagenProductoDAL { get; set; }

        public IContactoDAL ContactoDALImpl { get; set; }

        IContactoDAL IUnidadDeTrabajo.ContactoDAL => this.ContactoDALImpl;

        private TiendaGeekContext _tiendaContext;

        public UnidadDeTrabajo(TiendaGeekContext tiendaContext, IProductoDAL productoDAL, ICategoriumDAL categoriumDAL, IContactoDAL ContactoDALImpl)
        {
            this._tiendaContext = tiendaContext;
            this.ProductoDAL = productoDAL;
            this.CategoriumDAL = categoriumDAL;
            this.ContactoDALImpl = ContactoDALImpl;
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
