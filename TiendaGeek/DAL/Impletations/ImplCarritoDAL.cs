using DAL.Interfaces;
using Entities.Entities;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;

namespace DAL.Impletations
{
    public class ImplCarritoDAL : ICarritoDAL
    {
        private TiendaGeekContext context;
        public ImplCarritoDAL(TiendaGeekContext _context)
        {
            this.context = _context;
        }

        public bool Add(Carrito _carrito)
        {
            try
            {
                context.Carritos.Add(_carrito);
                context.SaveChanges();
                return true;
            }
            catch
            {
                return false;
            }
        }

        public Carrito Get(int id)
        {
            return context.Carritos.Find(id) ?? new Carrito();
        }

        public IEnumerable<Carrito> GetAll()
        {
            return context.Carritos.ToList();
        }
    }
}
