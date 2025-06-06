using System;
using System.Collections.Generic;

namespace WEBTICKETSAPPI.ContextBD;

public partial class Tiposolucion
{
    public ulong NIdTipoSol { get; set; }

    public string SNombre { get; set; } = null!;

    public string SDescripcion { get; set; } = null!;

    public virtual ICollection<Atencion> Atencions { get; set; } = new List<Atencion>();
}
