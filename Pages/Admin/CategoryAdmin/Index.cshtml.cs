using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using LitLounge.Data;
using LitLounge.Models;

namespace LitLounge.Pages.Admin.CategoryAdmin
{
    public class IndexModel : PageModel
    {
        private readonly LitLounge.Data.LitLoungeContext _context;

        public IndexModel(LitLounge.Data.LitLoungeContext context)
        {
            _context = context;
        }

        public IList<Category> Category { get;set; } = default!;

        public async Task OnGetAsync()
        {
            Category = await _context.Category.ToListAsync();
        }
    }
}
