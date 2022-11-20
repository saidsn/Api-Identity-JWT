using AutoMapper;
using DomainLayer.Entities;
using ServiceLayer.DTOs.Account;
using ServiceLayer.DTOs.Book;
using ServiceLayer.DTOs.Category;
using ServiceLayer.DTOs.Product;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ServiceLayer.Mappings
{
    public class MappingProfile : Profile   
    {
        public MappingProfile()
        {
            CreateMap<ProductCreateDto, Product>();
            CreateMap<Product, ProductListDto>();
            CreateMap<ProductUpdateDto, Product>().ReverseMap();


            CreateMap<BookCreateDTO, Book>();
            CreateMap<Book, BookListDTO>();
            CreateMap<BookUpdateDTO, Book>().ReverseMap();
            CreateMap<Book, BookFindDTO>();

            CreateMap<CategoryCreateDTO, Category>();
            CreateMap<Category, CategoryListDTO>();
            CreateMap<CategoryUpdateDTO, Category>().ReverseMap();
            CreateMap<Category, CategoryFindDTO>();

            CreateMap<RegisterDTO, AppUser>();
          

        }
    }
}
