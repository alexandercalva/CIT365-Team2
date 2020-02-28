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
            var materials = 0; ;
            var orderRush = 0;
            var basePrice = 200;
            // Calculate
            var widthNumber = int.Parse(Request.Form["width"]);
            Desk.Width = widthNumber;
            var depthNumber = int.Parse(Request.Form["depth"]);
            Desk.Depth = depthNumber;
            var area = widthNumber * depthNumber; // $1 per in2
            var drawersNumber = int.Parse(Request.Form["drawers"]);
            Desk.Drawers = drawersNumber;
            var drawers = drawersNumber * 50;
            var material = Request.Form["material"];
            Desk.Material = material;
            var order = int.Parse(Request.Form["order"]);
            Desk.Order = order;
            if (material == "Laminate")
                materials = 100;
            else if (material == "Oak")
                materials = 200;
            else if (material == "Pine")
                materials = 50;
            else if (material == "Rosewood")
                materials = 300;
            else if (material == "Veneer")
                materials = 125;

            if (order == 3 && area < 1000)
                orderRush = 60;

            else if (order == 5 && area < 1000)
                orderRush = 40;
            else if (order == 7 && area < 1000)
                orderRush = 30;

            if (order == 3 && (area >= 1000 && area <= 2000))
                orderRush = 70;
            else if (order == 5 && (area >= 1000 && area <= 2000))
                orderRush = 50;
            else if (order == 7 && (area >= 1000 && area <= 2000))
                orderRush = 35;

            if (order == 3 && area > 2000)
                orderRush = 80;
            else if (order == 5 && area > 2000)
                orderRush = 60;
            else if (order == 7 && area > 2000)
                orderRush = 40;

            Desk.Price = basePrice + area + drawers + materials + orderRush;

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
