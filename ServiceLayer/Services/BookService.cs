using AutoMapper;
using DomainLayer.Entities;
using RepositoryLayer.Repositories.Interfaces;
using ServiceLayer.DTOs.Book;
using ServiceLayer.Services.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ServiceLayer.Services
{
    public class BookService : IBookService
    {
        private readonly IBookRepository _repository;
        private readonly IMapper _mapper;
        public BookService(IBookRepository repository, IMapper mapper)
        {
            _repository = repository;
            _mapper = mapper;
        }

        public async Task CreateAsync(BookCreateDTO book)
        {
            await _repository.Create(_mapper.Map<Book>(book));
        }

        public async Task DeleteAsync(int id)
        {
            Book book = await _repository.Get(id);
            await _repository.Delete(book);
        }

        public async Task<List<BookListDTO>> GetAllAsync()
        {
            return _mapper.Map<List<BookListDTO>>(await _repository.GetAll());
        }

        public async Task<List<BookListDTO>> SearchAsync(string? serachText)
        {
            List<Book> searchDatas = new();

            if(serachText != null)
            {
                searchDatas = await _repository.FindAllByExpressionAsync(m=>m.Name.Contains(serachText));
            }
            else
            {
                searchDatas = await _repository.GetAll();   
            }
            return _mapper.Map<List<BookListDTO>> (searchDatas);

        }

        public async Task SoftDeleteAsync(int id)
        {
            Book book = await _repository.Get(id);
            await _repository.SoftDelete(book);
        }

        public async Task UpdateAsync(int id, BookUpdateDTO book)
        {
            var dbBook = await _repository.Get(id);

            _mapper.Map(book, dbBook);

            await _repository.Update(dbBook);

        }

        public async Task<BookFindDTO> GetByIdAsync(int id)
        {
            return _mapper.Map<BookFindDTO>(await _repository.Get(id));
            
        }

   
    }
}
