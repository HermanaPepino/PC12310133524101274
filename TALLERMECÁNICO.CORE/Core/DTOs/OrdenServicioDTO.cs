using System;
using System.Collections.Generic;
using System.Text;

namespace TALLERMECÁNICO.CORE.Core.DTOs
{
    public class OrdenServicioDTO
    {
        public int Id { get; set; }

        public DateTime FechaIngreso { get; set; }

        public string DescripcionProblema { get; set; }

        public decimal? CostoEstimado { get; set; }

        public char? Estado { get; set; }

        public int VehiculoId { get; set; }

        public int TipoServicioId { get; set; }
    }

    public class OrdenServicioListDTO
    {
        public int Id { get; set; }
        public DateTime FechaIngreso { get; set; }
        public string DescripcionProblema { get; set; }
        public decimal? CostoEstimado { get; set; }
        public int VehiculoId { get; set; }
        public int TipoServicioId { get; set; }
    }

    public class OrdenServicioCreateDTO
    {
        public DateTime FechaIngreso { get; set; }
        public string DescripcionProblema { get; set; }
        public decimal? CostoEstimado { get; set; }
    }
    public class OrdenServicioUpdateDTO
    {
        public int Id { get; set; }
        public DateTime FechaIngreso { get; set; }
        public string DescripcionProblema { get; set; }
        public decimal? CostoEstimado { get; set; }
    }
    public class OrdenServicioDeleteDTO
    {
        public int Id { get; set; }
    }
}
