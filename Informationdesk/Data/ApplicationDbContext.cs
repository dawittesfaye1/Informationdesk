using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using InformationDesk.Models;

namespace Informationdesk.Data
{
    public class ApplicationDbContext : IdentityDbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
            : base(options)
        {
        }
        public DbSet<InformationDesk.Models.Userinfo>? Userinfo { get; set; }
        public DbSet<InformationDesk.Models.Announcements>? Announcements { get; set; }
    }
}