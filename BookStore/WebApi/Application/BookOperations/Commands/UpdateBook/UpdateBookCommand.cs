using System;
using System.Collections.Generic;
using System.Linq;
using WebApi.Common;
using WebApi.DbOperations;


namespace WebApi.Application.BookOperations.Commands.UpdateBook
{
 public class UpdateBookCommand
 {
   private readonly IBookStoreDbContext _context;
   public UpdateBookModel Model {get; set;}
   public int BookId { get; set; }
   public UpdateBookCommand(IBookStoreDbContext Context)
   {
      _context = Context;
   }
   public void Handle()
   {
                var book = _context.Books.SingleOrDefault(x=> x.Id == BookId);
           if(book is null)
           throw new InvalidOperationException("Güncellenecek Kitap Bulunamadı!");
           
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