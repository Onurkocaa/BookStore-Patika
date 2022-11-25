using System;
using System.Linq;
using AutoMapper;
using Microsoft.Extensions.Configuration;
using WebApi.DbOperations;
using WebApi.Entities;
using WebApi.TokenOperations;
using WebApi.TokenOperations.Models;

namespace WebApi.Application.UserOperations.Commands.CreateToken
{
    public class CreateTokenCommand
    {
        public CreateTokenModel Model {get;set;}
        private readonly IBookStoreDbContext _dbContext;
        private readonly IMapper _mapper;
        private readonly IConfiguration _configuration;

        public CreateTokenCommand(IBookStoreDbContext dBContext, IMapper mapper, IConfiguration configuration)
        {
            _dbContext = dBContext;
            _mapper = mapper;
            _configuration = configuration;
        }

        public Token Handle()
        {
            var user = _dbContext.Users.FirstOrDefault(x=>x.Email==Model.email && x.Password==Model.password);
            if(user is not null)
            {
                //Token yarat
                TokenHandler handler = new TokenHandler(_configuration);
                Token token = handler.CreateAccessToken(user);

                user.RefreshToken = token.RefreshToken;
                user.RefreshTokenExpireDate= token.Expiration.AddMinutes(5);
                _dbContext.SaveChanges();
                return token;
            }
            else
            throw new InvalidOperationException("Kullancı adı ve Şifre Hatalı!");
            
        }
    }
    public class CreateTokenModel
    {
      public string email { get; set; }
      public string password { get; set; }
    }
}