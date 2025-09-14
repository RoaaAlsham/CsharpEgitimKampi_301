using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CsharpEgitimKampi_501_Dapper_Project.DTOs
{
    public class CreateBookDTO
    {
        public string Title { get; set; } = string.Empty;
        public decimal Price { get; set; }
        public int Stock { get; set; }
    }
}
