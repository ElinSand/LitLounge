using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using System.Security.Claims;

namespace LitLounge.Pages
{
    public class PostsPageModel : PageModel
    {
        public class IndexModel : PageModel
        {
            private readonly Data.LitLoungeContext _context;

            public IndexModel(Data.LitLoungeContext context)
            {
                _context = context;
            }

            [BindProperty]
            public Models.Blog Blog { get; set; }

            [BindProperty]
            public IFormFile UploadedImage { get; set; }

            public List<Models.Blog> Blogs { get; set; }

            //public async Task OnGetAsync(int deleteId)
            //{
            //    if (deleteId != 0)
            //    {
            //        Models.Blog blogToBeDeleted = await _context.Blog.FindAsync(deleteId);

            //        if (blogToBeDeleted != null)
            //        {
            //            if (System.IO.File.Exists("./wwwroot/userImages/" + blogToBeDeleted.Image))
            //            {
            //                System.IO.File.Delete("./wwwroot/userImages/" + blogToBeDeleted.Image);
            //            }
            //            _context.Blog.Remove(blogToBeDeleted);
            //            await _context.SaveChangesAsync();

            //        }
            //    }
            //    Blogs = await _context.Blog.ToListAsync();
            //}

        //    public async Task<IActionResult> OnPostAsync()
        //    {
        //        var image = UploadedImage;
        //        string fileName = "";

        //        if (image != null)
        //        {
        //            Random rnd = new();
        //            fileName = rnd.Next(0, 100000).ToString() + image.FileName;

        //            using (var fileStream = new FileStream("./wwwroot/userImages/" + fileName, FileMode.Create))
        //            {
        //                await image.CopyToAsync(fileStream);
        //            }
        //        }

        //        Blog.Date = DateTime.Now;
        //        Blog.Image = fileName;
        //        Blog.UserId = User.FindFirstValue(ClaimTypes.NameIdentifier);
        //        _context.Blog.Add(Blog);

        //        await _context.SaveChangesAsync();

        //        return RedirectToPage("./Index");

        //    }


        }
    }
}
