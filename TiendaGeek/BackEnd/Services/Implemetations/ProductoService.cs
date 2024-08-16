using BackEnd.Model;
using BackEnd.Services.Interfaces;
using DAL.Implementations;
using DAL.Interfaces;
using Entities.Entities;

namespace BackEnd.Services.Implemetations
{
    public class ProductoService : IProductoService
    {

        private IUnidadDeTrabajo _unidadDeTrabajo;

        private IProductoDAL ProductoDAL;
        private Producto Convertir(ProductoModel productoModel)
        {
            Producto entity = new Producto
            {
                CodigoProducto = productoModel.CodigoProducto,
                CodigoCategoria = productoModel.CodigoCategoria,
                Nombre = productoModel.Nombre,
                Descripcion = productoModel.Descripcion,
                Precio = productoModel.Precio,
                Unidades = productoModel.Unidades,
                Estado = productoModel.Estado
            };
            return entity;
        }

        private ProductoModel Convertir(Producto producto)
        {
            ProductoModel entity = new ProductoModel
            {
                CodigoProducto = producto.CodigoProducto,
                CodigoCategoria = producto.CodigoCategoria,
                Nombre = producto.Nombre,
                Descripcion = producto.Descripcion,
                Precio = producto.Precio,
                Unidades = producto.Unidades,
                Estado = producto.Estado
            };
            return entity;
        }


        public ProductoService(IUnidadDeTrabajo unidadDeTrabajo, IProductoDAL productoDAL)
        {
            this._unidadDeTrabajo = unidadDeTrabajo;
        }

        public bool Add(ProductoModel producto)
        {
            _unidadDeTrabajo.ProductoDAL.Add(Convertir(producto));
            return _unidadDeTrabajo.Complete();
        }

        public ProductoModel Get(int id)
        {
            return Convertir(_unidadDeTrabajo.ProductoDAL.Get(id));
        }

        public IEnumerable<ProductoModel> Get()
        {
            var lista = _unidadDeTrabajo.ProductoDAL.GetAll();
            List<ProductoModel> productos = new List<ProductoModel>();
            foreach (var item in lista)
            {
                productos.Add(Convertir(item));
            }
            return productos;
        }

        public bool Remove(ProductoModel producto)
        {
            _unidadDeTrabajo.ProductoDAL.Remove(Convertir(producto));
            return _unidadDeTrabajo.Complete();
        }

        public bool Update(ProductoModel producto)
        {
            _unidadDeTrabajo.ProductoDAL.Update(Convertir(producto));
            return _unidadDeTrabajo.Complete();
        }

        //filtro categoria
        public IEnumerable<ProductoModel> GetByCategory(int categoryId)
        {
            var productos = _unidadDeTrabajo.ProductoDAL.GetAll()
                               .Where(p => p.CodigoCategoria == categoryId)
                               .ToList();
            return productos.Select(p => Convertir(p)).ToList();
        }

    }
}
