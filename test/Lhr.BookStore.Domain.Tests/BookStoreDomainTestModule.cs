using Lhr.BookStore.EntityFrameworkCore;
using Volo.Abp.Modularity;

namespace Lhr.BookStore
{
    [DependsOn(
        typeof(BookStoreEntityFrameworkCoreTestModule)
        )]
    public class BookStoreDomainTestModule : AbpModule
    {

    }
}