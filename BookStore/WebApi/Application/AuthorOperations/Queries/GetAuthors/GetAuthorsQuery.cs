using System;
using WebApi.DbOperations;
using AutoMapper;
using System.Linq;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;

namespace WebApi.Application.AuthorOperations.Queries.GetAuthors
{
    public class GetAuthorsQuery
    {
        private readonly BookStoreDbContext _dbContext;
        private readonly IMapper _mapper;
        public GetAuthorsQuery(BookStoreDbContext dbContext, IMapper mapper)
        {
            _dbContext = dbContext;
            _mapper = mapper;
        }
        public List<AuthorsViewModel> Handle()
        {
           var authors = _dbContext.Authors.OrderBy(x=>x.Id).ToList();
           List <AuthorsViewModel> returnobj = _mapper.Map<List<AuthorsViewModel>>(authors);
           return returnobj;

        }

    }
    public class AuthorsViewModel
    {
      public string Name { get; set; }
      public string SurName { get; set; }
      public DateTime DateOfBirth { get; set; }
    }
}