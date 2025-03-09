using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;

namespace Application.DTOs.Movie
{
    public class MovieToAddDto
    {
        public string Name { get; set; }
        public IFormFile Image { get; set; }
        public int CategoryId { get; set; }
        
    }
}
