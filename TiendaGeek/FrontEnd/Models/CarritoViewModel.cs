namespace FrontEnd.Models
{
    public class CarritoViewModel
    {
        public int Id { get; set; }

        public double Monto { get; set; }

        public string? UsuarioId { get; set; }

        public string? CarritoTemporalId { get; set; }

        public string? Estado { get; set; }

        public virtual ICollection<ItemCarritoViewModel> ItemCarritos { get; set; } = new List<ItemCarritoViewModel>();

        public virtual AspNetUserViewModel? Usuario { get; set; }
    }
}
