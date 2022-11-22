using System;
using System.Linq;
using AutoMapper;
using Microsoft.AspNetCore.Authorization;
using WebApi.DbOperations;
using WebApi.Entities;

namespace WebApi.Application.AuthorOperations.Commands.UpdateAuthor
{
    public class UpdateAuthorCommand
    {
        public int AuthorId { get; set; }
        private readonly IBookStoreDbContext _dbContext;
        public UpdateAuthorModel Model {get; set;}
        public UpdateAuthorCommand(IBookStoreDbContext dbContext)
        {
            _dbContext = dbContext;
        }
        public void Handle()
        {
            var author = _dbContext.Authors.SingleOrDefault(x=>x.Id == AuthorId);
            if(author is null)
            throw new InvalidOperationException("Yazar Bulunamadı!");

            author.Name = string.IsNullOrEmpty(Model.Name.Trim())  ?  author.Name : Model.Name;
            author.SurName = string.IsNullOrEmpty(Model.Name.Trim())  ?  author.SurName : Model.SurName;
            _dbContext.SaveChanges();
        }

    }
    public class UpdateAuthorModel
    {
        public string Name { get; set; }
        public string SurName { get; set; }
    }
}