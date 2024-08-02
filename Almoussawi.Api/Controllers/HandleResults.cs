using Almoussawi.Shared;
using MediatR;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using WebApiExercise.Repository.Interfaces;

namespace Almoussawi.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class HandleResults : ControllerBase
    {
       
        private IMediator mediator;
        protected IMediator Mediator => mediator ??= HttpContext.RequestServices.GetService<IMediator>();

        public ActionResult HandleResult<T>(Response<T> result)
        {
            if (result is null) return NotFound();

            if (result.IsSuccess && result.Value is not null)
            {
                return Ok(result.Value);
            }
            if (result.IsSuccess && result.Value is null)
            {
                return NotFound();
            }
            return BadRequest(result.Message);
        }
    }
}
