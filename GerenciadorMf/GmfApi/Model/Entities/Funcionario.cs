namespace GmfApi.Models.Entities
{
    public class Funcionario
    {
        public int Id { get; set; }
        public string Nome { get; set; }
        public DateTime DataNascimento { get; set; }
        public string Rg { get; set; }
        public decimal Salario { get; set; }
        public Cargo Cargo { get; set; }
        public int CargoId { get; set; }



    }
}
