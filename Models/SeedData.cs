using QLNhaSach.Data;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Linq;
using QLNhaSach.Models;

namespace QLNhaSach.Models
{
    public class SeedData
    {
        public static void Initialize(IServiceProvider serviceProvider)
        {
            using (var context = new QLNhaSachContext(serviceProvider.GetRequiredService<DbContextOptions<QLNhaSachContext>>()))
            {
                if (context.Books.Any())    // Check if database contains any books
                {
                    return;     // Database contains books already
                }

                context.Books.AddRange(
                    new Book
                    {
                        BookName = "The Great Gatsby",
                        Description = "A novel about the American dream.",
                        Author = "F. Scott Fitzgerald",
                        Language = "English",
                        Publisher = "Scribner",
                        BookStatus = true,
                        Price = 10,
                        NumOfBook = 5,
                        ImageUrl = "/images/dac-nhan-tam.jpg"
                    },
                    new Book
                    {
                        BookName = "To Kill a Mockingbird",
                        Description = "A novel about racial injustice.",
                        Author = "Harper Lee",
                        Language = "English",
                        Publisher = "J.B. Lippincott & Co.",
                        BookStatus = true,
                        Price = 15,
                        NumOfBook = 7,
                        ImageUrl = "/images/dac-nhan-tam.jpg"
                    },
                    new Book
                    {
                        BookName = "1984",
                        Description = "A dystopian novel about totalitarianism.",
                        Author = "George Orwell",
                        Language = "English",
                        Publisher = "Secker & Warburg",
                        BookStatus = true,
                        Price = 12,
                        NumOfBook = 6,
                        ImageUrl = "/images/dac-nhan-tam.jpg"
                    },
                    new Book
                    {
                        BookName = "Pride and Prejudice",
                        Description = "A romantic novel about manners.",
                        Author = "Jane Austen",
                        Language = "English",
                        Publisher = "T. Egerton",
                        BookStatus = true,
                        Price = 8,
                        NumOfBook = 10,
                        ImageUrl = "/images/dac-nhan-tam.jpg"
                    },
                    new Book
                    {
                        BookName = "The Catcher in the Rye",
                        Description = "A novel about teenage rebellion.",
                        Author = "J.D. Salinger",
                        Language = "English",
                        Publisher = "Little, Brown and Company",
                        BookStatus = true,
                        Price = 10,
                        NumOfBook = 9,
                        ImageUrl = "/images/dac-nhan-tam.jpg"
                    },
                    new Book
                    {
                        BookName = "The Hobbit",
                        Description = "A fantasy novel about a hobbit's adventure.",
                        Author = "J.R.R. Tolkien",
                        Language = "English",
                        Publisher = "George Allen & Unwin",
                        BookStatus = true,
                        Price = 15,
                        NumOfBook = 4,
                        ImageUrl = "/images/dac-nhan-tam.jpg"
                    },
                    new Book
                    {
                        BookName = "Fahrenheit 451",
                        Description = "A dystopian novel about book burning.",
                        Author = "Ray Bradbury",
                        Language = "English",
                        Publisher = "Ballantine Books",
                        BookStatus = true,
                        Price = 9,
                        NumOfBook = 8,
                        ImageUrl = "/images/dac-nhan-tam.jpg"
                    },
                    new Book
                    {
                        BookName = "Moby-Dick",
                        Description = "A novel about a sea captain's obsession.",
                        Author = "Herman Melville",
                        Language = "English",
                        Publisher = "Harper & Brothers",
                        BookStatus = true,
                        Price = 11,
                        NumOfBook = 6,
                        ImageUrl = "/images/dac-nhan-tam.jpg"
                    },
                    new Book
                    {
                        BookName = "War and Peace",
                        Description = "A novel about the French invasion of Russia.",
                        Author = "Leo Tolstoy",
                        Language = "English",
                        Publisher = "The Russian Messenger",
                        BookStatus = true,
                        Price = 20,
                        NumOfBook = 3,
                        ImageUrl = "/images/dac-nhan-tam.jpg"
                    }
                );



                context.SaveChanges();
            }
            
        }
    }
}
