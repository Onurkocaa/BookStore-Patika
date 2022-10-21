using System;
using System.Collections.Generic;
using System.Linq;
using WebApi.Common;
using WebApi.DbOperations;


namespace WebApi.BookOperations.UpdateBook
{
 public class UpdateBookCommand
 {
   private readonly BookStoreDbContext _context;
   public UpdateBookModel Model {get; set;}
   public int BookId { get; set; }
   public UpdateBookCommand(BookStoreDbContext Context)
   {
      _context = Context;
   }
   public void Handle()
   {
                var book = _context.Books.SingleOrDefault(x=> x.Id == BookId);
           if(book is null)
           throw new InvalidOperationException("Güncenlenecek Kitap Bulunamadı!");
           
           book.GenreId = Model.GenreId != default ? Model.GenreId : book.GenreId;
           book.Title = Model.Title != default ? Model.Title : book.Title;
           
           _context.SaveChanges();
   }
   public class UpdateBookModel
   {
    public string Title { get; set; }
    public int GenreId { get; set; }
   }
 }
}