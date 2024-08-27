using DAL.Interfaces;
using Entities.Entities;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;

namespace DAL.Implementations
{
    public class ImplCarritoDAL : ICarritoDAL
    {
        private readonly TiendaGeekContext context;

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

        public Carrito GetCarritoByUsuarioId(string usuarioId, string estado = "Incompleto")
        {
            return context.Carritos
                          .Include(c => c.ItemCarritos)
                          .ThenInclude(i => i.Producto)
                          .FirstOrDefault(c => c.UsuarioId == usuarioId && c.Estado == estado);
        }

        public Carrito GetCarritoByTemporalId(string carritoTemporalId, string estado = "Incompleto")
        {
            return context.Carritos
                          .Include(c => c.ItemCarritos)
                          .ThenInclude(i => i.Producto)
                          .FirstOrDefault(c => c.CarritoTemporalId == carritoTemporalId && c.Estado == estado);
        }

        public bool Update(Carrito _carrito)
        {
            try
            {
                context.Carritos.Update(_carrito);
                context.SaveChanges();
                return true;
            }
            catch
            {
                return false;
            }
        }

        public bool Remove(Carrito _carrito)
        {
            try
            {
                context.Carritos.Remove(_carrito);
                context.SaveChanges();
                return true;
            }
            catch
            {
                return false;
            }
        }

        public bool MergeCarritos(Carrito usuarioCarrito, Carrito temporalCarrito)
        {
            try
            {
                foreach (var item in temporalCarrito.ItemCarritos)
                {
                    var existingItem = usuarioCarrito.ItemCarritos
                        .FirstOrDefault(i => i.ProductoId == item.ProductoId);

                    if (existingItem != null)
                    {
                        existingItem.Cantidad += item.Cantidad;
                    }
                    else
                    {
                        usuarioCarrito.ItemCarritos.Add(item);
                    }
                }
                context.Carritos.Remove(temporalCarrito);
                context.Carritos.Update(usuarioCarrito);
                context.SaveChanges();
                return true;
            }
            catch
            {
                return false;
            }
        }

        public IEnumerable<Carrito> GetCarritosCompletados(string usuarioId)
        {
            return context.Carritos
                          .Include(c => c.ItemCarritos)
                          .ThenInclude(i => i.Producto)
                          .Where(c => c.UsuarioId == usuarioId && c.Estado == "Completo")
                          .ToList();
        }
    }
}
