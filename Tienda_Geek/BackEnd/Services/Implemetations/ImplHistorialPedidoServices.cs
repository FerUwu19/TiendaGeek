using BackEnd.Model;
using BackEnd.Services.Interfaces;
using DAL.Interfaces;
using Entities.Entities;

namespace BackEnd.Services.Implemetations
{
    public class ImplHistorialPedidoServices : IHistorialPedidoServices
    {
        public IHistorialPedidoDAL historialPedido;

        public ImplHistorialPedidoServices(IHistorialPedidoDAL _historial) 
        {
            this.historialPedido = _historial;
        }
        public bool Add(HistorialPedidoModel _hist)
        {
            return this.historialPedido.Add(Convertir(_hist));
        }

        public HistorialPedidoModel Get(int _id)
        {
            return Convertir(this.historialPedido.Get(_id));
        }

        public IEnumerable<HistorialPedidoModel> GetAll()
        {
            var list = this.historialPedido.GetAll();
            var historialPedido = new List<HistorialPedidoModel>();
            foreach (var item in list)
            {
                historialPedido.Add(Convertir(item));
            }
            return historialPedido;
        }

        public bool Remove(HistorialPedidoModel _hist)
        {
            return this.historialPedido.Remove(Convertir(_hist));
        }

        public bool Update(HistorialPedidoModel _hist)
        {
            return this.historialPedido.Update(Convertir(_hist));
        }

        private HistorialPedido Convertir(HistorialPedidoModel _hist) 
        {
            HistorialPedido historial = new HistorialPedido()
            {
                id = _hist.id,
                id_orden = _hist.id_orden 
            };
            return historial;
        }

        private HistorialPedidoModel Convertir(HistorialPedido _hist) 
        {
            HistorialPedidoModel historial = new HistorialPedidoModel()
            {
                id = _hist.id,
                id_orden = _hist.id_orden
            };
            return historial;

        }
    }
}
