using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.Hosting;
using Service.Contracts;

namespace Services;

public sealed class FileManager : IFileManager
{
    private readonly IHostEnvironment _environment;

    public FileManager (IHostEnvironment environment)
    {
        _environment = environment;
    }

    public async Task<string> SaveFileAsync(IFormFile file)
    {
        if (file == null || file.Length == 0)
            throw new ArgumentException("File is null or empty", nameof(file));
        
        var uploadDir = Path.Combine(_environment.ContentRootPath, "wwwroot", "uploads");
        
        if (!Directory.Exists(uploadDir))
            Directory.CreateDirectory(uploadDir);
        
        var uniqueFileName = Guid.NewGuid().ToString() + "_" + file.FileName;
        var filePath = Path.Combine(uploadDir, uniqueFileName);
        await using var fileStream = new FileStream(filePath, FileMode.Create);
        await file.CopyToAsync(fileStream);
        return filePath;
    }

    public async Task DeleteFileAsync(string filePath)
    {
        if (File.Exists(filePath))
        {
            await Task.Run(() => File.Delete(filePath));
        }
    }
}