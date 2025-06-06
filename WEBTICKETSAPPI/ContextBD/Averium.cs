using System;
using System.Collections.Generic;

namespace WEBTICKETSAPPI.ContextBD;

public partial class Averium
{
    public ulong NIdAveria { get; set; }

    public string SCodOperacion { get; set; } = null!;

    public ulong OCliente { get; set; }

    public ulong OProducto { get; set; }

    public ulong OUsuario { get; set; }

    public DateOnly DRangoAtencion { get; set; }

    public string SReferencia { get; set; } = null!;

    public string SContacto { get; set; } = null!;

    public string STelefono { get; set; } = null!;

    public string SCorreo { get; set; } = null!;

    public virtual ICollection<Atencion> Atencions { get; set; } = new List<Atencion>();

    public virtual Cliente OClienteNavigation { get; set; } = null!;

    public virtual Producto OProductoNavigation { get; set; } = null!;

    public virtual Usuario OUsuarioNavigation { get; set; } = null!;
}
