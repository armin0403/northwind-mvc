namespace NorthwindMVC.Core.Models
{
    public class Category
    {
        public int Id {  get; set; }
        public string CategoryName { get; set; }
        public string Description { get; set; }
        public string PhotoPath { get; set; }

        ICollection<Product> Products { get; set; }
    }
}
