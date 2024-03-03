using AutoMapper;
using FluentValidation;
using Library.Business.Contracts;
using Library.Business.Extensions;
using Library.Business.MessageBrokers.RabbitMQ;
using Library.Business.Validators;
using Library.Data.Repositories;
using Library.Entities.MongoDB;
using Library.Entities.MongoDB.Dtos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Library.Business.Concretes
{
    public class BookService : IBookService
    {
        private IMongoDBRepository<Book> _repository;
        private IMapper _mapper;
        private readonly IRabbitMQProducer _rabbitMQProducer;


        public BookService(IMongoDBRepository<Book> repository, IMapper mapper, IRabbitMQProducer rabbitMQProducer)
        {
            _repository = repository;
            _mapper = mapper;
            _rabbitMQProducer = rabbitMQProducer;
        }

        public async Task<bool> CreateAsync(CreateBookDto model)
        {
            var validator = new CreateBookDtoValidator();
            await validator.ValidateAndThrowAsync(model);
            var result = await _repository.Create(_mapper.Map<Book>(model));
            if (result)
            {
                await _rabbitMQProducer.SendBookInsertedMessage(model.ToRabbitMQBookCreatedModel());
            }
            return result;
        }

        public async Task<bool> DeleteAsync(string id)
        {

            return await _repository.Delete(await _repository.Get(id));
        }

        public async Task<bool> DeletePermanentAsync(string id)
        {
            return await _repository.DeletePermanent(id);
        }

        public async Task<List<BookDto>> GetAllAsync()
        {
            var data = await _repository.GetAll(x => x.IsDeleted == false);
            return _mapper.Map<List<BookDto>>(data);
        }

        public async Task<BookDto> GetByIdAsync(string id)
        {
            return _mapper.Map<BookDto>(await _repository.Get(id));
        }

        public async Task<bool> UpdateAsync(UpdateBookDto model)
        {
            var validator = new UpdateBookDtoValidator();
            await validator.ValidateAndThrowAsync(model);
            var book = await _repository.Get(model.Id);
            if (book is null) return false;
            return await _repository.Update(model.ToUpdateBookObject(book, _mapper));
        }
    }
}
