using Library.Entities.MessageBrokers.RabbitMQ.Dtos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Library.Entities.MongoDB.Dtos
{
    public sealed class CreateBookDto
    {
        public CreateBookDto()
        {
            this.Publishers = new List<PublisherDto>();
            this.Authors = new List<AuthorDto>();
        }
        public string Name { get; set; }
        public int PageCount { get; set; }
        public List<AuthorDto> Authors { get; set; }
        public DateTime CreatedDate { get; private set; } = DateTime.Now;
        public int PublishedYear { get; set; }
        public List<PublisherDto> Publishers { get; set; }

    }
   
}
