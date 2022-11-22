using System;
using System.Collections.Generic;
using System.Linq;
using AutoMapper;
using Microsoft.EntityFrameworkCore;
using WebApi.DbOperations;

namespace WebApi.Application.AuthorOperations.Queries.GetAuthorDetail
{
    public class GetAuthorDetailQuery
    {
        public int AuthorId { get; set; }
        private readonly IBookStoreDbContext _dbContext;
        private readonly IMapper _mapper;
        public GetAuthorDetailQuery(IBookStoreDbContext dbContext, IMapper mapper)
        {
            _dbContext = dbContext;
            _mapper = mapper;
        }
        public AuthorDetailViewModel Handle()
        {
            var author = _dbContext.Authors.Include(x=>x.Book).SingleOrDefault(x=>x.Id == AuthorId);

            if(author is null)
            throw new InvalidOperationException("Yazar bulunamadı!");

            return _mapper.Map<AuthorDetailViewModel>(author);
        }

    }
    public class AuthorDetailViewModel
    {
        public string Name { get; set; }
        public string SurName { get; set; }
        public string DateOfBirth { get; set; }
        public string Book { get; set; }
    }
}
