using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using MegaDesk_RazorPages.Models;

namespace MegaDesk_RazorPages.Data
{
    public class MegaDesk_RazorPagesContext : DbContext
    {
        public MegaDesk_RazorPagesContext (DbContextOptions<MegaDesk_RazorPagesContext> options)
            : base(options)
        {
        }

        public DbSet<MegaDesk_RazorPages.Models.Desk> Desk { get; set; }
    }
}
