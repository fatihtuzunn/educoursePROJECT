
using Microsoft.Extensions.Configuration;
using Microsoft.IdentityModel.Tokens;
using MongoDB.Driver;
using System;
using System.Collections.Generic;
using System.IdentityModel.Tokens.Jwt;
using System.Linq;
using System.Security.Claims;
using System.Text;
using webapi.Models;

namespace webapi.Services
{
    public class UserService
    {
        private readonly IMongoCollection<User> _users;

        private readonly string key;

        public UserService(IDatabaseSettings settings, IConfiguration configuration)
        {
            var client = new MongoClient(settings.ConnectionString);
            var database = client.GetDatabase(settings.DatabaseName);

            _users = database.GetCollection<User>(settings.CollectionName);

            this.key = configuration.GetSection("JwtKey").ToString();
        }

        public List<User> Get() =>
            _users.Find(user => true).ToList();

        public User Get(string id) =>
            _users.Find<User>(user => user.Id == id).FirstOrDefault();

        public User Create(User user)
        {
            _users.InsertOne(user);
            return user;
        }

        public void Update(string id, User bookIn) =>
            _users.ReplaceOne(book => book.Id == id, bookIn);

        public void Remove(User bookIn) =>
            _users.DeleteOne(book => book.Id == bookIn.Id);

        public void Remove(string id) =>
            _users.DeleteOne(book => book.Id == id);
        public string Authenticate(string email, string password)
        {
            var user = _users.Find(x => x.Email == email && x.Password == password).FirstOrDefault();
            if (user == null)
                return null;

            var tokenHandler = new JwtSecurityTokenHandler();
            var tokenKey = Encoding.ASCII.GetBytes(key);
            var tokenDescriptor = new SecurityTokenDescriptor()
            {
                Subject = new ClaimsIdentity(new Claim[]
                {
                    new Claim(ClaimTypes.Email, email),
                }),

                Expires = DateTime.UtcNow.AddHours(1),

                SigningCredentials = new SigningCredentials(
                    new SymmetricSecurityKey(tokenKey),
                    SecurityAlgorithms.HmacSha256Signature)
            };

            var token = tokenHandler.CreateToken(tokenDescriptor);

            return tokenHandler.WriteToken(token);

        }

    }

    


}

