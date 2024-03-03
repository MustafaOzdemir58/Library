using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Library.Entities.MongoDB.Dtos
{
    public sealed class BookDto
    {
        public  BookDto()
        {
            this.Authors = new List<AuthorDto>();
            this.Publishers = new List<PublisherDto>();
        }
        public string Id { get; set; }
        public string Name { get; set; }
        public int PageCount { get; set; }
        public List<AuthorDto> Authors { get; set; }
        public DateTime CreatedDate { get; set; } = DateTime.Now;
        public int PublishedYear{ get; set; }
        public List<PublisherDto> Publishers { get; set; }
    }
}
