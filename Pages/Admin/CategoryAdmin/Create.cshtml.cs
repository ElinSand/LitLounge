using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using LitLounge.Data;
using LitLounge.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.AspNetCore.Authorization;

namespace LitLounge.Pages.Admin.CategoryAdmin
{
    [Authorize(Roles = "Admin")]
    public class CreateModel : PageModel
    {
        private readonly LitLounge.Data.LitLoungeContext _context;

        public CreateModel(LitLounge.Data.LitLoungeContext context)
        {
            _context = context;
        }

        [BindProperty]
        public Models.Category Category { get; set; }

        public List<Models.Category> Categories { get; set; }

        public async Task<IActionResult> OnGetAsync()
        {
            Categories = await _context.Category.ToListAsync();
            return Page();
        }

        //[BindProperty]
        //public Category Category { get; set; } = default!;

        // To protect from overposting attacks, see https://aka.ms/RazorPagesCRUD
        public async Task<IActionResult> OnPostAsync()
        {
            //if (!ModelState.IsValid)   Tog bort i efterhand
            //{
            //    Categories = await _context.Category.ToListAsync();
            //    return Page();
            //}

            _context.Category.Add(Category);
            await _context.SaveChangesAsync();

            return RedirectToPage("./Index");
        }
    }
}
