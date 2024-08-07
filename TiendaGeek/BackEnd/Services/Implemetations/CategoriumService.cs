using BackEnd.Model;
using BackEnd.Services.Interfaces;
using DAL.Implementations;
using DAL.Interfaces;
using Entities.Entities;

namespace BackEnd.Services.Implementations
{
    public class CategoriumService : ICategoriumService
    {
        private IUnidadDeTrabajo _unidadDeTrabajo;
        private ICategoriumDAL CategoriumDAL;

        private Categorium Convertir(CategoriumModel categoriumModel)
        {
            Categorium entity = new Categorium
            {
                CodigoCategoria = categoriumModel.CodigoCategoria,
                Nombre = categoriumModel.Nombre,
                Descripcion = categoriumModel.Descripcion
            };
            return entity;
        }

        private CategoriumModel Convertir(Categorium categorium)
        {
            CategoriumModel entity = new CategoriumModel
            {
                CodigoCategoria = categorium.CodigoCategoria,
                Nombre = categorium.Nombre,
                Descripcion = categorium.Descripcion
            };
            return entity;
        }

        public CategoriumService(IUnidadDeTrabajo unidadDeTrabajo, ICategoriumDAL categoriumDAL)
        {
            this._unidadDeTrabajo = unidadDeTrabajo;
            this.CategoriumDAL = categoriumDAL;
        }

        public bool Add(CategoriumModel categorium)
        {
            _unidadDeTrabajo.CategoriumDAL.Add(Convertir(categorium));
            return _unidadDeTrabajo.Complete();
        }

        public CategoriumModel Get(int id)
        {
            return Convertir(_unidadDeTrabajo.CategoriumDAL.Get(id));
        }

        public IEnumerable<CategoriumModel> Get()
        {
            var lista = _unidadDeTrabajo.CategoriumDAL.GetAll();
            List<CategoriumModel> categorias = new List<CategoriumModel>();
            foreach (var item in lista)
            {
                categorias.Add(Convertir(item));
            }
            return categorias;
        }

        public bool Remove(CategoriumModel categorium)
        {
            _unidadDeTrabajo.CategoriumDAL.Remove(Convertir(categorium));
            return _unidadDeTrabajo.Complete();
        }

        public bool Update(CategoriumModel categorium)
        {
            _unidadDeTrabajo.CategoriumDAL.Update(Convertir(categorium));
            return _unidadDeTrabajo.Complete();
        }
    }
}


