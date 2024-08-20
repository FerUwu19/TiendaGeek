using FrontEnd.ApiModel;
using FrontEnd.Controllers;
using FrontEnd.Helpers.Interfaces;
using FrontEnd.Models;
using Newtonsoft.Json;

namespace FrontEnd.Helpers.Implemetations
{
    public class ImpHistorialPedidoHelper : IHistorialPedidoHelper
    {
        IServiceRepository ServiceRepository;
        public ImpHistorialPedidoHelper(IServiceRepository _serviceRepository) {
            ServiceRepository = _serviceRepository;
        }

        public List<HistorialPedidosViewModel> GetHistorialPedidos() {
            HttpResponseMessage response = ServiceRepository.GetResponse("api/HistorialPedido");
            var resultado = new List<HistorialPedidos>();
            var pedidos = new List<HistorialPedidosViewModel>();



            if (response != null)
            {
                var content = response.Content.ReadAsStringAsync().Result;
                resultado = JsonConvert.DeserializeObject<List<HistorialPedidos>>(content);
            }

            foreach (var item in resultado)
            {
                pedidos.Add(Convertir(item));
            }

            return pedidos;
        }

        private HistorialPedidosViewModel Convertir(ApiModel.HistorialPedidos _pedido)
        {
            return new HistorialPedidosViewModel
            {
                id = _pedido.id,
                id_orden = _pedido.id_orden,
                fecha_de_creacion = _pedido.fecha_de_creacion
            };
        }

    }
}
