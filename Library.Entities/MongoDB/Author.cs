using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Library.Entities.MongoDB
{
    public sealed class Author
    {
        public string Name { get; set; }
        public int Age { get; set; }
        public string ShortDescription { get; set; }
        public string PhoneNumber { get; set; }
        public string Email { get; set; }
    }
}
