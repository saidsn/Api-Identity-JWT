using ServiceLayer.DTOs.Book;
using ServiceLayer.DTOs.Product;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ServiceLayer.Services.Interfaces
{
    public interface IBookService
    {
        Task CreateAsync(BookCreateDTO book);
        Task<List<BookListDTO>> GetAllAsync();
        Task DeleteAsync(int id);
        Task SoftDeleteAsync(int id);
        Task UpdateAsync(int id, BookUpdateDTO book);
        Task<List<BookListDTO>> SearchAsync(string? serachText);
        Task<BookFindDTO> GetByIdAsync(int id);
    }
}
