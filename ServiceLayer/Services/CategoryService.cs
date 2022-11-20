using AutoMapper;
using DomainLayer.Entities;
using RepositoryLayer.Repositories;
using RepositoryLayer.Repositories.Interfaces;
using ServiceLayer.DTOs.Book;
using ServiceLayer.DTOs.Category;
using ServiceLayer.DTOs.Product;
using ServiceLayer.Services.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ServiceLayer.Services
{
    public class CategoryService : ICategoryService
    {

        private readonly ICategoryRepository _repo;
        private readonly IMapper _mapper;
        public CategoryService(ICategoryRepository repo, IMapper mapper)
        {
            _repo = repo;
            _mapper = mapper;
        }

        public async Task CreateAsync(CategoryCreateDTO category)
        {
            await _repo.Create(_mapper.Map<Category>(category));
        }

        public async Task DeleteAsync(int id)
        {
            Category category = await _repo.Get(id);
            await _repo.Delete(category);
        }

        public async Task<List<CategoryListDTO>> GetAllAsync()
        {
            return _mapper.Map<List<CategoryListDTO>>(await _repo.GetAll());
        }

        public async Task<CategoryFindDTO> GetByIdAsync(int id)
        {
            return _mapper.Map<CategoryFindDTO>(await _repo.Get(id));
        }

        public async Task<List<CategoryListDTO>> SearchAsync(string? serachText)
        {
            List<Category> searchDatas = new();

            if (serachText != null)
            {
                searchDatas = await _repo.FindAllByExpressionAsync(m => m.Name.Contains(serachText));
            }
            else
            {
                searchDatas = await _repo.GetAll();
            }

            return _mapper.Map<List<CategoryListDTO>>(searchDatas);
        }

        public async Task SoftDeleteAsync(int id)
        {
            Category category = await _repo.Get(id);

            await _repo.SoftDelete(category);
        }

        public async Task UpdateAsync(int id, CategoryUpdateDTO category)
        {
            var dbcategory = await _repo.Get(id);

            _mapper.Map(category, dbcategory);

            await _repo.Update(dbcategory);
        }

     
    }
}
