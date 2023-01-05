using BAckendApi.Models;

namespace BAckendApi.Services.Contrato
{
    public interface IDepartamentoService

    {
        Task<List<Departamento>> GetList();
    }
}
