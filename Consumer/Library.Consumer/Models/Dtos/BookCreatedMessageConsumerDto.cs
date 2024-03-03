using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Library.Consumer.Models.Dtos
{
    public sealed class BookCreatedMessageConsumerDto
    {
        public string BookName { get; set; }
        public DateTime BookCreatedDate { get; set; }
    }
}
