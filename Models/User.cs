using System.ComponentModel.DataAnnotations;
using System.Text.RegularExpressions;

namespace CopilotDemo.Models
{
    public class User
    {
        public int Id { get; set; }
        public string Name { get; set; } = string.Empty;
        public string Email { get; set; } = string.Empty;

        /// <summary>
        /// Validates the email format using regex pattern
        /// </summary>
        /// <returns>True if email is valid, false otherwise</returns>
        public bool IsEmailValid()
        {
            if (string.IsNullOrWhiteSpace(Email))
                return false;

            // Email regex pattern
            string emailPattern = @"^[a-zA-Z0-9._%+-]+@[a-zA-Z0-9.-]+\.[a-zA-Z]{2,}$";
            return Regex.IsMatch(Email, emailPattern);
        }
    }
}
