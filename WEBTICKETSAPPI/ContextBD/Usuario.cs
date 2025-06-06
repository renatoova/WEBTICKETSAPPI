using System;
using System.Collections.Generic;

namespace WEBTICKETSAPPI.ContextBD;

public partial class Usuario
{
    public ulong NIdUsuario { get; set; }

    public string SNombres { get; set; } = null!;

    public string SApellPaterno { get; set; } = null!;

    public string SApellMaterno { get; set; } = null!;

    public int NEstado { get; set; }

    public int ORol { get; set; }

    public string SUsername { get; set; } = null!;

    public string SPassword { get; set; } = null!;

    public virtual ICollection<Averium> Averia { get; set; } = new List<Averium>();

    public virtual ICollection<Cliente> Clientes { get; set; } = new List<Cliente>();

    public virtual Rol ORolNavigation { get; set; } = null!;
}
