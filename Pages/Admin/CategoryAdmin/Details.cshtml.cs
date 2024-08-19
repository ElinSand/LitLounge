using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using LitLounge.Data;
using LitLounge.Models;
using Microsoft.AspNetCore.Authorization;

namespace LitLounge.Pages.Admin.CategoryAdmin
{
    [Authorize(Roles = "Admin")]
    public class DetailsModel : PageModel
    {
        private readonly LitLounge.Data.LitLoungeContext _context;

        public DetailsModel(LitLounge.Data.LitLoungeContext context)
        {
            _context = context;
        }

        public Category Category { get; set; } = default!;

        public async Task<IActionResult> OnGetAsync(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var category = await _context.Category.FirstOrDefaultAsync(m => m.Id == id);
            if (category == null)
            {
                return NotFound();
            }
            else
            {
                Category = category;
            }
            return Page();
        }
    }
}
