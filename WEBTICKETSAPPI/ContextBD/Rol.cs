using System;
using System.Collections.Generic;

namespace WEBTICKETSAPPI.ContextBD;

public partial class Rol
{
    public int NIdRol { get; set; }

    public string SNombreRol { get; set; } = null!;

    public string SDescripcionRol { get; set; } = null!;

    public virtual ICollection<MenuRol> MenuRols { get; set; } = new List<MenuRol>();

    public virtual ICollection<Menu> Menus { get; set; } = new List<Menu>();

    public virtual ICollection<Usuario> Usuarios { get; set; } = new List<Usuario>();
}
