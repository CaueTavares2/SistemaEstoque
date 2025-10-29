// Arquivo: UserSession.cs (Na pasta Classes)

using System;

namespace SistemaEstoque.Classes
{
    // A classe deve ser estática para armazenar os dados do usuário
    public static class UserSession
    {
        public static int IdUsuario { get; set; }

        // CORREÇÃO CRÍTICA: Adiciona a propriedade Login
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