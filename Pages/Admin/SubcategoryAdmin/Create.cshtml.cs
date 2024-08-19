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


namespace LitLounge.Pages.Admin.SubcategoryAdmin
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
        public Subcategory Subcategory { get; set; }
        public List<Category> Categories { get; set; }
        public List<Subcategory> Subcategories { get; set; }


        public async Task<IActionResult> OnGetAsync()
        {
            Categories = await _context.Category.ToListAsync();
            Subcategories = await _context.Subcategories.Include(s => s.Category)
                .ToListAsync();
            return Page();
        }


        public async Task<IActionResult> OnPostAsync()
        {
            //if (!ModelState.IsValid)
            //{

            //    Categories = await _context.Category.ToListAsync();
            //    Subcategories = await _context.Subcategories.Include(s => s.Category)
            //        .ToListAsync();
            //    return Page();
            //}

            _context.Subcategories.Add(Subcategory);
            await _context.SaveChangesAsync();

            return RedirectToPage("./Index");
        }
    }
}
