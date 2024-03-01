using AutoMapper;
using Library.Business.Contracts;
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


        public BookService(IMongoDBRepository<Book> repository, IMapper mapper)
        {
            _repository = repository;
            _mapper = mapper;
        }

        public async Task<bool> CreateAsync(CreateBookDto model)
        {
            return await _repository.Create(_mapper.Map<Book>(model));
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
            var data = await _repository.GetAll(x => x.IsDeleted == false && x.DeletedDate == null);
            return _mapper.Map<List<BookDto>>(data);
        }

        public async Task<BookDto> GetByIdAsync(string id)
        {
            return _mapper.Map<BookDto>(await _repository.Get(id));
        }

        public async Task<bool> UpdateAsync(UpdateBookDto model)
        {
            return await _repository.Update(_mapper.Map<Book>(model));
        }
    }
}
