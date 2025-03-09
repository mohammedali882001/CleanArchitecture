using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Application.DTOs.Movie;
using Application.GeneralResponses;
using Domain.Models;

namespace Application.Interfaces.Services
{
    public interface IMovieMapper:IServiceMapper<Movie>
    {
        public  Task<GeneralResponse<string>> AddMovie(MovieToAddDto dto);
        public GeneralResponse<MovieToGetDto> GetMovie(int id);
    }
}
