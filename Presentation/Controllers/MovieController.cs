using Application.Commands.Movie;
using Application.DTOs.Movie;
using Application.GeneralResponses;
using Application.Interfaces.UnitOfWork;
using Application.Queries.Movie;
using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Presentation.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class MovieController : ControllerBase
    {
        private readonly IMediator Mediator;
        public MovieController(IMediator mediator)
        {
            this.Mediator = mediator;
        }
        [HttpPost]
        public async Task<ActionResult> Add([FromForm] MovieToAddDto dto)
        {
           GeneralResponse<string> generalResponse= await Mediator.Send(new AddMovieCommand(dto));
            if (generalResponse.IsSuccess==true)
            {
                return Ok(generalResponse);
            }
            else
            {
                return BadRequest(generalResponse);
            }
            
        }

        [HttpGet("{id}")]
        public async Task<ActionResult> GetAction(int id)
        {
            GeneralResponse<MovieToGetDto> generalResponse = await Mediator.Send(new GetMovieQuery(id));
            if (generalResponse.IsSuccess == true)
            {
                return Ok(generalResponse);
            }
            else
            {
                return BadRequest(generalResponse);
            }
            
        }


    }
}
