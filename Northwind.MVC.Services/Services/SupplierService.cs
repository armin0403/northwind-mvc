using NorthwindMVC.Core.Models;
using NorthwindMVC.Core.Pagination;
using NorthwindMVC.Infrastructure.UnitOfWork;

namespace NorthwindMVC.Services.Services
{
	public class SupplierService : ISupplierService
	{
		private readonly IUnitOfWork UnitOfWork;
		private readonly IPaginationService _paginationService;

		public SupplierService(IUnitOfWork unitOfWork,
							   IPaginationService paginationService) 
		{
			this.UnitOfWork = unitOfWork;
			_paginationService = paginationService;
		}

		public async Task<bool> Add(Supplier supplier)
		{
			await UnitOfWork.SupplierRepository.AddAsync(supplier);
			await UnitOfWork.SaveChangesAsync();
			return true;
		}

		public async Task<bool> Delete(Supplier supplier)
		{
			await UnitOfWork.SupplierRepository.DeleteAsync(supplier);
			await UnitOfWork.SaveChangesAsync();
			return true;
		}

		public async Task<Supplier> GetByIdAsync(int id)
		{
			return await UnitOfWork.SupplierRepository.GetByIdAsync(id);
		}

		public async Task<PagedList<Supplier>> GetPagedSuppliers(int pageNumber, int pageSize, string searchTerm)
		{
			string? normalizedSearchTerm = searchTerm?.ToLower();
			var query = UnitOfWork.SupplierRepository.Find(s =>
				string.IsNullOrWhiteSpace(normalizedSearchTerm)||
				s.CompanyName.ToLower().Contains(normalizedSearchTerm));
			var pagedSuppliers = _paginationService.CreatePagedList(query, pageNumber, pageSize);
			
			return pagedSuppliers;
		}

		public async Task<bool> Update(Supplier supplier)
		{
			await UnitOfWork.SupplierRepository.UpdateAsync(supplier);
			await UnitOfWork.SaveChangesAsync();
			return true;
		}
	}
}
