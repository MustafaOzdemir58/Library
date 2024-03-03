using AutoMapper;
using Library.Entities.MessageBrokers.RabbitMQ.Dtos;
using Library.Entities.MongoDB;
using Library.Entities.MongoDB.Dtos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Library.Business.Extensions
{
    public static class ModelConverterExtension
    {
        public static BookCreatedMessageDto ToRabbitMQBookCreatedModel(this CreateBookDto model)
        {
            return new BookCreatedMessageDto
            {
                BookCreatedDate = model.CreatedDate,
                BookName = model.Name
            };
        }
        public static Book ToUpdateBookObject(this UpdateBookDto model, Book entity, IMapper mapper)
        {
            entity.UpdateDate = model.UpdateDate;
            entity.Name = model.Name;
            entity.Authors = mapper.Map<List<Author>>(model.Authors);
            entity.Publishers = mapper.Map<List<Publisher>>(model.Publishers);
            entity.PageCount = model.PageCount;
            entity.PublishedYear = model.PublishedYear;
            return entity;
        }
    }
}
