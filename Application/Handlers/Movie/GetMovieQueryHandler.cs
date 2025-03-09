using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Application.DTOs.Movie;
using Application.GeneralResponses;
using Application.Interfaces.UnitOfWork;
using Application.Queries.Movie;
using MediatR;

namespace Application.Handlers.Movie
{
    public class GetMovieQueryHandler : IRequestHandler<GetMovieQuery, GeneralResponse<MovieToGetDto>>
    {
        private readonly IUnitOfWork unitOfWork;

        public GetMovieQueryHandler(IUnitOfWork unitOfWork)
        {
            this.unitOfWork = unitOfWork;
        }
        public Task<GeneralResponse<MovieToGetDto>> Handle(GetMovieQuery request, CancellationToken cancellationToken)
        {
           
            GeneralResponse<MovieToGetDto> generalResponse = unitOfWork.MovieMapper.GetMovie(request.id);
            return Task.FromResult(generalResponse);
        }
    }
}
