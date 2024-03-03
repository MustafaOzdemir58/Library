using Microsoft.VisualBasic;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Library.Entities.MongoDB.Dtos
{
    public sealed class UpdateBookDto
    {
        public string Id { get; set; }
        public string Name { get; set; }
        public int PageCount { get; set; }
        public List<AuthorDto> Authors { get; set; }
        public DateTime  UpdateDate { get; private set; }=DateTime.Now;
        public int PublishedYear{ get; set; }
        public List<PublisherDto> Publishers { get; set; }
    }
}
