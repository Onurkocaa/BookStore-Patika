using WebApi.DbOperations;
using AutoMapper;
using Microsoft.EntityFrameworkCore;
using System.Security.AccessControl;
using WebApi.Common;

namespace TestSetup
{
 public class CommonTestFixture 
 {
  public BookStoreDbContext Context {get; set;}
  public IMapper Mapper {get; set;}

  public CommonTestFixture()
  {
    var options = new DbContextOptionsBuilder<BookStoreDbContext>().UseInMemoryDatabase(databaseName:"BookStoreTestDB").Options;
    Context = new BookStoreDbContext(options);

    Context.AddBooks();
    Context.AddGenres();
    Context.AddAuthors();
    Context.SaveChanges();

    Mapper = new MapperConfiguration(cfg=> {cfg.AddProfile<MappingProfile>(); }).CreateMapper();
  }
 }
}