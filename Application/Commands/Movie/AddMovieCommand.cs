using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Application.DTOs.Movie;
using Application.GeneralResponses;
using MediatR;

namespace Application.Commands.Movie
{
    public class AddMovieCommand:IRequest<GeneralResponse<string>>
    {
        public MovieToAddDto MovieToAddDto{ get; set; }

        public AddMovieCommand(MovieToAddDto movieToAddDto)
        {
            this.MovieToAddDto = movieToAddDto;
        }
    }
}
