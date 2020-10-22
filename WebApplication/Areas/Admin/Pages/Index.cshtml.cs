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
    public class IndexModel : PageModel
    {
        private readonly WebApplication.DAL.Data.ApplicationDbContext _context;

        public IndexModel(WebApplication.DAL.Data.ApplicationDbContext context)
        {
            _context = context;
        }

        public IList<Phone> Phone { get;set; }

        public async Task OnGetAsync()
        {
            Phone = await _context.Phones
                .Include(p => p.Group).ToListAsync();
        }
    }
}
