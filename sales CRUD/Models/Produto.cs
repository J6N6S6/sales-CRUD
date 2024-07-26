namespace Sales_CRUD.Models
{
    public class Produto
    {
        public int ID { get; set; }
        public int Tipo { get; set; }
        public int Filial { get; set; }
        public float ValorUnitario { get; set; }
        public int QuantidadeEstoque { get; set; }
        public int QuantidadeMinima { get; set; } = 1;
        public bool Inativo { get; set; } = false;
    }
}
