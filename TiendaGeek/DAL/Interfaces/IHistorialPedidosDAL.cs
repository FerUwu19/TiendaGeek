using System;
using Entities.Entities;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL.Interfaces
{
    public interface IHistorialPedidoDAL
    {
        IEnumerable<HistorialPedido> GetAll();
        bool Add(HistorialPedido _hist);
        HistorialPedido Get(int _id);
        bool Update(HistorialPedido _hist);
        bool Remove(HistorialPedido _hist);
    }
}