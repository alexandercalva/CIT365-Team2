using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using MegaDesk_RazorPages.Data;
using MegaDesk_RazorPages.Models;

namespace MegaDesk_RazorPages
{
    public class CreateModel : PageModel
    {
       
       
        private readonly MegaDesk_RazorPages.Data.MegaDesk_RazorPagesContext _context;

        public CreateModel(MegaDesk_RazorPages.Data.MegaDesk_RazorPagesContext context)
        {
            _context = context;
        }

        public IActionResult OnGet()
        {
            return Page();
        }

        [BindProperty]
        public Desk Desk { get; set; }

        // To protect from overposting attacks, please enable the specific properties you want to bind to, for
        // more details see https://aka.ms/RazorPagesCRUD.
        public async Task<IActionResult> OnPostAsync()
        {
            if (!ModelState.IsValid)
            {
                return Page();
            }

            
            Desk.DateOrder = DateTime.Today;
          //***************************************************************************************

                            //ADD code to calculate the final price

          //**************************************************************************************
            _context.Desk.Add(Desk);
            await _context.SaveChangesAsync();

            return RedirectToPage("./View");
        }
    }
    public class Calculate
    {
        
    }
   
}
