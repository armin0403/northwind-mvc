using Microsoft.AspNetCore.Http;

namespace NorthwindMVC.Services.Services
{
    public interface IPhotoService
    {
        Task<string> AddPhotoAsync<TEntity>(IFormFile photo, TEntity entity, string folderPath) where TEntity : class;
        Task DeletePhotoAsync(string photoPath);
        Task<bool> CheckPhotoAsync (string photoPath);
    }
}
