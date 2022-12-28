using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using TimedAssignment.Models.Reply;

namespace TimedAssignment.Services.Reply
{
    public interface IReplyService
    {
        Task<bool> CreateReplyAsync(ReplyCreate request);
        Task<IEnumerable<ReplyListItem>> GetAllRepliesAsync();
        Task<ReplyDetail> GetReplyIdAsync(int replyId);
        Task<bool> UpdateReplyAsync(ReplyUpdate request);
        Task<bool> DeleteReplyAsync(int replyId);
    }
}