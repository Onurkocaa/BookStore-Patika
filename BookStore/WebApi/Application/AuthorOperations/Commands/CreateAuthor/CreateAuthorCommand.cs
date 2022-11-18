using System;
using System.Linq;
using AutoMapper;
using WebApi.DbOperations;
using WebApi.Entities;

namespace WebApi.Application.AuthorOperations.Commands.CreateAuthor
{
    public class CreateAuthorCommand
    {
        private readonly IMapper _mapper;
        private readonly BookStoreDbContext _dbContext;
        public CreateAuthorModel Model {get; set;}
        public CreateAuthorCommand(IMapper mapper, BookStoreDbContext context)
        {
            _mapper = mapper;
            _dbContext = context;
        }
        public void Handle()
        {
            var author = _dbContext.Authors.SingleOrDefault(x=>x.Name == Model.Name);
         if(author is not null)
         throw new InvalidOperationException("Yazar zaten mevcut");
         author = _mapper.Map<Author>(Model);
         _dbContext.Authors.Add(author);
         _dbContext.SaveChanges();

        }

    }
    public class CreateAuthorModel
    {
    public string Name { get; set; }
      public string SurName { get; set; }
      public DateTime PublishDate { get; set; }
      public int BookId { get; set; }

    }
}