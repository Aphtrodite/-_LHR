using AutoMapper;
using Lhr.BookStore.Books.Dto;

namespace Lhr.BookStore.Web
{
    public class BookStoreWebAutoMapperProfile : Profile
    {
        public BookStoreWebAutoMapperProfile()
        {
            //Define your AutoMapper configuration here for the Web project.

            CreateMap<BookDto, CreateUpdateBookDto>();
        }
    }
}
