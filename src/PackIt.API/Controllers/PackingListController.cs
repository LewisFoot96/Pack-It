using Microsoft.AspNetCore.Mvc;
using PackIT.Application.Commands;
using PackIT.Application.DTO;
using PackIT.Domain.ValueObject;
using PackIT.Infastructure.EF.Queries;
using PackIT.Shared.Abstractions.Commands;
using PackIT.Shared.Abstractions.Queries;

namespace PackIt.API.Controllers;

[ApiController]
  
[Route("api/[controller]")]
public class PackingListController : BaseController
{
  private IQueryDispatcher _queryDispatcher;
  private ICommandDispatcher _commandDispatcher;

  public PackingListController(IQueryDispatcher queryDispatcher, ICommandDispatcher commandDispatcher)
  {
    _queryDispatcher = queryDispatcher;
    _commandDispatcher = commandDispatcher;
  }

  [HttpGet("{id:guid")]
  public async Task<ActionResult<PackingListDto>> Get([FromRoute] GetPackingList query)
  {
    var result = await _queryDispatcher.QueryAsync(query);
    return OkOrNotFound(result);
  }

  [HttpGet]
  public async Task<ActionResult<IEnumerable<PackingListDto>>> Get([FromQuery] SearchPackingList query)
  {
    var result = await _queryDispatcher.QueryAsync(query);
    return OkOrNotFound(result);
  }

  [HttpPost]
  public async Task<IActionResult> Post([FromBody] CreatePackingListWithItems command)
  {
    await _commandDispatcher.DispatchAsync(command);
    return CreatedAtAction(nameof(Get), new { id = command.Id }, null);
  }
  
  [HttpPut("{packingListId}/items")]
  public async Task<IActionResult> Put([FromBody] AddPackingItem command)
  {
    await _commandDispatcher.DispatchAsync(command);
    return Ok();
  }
  
  [HttpPut("packingListId:guid/items/{name}/pack")]
  public async Task<IActionResult> Put([FromBody] PackItem command)
  {
    await _commandDispatcher.DispatchAsync(command);
    return Ok();
  }
  
  [HttpDelete("packingListId:guid/items/{name}")]
  public async Task<IActionResult> Delete([FromBody] RemovePackingItem command)
  {
    await _commandDispatcher.DispatchAsync(command);
    return Ok();
  }
  
  [HttpDelete("{id:guid")]
  public async Task<IActionResult> Delete([FromBody] RemovePackingList command)
  {
    await _commandDispatcher.DispatchAsync(command);
    return Ok();
  }
}
