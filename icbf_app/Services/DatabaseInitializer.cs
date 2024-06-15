using Microsoft.AspNetCore.Identity;

namespace icbf_app.Services
{
    public class DatabaseInitializer
    {
        public static async Task  SeedDataAsync(UserManager<IdentityUser>? userManager,
            RoleManager<IdentityRole> roleManager)
        {
            if(userManager==null || roleManager == null)
            {
                Console.WriteLine("userManager or roleManager is null => exit");
                return;
            }
            //Revisar si existe el rol de administrador
            var exists = await roleManager.RoleExistsAsync("admin");
            if (!exists)
            {
                Console.WriteLine("Admin role is not defined and will be created");
                await roleManager.CreateAsync(new IdentityRole("admin"));
            }

            //Revisar si existe el rol de acudiente
            exists = await roleManager.RoleExistsAsync("acudiente");
            if (!exists)
            {
                Console.WriteLine("Acudiente role is not defined and will be created");
                await roleManager.CreateAsync(new IdentityRole("acudiente"));
            }

            //Revisar si existe el rol de madre comunitaria
            exists = await roleManager.RoleExistsAsync("madre");
            if (!exists)
            {
                Console.WriteLine("Madre role is not defined and will be created");
                await roleManager.CreateAsync(new IdentityRole("madre"));
            }

            var adminUsers = await userManager.GetUsersInRoleAsync("admin");
            if (adminUsers.Any())
            {
                //El admin ya esta creado
                Console.WriteLine("El usuario adminsitrador ya existe => exit");
                return;
            }

            //Crear el usuario administrador
            var user = new IdentityUser()
            {
                UserName = "admin.icbf@icbf.com",
                Email = "admin.icbf@icbf.com"
            };
            string defaultPassword = "Admin123#";

            var result= await userManager.CreateAsync(user,defaultPassword);
            if (result.Succeeded)
            {
                //modificar la tabla rol
                await userManager.AddToRoleAsync(user, "admin");
                Console.WriteLine("Admin user created successfully! Please update the initial password!");
                Console.WriteLine("Email: " + user.Email + " Initial password: " + defaultPassword);
            }
            else
            {
                Console.WriteLine("Unable to create Admin User: " + result.Errors.First().Description);
            }

        }
    }
}
