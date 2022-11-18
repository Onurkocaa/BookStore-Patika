using System.ComponentModel.DataAnnotations.Schema;
using System;

namespace WebApi.Entities
{
    public class Author
    {
      [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
      public int Id { get; set; }

      public string Name { get; set; }
      public string SurName { get; set; }
      public DateTime DateOfBirth { get; set; }
      public int BookId { get; set; }
      public Book Book { get; set; }

    }
}