using Dapper;
using System.Collections.Generic;
using System.Data;
using System.Threading.Tasks;
using WebApplication1.Models;
namespace WebApplication1.Services
{
    public interface ILibroService
    {
        Task<IEnumerable<Libro>> GetAllLibrosAsync();
        Task<Libro> GetLibroByIdAsync(int id);
        Task<bool> AddLibroAsync(Libro libro);
        Task<bool> UpdateLibroAsync(Libro libro);
    }
}
