using NorthwindMVC.Core.Models;
using NorthwindMVC.Core.Pagination;
using NorthwindMVC.Infrastructure.UnitOfWork;

namespace NorthwindMVC.Services.Services
{
    public class CategoryService : ICategoryService
    {
        private readonly IUnitOfWork UnitOfWork;
        private readonly IPaginationService _paginationService;
        public CategoryService(IUnitOfWork unitOfWork,
                               IPaginationService paginationService) 
        {
            this.UnitOfWork = unitOfWork;
            _paginationService = paginationService;
        }

        public async Task<bool> Add(Category category)
        {
            await UnitOfWork.CategoryRepository.AddAsync(category);
            await UnitOfWork.SaveChangesAsync();
            return true;
        }

        public async Task<bool> Delete(Category category)
        {
            await UnitOfWork.CategoryRepository.DeleteAsync(category);
            await UnitOfWork.SaveChangesAsync();
            return true;
        }

        public async Task<Category> GetById(int id)
        {
            return await UnitOfWork.CategoryRepository.GetByIdAsync(id);
        }       

        public async Task<PagedList<Category>> GetPagedCategories(int pageNumber, int pageSize, string searchTerm)
        {
            string? normalizedSearchTerm = searchTerm?.ToLower();

            var query = UnitOfWork.CategoryRepository.Find(c =>
            string.IsNullOrEmpty(normalizedSearchTerm) ||
            c.CategoryName.ToLower().Contains(normalizedSearchTerm));

            var pagedCategories = _paginationService.CreatePagedList<Category>(query, pageNumber, pageSize);

            return pagedCategories;

        }

        public async Task<bool> Update(Category category)
        {
            await UnitOfWork.CategoryRepository.UpdateAsync(category);
            await UnitOfWork.SaveChangesAsync();
            return true;
        }
    }
}
