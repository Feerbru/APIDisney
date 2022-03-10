using System.Threading.Tasks;

namespace Disney.Infrastructure.utils
{
    public interface IStorage
    {
        Task<string> ToCreate(byte[] file, string contentType, string extend, string container, string name);

        Task Delete(string route, string container);
    }
}