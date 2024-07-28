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
                        BookName = "Dark Nhân Tâm",
                        Description = "A novel about the Dark of Tâm.",
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
                        BookName = "Cải thiện giao tiếp thành công",
                        Description = "A Book about Giao tiếp thành cong.",
                        Author = "Harper Lee",
                        Language = "English",
                        Publisher = "J.B. Lippincott & Co.",
                        BookStatus = true,
                        Price = 15,
                        NumOfBook = 7,
                        ImageUrl = "/images/DaleCarnegie.jpg"
                    },
                    new Book
                    {
                        BookName = "Dark Nhân Tâm Kiểu Nhật",
                        Description = "Vẫn là Dark Nhân Tâm nhưng là tiếng nhật.",
                        Author = "George Orwell",
                        Language = "English",
                        Publisher = "Secker & Warburg",
                        BookStatus = true,
                        Price = 12,
                        NumOfBook = 6,
                        ImageUrl = "/images/DNTJP.jpg"
                    },
                    new Book
                    {
                        BookName = "Hành trình về Phương đông",
                        Description = "Hành trình để di đến phương đông",
                        Author = "Jane Austen",
                        Language = "English",
                        Publisher = "T. Egerton",
                        BookStatus = true,
                        Price = 8,
                        NumOfBook = 10,
                        ImageUrl = "/images/HTVPN.jpg"
                    },
                    new Book
                    {
                        BookName = "Oshio",
                        Description = "Ohio.",
                        Author = "J.D. Salinger",
                        Language = "English",
                        Publisher = "Little, Brown and Company",
                        BookStatus = true,
                        Price = 10,
                        NumOfBook = 9,
                        ImageUrl = "/images/Osho.jpg"
                    },
                    new Book
                    {
                        BookName = "Xứ Anh Đào",
                        Description = "A book about a Japanese's adventure.",
                        Author = "J.R.R. Tolkien",
                        Language = "English",
                        Publisher = "George Allen & Unwin",
                        BookStatus = true,
                        Price = 15,
                        NumOfBook = 4,
                        ImageUrl = "/images/XAD.jpg"
                    },
                    new Book
                    {
                        BookName = "Mưu ế người xưa",
                        Description = "Sách hướng đẫn người câm nói được.",
                        Author = "Ray Bradbury",
                        Language = "English",
                        Publisher = "Ballantine Books",
                        BookStatus = true,
                        Price = 9,
                        NumOfBook = 8,
                        ImageUrl = "/images/MKNX.jpg"
                    },
                    new Book
                    {
                        BookName = "Xuất phát điểm",
                        Description = "1 cuốn sách về điểm bắt đầu",
                        Author = "Herman Melville",
                        Language = "English",
                        Publisher = "Harper & Brothers",
                        BookStatus = true,
                        Price = 11,
                        NumOfBook = 6,
                        ImageUrl = "/images/TTBP.jpg"
                    },
                    new Book
                    {
                        BookName = "Mô hình kinh doanh",
                        Description = "hướng dẫn để khoong bị scam khi kinh doanh",
                        Author = "Leo Tolstoy",
                        Language = "English",
                        Publisher = "The Russian Messenger",
                        BookStatus = true,
                        Price = 20,
                        NumOfBook = 3,
                        ImageUrl = "/images/mohinhkinhdoanh.jpg"
                    }
                );



                context.SaveChanges();
            }
            
        }
    }
}
