using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;
using Amazon.DynamoDBv2;
using api.Services.DelphITService;
using Models;


namespace api.Controllers;
[ApiController]
[Route("api/[controller]")]
public class DelphITController : ControllerBase
{
    private readonly IDelphITService _delphiService;

    public DelphITController(IDelphITService delphiService)
    {
        _delphiService = delphiService;
    }

    [HttpGet("whoisdelphi/{id}")]
    public async Task<IActionResult> GetById(int id)
    {
        var result = await _delphiService.GetByIdAsync(id);
        if (result == null)
            return NotFound();
        return Ok(result);
    }

    [HttpGet("whoisdelphi")]
    public async Task<IActionResult> GetAll()
    {
        var result = await _delphiService.GetAllAsync();
        if (result == null || !result.Any())
        {
            // If no results were returned, return a default response
            return Ok("No DelphIT records found.");
        }
        return Ok(result);
    }
    [HttpPost("add")]
        public async Task<IActionResult> Add([FromBody] DelphIT newItem)
        {
            if (newItem == null)
                return BadRequest("Invalid input");

            await _delphiService.AddAsync(newItem);
            return Ok("Item added successfully");
        }

}
