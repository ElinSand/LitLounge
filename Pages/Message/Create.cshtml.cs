using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Authorization;
using Microsoft.EntityFrameworkCore;
using LitLounge.Data;
using LitLounge.Models;
using LitLounge.Areas.Identity.Data;

namespace LitLounge.Pages.Message
{
    public class CreateModel : PageModel
    {
        private readonly LitLounge.Data.LitLoungeContext _context;
        private readonly UserManager<LitLoungeUser> _userManager;


        public CreateModel(LitLounge.Data.LitLoungeContext context, UserManager<LitLoungeUser> userManager)
        {
            _context = context;
            _userManager = userManager;
        }

        [BindProperty]
        public string? ReceiverId { get; set; }

        [BindProperty]
        public string? MessageContent { get; set; }


        public async Task<IActionResult> OnPostAsync()
        {
            if (!User.Identity.IsAuthenticated)
            {
                return RedirectToPage("/account/login");
            }

            var senderId = _userManager.GetUserId(User);

            var message = new PrivateMessage
            {
                SenderId = senderId,
                ReceiverId = ReceiverId,
                MessageContent = MessageContent,
                SentAt = DateTime.Now
            };


            _context.PrivateMessages.Add(message);
            await _context.SaveChangesAsync();
            return RedirectToPage("/message/receive");
        }
    }
}
