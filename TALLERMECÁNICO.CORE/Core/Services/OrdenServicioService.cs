using System.Collections.Generic;
using System.Threading.Tasks;
using TALLERMECÁNICO.CORE.Core.DTOs;
using TALLERMECÁNICO.CORE.Core.Entities;
using TALLERMECÁNICO.CORE.Core.Interfaces;

namespace TALLERMECÁNICO.CORE.Core.Services
{
    public class OrdenServicioService : IOrdenServicioService
    {
        private readonly IOrdenServicioRepository _ordenServicioRepository;

        public OrdenServicioService(IOrdenServicioRepository ordenServicioRepository)
        {
            _ordenServicioRepository = ordenServicioRepository;
        }

        // GET ALL
        public async Task<IEnumerable<OrdenServicioListDTO>> GetOrdenesServicio()
        {
            var ordenes = await _ordenServicioRepository.GetOrdenesServicio();

            var ordenesDTO = new List<OrdenServicioListDTO>();

            foreach (var orden in ordenes)
            {
                var ordenDTO = new OrdenServicioListDTO
                {
                    Id = orden.Id,
                    FechaIngreso = orden.FechaIngreso,
                    DescripcionProblema = orden.DescripcionProblema,
                    CostoEstimado = orden.CostoEstimado,
                    VehiculoId = orden.VehiculoId,
                    TipoServicioId = orden.TipoServicioId
                };

                ordenesDTO.Add(ordenDTO);
            }

            return ordenesDTO;
        }

        // GET BY ID
        public async Task<OrdenServicioDTO> GetOrdenServicioById(int id)
        {
            var orden = await _ordenServicioRepository.GetOrdenServicioById(id);

            if (orden == null)
            {
                return null;
            }

            var ordenDTO = new OrdenServicioDTO
            {
                Id = orden.Id,
                FechaIngreso = orden.FechaIngreso,
                DescripcionProblema = orden.DescripcionProblema,
                CostoEstimado = orden.CostoEstimado,
                Estado = orden.Estado,
                VehiculoId = orden.VehiculoId,
                TipoServicioId = orden.TipoServicioId
            };

            return ordenDTO;
        }

        // CREATE
        public async Task CreateOrdenServicio(OrdenServicioCreateDTO ordenServicioCreateDTO)
        {
            var ordenServicio = new OrdenServicio
            {
                FechaIngreso = ordenServicioCreateDTO.FechaIngreso,
                DescripcionProblema = ordenServicioCreateDTO.DescripcionProblema,
                CostoEstimado = ordenServicioCreateDTO.CostoEstimado,
                Estado = "P"
            };

            await _ordenServicioRepository.CreateOrdenServicio(ordenServicio);
        }

        // UPDATE
        public async Task UpdateOrdenServicio(OrdenServicioUpdateDTO ordenServicioUpdateDTO)
        {
            var existingOrden = await _ordenServicioRepository
                .GetOrdenServicioById(ordenServicioUpdateDTO.Id);

            if (existingOrden != null)
            {
                existingOrden.FechaIngreso = ordenServicioUpdateDTO.FechaIngreso;
                existingOrden.DescripcionProblema = ordenServicioUpdateDTO.DescripcionProblema;
                existingOrden.CostoEstimado = ordenServicioUpdateDTO.CostoEstimado;

                await _ordenServicioRepository.UpdateOrdenServicio(existingOrden);
            }
        }

        // DELETE
        public async Task DeleteOrdenServicio(OrdenServicioDeleteDTO ordenServicioDeleteDTO)
        {
            await _ordenServicioRepository.DeleteOrdenServicio(ordenServicioDeleteDTO.Id);
        }
    }
}
