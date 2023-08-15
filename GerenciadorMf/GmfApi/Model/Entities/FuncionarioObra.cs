namespace GmfApi.Models.Entities
{
    public class FuncionarioObra
    {
        public int Id { get; set; }
        public Funcionario Funcionario { get; set; }
        public int FuncionarioId { get; set; }
        public Obra Obra { get; set; }
        public int ObraId { get; set; }
        public DateTime DtInicio { get; set; }
        public DateTime DtFim { get; set; }


    }
}
