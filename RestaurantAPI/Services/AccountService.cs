using RestaurantAPI.Entities;
using RestaurantAPI.Models;
using System.ComponentModel.DataAnnotations;

namespace RestaurantAPI.Services
{
    public interface IAccountService
    {
        void RegisterUser(RegisterUserDto dto);
    }
    public class AccountService : IAccountService
    {
        private readonly RestaurantDbContext _context;

        public AccountService(RestaurantDbContext context)
        {
            _context = context;
        }

        public void RegisterUser(RegisterUserDto dto)
        {
            var newUser = new User()
            {
                FirstName = dto.FirstName,
                LastName=dto.LastName,
                PasswordHash=dto.Password,
                Email = dto.Email,
                DateOfBirth = dto.DateOfBirth,
                Nationality = dto.Nationality,
                RoleId = 1,
            };

            _context.Users.Add(newUser);
            _context.SaveChanges();
        }
    }
    
}
