namespace Sales_CRUD.Models
{
    public class Filial
    {
        public int Id { get; set; }
        public string Descricao { get; set; } = string.Empty;
        public string Logradouro { get; set; } = string.Empty ;
        public string? Numero { get; set; }
        public string? Cep { get; set; }
        public int VendedorResponsavel { get; set; } = 0 ;
        public bool Inativo { get; set; } = false ;
    }
}
