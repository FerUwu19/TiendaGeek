using DAL.Interfaces;
using Entities.Entities;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL.Impletations
{
    public class ImplImagenProductoDAL : IImagenProductoDAL
    {
        private TiendaGeekContext context;
        public ImplImagenProductoDAL(TiendaGeekContext _context)
        {
            this.context = _context;
        }
        public bool Add(ImagenProducto _img)
        {
            try
            {
                context.ImagenProductos.Add(_img);
                context.SaveChanges();
                return true;
            }
            catch
            {
                return false;
            }
        }

        public ImagenProducto Get(int _id)
        {
            return context.ImagenProductos.Find(_id) ?? new ImagenProducto();
        }

        public IEnumerable<ImagenProducto> GetAll()
        {
            return context.ImagenProductos.ToList();
        }

        public bool Remove(ImagenProducto _img)
        {
            try
            {
                context.ImagenProductos.Attach(_img);
                context.ImagenProductos.Remove(_img);
                context.SaveChanges();
                return true;
            }
            catch (Exception)
            {
                return false;
            }
        }

        public bool Update(ImagenProducto _img)
        {
            try
            {
                context.Entry(_img).State = Microsoft.EntityFrameworkCore.EntityState.Modified;
                context.SaveChanges();
                return true;
            }
            catch (Exception)
            {
                return false;
            }
        }


        //Método para obtener las imágenes por producto
        public IEnumerable<ImagenProducto> GetImagenesPorProducto(int productoId)
        {
            return context.ImagenProductos
                          .Where(img => img.CodigoProducto == productoId)
                          .ToList();
        }
    }
}
