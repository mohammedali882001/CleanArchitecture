using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Application.DTOs.Movie;
using Domain.Models;
using Mapster;

namespace Application.Profiles
{
    public static class MovieProfileMapster
    {
        public static void RegisterMappings()
        {
            TypeAdapterConfig<Movie, MovieToGetDto>
                .NewConfig()
                .Map
                (
                    dest => dest.CategoryName,
                    src => src.Category.Name
                )
                .Map
                (
                    dest => dest.Name,
                    src=>$"movie name is {src.Name}"
                );
        }
    }
}
