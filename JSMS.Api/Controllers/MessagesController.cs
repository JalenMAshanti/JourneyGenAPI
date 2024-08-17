using JSMS.Persitence.Factories;
using JSMS.Persitence.Models.Message;
using JSMS.Persitence.Repositories;
using Microsoft.AspNetCore.Mvc;

namespace JSMS.Api.Controllers
{
	[Route("api/[controller]")]
	[ApiController]
	public class MessagesController : ControllerBase
	{

		DbConnectionFactory connectionFactory = new DbConnectionFactory();
		private readonly MessageRepository _messageRepository;

		public MessagesController(MessageRepository messageRepository)
		{
			_messageRepository = messageRepository;
		}

		[HttpGet("GetMessagesByGroupId")]
		public async Task<IActionResult> GetMessagesByGroupById(int groupId) => Ok(await _messageRepository.GetMessagesByGroupIdAsync(groupId));

		
		[HttpGet("GetRecentActivityByGroupId")]
		public async Task<IActionResult> GetRecentActivityByGroupId(int groupId) => Ok(await _messageRepository.GetRecentActivityByGroupIdAsync(groupId));

        [HttpPost("PostMessageToGroupBoard")]
        public async Task<IActionResult> PostMessage(MessageRequest request) => Ok(await _messageRepository.PostMessage(request));
    }
}
