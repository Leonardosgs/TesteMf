using GmfApi.Models.Entities;

namespace GmfView.Service
{
    public class FuncionarioService : IFuncionarioService
    {
        private readonly HttpClient _httpClient;
        private IEnumerable<Funcionario> _functions;

        public FuncionarioService(HttpClient httpClient)
        {
            _httpClient = httpClient;
        }

        public async Task<Funcionario> AddFuncionario(Funcionario funcionario)
        {
            Cargo[]Lista = new Cargo[5]
            {  
                   new Cargo(){ Id = 1, Nome = "Engenheiro"},
                   new Cargo(){ Id = 2, Nome = "Pedreiro"},
                   new Cargo(){ Id = 3, Nome = "Servente"},
                   new Cargo(){ Id = 4, Nome = "Encarregado de Obra"},
                   new Cargo(){ Id = 5, Nome = "Eletricista"}
            };
            Cargo c = Lista.FirstOrDefault(x => x.Id == funcionario.CargoId);
            funcionario.Cargo = c;

            var response = await _httpClient.PostAsJsonAsync<Funcionario>("Funcionarios", funcionario);
            var message = await response.Content.ReadFromJsonAsync<Funcionario>();
            return message;
        }


        public async Task<IEnumerable<Funcionario>> GetFuncionarios()
        {
            var funcionarios = await _httpClient.GetFromJsonAsync<IEnumerable<Funcionario>>("Funcionarios");
            _functions = funcionarios;
            return funcionarios;
        }
    }
}

