using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using exercise22.Data;
using exercise22.Models;

namespace exercise22.Pages.Forms.PolicyHolder
{
    public class EditModel : PageModel
    {
        private readonly exercise22.Data.InsuranceContext _context;

        public EditModel(exercise22.Data.InsuranceContext context)
        {
            _context = context;
        }

        [BindProperty]
        public PersonModel PersonModel { get; set; }

        public async Task<IActionResult> OnGetAsync(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            PersonModel = await _context.PersonModel.FirstOrDefaultAsync(m => m.ID == id);

            if (PersonModel == null)
            {
                return NotFound();
            }
            return Page();
        }

        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see https://aka.ms/RazorPagesCRUD.
        public async Task<IActionResult> OnPostAsync()
        {
            if (!ModelState.IsValid)
            {
                return Page();
            }

            _context.Attach(PersonModel).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!PersonModelExists(PersonModel.ID))
                {
                    return NotFound();
                }
                else
                {
                    throw;
                }
            }

            return Page();
        }

        private bool PersonModelExists(int id)
        {
            return _context.PersonModel.Any(e => e.ID == id);
        }
    }
}
