using Microsoft.AspNetCore.Mvc;

public class RabbitMQController : ControllerBase
{
    private readonly IRabbitMQService _rabbitMQService;

    public RabbitMQController(IRabbitMQService rabbitMQService)
    {
        _rabbitMQService = rabbitMQService;
    }

    [HttpGet("/send-message")]
    public IActionResult SendMessage()
    {
        _rabbitMQService.SendMessage("Hello RabbitMQ!");
        return Ok();
    }
}
