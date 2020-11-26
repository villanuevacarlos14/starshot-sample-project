using System;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Starshot.Data;
using Starshot.Data.Models;
using Starshot.DTO;

namespace Starshot.Service
{
    public interface IUserService
    {
        Task<UserDTO> GetUser(string userName, string password);
    }

    public class UserService : IUserService
    {
        private readonly IMapper _mapper;
        private readonly StarshotDbContext _dbContext;
        public UserService(StarshotDbContext dbContext, IMapper mapper)
        {
            _dbContext = dbContext;
            _mapper = mapper;
        }

        public async Task<UserDTO> GetUser(string userName, string password)
        {
           
            var user = await this._dbContext.Users.AsNoTracking().SingleOrDefaultAsync(x => x.UserName == userName);

            if (user != null)
            {
                var passwordVerificationResult = new PasswordHasher<object?>().VerifyHashedPassword(null, user.HashedPassword, password);

                if (passwordVerificationResult == PasswordVerificationResult.Success)
                {
                    return this._mapper.Map<User, UserDTO>(user);
                }
            }
         
            return null;
        }
    }
}
