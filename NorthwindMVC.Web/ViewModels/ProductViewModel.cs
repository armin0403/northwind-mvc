using Microsoft.AspNetCore.Mvc.Rendering;
using NorthwindMVC.Core.Models;
using NorthwindMVC.Core.Pagination;

namespace NorthwindMVC.Web.ViewModels
{
	public class ProductViewModel
	{
        public int Id { get; set; }
        public string ProductName { get; set; }
        public Supplier Supplier { get; set; }
        public int SupplierId { get; set; }
        public Category Category { get; set; }
        public int CategoryId { get; set; }
        public string QuantityPerUnit { get; set; }
        public float UnitPrice { get; set; }
        public int UnitsInStock { get; set; }
        public int UnitsOnOrder { get; set; }
        public int ReOrderLevel { get; set; }
        public bool Discontinued { get; set; }

        public IEnumerable<SelectListItem> CategoriesDropdown { get; set; }
        public IEnumerable<SelectListItem> SuppliersDropdown { get; set; }
        public PagedList<Product> Products { get; set; }
        public int? SelectedCategoryId { get; set; }
    }
}
