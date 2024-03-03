using Library.Consumer.Models.Dtos;
using Library.Consumer.Models.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Library.Consumer.Extensions
{
    public static class ModelConverterExtensions
    {
        public static CreatedBookLogJson ConvertToCreatedLogJsonModel(this BookCreatedMessageConsumerDto model)
        {
            return new CreatedBookLogJson
            {
                BookCreatedDate = model.BookCreatedDate.ToString(),
                BookName = model.BookName
            };
        }
    }
}
