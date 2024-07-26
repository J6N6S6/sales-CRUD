using System.Reflection.Metadata.Ecma335;

namespace Sales_CRUD.Models
{
    public class Vendedor
    {
        public int Id { get; set; }
        public int Filial { get; set; }
        public string Nome { get; set; } = string.Empty;
        public string CnpjCpf { get; set; } = string.Empty;
        public string? Email { get; set; }
        public string Telefone { get; set; } = string.Empty;
        public DateTime DataAdmissao { get; set; } = DateTime.MinValue;
        public DateTime DataAniversario { get; set; } = DateTime.MinValue;
        public float PercentualComissao { get; set; }
        public bool Inativo { get; set; } = false;
    }
}
