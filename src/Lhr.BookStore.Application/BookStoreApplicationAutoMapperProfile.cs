using AutoMapper;
using Lhr.BookStore.Books;
using Lhr.BookStore.Books.Dto;

namespace Lhr.BookStore
{
    public class BookStoreApplicationAutoMapperProfile : Profile
    {
        public BookStoreApplicationAutoMapperProfile()
        {
            
            CreateMap<Book, BookDto>();     /* 将Book实体转换为BookDto,定义映射*/
            CreateMap<CreateUpdateBookDto, Book>();

        }
    }
}
