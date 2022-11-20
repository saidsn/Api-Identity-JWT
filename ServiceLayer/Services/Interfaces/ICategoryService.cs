using ServiceLayer.DTOs.Category;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ServiceLayer.Services.Interfaces
{
    public interface ICategoryService
    {
        Task CreateAsync(CategoryCreateDTO category);
        Task<List<CategoryListDTO>> GetAllAsync();
        Task DeleteAsync(int id);
        Task SoftDeleteAsync(int id);
        Task UpdateAsync(int id, CategoryUpdateDTO category);
        Task<List<CategoryListDTO>> SearchAsync(string? serachText);
        Task<CategoryFindDTO> GetByIdAsync(int id);
    }
}
