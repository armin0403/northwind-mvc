using Microsoft.AspNetCore.Http;

namespace NorthwindMVC.Services.Services;

public class PhotoService : IPhotoService
{

    public async Task<string> AddPhotoAsync<TEntity>(IFormFile photo, TEntity entity, string folderPath) where TEntity : class
    {
        if (photo == null || photo.Length == 0)
            throw new ArgumentException("Invalid photo file");

        string rootPath = Directory.GetCurrentDirectory();
        string uploadFolder = Path.Combine(rootPath, "wwwroot", folderPath);

        if (!Directory.Exists(uploadFolder))
        {
            Directory.CreateDirectory(uploadFolder);
        }

        string uniqueFileName = Guid.NewGuid().ToString() + Path.GetExtension(photo.FileName);
        string filePath = Path.Combine(uploadFolder, uniqueFileName);

        using (var fileStream = new FileStream(filePath, FileMode.Create))
        {
            await photo.CopyToAsync(fileStream);
        }

        string relativePath = $"/{folderPath.Replace("\\", "/")}/{uniqueFileName}";

        var photoPathProperty = entity.GetType().GetProperty("PhotoPath");
        if (photoPathProperty != null)
        {
            photoPathProperty.SetValue(entity, relativePath);
        }
        else
        {
            throw new InvalidOperationException($"The entity of type {typeof(TEntity).Name} does not contain a 'PhotoPath' property.");
        }

        return relativePath;
    }

    public async Task<bool> CheckPhotoAsync(string photoPath)
    {
        if (string.IsNullOrEmpty(photoPath))
        {
            return false;
        }

        string rootPath = Directory.GetCurrentDirectory();
        string fullPath = Path.Combine(rootPath, "wwwroot", photoPath.TrimStart('/'));
        return File.Exists(fullPath);

    }

    public async Task DeletePhotoAsync(string photoPath)
    {
        if (string.IsNullOrEmpty(photoPath))
            return;

        string rootPath = Directory.GetCurrentDirectory();
        string fullPath = Path.Combine(rootPath, "wwwroot", photoPath.TrimStart('/'));

        if (File.Exists(fullPath))
        {
            await Task.Run(() => File.Delete(fullPath));
        }
    }

}
