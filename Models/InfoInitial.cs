using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using MegaDesk_RazorPages.Data;
using System;
using System.Linq;

namespace MegaDesk_RazorPages.Models
{
    public static class InfoInitial
    {
        public static void Initialize(IServiceProvider serviceProvider)
        {
            using (var context = new MegaDesk_RazorPagesContext(
                serviceProvider.GetRequiredService<
                    DbContextOptions<MegaDesk_RazorPagesContext>>()))
            { 
                
                if (context.Desk.Any())
                {
                    return;   
                }

                context.Desk.AddRange(
                    new Desk
                    {
                        Name = "Alexander Calva",
                        DateOrder = DateTime.Parse("2020-2-25"),
                        Width = 35,
                        Depth = 35,
                        Drawers = 4,
                        Order = 5,
                        Material = "Laminate",
                        Price = 1760
                    }

                    
                );
                context.SaveChanges();
            }
        }
    }
}