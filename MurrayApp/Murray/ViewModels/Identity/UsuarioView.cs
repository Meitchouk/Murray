namespace Murray.ViewModels.Identity
{
    /// <summary>
    ///     Vista de usuario de sistema
    /// </summary>
    internal class UsuarioView
    {
        public int Id { get; set; }
        public string Username { get; set; }
        public string Role { get; set; }
        public string Nombre { get; set; }
        public int IdContacto { get; set; }
    }
}
