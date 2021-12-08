using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Filters;
using Projeto.Estudo.Core.Commands;
using Projeto.Estudo.Core.Commands.Contracts;

namespace Projeto.Estudo.Api.Controllers
{
    [ApiController]
    [Route("[controller]")]
    [ProducesResponseType(StatusCodes.Status500InternalServerError)]
    [ProducesResponseType(StatusCodes.Status400BadRequest)]
    [ProducesResponseType(StatusCodes.Status200OK)]
    [ProducesResponseType(StatusCodes.Status204NoContent)]
    public class BaseController : Controller
    {
        protected new IActionResult Response(ICommandResult result)
        {
            if (result.Success)
                return Ok(result.Data);

            return BadRequest(result.ValidationResult?.Errors.Select(x => x.ErrorMessage));
        }

        protected new IActionResult Response(object? result = null)
        {
            return Ok(result);
        }

        public override void OnActionExecuting(ActionExecutingContext context)
        {
            if (!ModelState.IsValid)
            {
                List<string> errors = context.ModelState.Values
                    .SelectMany(x => x.Errors).Select(x => x.ErrorMessage).ToList();
                context.Result = new BadRequestObjectResult(errors);
            }
            base.OnActionExecuting(context);
        }
    }
}
