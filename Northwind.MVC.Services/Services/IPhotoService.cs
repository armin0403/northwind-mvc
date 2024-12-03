using Microsoft.AspNetCore.Http;

namespace NorthwindMVC.Services.Services
{
    public interface IPhotoService
    {
        Task AddPhotoAsync<TEntity>(IFormFile photo, TEntity entity, string folderPath) where TEntity : class;
    }
}
