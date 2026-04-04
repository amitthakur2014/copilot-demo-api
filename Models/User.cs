using System.ComponentModel.DataAnnotations;

namespace CopilotDemo.Models
{
    public class User
    {
        public int Id { get; set; }
        
        public string Name { get; set; } = string.Empty;
        
        [EmailAddress(ErrorMessage = "Email format is invalid")]
        public string Email { get; set; } = string.Empty;
        
        /// <summary>
        /// Validates the user's email format using regex pattern matching
        /// </summary>
        /// <returns>True if email is valid, false otherwise</returns>
        public bool IsEmailValid()
        {
            // Regex pattern for email validation
            const string emailPattern = @"^[a-zA-Z0-9._%+-]+@[a-zA-Z0-9.-]+\.[a-zA-Z]{2,}$";
            return System.Text.RegularExpressions.Regex.IsMatch(Email, emailPattern);
        }
    }
}
