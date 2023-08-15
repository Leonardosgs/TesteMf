using GmfApi.Models.Data;
using GmfApi.Models.Entities;

namespace GmfView.Service
{
    public class FuncionarioObraService : IFuncionarioObraService
    {
        private readonly IFuncionarioService _funcionarioService;
        private readonly HttpClient _httpClient;

        public FuncionarioObraService(HttpClient httpClient, IFuncionarioService funcionarioService)
        {
            _httpClient = httpClient;
            _funcionarioService = funcionarioService;
        }

        public async Task<FuncionarioObra> AddFuncionarioObra(FuncionarioObra funcionarioObra)
        {
            if(funcionarioObra != null)
            {

                List<Obra> Lista = new List<Obra>()
                {
                        new Obra(){ Id = 1, Nome = "Residencial Vale Verde"},
                        new Obra(){ Id = 2, Nome = "Campina Nova"},
                        new Obra(){ Id = 3, Nome = "Plaza Shopping"},
                        new Obra(){ Id = 4, Nome = "Residencial Meridien"},
                        new Obra(){ Id = 5, Nome = "Albuquerque Buildings"},
                        new Obra(){ Id = 6, Nome = "Garden Park"}
                };
                Obra o = Lista.FirstOrDefault(x => x.Id == funcionarioObra.ObraId);
                funcionarioObra.Obra = o;

                IEnumerable<Funcionario> fLista = await _funcionarioService.GetFuncionarios();
                Funcionario f = fLista.FirstOrDefault(x => x.Id == funcionarioObra.FuncionarioId);
                funcionarioObra.Funcionario = f;

                var response = await _httpClient.PostAsJsonAsync<FuncionarioObra>("FuncionarioObra", funcionarioObra);
                var content = await response.Content.ReadFromJsonAsync<FuncionarioObra>();
                return content;

            }
            return funcionarioObra;
               
        }
    }
}
