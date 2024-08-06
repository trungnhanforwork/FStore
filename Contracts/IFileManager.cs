using Microsoft.AspNetCore.Http;

namespace Service.Contracts;

public interface IFileManager
{
    Task<string> SaveFileAsync(IFormFile file);
    Task DeleteFileAsync(string filePath);
}