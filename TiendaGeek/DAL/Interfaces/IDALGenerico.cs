using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL.Interfaces
{
    public interface IDALGenerico<TEntity> where TEntity : class
    {
        IEnumerable<TEntity> GetAll();
        bool Add(TEntity entity);
        TEntity Get(int id);
        bool Update(TEntity entity);
        bool Remove(TEntity entity);
    }
}
