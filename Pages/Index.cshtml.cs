using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using LitLounge.Data;
using LitLounge.Areas.Identity.Data;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using System.Collections;
using System.Collections.Generic;
using System.Threading.Tasks;
using Microsoft.CodeAnalysis.CSharp.Syntax;


namespace LitLounge.Pages
{
    public class IndexModel : PageModel
    {
        private readonly UserManager<LitLoungeUser> _userManager;
        private readonly LitLoungeContext _context;

        public IndexModel(UserManager<LitLoungeUser> userManager, LitLoungeContext context)
        {
            _userManager = userManager;
            _context = context;
        }
        
        public LitLoungeUser MyUser { get; set; }
        public List<Models.Category> Categories { get; set; } 

        public async Task OnGetAsync()
        {
            MyUser = await _userManager.GetUserAsync(User);
            Categories = await _context.Category.Include(c => c.Subcategories).ToListAsync();

            //    if (_context.Category != null)
            //    {
            //        Categories = await _context.Category_1.ToListAsync();
            //    }
        }

        
        
    }
}
