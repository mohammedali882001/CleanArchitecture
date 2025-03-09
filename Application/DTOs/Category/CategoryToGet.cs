using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Application.DTOs.Movie;

namespace Application.DTOs.Category
{
    public class CategoryToGet:CategoryDto
    {
        public List<MovieToGetDto> Movies { get; set; } = new List<MovieToGetDto>(); 
    }
}
