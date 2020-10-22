using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using WebApplication.DAL.Data;
using WebApplication.DAL.Entities;

namespace WebApplication.Areas.Admin.Pages
{
    public class DetailsModel : PageModel
    {
        private readonly WebApplication.DAL.Data.ApplicationDbContext _context;

        public DetailsModel(WebApplication.DAL.Data.ApplicationDbContext context)
        {
            _context = context;
        }

        public Phone Phone { get; set; }

        public async Task<IActionResult> OnGetAsync(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            Phone = await _context.Phones
                .Include(p => p.Group).FirstOrDefaultAsync(m => m.PhoneId == id);

            if (Phone == null)
            {
                return NotFound();
            }
            return Page();
        }
    }
}
