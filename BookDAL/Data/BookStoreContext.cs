using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using BookWebApp.Models;

namespace BookWebApp.Data
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
        public DbSet<BookWebApp.Models.SignUpUserModel>? SignUpUserModel { get; set; }
        public DbSet<BookWebApp.Models.SignInModel>? SignInModel { get; set; }
        public DbSet<BookWebApp.Models.ChangePasswordModel>? ChangePasswordModel { get; set; }

    }
}
