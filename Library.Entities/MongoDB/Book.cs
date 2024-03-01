using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Library.Entities.MongoDB
{
    public sealed class Book : IEntity
    {
        public Book()
        {
            this.Authors = new List<Author>();
            this.Publishers = new List<Publisher>();
        }
        public string Id { get; set; }
        public string Name { get; set; }
        public int PageCount { get; set; }
        public List<Author> Authors { get; set; }
        public DateTime CreatedDate { get; set; }
        public DateTime PublishedDate { get; set; }
        public DateTime UpdateDate { get; set; }
        public DateTime DeletedDate { get; set; }
        public bool IsDeleted { get; set; }
        public List<Publisher> Publishers { get; set; }
    }
}
