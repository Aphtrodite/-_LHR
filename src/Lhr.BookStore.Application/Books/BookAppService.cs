using Lhr.BookStore.Books.Dto;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Volo.Abp.Application.Dtos;
using Volo.Abp.Application.Services;
using Volo.Abp.Domain.Repositories;

namespace Lhr.BookStore.Books
{
    /// <summary>
    /// 继承于CrudAppService,实现了ICrudAppService中定义的CRUD(增删查改)
    /// </summary>
    public class BookAppService: CrudAppService<Book,BookDto,Guid, PagedAndSortedResultRequestDto, CreateUpdateBookDto>,IBookAppService
    {
        /// <summary>
        /// Book实体的默认仓储
        /// </summary>
        /// <param name="repository"></param>
        public BookAppService(IRepository<Book, Guid> repository) : base(repository)
        { 

        }
    }
}
