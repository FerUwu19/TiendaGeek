using BackEnd.Model;
using BackEnd.Services.Interfaces;
using DAL.Interfaces;
using Entities.Entities;

namespace BackEnd.Services.Implemetations
{
    public class ImplImagenProductoServices : IImagenProductoServices
    {
        public IImagenProductoDAL imagenProducto;

        public ImplImagenProductoServices(IImagenProductoDAL _img)
        {
            this.imagenProducto = _img;
        }
        public bool Add(ImagenProductoModel _img)
        {
            return this.imagenProducto.Add(Convertir(_img));
        }

        public ImagenProductoModel Get(int _id)
        {
            return Convertir(this.imagenProducto.Get(_id));
        }

        public IEnumerable<ImagenProductoModel> GetAll()
        {
            var list = this.imagenProducto.GetAll();
            var imagenProducto = new List<ImagenProductoModel>();
            foreach (var item in list)
            {
                imagenProducto.Add(Convertir(item));
            }
            return imagenProducto;
        }

        public bool Remove(ImagenProductoModel _img)
        {
            return this.imagenProducto.Remove(Convertir(_img));
        }

        public bool Update(ImagenProductoModel _img)
        {
            return this.imagenProducto.Update(Convertir(_img));
        }

        private ImagenProducto Convertir(ImagenProductoModel _img)
        {
            ImagenProducto img = new ImagenProducto()
            {
                CodigoImagen = _img.CodigoImagen,
                CodigoProducto = _img.CodigoProducto,
                RutaImagen = _img.RutaImagen
            };
            return img;
        }

        private ImagenProductoModel Convertir(ImagenProducto _img)
        {
            ImagenProductoModel img = new ImagenProductoModel()
            {
                CodigoImagen = _img.CodigoImagen,
                CodigoProducto = _img.CodigoProducto,
                RutaImagen = _img.RutaImagen
            };
            return img;

        }
    }
}
