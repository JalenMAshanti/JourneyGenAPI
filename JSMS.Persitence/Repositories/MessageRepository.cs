using Dapper;
using JSMS.Domain.Models;
using JSMS.Persitence.Abstractions;
using JSMS.Persitence.Models.Message;
using Microsoft.AspNetCore.Mvc;
using System.Data;

namespace JSMS.Persitence.Repositories
{
	public class MessageRepository : IMessageRepository
	{
		private readonly IDbConnection _db;
		public MessageRepository(IDbConnection db) 
		{
			_db = db;
		}

		public async Task<IEnumerable<Message>> GetMessagesByGroupIdAsync(int groupId)
		{
			string sql = "SELECT * FROM posts WHERE	GroupId = @GroupId";
			var messages = await _db.QueryAsync<Message>(sql, new {GroupId = groupId});
			return messages;
		}

		public async Task<IEnumerable<Message>> GetRecentActivityByGroupIdAsync(int groupId)
		{
			string sql = "SELECT * FROM posts WHERE GroupId = @GroupId ORDER BY DatePosted DESC LIMIT 2";
			var messages = await _db.QueryAsync<Message>(sql, new {GroupId = groupId});
			return messages;
		}

        public async Task<string> PostMessage(MessageRequest request)
        {
			string sql = "INSERT INTO posts (GroupId, Content, UserId, FirstName, LastName, DatePosted) VALUES (@GroupId, @Content, @UserId, @FirstName, @LastName, @DatePosted)";
			var result = await _db.ExecuteAsync(sql, new
			{
				GroupId = request.GroupId,
				Content = request.Content,
				UserId = request.UserId,
				FirstName = request.FirstName,
				LastName = request.LastName,
				DatePosted = DateTime.Now
			});
			if (result == 1)
			{
				return "Successful";
			}
			else 
			{
				return "Unsuccessful";
			}
			
        }
    }
}
