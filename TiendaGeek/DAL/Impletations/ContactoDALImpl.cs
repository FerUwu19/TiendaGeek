using DAL.Implementations;
using DAL.Interfaces;
using Entities.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL.Impletations
{
    public class ContactoDALImpl : DALGenericoImpl<Contacto>, IContactoDAL
    {
        private TiendaGeekContext _tiendaContext;

        public ContactoDALImpl(TiendaGeekContext tiendaContext) : base(tiendaContext)
        {
            this._tiendaContext = tiendaContext;
        }

    }//fn class
}//fn space
