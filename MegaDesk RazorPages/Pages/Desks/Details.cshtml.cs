using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using MegaDesk_RazorPages.Data;
using MegaDesk_RazorPages.Models;

namespace MegaDesk_RazorPages
{
    public class DetailsModel : PageModel
    {
        private readonly MegaDesk_RazorPages.Data.MegaDesk_RazorPagesContext _context;

        public DetailsModel(MegaDesk_RazorPages.Data.MegaDesk_RazorPagesContext context)
        {
            _context = context;
        }

        public Desk Desk { get; set; }

        public async Task<IActionResult> OnGetAsync(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            Desk = await _context.Desk.FirstOrDefaultAsync(m => m.ID == id);

            if (Desk == null)
            {
                return NotFound();
            }
            return Page();
        }
    }
}
