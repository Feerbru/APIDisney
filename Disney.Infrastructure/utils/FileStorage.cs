using System;
using System.IO;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;

namespace Disney.Infrastructure.utils
{
    public class FileStorage : IStorage
    {
        private readonly IWebHostEnvironment _webEnvironment;
        private readonly IHttpContextAccessor _httpContext;

        public FileStorage(IWebHostEnvironment webHostEnvironment, IHttpContextAccessor contextAccessor)
        {
            _webEnvironment = webHostEnvironment;
            _httpContext = contextAccessor;
        }
        
        public async Task<string> ToCreate(byte[] file, string contentType, string extend, string container, string name)
        {
            var wwwrootPath = _webEnvironment.WebRootPath;

            if (string.IsNullOrEmpty(wwwrootPath))
            {
                throw new Exception();
            }

            var fileDirectory = Path.Combine(wwwrootPath, container);
            if (!Directory.Exists(fileDirectory))
            {
                Directory.CreateDirectory(fileDirectory);
            }

            var endName = $"{name}{extend}";
            var endRoute = Path.Combine(fileDirectory, endName);

            await File.WriteAllBytesAsync(endRoute, file);

            var currentUrl = $"{_httpContext.HttpContext.Request.Scheme}://{_httpContext.HttpContext.Request.Host}";
            var dbUrl = Path.Combine(currentUrl, container, endName).Replace("\\", "/");
            return dbUrl;
        }

        public Task Delete(string route, string container)
        {
            
            var wwwrootPath = _webEnvironment.WebRootPath;

            if (string.IsNullOrEmpty(wwwrootPath))
            {
                throw new Exception();
            }

            var fileName = Path.GetFileName(route);
            var endPath = Path.Combine(wwwrootPath, container, fileName);

            if (File.Exists(endPath))
            {
                File.Delete(endPath);
            }

            return Task.CompletedTask;
        }
    }
}