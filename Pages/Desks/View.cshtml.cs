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
    public class IndexModel : PageModel
    {
        private readonly MegaDesk_RazorPages.Data.MegaDesk_RazorPagesContext _context;

        public IndexModel(MegaDesk_RazorPages.Data.MegaDesk_RazorPagesContext context)
        {
            _context = context;
        }

        public string SortByName { get; set; }
        public string SortByDate { get; set; }
        public string SearchName { get; set; }
        public string SearchMaterial { get; set; }
        public string SortItems { get; set; }

        public IList<Desk> Desk { get; set; }
        public async Task OnGetAsync(int? page, string sortOrder, string searchName, string filterName, string searchMaterial, string filterMaterial)
        {
            SortItems = sortOrder;
            SortByName = String.IsNullOrEmpty(sortOrder) ? "name_desc" : "";
            SortByDate = sortOrder == "dateOrder" ? "dateOrder_desc" : "dateOrder";

            if (searchName != null || searchMaterial != null)
            {
                page = 1;
            }
            else
            {
                searchName = filterName;
                searchMaterial = filterMaterial;
            }

            SearchName = searchName;
            SearchMaterial = searchMaterial;

            var desks = from m in _context.Desk
                        select m;

            if (!String.IsNullOrEmpty(searchName))
            {
                desks = desks.Where(s => s.Name.Contains(searchName));
            }
            if (!string.IsNullOrEmpty(searchMaterial))
            {
                desks = desks.Where(s => s.Material.Contains(searchMaterial));
            }

            desks = sortOrder switch
            {
                "name_desc" => desks.OrderByDescending(s => s.Name),
                "name" => desks.OrderBy(s => s.Name),
                "dateOrder_desc" => desks.OrderByDescending(s => s.DateOrder),
                _ => desks.OrderBy(s => s.DateOrder),
            };
            Desk = await desks.ToListAsync();
        }
    }
}