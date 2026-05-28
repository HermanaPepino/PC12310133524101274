using System;
using System.Collections.Generic;
using System.Text;


namespace TALLERMECÁNICO.CORE.Core.DTOs
{
    public class TipoServicioDTO
    {
        public int Id { get; set; }
        public string Nombre { get; set; }
        public string Descripcion { get; set; }
        public decimal Precio { get; set; }
    }
    public class TipoServicioListDTO
    {
        public int Id { get; set; }
        public string Nombre { get; set; }
        public string Descripcion { get; set; }
        public decimal Precio { get; set; }
    }
    public class TipoServicioCreateDTO
    {
        public string Nombre { get; set; }
        public string Descripcion { get; set; }
        public decimal Precio { get; set; } = 0;
    }
    public class TipoServicioUpdateDTO
    {
        public int Id { get; set; }
        public string Nombre { get; set; }
        public string Descripcion { get; set; }
        public decimal Precio { get; set; } = 0;
    }
    public class TipoServicioDeleteDTO
    {
        public int Id { get; set; }
    }


    }
