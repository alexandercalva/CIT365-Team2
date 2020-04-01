using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.AspNetCore.Mvc.RazorPages;
using MegaDesk_RazorPages.Models;

namespace MegaDesk_RazorPages
{
    public class QuotesModel : PageModel
    {
        private readonly MegaDesk_RazorPages.Data.MegaDesk_RazorPagesContext _context;

        public QuotesModel(MegaDesk_RazorPages.Data.MegaDesk_RazorPagesContext context)
        {
            _context = context;
        }
        public IList<Desk> Desk { get; set; }

        public async Task OnGetAsync()
        {
            Desk = await _context.Desk.ToListAsync();
        }

    }
}