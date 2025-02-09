using Microsoft.EntityFrameworkCore;
using NorthwindMVC.Core.Models;
using NorthwindMVC.Core.Pagination;
using NorthwindMVC.Infrastructure.UnitOfWork;

namespace NorthwindMVC.Services.Services
{
	public class ProductService : IProductService
	{
		private readonly IUnitOfWork UnitOfWork;
		private readonly IPaginationService _paginationService;

		public ProductService(IUnitOfWork unitOfWork,
						      IPaginationService paginationService) 
		{
			this.UnitOfWork = unitOfWork;
			_paginationService = paginationService;
		}

		public async Task<bool> Add(Product product)
		{
			await UnitOfWork.ProductRepository.AddAsync(product);
			await UnitOfWork.SaveChangesAsync();
			return true;
		}

		public async Task<bool> Delete(Product product)
		{
			await UnitOfWork.ProductRepository.DeleteAsync(product);
			await UnitOfWork.SaveChangesAsync();
			return true;

		}

		public Task<Product> GetByIdAsync(int id)
		{
			return UnitOfWork.ProductRepository.GetByIdAsync(id);
		}

		public async Task<PagedList<Product>> GetPagedProducts(int pageNumber, int pageSize, string searchTerm, int? categoryId)
		{
			string? normalizedSearchTerm = searchTerm?.ToLower();
			var query = UnitOfWork.ProductRepository
				.Find(p =>
					string.IsNullOrEmpty(normalizedSearchTerm) ||
					p.ProductName.ToLower().Contains(normalizedSearchTerm));

			if (categoryId.HasValue)
			{
				query = query.Where(p => p.CategoryId == categoryId.Value);
			}

			var pagedProducts = _paginationService.CreatePagedList(query,pageNumber,pageSize);
			return pagedProducts;
		}

		public async Task<bool> Update(Product product)
		{
			await UnitOfWork.ProductRepository.UpdateAsync(product);
			await UnitOfWork.SaveChangesAsync();
			return true;
		}
	}
}
