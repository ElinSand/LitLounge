using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using LitLounge.Data;
using LitLounge.Models;

namespace LitLounge.Pages.Admin.SubcategoryAdmin
{
    // [Authorize(Roles = "Admin")]
    public class IndexModel : PageModel
    {
        private readonly LitLounge.Data.LitLoungeContext _context;

        public IndexModel(LitLounge.Data.LitLoungeContext context)
        {
            _context = context;
        }

        public IList<Subcategory> Subcategory { get;set; } = default!;

        public async Task OnGetAsync()
        {
            Subcategory = await _context.Subcategories
                .Include(s => s.Category).ToListAsync();
        }
    }
}
