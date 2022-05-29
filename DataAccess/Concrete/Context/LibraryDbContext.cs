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
                new Book { BookId = 1, BookName = "1984", CategoryName ="Bilim-Kurgu, Distopik-Kurgu", NumberOfPages= 352, PublishingHouse= "MK Publications", Status=true, WriterFullName="George Orwell"},
                new Book { BookId = 2, BookName = "Varolmanın Dayanılmaz Hafifliği", CategoryName = "Roman", NumberOfPages =320, PublishingHouse = "HarperCollins Publishers", Status = true, WriterFullName = "Milan Kundera" },
                new Book { BookId = 3, BookName = "Hayvan Çiftliği", CategoryName = "Distopik Kurgu", NumberOfPages =112, PublishingHouse = "Secker & Warburg", Status = true, WriterFullName = "George Orwell" },
                new Book { BookId = 4, BookName = "Martı Jonathan Livingston", CategoryName = "Kişisel Gelişim", NumberOfPages =96, PublishingHouse = "Harpercollins", Status = true, WriterFullName = "Richard Bach" },
                new Book { BookId = 5, BookName = "Anne Frank'ın Hatıra Defteri", CategoryName = "Otobiyografi", NumberOfPages =356, PublishingHouse = "Puffin", Status = true, WriterFullName = "Anne Frank" },
                new Book { BookId = 6, BookName = "Fahrenheit 451", CategoryName = "Bilim-Kurgu", NumberOfPages =192, PublishingHouse = "HarperCollins", Status = true, WriterFullName = "Ray Bradbury" },
                new Book { BookId = 7, BookName = "Kürk Mantolu Madonna", CategoryName = "Roman", NumberOfPages = 160, PublishingHouse = "Penguin Classics", Status = true, WriterFullName = "Sabahattin Ali" });
        }
        public DbSet<Book> Books { get; set; }
        public DbSet<User> Users { get; set; }
        public DbSet<OperationClaim> OperationClaims { get; set; }
        public DbSet<UserOperationClaim> UserOperationClaims { get; set; }
    }
}
