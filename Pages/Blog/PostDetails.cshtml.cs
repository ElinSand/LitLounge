using LitLounge.Data;
using LitLounge.Areas.Identity.Data;
using LitLounge.Models;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using System.Security.Claims;
using Microsoft.Extensions.Hosting;

namespace LitLounge.Pages.Blog
{
    public class PostDetailsModel : PageModel
    {
        private readonly LitLoungeContext _context;
        private readonly UserManager<LitLoungeUser> _userManager;

        public PostDetailsModel(LitLoungeContext context, UserManager<LitLoungeUser> userManager)
        {
            _context = context;
            _userManager = userManager;
        }

        public Post Post { get; set; }
        public IList<Comment> Comments { get; set; }

        [BindProperty]
        public string CommentContent { get; set; }

        public async Task<IActionResult> OnGetAsync(int postId, string action)
        {
            Post = await _context.Posts
                .Include(p => p.Comments)
                .ThenInclude(c => c.User)
                .FirstOrDefaultAsync(p => p.Id == postId);

            if (Post == null)
            {
                return NotFound();
            }

            var user = await _userManager.FindByIdAsync(Post.UserId);  //Added
            if (user == null)
            {
                return NotFound();
            }

            //if (Post.UserId != User.FindFirstValue(ClaimTypes.NameIdentifier))  //Added, här går det inte att se inlägget närmare
            //{
            //    return RedirectToPage("/Blog/PostDetails");
            //}

            Comments = Post.Comments.ToList();

            if (action == "like")
            {
                Post.LikeCount++;
                await _context.SaveChangesAsync();
            }
            else if (action == "report")
            {
                Post.ReportCount++;
                await _context.SaveChangesAsync();
            }
            //else if (action == "delete")
            //{
            //    var postid = await _context.Posts.FindAsync(Post.Id);
            //    _context.Posts.Remove(postid);
            //    await _context.SaveChangesAsync();
            //}

            return Page();
        }

        public async Task<IActionResult> OnPostAsync(int postId)
        {
            if (!User.Identity.IsAuthenticated)  //Added
            {
                return RedirectToPage("/Account/Login");
            }


            //    if (!ModelState.IsValid)
            //    {
            //        return Page();
            //    }

            var comment = new Comment
            {
                Content = CommentContent,
                DateCreated = DateTime.Now,
                PostId = postId,
                UserId = User.FindFirstValue(ClaimTypes.NameIdentifier)
            };

            _context.Comments.Add(comment);
            await _context.SaveChangesAsync();

            return RedirectToPage(new { postId = postId });
        }


        // Nytt tillagd metod för att hantera borttagning av kommentarer
        public async Task<IActionResult> OnPostDeleteCommentAsync(int commentId)
        {
            var comment = await _context.Comments.FindAsync(commentId);

            if (comment == null)
            {
                return NotFound();
            }

            // Kontrollera att det är den inloggade användaren som äger kommentaren
            if (comment.UserId != User.FindFirstValue(ClaimTypes.NameIdentifier))
            {
                return Forbid();
            }

            _context.Comments.Remove(comment);
            await _context.SaveChangesAsync();

            return RedirectToPage(new { postId = comment.PostId });
        }


    }

}





