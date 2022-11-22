using WebApi.DbOperations;
using System;
using WebApi.Entities;
namespace TestSetup
{
    public static class Authors
    {
        public static void AddAuthors(this BookStoreDbContext context)
        {
        context.Authors.AddRange(
        new Author{Name = "Onur",SurName ="Koca",DateOfBirth = new DateTime(1996,01,01),BookId = 1},
        new Author{Name = "Mehmet",SurName = "Kozanoğlu",DateOfBirth = new DateTime(1996,06,12),BookId = 2},
        new Author{Name = "Mali",SurName ="Zorba",DateOfBirth = new DateTime(1996,03,24),BookId = 3});
        }
    }
}