using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using WebAPI.Data;

namespace WebAPI
{
    public class studentrazorModel : PageModel
    {
        private readonly WebAPI.Data.StudentContext _context;

        public studentrazorModel(WebAPI.Data.StudentContext context)
        {
            _context = context;
        }

        public IActionResult OnGet()
        {
            return Page();
        }

        [BindProperty]
        public StudentModel StudentModel { get; set; } = default!;
        

        // To protect from overposting attacks, see https://aka.ms/RazorPagesCRUD
        public async Task<IActionResult> OnPostAsync()
        {
          if (!ModelState.IsValid || _context.StudentModel == null || StudentModel == null)
            {
                return Page();
            }

            _context.StudentModel.Add(StudentModel);
            await _context.SaveChangesAsync();

            return RedirectToPage("./Index");
        }
    }
}
