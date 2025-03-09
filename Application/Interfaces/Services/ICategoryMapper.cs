using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Application.DTOs.Category;
using Application.GeneralResponses;
using Application.Interfaces.Repository;
using Domain.Models;

namespace Application.Interfaces.Services
{
    public interface ICategoryMapper:IServiceMapper<Category>
    {
        // ICategoryRepository CategoryRepository { get; set; }
        public Category GetCategory(CategoryDto dto);
        public void AddCategory(CategoryDto dto);
        public Category GetCategoryById(int CatId);
        public GeneralResponse<CategoryToGet> GetCategoryById2(int CatId);



    }
}
