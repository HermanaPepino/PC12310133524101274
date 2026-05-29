using TALLERMECÁNICO.CORE.Core.DTOs;

namespace TALLERMECÁNICO.CORE.Core.Interfaces
{
    public interface IOrdenServicioService
    {
        Task CreateOrdenServicio(OrdenServicioCreateDTO ordenServicioCreateDTO);
        Task DeleteOrdenServicio(OrdenServicioDeleteDTO ordenServicioDeleteDTO);
        Task<IEnumerable<OrdenServicioListDTO>> GetOrdenesServicio();
        Task<OrdenServicioDTO> GetOrdenServicioById(int id);
        Task UpdateOrdenServicio(OrdenServicioUpdateDTO ordenServicioUpdateDTO);
    }
}