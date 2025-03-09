using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Application.DTOs.Movie;
using Application.GeneralResponses;
using MediatR;

namespace Application.Queries.Movie
{
    public class GetMovieQuery:IRequest<GeneralResponse<MovieToGetDto>>
    {
        public int id{ get; set; }
        
        public GetMovieQuery(int ID)
        {
            this.id = ID;
            
        }
    }
}
