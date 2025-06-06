using System;
using System.Collections.Generic;

namespace WEBTICKETSAPPI.ContextBD;

public partial class Cliente
{
    public ulong NIdCliente { get; set; }

    public string STipoDoc { get; set; } = null!;

    public string SNumDoc { get; set; } = null!;

    public string SNombres { get; set; } = null!;

    public string SApellPaterno { get; set; } = null!;

    public string SApellMaterno { get; set; } = null!;

    public string STelefono { get; set; } = null!;

    public string SCorreo { get; set; } = null!;

    public string? SDireccion { get; set; }

    public ulong? OIdUsuario { get; set; }

    public virtual ICollection<Averium> Averia { get; set; } = new List<Averium>();

    public virtual Usuario? OIdUsuarioNavigation { get; set; }
}
