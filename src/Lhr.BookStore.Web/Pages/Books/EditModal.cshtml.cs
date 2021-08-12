using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Lhr.BookStore.Books;
using Lhr.BookStore.Books.Dto;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace Lhr.BookStore.Web.Pages.Books
{
    public class EditModalModel : BookStorePageModel
    {
        [HiddenInput]
        [BindProperty(SupportsGet = true)]      /*从http请求的查询字符串中获取id的值*/
        public Guid Id { get; set; }

        [BindProperty]
        public CreateUpdateBookDto Book { get; set; }

        private readonly IBookAppService _bookAppService;

        public EditModalModel(IBookAppService bookAppService)
        {
            _bookAppService = bookAppService;
        }

        public async Task OnGetAsync()
        {
            var bookDto = await _bookAppService.GetAsync(Id);
            Book = ObjectMapper.Map<BookDto, CreateUpdateBookDto>(bookDto);   /*将 BookAppService.GetAsync 方法返回的 BookDto 映射成 CreateUpdateBookDto 并赋值给Book属性*/
        }

        public async Task<IActionResult> OnPostAsync()
        {
            await _bookAppService.UpdateAsync(Id, Book);    /*PostAsync 方法直接使用 BookAppService.UpdateAsync 来更新实体.*/
            return NoContent();
        }
    }
}
