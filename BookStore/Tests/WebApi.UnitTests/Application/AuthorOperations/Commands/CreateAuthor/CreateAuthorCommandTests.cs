using AutoMapper;
using Microsoft.AspNetCore.Mvc.Formatters.Xml;
using TestSetup;
using WebApi.DbOperations;
using WebApi.Entities;
using System;
using Xunit;
using WebApi.Application.AuthorOperations.Commands.CreateAuthor;
using FluentAssertions;
using System.Linq;

namespace Application.AuthorOperations.Commands.CreateAuthor
{
public class CreateAuthorCommandTests :IClassFixture<CommonTestFixture>
{
    private readonly BookStoreDbContext _context;
    private readonly IMapper _mapper;
    public CreateAuthorCommandTests(CommonTestFixture testFixture)
    {
        _context = testFixture.Context;
        _mapper = testFixture.Mapper;
    }
    [Fact]
    public void WhenAlreadyExistAuthorTitleIsGiven_InvalidOperationsException_ShouldBeReturn()
    {
        var author = new Author(){Name="Deneme",SurName="string",DateOfBirth= new System.DateTime(1996,03,01),BookId=1};
        _context.Authors.Add(author);
        _context.SaveChanges();

        CreateAuthorCommand command = new CreateAuthorCommand(_mapper,_context);
        command.Model = new CreateAuthorModel(){Name=author.Name};

        FluentActions.Invoking(()=>command.Handle())
        .Should().Throw<InvalidOperationException>().And.Message.Should().Be("Yazar zaten mevcut");

    }
    [Fact]
        public void WhenValidInputAreGiven_Author_ShouldBeCreated()
        {
            CreateAuthorCommand command = new CreateAuthorCommand(_mapper,_context);
            command.Model= new CreateAuthorModel(){Name="WhenValidInputAreGiven_Author_ShouldBeCreated",SurName="string",BookId=5,PublishDate=DateTime.Now.Date.AddYears(-5) };
            
            FluentActions.Invoking(()=>command.Handle()).Invoke();
            var author = _context.Authors.SingleOrDefault(author=>author.Name==command.Model.Name);
            author.Should().NotBeNull();
        }
}
}