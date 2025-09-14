using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CsharpEgitimKampi_501_Dapper_Project.DTOs;

namespace CsharpEgitimKampi_501_Dapper_Project.Repositories
{
    public class BookRepository : IBookRepository
    {
        public BookRepository()
        {
        }

        public Task CreateBookAsync(CreateBookDTO createBookDto)
        {
            throw new NotImplementedException();
        }

        public Task DeleteBookAsync(int bookId)
        {
            throw new NotImplementedException();
        }

        public Task<List<BookResultDTO>> GetAllBooksAsync()
        {
            throw new NotImplementedException();
        }

        public Task GetByBookId(int bookId)
        {
            throw new NotImplementedException();
        }

        public Task UpdateBookAsync(int bookId, CreateBookDTO updateBookDto)
        {
            throw new NotImplementedException();
        }
    }
}
