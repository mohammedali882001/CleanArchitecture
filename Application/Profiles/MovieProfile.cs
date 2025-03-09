using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Application.DTOs.Movie;
using AutoMapper;
using Domain.Models;

namespace Application.Profiles
{
    public class MovieProfile:Profile
    {
        public MovieProfile()
        {
            CreateMap<Movie, MovieToGetDto>()
                .ForMember
                (
                    dest=>dest.CategoryName ,
                    src=>src.MapFrom(src=>src.Category.Name)
                )
                .ForMember
                (
                    dest=>dest.Name,
                    src=>src.MapFrom(src=>$"Name is : {src.Name}"))
                ;
        }
    }
}
