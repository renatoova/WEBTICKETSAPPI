using System;
using System.Collections.Generic;

namespace WEBTICKETSAPPI.ContextBD;

public partial class Producto
{
    public ulong NIdProducto { get; set; }

    public string SNombre { get; set; } = null!;

    public string SDescripcion { get; set; } = null!;

    public string SEstado { get; set; } = null!;

    public virtual ICollection<Averium> Averia { get; set; } = new List<Averium>();
}
