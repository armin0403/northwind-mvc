namespace NorthwindMVC.Web.ViewModels
{
    public class CategoryViewModel
    {
        public int Id { get; set; }
        public string CategoryName { get; set; }
        public string Description { get; set; }
        public string PhotoPath { get; set; }
        public IFormFile Photo {  get; set; } 
    }
}
