using NorthwindMVC.Core.Models;

namespace NorthwindMVC.Core
{
    public class User
    {
        public int Id { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public DateOnly DateOfBirth { get; set; }
        public string Email { get; set; }
        public string Username { get; set; }
        public string Password { get; set; }
        public List<UserRole>? Roles { get; set; }
    }
}