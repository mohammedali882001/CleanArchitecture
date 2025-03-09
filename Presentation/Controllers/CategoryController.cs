using Application.DTOs.Category;
using Application.GeneralResponses;
using Application.Interfaces.UnitOfWork;
using Application.Queries.Category;
using Domain.Models;
using MediatR;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Presentation.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CategoryController : ControllerBase
    {
        private readonly IMediator mediator;
        public CategoryController(IMediator mediator)
        {
            this.mediator = mediator;
        }

        //[HttpPost("AddCategory")]
        //public ActionResult Add(CategoryDto categoryDto)
        //{
        //    unitOfWork.CategoryMapper.AddCategory(categoryDto);
        //    unitOfWork.Save();
        //    return Ok("Added Succesfully");
        //}

        [HttpGet("{id}")]
        public async Task< ActionResult> Get(int id)
        {
            GeneralResponse<CategoryToGet> category=await mediator.Send(new GetCategoryQuery(id));
            if (category.IsSuccess==true)
            {
                return Ok(category);
            }
            return BadRequest(category);
            
        }

    }
}
