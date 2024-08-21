using Entities.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL.Interfaces
{
    public interface IImagenProductoDAL
    {
        IEnumerable<ImagenProducto> GetAll();
        bool Add(ImagenProducto _img);
        ImagenProducto Get(int _id);
        bool Update(ImagenProducto _img);
        bool Remove(ImagenProducto _img);

        IEnumerable<ImagenProducto> GetImagenesPorProducto(int productoId);
    }
}
