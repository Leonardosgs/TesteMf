using GmfApi.Models.Entities;
using GmfApi.Models.Repository.Interfaces;
using Microsoft.AspNetCore.Mvc;


namespace GmfApi.Controllers
{
    [Route("[controller]")]
    [ApiController]
    public class FuncionariosController : ControllerBase
    {
        private readonly IFuncionarioRepository _funcionarioRepository;

        public FuncionariosController(IFuncionarioRepository funcionarioRepository)
        {
            _funcionarioRepository = funcionarioRepository;
        }

        [HttpGet]
        public async Task<ActionResult> GetAll()
        {
            return Ok(await _funcionarioRepository.GetAllFuncionarios());
        }

        [HttpPost]
        public async Task<ActionResult> Post(Funcionario funcionario)
        {
            var novoFucnionario = await _funcionarioRepository.AddFuncionario(funcionario);
            return Ok(novoFucnionario);
        }

    }
}
