using System.Globalization;

namespace NorthwindMVC.Services
{
    public class LanguageService
    {
        public string GetCurrentLanguage()
        {
            return CultureInfo.CurrentCulture.Name switch
            {
                "en-US" => "English",
                "bs-Latn-BA" => "Bosanski",
                _ => "en-US",
            };
        }
    }
}
