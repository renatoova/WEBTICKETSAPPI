namespace WEBTICKETSAPPI.DTO
{
    public class UsuarioDTO
    {
        public ulong NIdUsuario { get; set; }

        public string SNombres { get; set; } = null!;

        public string SApellPaterno { get; set; } = null!;

        public string SApellMaterno { get; set; } = null!;

        public int NEstado { get; set; }

        public int ORol { get; set; }

        public string SUsername { get; set; } = null!;

        public string SPassword { get; set; } = null!;
    }
}
