using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CsharpEgitimKampi_501_Dapper_Project.DTOs;
namespace CsharpEgitimKampi_501_Dapper_Project.Repositories
{
    public interface IBookRepository
    {
        Task<List<BookResultDTO>> GetAllBooksAsync();
        Task CreateBookAsync(CreateBookDTO createBookDto);
        Task UpdateBookAsync(int bookId, CreateBookDTO updateBookDto);

        Task DeleteBookAsync(int bookId);
        Task GetByBookId(int bookId);

    }
}
