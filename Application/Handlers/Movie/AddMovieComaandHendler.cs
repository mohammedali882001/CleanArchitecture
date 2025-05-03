using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Application.Commands.Movie;
using Application.DTOs.Movie;
using Application.GeneralResponses;
using Application.Interfaces.Hangfire;
using Application.Interfaces.UnitOfWork;
using Hangfire;
using MediatR;

namespace Application.Handlers.Movie
{
    public class AddMovieComaandHendler : IRequestHandler<AddMovieCommand, GeneralResponse<string>>
    {
        private readonly IUnitOfWork UnitOfWork;

        public AddMovieComaandHendler(IUnitOfWork unitOfWork)
        {
            this.UnitOfWork = unitOfWork;
        }

        //public Task<GeneralResponse<string>> Handle(AddMovieCommand request, CancellationToken cancellationToken)
        //{
        //    var rest = UnitOfWork.MovieMapper.AddMovie(request.MovieToAddDto);
        //    return rest;
        //}
        public async Task<GeneralResponse<string>> Handle(AddMovieCommand request, CancellationToken cancellationToken)
        {
            GeneralResponse<string> generalResponse = await UnitOfWork.MovieMapper.AddMovie(
                request.MovieToAddDto
                );
            if (generalResponse.IsSuccess == true)
            {
                UnitOfWork.Save();
                 BackgroundJob.Enqueue<ISenderMessage>(s=>s.Send($"Movie {request.MovieToAddDto.Name} Added Succesfully"));
                 BackgroundJob.Schedule<ISenderMessage>(s=>s.Send($"Movie {request.MovieToAddDto.Name} Added Succesfully Since 30 Seconds"),TimeSpan.FromSeconds(30));
                RecurringJob.AddOrUpdate<ISenderMessage>("Minutely Job", s => s.Send($"Recurring Job for movie {request.MovieToAddDto.Name}"), Cron.Minutely);
            }


            return generalResponse;
        }
    }
}
