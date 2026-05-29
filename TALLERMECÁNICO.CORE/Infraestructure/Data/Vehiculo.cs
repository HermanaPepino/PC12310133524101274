using System;
using System.Collections.Generic;

namespace TALLERMECÁNICO.CORE.Infraestructure.Data;

public partial class Vehiculo
{
    public int Id { get; set; }

    public string Placa { get; set; } = null!;

    public string? Marca { get; set; }

    public string? Modelo { get; set; }

    public int? Anio { get; set; }

    public int ClienteId { get; set; }

    public virtual Cliente Cliente { get; set; } = null!;

    public virtual ICollection<OrdenServicio> OrdenServicio { get; set; } = new List<OrdenServicio>();
}
