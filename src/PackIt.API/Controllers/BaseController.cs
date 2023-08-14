using Microsoft.AspNetCore.Mvc;

namespace PackIt.API.Controllers;

[ApiController]
[Route("api/[controller]")]
public abstract class BaseController : ControllerBase
{
  protected ActionResult<TResult> OkOrNotFound<TResult>(TResult result)
  {
    if (result is null)
    {
      return NotFound();
    }

    return Ok(result);
  }
}
