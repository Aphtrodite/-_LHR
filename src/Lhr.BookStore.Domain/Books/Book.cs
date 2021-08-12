using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Volo.Abp.Domain.Entities.Auditing;

namespace Lhr.BookStore.Books
{
    public class Book : AuditedAggregateRoot<Guid>
    {
        /// <summary>
        /// 书名
        /// </summary>
        public string Name { get; set; }
        /// <summary>
        /// 类型
        /// </summary>
        public BookType Type { get; set; }
        /// <summary>
        /// 出版时间
        /// </summary>
        public DateTime PublishDate { get; set; }
        /// <summary>
        /// 价格
        /// </summary>
        public float Price { get; set; }
    }
}
