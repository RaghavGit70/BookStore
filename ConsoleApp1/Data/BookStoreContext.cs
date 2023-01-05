using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using ConsoleApp1.Models;

namespace ConsoleApp1.Data
{
    public class BookStoreContext : IdentityDbContext<ApplicationUser>
    {
        public BookStoreContext(DbContextOptions<BookStoreContext> options)
           : base(options)
        {

        }

        public DbSet<Books>? Books { get; set; }
        public DbSet<BookGallery>? BookGallery { get; set; }
        public DbSet<Language>? Language { get; set; }
        public DbSet<ConsoleApp1.Models.SignUpUserModel>? SignUpUserModel { get; set; }
        public DbSet<ConsoleApp1.Models.SignInModel>? SignInModel { get; set; }
        public DbSet<ConsoleApp1.Models.ChangePasswordModel>? ChangePasswordModel { get; set; }

    }
}
