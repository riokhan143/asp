using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using exercise22.Data;
using exercise22.Models;

namespace exercise22.Pages.Forms.PolicyHolder
{
    public class DeleteModel : PageModel
    {
        private readonly exercise22.Data.InsuranceContext _context;

        public DeleteModel(exercise22.Data.InsuranceContext context)
        {
            _context = context;
        }

        [BindProperty]
        public PersonModel PersonModel { get; set; }

        public async Task<IActionResult> OnPostAsync(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            PersonModel = await _context.PersonModel.FindAsync(id);

            if (PersonModel != null)
            {
                _context.PersonModel.Remove(PersonModel);
                await _context.SaveChangesAsync();
            }
                return Page();
        }
    }
}
