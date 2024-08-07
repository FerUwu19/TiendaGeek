using DAL.Implementations;
using DAL.Interfaces;
using Entities.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL.Implementations
{
    public class CategoriumDALImpl : DALGenericoImpl<Categorium>, ICategoriumDAL
    {
        private TiendaGeekContext _tiendaContext;

        public CategoriumDALImpl(TiendaGeekContext tiendaContext) : base(tiendaContext)
        {
            this._tiendaContext = tiendaContext;
        }
    }
}
