using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.SignalR;
using job_search_be.Api.Hubs;

namespace job_search_be.Api.Controllers.RealTime
{
    [Route("api/[controller]")]
    [ApiController]
    public class NotificationController : ControllerBase
    {
        private readonly IHubContext<NotificationHub> _hubContext;

        public NotificationController(IHubContext<NotificationHub> hubContext)
        {
            _hubContext = hubContext;
        }
        [HttpPost("send")]
        public async Task<IActionResult> SendNotification(string message)
        {
            await _hubContext.Clients.All.SendAsync("ReceiveNotification", message);
            return Ok("OK");
        }
    }
}
