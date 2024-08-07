using DAL.Interfaces;
using Entities.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL.Impletations
{
    public class ImplHistorialPedidoDAL : IHistorialPedidoDAL
    {
        private TiendaGeekContext context;
        public ImplHistorialPedidoDAL(TiendaGeekContext _context)
        {
            this.context = _context;
        }
        public bool Add(HistorialPedido _hist)
        {
            try
            {
                context.HistorialPedidos.Add(_hist);
                context.SaveChanges();
                return true;
            }
            catch
            {
                return false;
            }
        }

        public HistorialPedido Get(int _id)
        {
            return context.HistorialPedidos.Find(_id) ?? new HistorialPedido();
        }

        public IEnumerable<HistorialPedido> GetAll()
        {
            return context.HistorialPedidos.ToList();
        }

        public bool Remove(HistorialPedido _hist)
        {
            try
            {
                context.HistorialPedidos.Attach(_hist);
                context.HistorialPedidos.Remove(_hist);
                context.SaveChanges();
                return true;
            }
            catch (Exception)
            {
                return false;
            }
        }

        public bool Update(HistorialPedido _hist)
        {
            try
            {
                context.Entry(_hist).State = Microsoft.EntityFrameworkCore.EntityState.Modified;
                context.SaveChanges();
                return true;
            }
            catch (Exception)
            {
                return false;
            }
        }
    }
}