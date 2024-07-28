using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using QLNhaSach.Models;

namespace QLNhaSach.Data
{
    public class QLNhaSachContext : IdentityDbContext<DefaultUser>
    {
        public QLNhaSachContext (DbContextOptions<QLNhaSachContext> options)
            : base(options)
        {
        }

        public DbSet<Book> Books { get; set; } = default!;
        public DbSet<CartItem> CartItems { get; set; }
        public DbSet<Bill> Bills { get; set; }
        public DbSet<BillItem> BillItems { get; set; }
        public DbSet<QLNhaSach.Models.Storage>? Storage { get; set; }
        public DbSet<QLNhaSach.Models.Complain>? Complain { get; set; }
    }
}
