using System;
using System.Collections.Generic;

namespace WEBTICKETSAPPI.ContextBD;

public partial class Atencion
{
    public ulong NIdAtencion { get; set; }

    public ulong OAveria { get; set; }

    public ulong OTipoSol { get; set; }

    public bool BSolEnLinea { get; set; }

    public virtual Averium OAveriaNavigation { get; set; } = null!;

    public virtual Tiposolucion OTipoSolNavigation { get; set; } = null!;
}
