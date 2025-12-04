namespace PeluqueriAPP
{
    public static class Session
    {
        // Token de acceso
        public static string AccessToken { get; set; } = string.Empty;

        // Tipo de token (por ejemplo "Bearer")
        public static string TokenType { get; set; } = string.Empty;

        // ID del usuario logueado (opcional)
        public static long UserId { get; set; } = 0;

        // Nombre de usuario logueado (opcional)
        public static string Username { get; set; } = string.Empty;

        // Verifica si hay sesión iniciada
        public static bool IsLoggedIn => !string.IsNullOrEmpty(AccessToken) && !string.IsNullOrEmpty(TokenType);

        // Método para cerrar sesión
        public static void Logout()
        {
            AccessToken = string.Empty;
            TokenType = string.Empty;
            UserId = 0;
            Username = string.Empty;
        }
    }
}
