using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Application.DTOs.Category;
using Application.DTOs.Movie;
using Application.GeneralResponses;
using Application.Interfaces.Repository;
using Application.Interfaces.Services;
using Domain.Models;

namespace Infrastructure.Implementations.Services
{
    public class CategoryMapper:ServiceMapper<Category>,ICategoryMapper
    {
        private readonly ICategoryRepository categoryRepository;

        public CategoryMapper(ICategoryRepository categoryRepository)
        {
            this.categoryRepository = categoryRepository;
        }

        public void AddCategory(CategoryDto dto)
        {
            Category category = GetCategory(dto);

            categoryRepository.Insert(category);
        }

        public Category GetCategory(CategoryDto dto)
        {
            Category category = new Category()
            {
                Name = dto.Name,
            };

            return category;
        }

        public Category GetCategoryById(int CatId)
        {
            Category category = categoryRepository.Get(c=>c.Id==CatId);

            return category;
        }

        public GeneralResponse<CategoryToGet> GetCategoryById2(int CatId)
        {
            Category category = categoryRepository.GetCategoryWithMovies(CatId);
            GeneralResponse<CategoryToGet> generalResponse = new();
            if (category !=null)
            {
                generalResponse.IsSuccess = true;

                CategoryToGet categoryToGet = new CategoryToGet()
                {
                    Name = category.Name,
                    Movies = category.Movies.Select(m => new MovieToGetDto()
                    {
                        Name = m.Name,
                        CategoryId = CatId,
                        CategoryName = category.Name,
                        Id = m.Id,
                        Image = m.Image,

                    }).ToList()
                };
                generalResponse.Data = categoryToGet;
            }
            
            return generalResponse;
        }
    }
}
