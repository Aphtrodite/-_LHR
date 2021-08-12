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
        [BindProperty(SupportsGet = true)]      /*��http����Ĳ�ѯ�ַ����л�ȡid��ֵ*/
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
            Book = ObjectMapper.Map<BookDto, CreateUpdateBookDto>(bookDto);   /*�� BookAppService.GetAsync �������ص� BookDto ӳ��� CreateUpdateBookDto ����ֵ��Book����*/
        }

        public async Task<IActionResult> OnPostAsync()
        {
            await _bookAppService.UpdateAsync(Id, Book);    /*PostAsync ����ֱ��ʹ�� BookAppService.UpdateAsync ������ʵ��.*/
            return NoContent();
        }
    }
}
