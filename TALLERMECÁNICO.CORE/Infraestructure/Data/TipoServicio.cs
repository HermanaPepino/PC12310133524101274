using System;
using System.Collections.Generic;

namespace TALLERMECÁNICO.CORE.Infraestructure.Data;

public partial class TipoServicio
{
    public int Id { get; set; }

    public string Nombre { get; set; } = null!;

    public decimal PrecioBase { get; set; }

    public virtual ICollection<OrdenServicio> OrdenServicio { get; set; } = new List<OrdenServicio>();
}
