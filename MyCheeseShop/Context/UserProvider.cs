using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using MyCheeseShop.Model;

namespace MyCheeseShop.Context
{
    public class UserProvider
    {
        private readonly DatabaseContext _context;

        public User? GetUserByUsername(string? username)
        {
            return _context.Users.FirstOrDefault(user => user.UserName == username);
        }
    }
}
