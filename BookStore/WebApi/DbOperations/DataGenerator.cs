using System;
using System.Linq;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using WebApi.Entities;

namespace WebApi.DbOperations
{
    public class DataGenerator
    {
        public static void Initialize(IServiceProvider serviceProvider)
        {
            using (var context = new BookStoreDbContext(serviceProvider.GetRequiredService<DbContextOptions<BookStoreDbContext>>()))
            {
                if(context.Books.Any())
                {
                    return;
                }
                context.Authors.AddRange(
                    new Author{
                    Name = "Onur",
                    SurName ="Koca",
                    DateOfBirth = new DateTime(1996,01,01),
                    BookId = 1

                    },
                    new Author{
                    Name = "Mehmet",
                    SurName = "Kozanoğlu",
                    DateOfBirth = new DateTime(1996,06,12),
                    BookId = 2
                    },
                    new Author{
                    Name = "Mali",
                    SurName ="Zorba",
                    DateOfBirth = new DateTime(1996,03,24),
                    BookId = 3
                    }
                );
                context.Genres.AddRange(
                    new Genre{
                        Name = "Personal Growth"


                    },
                    new Genre{
                        Name = "Science Fiction"


                    },
                    new Genre{
                        Name = "Ramance "


                    }
                );
                context.Books.AddRange(     
                    new Book
                    {
                      
                       Title="Lean Startup",
                       GenreId = 1, 
                       PageCount= 200,
                       PublishDate = new DateTime(2001,06,12)
                    },
                        new Book{
                     
                        Title="Herland",
                        GenreId = 1, 
                        PageCount= 250,
                        PublishDate = new DateTime(2010,05,23)
                    },
                        new Book{
                       
                        Title="Dune",
                        GenreId = 2, 
                        PageCount= 540,
                        PublishDate = new DateTime(2001,12,21)
                    }
                );

                context.SaveChanges();
            }
        }
    }
}