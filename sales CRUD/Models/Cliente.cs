namespace Sales_CRUD.Models
{
    public class Cliente
    {
        public int Id { get; set; }
        public string Nome { get; set; } = string.Empty;
        public string? Cnpj_Cpf { get; set; }
        public string? Email { get; set; }
        public string Telefone { get; set; } = string.Empty;
        public DateTime? Data_Aniversario { get; set; }
        public bool Inativo { get; set; } = false;
    }
}
