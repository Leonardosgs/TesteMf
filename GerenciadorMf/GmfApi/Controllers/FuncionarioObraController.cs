using GmfApi.Models.Entities;
using GmfApi.Models.Repository.Interfaces;
using Microsoft.AspNetCore.Mvc;


namespace GmfApi.Controllers
{
    [Route("[controller]")]
    [ApiController]
    public class FuncionarioObraController : ControllerBase
    {
        private readonly IFuncionarioObrasRepository _fObrasRepository;

        public FuncionarioObraController(IFuncionarioObrasRepository fObrasRepository)
        {
            _fObrasRepository = fObrasRepository;
        }

        [HttpPost]
        public async Task<IActionResult> Post(FuncionarioObra novoFuncionarioObra)
        {
            var fo = await _fObrasRepository.AddFuncionarioObra(novoFuncionarioObra);
            if(fo.Funcionario == null)
            {
                return NotFound("Funcionario não encontrado");
            }
            if (fo.Obra == null)
            {
                return NotFound("Obra nao encontrada");
            }
            return Ok(fo);
        }

    }
}
