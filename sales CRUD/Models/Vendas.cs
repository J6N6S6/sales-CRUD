namespace Sales_CRUD.Models
{
    public class Vendas
    {
        public int Id { get; set; }
        public DateTime DataVenda { get; set; } = DateTime.MinValue;
        public int Cliente { get; set; }
        public int Vendedor { get; set; }
        public int Produto { get; set; }
        public int Quantidade { get; set; }
        public float Valor { get; set; }
        public bool VendaOnline { get; set; } = false;
        public bool Cancelada { get; set; } = false;
    }
}
