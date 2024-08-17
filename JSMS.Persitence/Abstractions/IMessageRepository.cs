using JSMS.Domain.Models;
using JSMS.Persitence.Models.Message;

namespace JSMS.Persitence.Abstractions
{
	public interface IMessageRepository
	{
		public Task<IEnumerable<Message>> GetMessagesByGroupIdAsync(int groupId);

		public Task<IEnumerable<Message>> GetRecentActivityByGroupIdAsync (int groupId);

		public Task<string> PostMessage(MessageRequest request);
		
	}
}
