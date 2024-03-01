
using Library.Entities.MongoDB.Dtos;
using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Library.Business.Contracts
{
    public interface IBookService
    {
        Task<bool> CreateAsync(CreateBookDto model);
        Task<bool> UpdateAsync(UpdateBookDto model);
        Task<bool> DeleteAsync(string id);
        Task<bool> DeletePermanentAsync(string id);
        Task<BookDto> GetByIdAsync(string id);
        Task<List<BookDto>> GetAllAsync();
    }
}
