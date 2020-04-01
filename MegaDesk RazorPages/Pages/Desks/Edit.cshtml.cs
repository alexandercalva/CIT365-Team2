using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using MegaDesk_RazorPages.Data;
using MegaDesk_RazorPages.Models;

namespace MegaDesk_RazorPages
{
    public class EditModel : PageModel
    {
        private readonly MegaDesk_RazorPages.Data.MegaDesk_RazorPagesContext _context;

        public EditModel(MegaDesk_RazorPages.Data.MegaDesk_RazorPagesContext context)
        {
            _context = context;
        }

        [BindProperty]
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

        // To protect from overposting attacks, please enable the specific properties you want to bind to, for
        // more details see https://aka.ms/RazorPagesCRUD.
        public async Task<IActionResult> OnPostAsync()
        {
            if (!ModelState.IsValid)
            {
                return Page();
            }

            //***************************************************************************************

            //ADD code to calculate the final price
            var materials = 0; ;
            var orderRush = 0;
            var basePrice = 200;
            // Calculate
            var area = Desk.Width * Desk.Depth; // $1 per in2
            var drawers = Desk.Drawers * 50;
            //var material = Request.Form["material"];
            // Desk.Material = material;

            // Materials
            if (Desk.Material == "Laminate")
                materials = 100;
            else if (Desk.Material == "Oak")
                materials = 200;
            else if (Desk.Material == "Pine")
                materials = 50;
            else if (Desk.Material == "Rosewood")
                materials = 300;
            else if (Desk.Material == "Veneer")
                materials = 125;

            // Orders
            if (Desk.Order == 3 && area < 1000)
                orderRush = 60;
            else if (Desk.Order == 5 && area < 1000)
                orderRush = 40;
            else if (Desk.Order == 7 && area < 1000)
                orderRush = 30;

            if (Desk.Order == 3 && (area >= 1000 && area <= 2000))
                orderRush = 70;
            else if (Desk.Order == 5 && (area >= 1000 && area <= 2000))
                orderRush = 50;
            else if (Desk.Order == 7 && (area >= 1000 && area <= 2000))
                orderRush = 35;

            if (Desk.Order == 3 && area > 2000)
                orderRush = 80;
            else if (Desk.Order == 5 && area > 2000)
                orderRush = 60;
            else if (Desk.Order == 7 && area > 2000)
                orderRush = 40;

            Desk.Price = basePrice + area + drawers + materials + orderRush;

            //**************************************************************************************


            _context.Attach(Desk).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!DeskExists(Desk.ID))
                {
                    return NotFound();
                }
                else
                {
                    throw;
                }
            }

            return RedirectToPage("./View");
        }

        private bool DeskExists(int id)
        {
            return _context.Desk.Any(e => e.ID == id);
        }
    }
}
