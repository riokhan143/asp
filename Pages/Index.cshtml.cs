using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.Extensions.Logging;
using exercise22.Data;
using exercise22.Models;


namespace exercise22.Pages
{
    public class IndexModel : PageModel
    {
        private readonly exercise22.Data.InsuranceContext _context;
        
        [BindProperty]      
        public IList<PersonModel> PersonModel { get;set; }
        public IndexModel(exercise22.Data.InsuranceContext context)
        {
            _context = context;
        }
        public async Task OnGetAsync()
        {
            PersonModel = await _context.PersonModel.ToListAsync();
        }

    }
}
