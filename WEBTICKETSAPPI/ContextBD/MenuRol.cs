using System;
using System.Collections.Generic;

namespace WEBTICKETSAPPI.ContextBD;

public partial class MenuRol
{
    public uint NId { get; set; }

    public ulong? OIdMenu { get; set; }

    public int? OIdRol { get; set; }

    public virtual Menu? OIdMenuNavigation { get; set; }

    public virtual Rol? OIdRolNavigation { get; set; }
}
