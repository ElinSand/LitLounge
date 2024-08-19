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

namespace LitLounge.Pages.Admin.SubcategoryAdmin
{
    [Authorize(Roles = "Admin")]
    public class DetailsModel : PageModel
    {
        private readonly LitLounge.Data.LitLoungeContext _context;

        public DetailsModel(LitLounge.Data.LitLoungeContext context)
        {
            _context = context;
        }

        public Subcategory Subcategory { get; set; } = default!;

        public async Task<IActionResult> OnGetAsync(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var subcategory = await _context.Subcategories.FirstOrDefaultAsync(m => m.Id == id);
            if (subcategory == null)
            {
                return NotFound();
            }
            else
            {
                Subcategory = subcategory;
            }
            return Page();
        }
    }
}
