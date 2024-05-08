using Microsoft.AspNetCore.Mvc;
using Amazon.DynamoDBv2;
using Amazon.DynamoDBv2.Model;
using Models;
using api.Services.DelphITService;

public class DelphITController : ControllerBase
{
    private readonly IDelphITService _delphiService;

    public  DelphITController(IDelphITService delphiService)
    {
        _delphiService = delphiService;
    }

    [HttpGet("/api/whoisdelphi/{id}")]
    public async Task<IActionResult> GetById(int id)
    {
        var result = await _delphiService.GetByIdAsync(id);
        if (result == null)
            return NotFound();
        return Ok(result);
    }

    [HttpGet("/api/whoisdelphi")]
    public async Task<IActionResult> GetAll()
    {
        var result = await _delphiService.GetAllAsync();
        return Ok(result);
    }

}
