using GmfApi.Models.Entities;

namespace GmfView.Service
{
    public interface IFuncionarioObraService
    {
        Task<FuncionarioObra> AddFuncionarioObra(FuncionarioObra funcionarioObra);
    }
}
