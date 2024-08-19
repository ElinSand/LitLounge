using LitLounge.Areas.Identity.Data;
using LitLounge.Models;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;

namespace LitLounge.Pages.Message
{
    public class ReceiveModel : PageModel
    {
       private readonly LitLounge.Data.LitLoungeContext _context;
       private readonly UserManager<LitLoungeUser> _userManager;


        public ReceiveModel(LitLounge.Data.LitLoungeContext context, UserManager<LitLoungeUser> userManager)
        {
            _context = context;
            _userManager = userManager;
        }


        public List<ShowMessage> ReceivedMessages { get; set; }
        public List<ShowMessage> SentMessages { get; set; }


        public async Task OnGetAsync()
        {
            var userId = _userManager.GetUserId(User);

            var receivedMessages = await _context.PrivateMessages
                 .Where(m => m.ReceiverId == userId)
                 .OrderByDescending(m => m.SentAt)
                 .ToListAsync();

            ReceivedMessages = new List<ShowMessage>();
            foreach (var message in receivedMessages)
            {
                var sender = await _userManager.FindByIdAsync(message.SenderId);
                ReceivedMessages.Add(new ShowMessage
                {
                    Id = message.Id,
                    MessageContent = message.MessageContent,
                    SentAt = message.SentAt,
                    AuthorNickname = sender.NickName
                    
                });
            }

            // Hämtar skickade meddelanden
            var sentMessages = await _context.PrivateMessages
                .Where(m => m.SenderId == userId)
                .OrderByDescending(m => m.SentAt)
                .ToListAsync();

            SentMessages = new List<ShowMessage>();
            foreach (var message in sentMessages)
            {
                var receiver = await _userManager.FindByIdAsync(message.ReceiverId);
                SentMessages.Add(new ShowMessage
                {
                    Id = message.Id,
                    MessageContent = message.MessageContent,
                    SentAt = message.SentAt,
                    AuthorNickname = receiver.NickName
                });
            }




        }






    }
}
