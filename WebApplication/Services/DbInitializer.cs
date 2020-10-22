using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WebApplication.DAL.Data;
using WebApplication.DAL.Entities;

namespace WebApplication.Services
{
    public class DbInitializer
    {
        public static async Task Seed(ApplicationDbContext context,
                                               UserManager<ApplicationUser> userManager,
                                               RoleManager<IdentityRole> roleManager)
        {
            context.Database.EnsureCreated();

            if (!context.Roles.Any())
            {
                var roleAdmin = new IdentityRole
                {
                    Name = "admin",
                    NormalizedName = "admin"
                };
                await roleManager.CreateAsync(roleAdmin);
            }

            if (!context.Users.Any())
            {
                var user = new ApplicationUser
                {
                    Email = "user@mail.ru",
                    UserName = "user@mail.ru"
                };
                await userManager.CreateAsync(user, "123456");

                var admin = new ApplicationUser
                {
                    Email = "admin@gmail.com",
                    UserName = "admin@mail.ru"
                };
                await userManager.CreateAsync(admin, "123456");
                admin = await userManager.FindByEmailAsync("admin@mail.ru");
                await userManager.AddToRoleAsync(admin, "admin");

            }
            // проверка наличия групп объектов
            if (!context.PhoneGroups.Any())
            {
                context.PhoneGroups.AddRange(
                    new List<PhoneGroup>
                    {
                        new PhoneGroup { GroupName = "BQ-Mobile" },
                        new PhoneGroup { GroupName = "TeXet" },
                        new PhoneGroup { GroupName = "Vertex" },
                        new PhoneGroup { GroupName = "ZTE" },
                        new PhoneGroup { GroupName = "Inoi" },
                        new PhoneGroup { GroupName = "Nobby" }
                    });
                await context.SaveChangesAsync();
            }

            // проверка наличия объектов
            if (!context.Phones.Any())
            {
                context.Phones.AddRange(
                    new List<Phone>
                    {
                        new Phone { PhoneName="TeXet TM-121 (черный)",  Description="экран 1.44 TFT (96x68), аккумулятор 500 мАч, 1 SIM", Price = 19.90, PhoneGroupId=2, Image="TeXet TM-121 (черный).jpg" },
                        new Phone { PhoneName="ZTE F327s (черный)",  Description="экран 2.4 TFT (240x320), карты памяти, камера 2 Мп, аккумулятор 1000 мАч, 2 SIM", Price =19.90, PhoneGroupId=4, Image="ZTE F327s (черный).jpg" },
                        new Phone { PhoneName="BQ-Mobile BQ-1805 Step (желтый)", Description="экран 1.77 TFT (128x160), ОЗУ 32 Мб, флэш-память 64 Мб, карты памяти, аккумулятор 600 мАч, 2 SIM", Price =20.11, PhoneGroupId=1, Image="BQ-Mobile BQ-1805 Step (желтый).jpeg" },
                        new Phone { PhoneName="Vertex M110 (черный)", Description="экран 1.77 TFT (128x160), карты памяти, аккумулятор 800 мАч, 2 SIM", Price =21.00, PhoneGroupId=3, Image="Vertex M110 (черный).jpg" },
                        new Phone { PhoneName="TeXet TM-128 (черный-красный)",  Description="экран 1.77 TFT (128x160), карты памяти, аккумулятор 500 мАч, 2 SIM", Price =21.90, PhoneGroupId=2, Image="TeXet TM-128 (черный-красный).jpg" }
                    });
                await context.SaveChangesAsync();
            }
        }
    }
}
