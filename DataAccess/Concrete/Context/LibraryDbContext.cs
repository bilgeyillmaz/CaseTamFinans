using Core.Entities.Concrete;
using Entities.Concrete;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccess.Concrete.Context
{
    public class LibraryDbContext: DbContext
    {
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer("server=MSI; database= LibraryDb; integrated security=true");
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Book>().HasData(
                new Book { BookId = 1, BookName = "1984", CategoryName ="Science Finction, Dystopian Finction", NumberOfPages= 352, PublishingHouse= "MK Publications", Status=true, WriterFullName="George Orwell"},
                new Book { BookId = 2, BookName = "The Unbearable Lightness of Being", CategoryName = "Novel", NumberOfPages =320, PublishingHouse = "HarperCollins Publishers", Status = true, WriterFullName = "Milan Kundera" },
                new Book { BookId = 3, BookName = "Animal Farm", CategoryName = "Dystopian Finction", NumberOfPages =112, PublishingHouse = "Secker & Warburg", Status = true, WriterFullName = "George Orwell" },
                new Book { BookId = 4, BookName = "Jonathan Livingston Seagull", CategoryName = "Self-Help", NumberOfPages =96, PublishingHouse = "Harpercollins", Status = true, WriterFullName = "Richard Bach" },
                new Book { BookId = 5, BookName = "The Diary of a Young Girl", CategoryName = "Autobiography", NumberOfPages =356, PublishingHouse = "Puffin", Status = true, WriterFullName = "Anne Frank" },
                new Book { BookId = 6, BookName = "Fahrenheit 451", CategoryName = "Science Finction", NumberOfPages =192, PublishingHouse = "HarperCollins", Status = true, WriterFullName = "Ray Bradbury" },
                new Book { BookId = 7, BookName = "Madonna in a Fur Coat", CategoryName = "Novel", NumberOfPages = 160, PublishingHouse = "Penguin Classics", Status = true, WriterFullName = "Sabahattin Ali" });
        }
        public DbSet<Book> Books { get; set; }
        public DbSet<User> Users { get; set; }
        public DbSet<OperationClaim> OperationClaims { get; set; }
        public DbSet<UserOperationClaim> UserOperationClaims { get; set; }
    }
}
