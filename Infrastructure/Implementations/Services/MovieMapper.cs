using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Application.DTOs.Movie;
using Application.GeneralResponses;
using Application.Interfaces.Repository;
using Application.Interfaces.Services;
using AutoMapper;
using Domain.Models;
using Mapster;

namespace Infrastructure.Implementations.Services
{
    public class MovieMapper:ServiceMapper<string>,IMovieMapper
    {
            
        private readonly IMovieRepository movieRepository;
        private readonly IMapper mapper;

        public MovieMapper(IMovieRepository movieRepository,
            IMapper mapper
            )
        {
            this.movieRepository = movieRepository;
            this.mapper = mapper;
        }
        public async Task<GeneralResponse<string>> AddMovie(MovieToAddDto dto)
        {
            
            if (dto!=null)
            {
                using var dataStream = new MemoryStream();
                await dto.Image.CopyToAsync(dataStream);

                Movie movie = new Movie()
                {
                    Name = dto.Name,
                    CategoryId = dto.CategoryId,
                    Image = dataStream.ToArray(),
                };

                movieRepository.Insert(movie);

                return new GeneralResponse<string>()
                {
                    IsSuccess = true,
                    Data="Movie Added successfully"
                };
            }
            else
            {
                return new GeneralResponse<string>()
                {
                    IsSuccess = false,
                    Data = "Invalid Data"
                };
            }
            
        }

        public GeneralResponse<MovieToGetDto> GetMovie(int id )
        {
            Movie movie = movieRepository.GetMovieWithCategory(id);
            if(movie!=null)
            {
                MovieToGetDto movieToGetDto = movie.Adapt<MovieToGetDto>();
                  //  mapper.Map<MovieToGetDto>(movie);
                //    new MovieToGetDto()
                //{
                //    Id = id,
                //    CategoryId = movie.CategoryId,
                //    CategoryName = "movie.Category.Name",// include مكسل اعمل 
                //    Name = movie.Name,
                //    Image = movie.Image
                //};

                return new GeneralResponse<MovieToGetDto>()
                {
                    IsSuccess = true,
                    Data = movieToGetDto
                };
            }
            else
            {
                return new GeneralResponse<MovieToGetDto>()
                {
                    IsSuccess = false,
                    Data = null
                };
            }
            

        
        }
    }
}
