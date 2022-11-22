using System;
using System.Linq;
using System.Runtime.Serialization;
using AutoMapper;
using WebApi.DbOperations;
using WebApi.Entities;

namespace WebApi.Application.AuthorOperations.Commands.DeleteAuthor
{
    public class DeleteAuthorCommand
    {
        private readonly IBookStoreDbContext _dbContext;
        public int AuthorId { get; set; }
        public DeleteAuthorCommand(IBookStoreDbContext dbContext)
        {
            _dbContext = dbContext;
        }
        public void Handle()
        {
           var author = _dbContext.Authors.SingleOrDefault(x=>x.Id == AuthorId);
           if(author is null)
           throw new InvalidOperationException("Yazar bulunamadı!");
           _dbContext.Authors.Remove(author);
           _dbContext.SaveChanges();
        }
    }
}