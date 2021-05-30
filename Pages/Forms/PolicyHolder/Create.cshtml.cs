using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using exercise22.Data;
using exercise22.Models;

namespace exercise22.Pages.Forms.PolicyHolder
{
    public class CreateModel : PageModel
    {
        private readonly exercise22.Data.InsuranceContext _context;

        public CreateModel(exercise22.Data.InsuranceContext context)
        {
            _context = context;
        }

        public IActionResult OnGet()
        {
            return Page();
        }

        [BindProperty]
        public PersonModel PersonModel { get; set; }

        // To protect from overposting attacks, see https://aka.ms/RazorPagesCRUD
        /*public async Task<IActionResult> OnPostAsync()
        {
            if (!ModelState.IsValid)
            {
                return Page();
            }

            _context.PersonModel.Add(PersonModel);
            await _context.SaveChangesAsync();

            return RedirectToPage("./Index");
        }*/

        public async Task<IActionResult> OnPostAsync()
{
    var newPerson = new PersonModel();

    if (await TryUpdateModelAsync<PersonModel>(
        newPerson,
        "PersonModel",   // Prefix for form value.
        p => p.FirstName, p => p.LastName, p => p.Age,  p => p.DOB,  p => p.ID,  p => p.PolicyDetails,  p => p.Address
        )
        )
    {
        
        _context.Person.Add(newPerson);
        await _context.SaveChangesAsync();
    }

    return Page();
}
    }
}
