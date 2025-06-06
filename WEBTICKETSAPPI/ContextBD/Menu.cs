using System;
using System.Collections.Generic;

namespace WEBTICKETSAPPI.ContextBD;

public partial class Menu
{
    public ulong NIdMenu { get; set; }

    public string SNombre { get; set; } = null!;

    public string SAcceso { get; set; } = null!;

    public int ORol { get; set; }

    public virtual ICollection<MenuRol> MenuRols { get; set; } = new List<MenuRol>();

    public virtual Rol ORolNavigation { get; set; } = null!;
}
