using FluentValidation;
using Library.Business.Concretes;
using Library.Business.Contracts;
using Library.Business.MessageBrokers.RabbitMQ;
using Library.Business.Validators;
using Library.Data.Repositories;
using Library.Entities.MongoDB;
using Library.Entities.MongoDB.Dtos;
using Library.Entities.MongoDB.Settings;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Options;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Library.Business.Extensions
{
    public static class IServiceCollectionExtensions
    {
        public static IServiceCollection AddRepositories(this IServiceCollection services, IConfiguration cfg)
        {
            var assmbly = AppDomain.CurrentDomain.Load("Library.Business");
            services.AddAutoMapper(assmbly);
            services.AddScoped<IMongoDBRepository<Book>, MongoDBBookRepository>();
            services.AddScoped<IBookService, BookService>();
            services.AddScoped<IRabbitMQProducer, RabbitMQProducer>();
            services.AddScoped<IValidator<CreateBookDto>, CreateBookDtoValidator>();
            services.AddScoped<IValidator<UpdateBookDto>, UpdateBookDtoValidator>();
            return services;
        }
    }
}
