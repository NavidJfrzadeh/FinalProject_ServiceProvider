using Microsoft.AspNetCore.Http;
namespace App.Domain.Core._3_BaseServices;

public static class SaveFileExtension
{
    public static string SaveFileAsync(this IFormFile file)
    {
        if (file != null && file.Length > 0)
        {
            var filePath = Path.Combine(Directory.GetCurrentDirectory(), "wwwroot\\UploadImages", file.FileName);
            using (var stream = new FileStream(filePath, FileMode.Create))
            {
                file.CopyToAsync(stream);
            }
            var imageAddress = $"\\UploadImages\\{file.FileName}";
            return imageAddress;
        }

        return null;
    }
}
