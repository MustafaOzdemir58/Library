using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Library.Entities.MongoDB.Dtos
{
    public sealed class AuthorDto
    {
        public string Name { get; set; }
        public string Image { get; set; }
        public string ShortDescription { get; set; }
        public string PhoneNumber { get; set; }
        public string Email { get; set; }
    }
}
