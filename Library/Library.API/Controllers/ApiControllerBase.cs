using Library.Domain;
using Microsoft.AspNetCore.Mvc;

namespace Library.API.Controllers
{
	public abstract class ApiControllerBase : ControllerBase
	{
		protected IActionResult GetResult(IActionResult successResult, ResultBase result)
		{
			if (result.Success)
			{
				return successResult;
			}
			else
			{
				return StatusCode(StatusCodes.Status500InternalServerError, result.ErrorMessage);
			}
		}
	}
}
