using BackEnd.Model;

namespace BackEnd.Services.Interfaces
{
    public interface IImagenProductoServices
    {
        IEnumerable<ImagenProductoModel> GetAll();
        bool Add(ImagenProductoModel _img);
        ImagenProductoModel Get(int _id);
        bool Update(ImagenProductoModel _img);
        bool Remove(ImagenProductoModel _img);
        IEnumerable<ImagenProductoModel> GetImagenesPorProducto(int codigoProducto);
    }
}
