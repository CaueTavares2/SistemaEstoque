namespace SistemaEstoque.Classes
{
    public static class UserSession
    {
        public static int IdUsuario { get; set; }
        public static string Login { get; set; }
        public static string NivelAcesso { get; set; }

        public static void ClearSession()
        {
            IdUsuario = 0;
            Login = null;
            NivelAcesso = null;
        }
    }
}