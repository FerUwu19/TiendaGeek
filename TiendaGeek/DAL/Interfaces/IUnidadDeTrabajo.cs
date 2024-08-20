using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL.Interfaces
{
    public interface IUnidadDeTrabajo: IDisposable
    {
        IProductoDAL ProductoDAL { get; }
        IImagenProductoDAL ImplImagenProductoDAL { get; }
        ICategoriumDAL CategoriumDAL { get; }
        IContactoDAL ContactoDAL { get; }
        bool Complete();
    }
}
