namespace Sales_CRUD.Models
{
    public class ProdutoTipo
    {
        public int Id { get; set; }
        public string Descricao { get; set; } = string.Empty;
        public bool DescontoAplicavel { get; set; } = true;
        public bool Inativo { get; set; } = false;
    }
}
