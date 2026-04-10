namespace CopilotDemo.Models
{
    public static class UserRepository
    {
        // Sample user data
        private static readonly Dictionary<int, User> Users = new()
        {
            { 1, new User { Id = 1, Name = "Amit", Email = "amit@example.com" } },
            { 2, new User { Id = 2, Name = "Rahul", Email = "rahul@example.com" } },
            { 3, new User { Id = 3, Name = "Jane Smith", Email = "jane.smith@example.com" } },
            { 4, new User { Id = 4, Name = "Bob Wilson", Email = "bob.wilson@company.com" } },
            { 5, new User { Id = 5, Name = "Alice Johnson", Email = "alice.johnson@company.com" } }
        };

        /// <summary>
        /// Get user by ID
        /// </summary>
        /// <param name="id">User ID (1-5)</param>
        /// <returns>User object if found, null otherwise</returns>
        public static User? GetUserById(int id)
        {
            if (id <= 0)
                return null;

            return Users.TryGetValue(id, out var user) ? user : null;
        }

        /// <summary>
        /// Get all users
        /// </summary>
        /// <returns>List of all users</returns>
        public static List<User> GetAllUsers()
        {
            return Users.Values.ToList();
        }
    }
}
