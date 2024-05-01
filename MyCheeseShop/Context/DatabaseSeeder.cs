using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using MyCheeseShop.Model;

namespace MyCheeseShop.Context
{

    public class DatabaseSeeder
    {
        private readonly DatabaseContext _context;
        private readonly UserManager<User> _userManager;
        private readonly RoleManager<IdentityRole> _roleManager;

        public DatabaseSeeder(DatabaseContext context, UserManager<User> userManager, RoleManager<IdentityRole> roleManager)
        {
            _context = context;
            _userManager = userManager;
            _roleManager = roleManager;
        }

        
        public async Task Seed()    
        {
            await _context.Database.MigrateAsync();

            if (!_context.Users.Any())
            {
                await _roleManager.CreateAsync(new IdentityRole("Admin"));
                await _roleManager.CreateAsync(new IdentityRole("Customer"));

                var adminEmail = "admin@cheese.com";
                var adminPassword = "Cheese123!";

                var admin = new User
                {
                    UserName = adminEmail,
                    Email = adminPassword,
                    FirstName = "admin",
                    LastName = "User",
                    Address = "123 Admin Street",
                    City = "Adminville",
                    PostCode = "AD12 MIN"
                };

                await _userManager.CreateAsync(admin, adminPassword);
                await _userManager.AddToRoleAsync(admin, "admin");
            }
            if (!_context.Cheeses.Any())
            {
                var cheeses = GetCheeses();
                _context.Cheeses.AddRange(cheeses);
                await _context!.SaveChangesAsync();
            }
        }
        private List<Cheese> GetCheeses()
        {
            return
            [
                new Cheese { Name = "Cheddar", Type = "Hard", Description = "Sharp and tangy", Strength = "Medium", Price = 10, ImageURL = "cheddar.png" },
                new Cheese { Name = "Brie", Type = "Soft", Description = "Creamy and mild", Strength = "Mild", Price =12, ImageURL= "brie.png" },
                new Cheese { Name = "Gouda", Type = "Semi-hard", Description = "Smooth and nutty", Strength = "Medium", Price = 8, ImageURL="gouda.png" },
                new Cheese { Name = "Mozzarella", Type = "Soft", Description = "Mild and milky", Strength = "Mild", Price = 9, ImageURL="mozzarella.png" },
                new Cheese { Name = "Swiss", Type = "Hard", Description = "Nutty and sweet", Strength = "Medium", Price = 11, ImageURL="swiss.png" },
                new Cheese { Name = "Blue Cheese", Type = "Semi-soft", Description = "Sharp and tangy with blue mold", Strength = "Strong", Price = 14, ImageURL="blue.png" },
                new Cheese { Name = "Parmesan", Type = "Hard", Description = "Sharp and salty", Strength = "Strong", Price = 13, ImageURL="parmesan.png" },
                new Cheese { Name = "Feta", Type = "Soft", Description = "Tangy and crumbly", Strength = "Medium", Price = 10, ImageURL="feta.png" },
                new Cheese { Name = "Camembert", Type = "Soft", Description = "Creamy and earthy", Strength = "Medium", Price = 12, ImageURL="camembert.png" },
                new Cheese { Name = "Provolone", Type = "Semi-hard", Description = "Smooth and mild", Strength = "Medium", Price = 9, ImageURL="provolone.png" },
                new Cheese { Name = "Roquefort", Type = "Blue", Description = "Sharp and creamy with blue mold", Strength = "Strong", Price = 15, ImageURL="roquefort.png" },
                new Cheese { Name = "Havarti", Type = "Semi-soft", Description = "Creamy and buttery", Strength = "Medium", Price = 11,ImageURL="havarti.png" },
                new Cheese { Name = "Munster", Type = "Semi-soft", Description = "Creamy and mild", Strength = "Medium", Price = 10, ImageURL="munster.png" },
                new Cheese { Name = "Pepper Jack", Type = "Semi-hard", Description = "Spicy and creamy", Strength = "Medium", Price = 10, ImageURL="pepperjack.png" },
                new Cheese { Name = "Ricotta", Type = "Soft", Description = "Mild and creamy", Strength = "Mild", Price = 8, ImageURL="ricotta.png" },
                new Cheese { Name = "Fontina", Type = "Semi-soft", Description = "Nutty and earthy", Strength = "Medium", Price = 12, ImageURL="fontina.png" },
                new Cheese { Name = "Colby", Type = "Semi-hard", Description = "Mild and creamy", Strength = "Mild", Price = 9, ImageURL="colby.png" },
                new Cheese { Name = "Edam", Type = "Hard", Description = "Mild and nutty", Strength = "Medium", Price = 10, ImageURL="edam.png" },
                new Cheese { Name = "Emmental", Type = "Hard", Description = "Sharp and nutty", Strength = "Medium", Price = 11, ImageURL="emmental.png" },
                new Cheese { Name = "Gorgonzola", Type = "Blue", Description = "Sharp and creamy with blue mold", Strength = "Strong", Price = 14, ImageURL="gorgonzola.png" }
            ];
        
        }

    }

}
