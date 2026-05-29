using TALLERMECÁNICO.CORE.Core.Entities;

namespace TALLERMECÁNICO.CORE.Core.Interfaces
{
    public interface IOrdenServicioRepository
    {
        Task CreateOrdenServicio(OrdenServicio ordenServicio);
        Task DeleteOrdenServicio(int id);
        Task<IEnumerable<OrdenServicio>> GetOrdenesServicio();
        Task<OrdenServicio> GetOrdenServicioById(int id);
        Task UpdateOrdenServicio(OrdenServicio ordenServicio);
    }
}