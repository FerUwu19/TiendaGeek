using Entities.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL.Interfaces
{
    public interface ICarritoDAL
    {
        IEnumerable<Carrito> GetAll();
        bool Add(Carrito carrito);
        Carrito Get(int id);
    }
}
