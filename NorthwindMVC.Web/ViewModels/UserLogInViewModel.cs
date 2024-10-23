using System.Text.Json.Serialization;

namespace NorthwindMVC.Web.ViewModels
{
    public class UserLogInViewModel
    {
        public string UsernameOrEmail { get; set; }
        [JsonIgnore]
        public string Password { get; set; }
    }
}
