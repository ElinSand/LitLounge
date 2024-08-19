using LitLounge.Data;
using LitLounge.Models;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using System.Security.Claims;

namespace LitLounge.Pages.Blog
{
    public class SubcategoryPostsModel : PageModel
    {
        private readonly LitLoungeContext _context;
        private readonly UserManager<Areas.Identity.Data.LitLoungeUser> _userManager;

        public SubcategoryPostsModel(LitLoungeContext context, UserManager<Areas.Identity.Data.LitLoungeUser> userManager)
        {
            _context = context;
            _userManager = userManager;
        }


        public Post Post { get; set; }

        public Subcategory Subcategory { get; set; }
        public IList<Post> Posts { get; set; }

        [BindProperty]
        public string Title { get; set; }

        [BindProperty]
        public string Content { get; set; }

        public async Task<IActionResult> OnGetAsync(int subcategoryId)
        {
            Subcategory = await _context.Subcategories
                .Include(s => s.Posts)
                .ThenInclude(p => p.User)
                .FirstOrDefaultAsync(s => s.Id == subcategoryId);


           

            Posts = Subcategory?.Posts?.ToList();

            if (Subcategory == null)
            {
                return NotFound();
            }

            Posts = Subcategory.Posts.ToList();

            return Page();
        }

        public async Task<IActionResult> OnPostAsync(int subcategoryId)
        {
            if (!ModelState.IsValid)
            {
                return Page();
            }

           

           

            var post = new Post
            {
                Title = Title,
                Content = Content,
                DateCreated = DateTime.Now,
                SubcategoryId = subcategoryId,
                UserId = User.FindFirstValue(ClaimTypes.NameIdentifier)
            };

            _context.Posts.Add(post);
            await _context.SaveChangesAsync();

            return RedirectToPage(new { subcategoryId = subcategoryId });
        }
    }
}
