using Smidge;

namespace SmidgeApp.Web
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var builder = WebApplication.CreateBuilder(args);


            builder.Services.AddSmidge(builder.Configuration.GetSection("smidge"));




            // Add services to the container.
            builder.Services.AddControllersWithViews();

            var app = builder.Build();

            // Configure the HTTP request pipeline.
            if (!app.Environment.IsDevelopment())
            {
                app.UseExceptionHandler("/Home/Error");
                // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
                app.UseHsts();
            }

            app.UseHttpsRedirection();
            app.UseStaticFiles();

            app.UseRouting();

            app.UseAuthorization();



            app.UseSmidge(bundle =>
            {
                bundle.CreateJs("my-js-bundle", "~/js/site.js", "~/js/site2.js");
                //hepsi ayný klasördeyse yukarýdaki gibi tek tek yazmaktansa sadece o klasörün yolunu da verebiliriz.
                //bundle.CreateJs("my-js-bundle", "~/js/");
                bundle.CreateCss("my-css-bundle", "~/css/site.css", "~/lib/bootstrap/dist/css/bootstrap.css");
            });

            app.MapControllerRoute(
                name: "default",
                pattern: "{controller=Home}/{action=Index}/{id?}");

            app.Run();
        }
    }
}