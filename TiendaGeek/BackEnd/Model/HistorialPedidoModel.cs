using System.ComponentModel.DataAnnotations;

namespace BackEnd.Model
{
    public class HistorialPedidoModel
    {
        public int id { get; set; }
        public int? id_orden { get; set; }
        public DateTime? fecha_de_creacion { get; set; }
    }
}