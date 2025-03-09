using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;

namespace Application.DTOs.Movie
{
    public class MovieToGetDto
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public Byte[] Image { get; set; }

        public int CategoryId { get; set; }
        public string CategoryName { get; set; }
    }
}
