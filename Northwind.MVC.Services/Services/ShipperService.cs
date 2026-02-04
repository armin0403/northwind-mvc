using NorthwindMVC.Core.Models;
using NorthwindMVC.Core.Pagination;
using NorthwindMVC.Infrastructure.UnitOfWork;

namespace NorthwindMVC.Services.Services
{
	public class ShipperService : IShipperService
	{
        private readonly IUnitOfWork UnitOfWork;
        private readonly IPaginationService _paginationService;

        public ShipperService(IUnitOfWork unitOfWork,
							  IPaginationService paginationService) 
		{ 
			this.UnitOfWork = unitOfWork;
			_paginationService = paginationService;
		}

        public async Task<bool> Add(Shipper shipper)
        {
            await UnitOfWork.ShipperRepository.AddAsync(shipper);
            await UnitOfWork.SaveChangesAsync();
            return true;
        }

        public async Task<bool> Delete(Shipper shipper)
        {
            await UnitOfWork.ShipperRepository.DeleteAsync(shipper);
            await UnitOfWork.SaveChangesAsync();
            return true;
        }

        public async Task<PagedList<Shipper>> GetPagedShippers(int pageNumber, int pageSize, string searchTerm)
        {
            string? normalizedSearchTerm = searchTerm?.ToLower();

            var query = UnitOfWork.ShipperRepository.Find(s => 
                string.IsNullOrEmpty(normalizedSearchTerm) ||
                s.CompanyName.ToLower().Contains(normalizedSearchTerm));

            var pagedShippers = _paginationService.CreatePagedList(query, pageNumber, pageSize);

            return pagedShippers;
        }

        public async Task<Shipper> GetShipperById(int id)
        {
            return await UnitOfWork.ShipperRepository.GetByIdAsync(id);
        }

        public async Task<bool> Update(Shipper shipper)
        {
            await UnitOfWork.ShipperRepository.UpdateAsync(shipper);
            await UnitOfWork.SaveChangesAsync();
            return true;
        }
    }
}
