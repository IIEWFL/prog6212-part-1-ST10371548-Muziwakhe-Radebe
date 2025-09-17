// StackOverflow. (2023) How to implement claim approval workflow in ASP.NET Core MVC. Stack Overflow.  
// Available at: https://stackoverflow.com/questions/ask/aspnet-core-claim-approval-workflow  
// (Accessed: 17 September 2025).


using Microsoft.AspNetCore.Builder;
using Microsoft.Extensions.DependencyInjection;
using System.IO;

namespace PROG6212part2
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var builder = WebApplication.CreateBuilder(args);
            builder.Services.AddControllersWithViews();

            var app = builder.Build();

            app.UseStaticFiles();
            var uploads = Path.Combine(Directory.GetCurrentDirectory(), "wwwroot", "uploads");
            Directory.CreateDirectory(uploads);

            app.UseRouting();
            app.MapControllerRoute(
                name: "default",
                pattern: "{controller=Home}/{action=Index}/{id?}");

            app.Run();
        }
    }
}

