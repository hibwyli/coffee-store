using System;
using System.Collections.Generic;
using System.Text;

namespace CoffeeServer.Models
{
    public static class SessionInfo
    {
        // Current logged-in username
        public static string Username { get; set; } = string.Empty;

        // User role
        public static string Role { get; set; } = string.Empty;

        // Authentication token
        public static string Token { get; set; } = string.Empty;

        // A helper to check if a user is logged in
        public static bool IsLoggedIn => !string.IsNullOrEmpty(Username);

        // Clear session (logout)
        public static void Clear()
        {
            Username = string.Empty;
            Role = string.Empty;
            Token = string.Empty;
        }
    }

}
