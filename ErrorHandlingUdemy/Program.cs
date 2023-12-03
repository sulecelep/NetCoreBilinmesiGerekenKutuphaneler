using ErrorHandlingUdemy.Filter;

namespace ErrorHandlingUdemy
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var builder = WebApplication.CreateBuilder(args);

            // Add services to the container.
            builder.Services.AddControllersWithViews();

            //uygulama bazýnda oldu bütün kontrolörlerde bu hata sýnýfý çalýþacak
            builder.Services.AddMvc(options =>
            {
                options.Filters.Add(new CustomHandleExceptionFilterAttribute() { ErrorPage="Hata1" });
            });

            var app = builder.Build();

            // Configure the HTTP request pipeline.
            
            if(app.Environment.IsDevelopment())
            {

                app.UseDeveloperExceptionPage();
                //1.yol
                //app.UseStatusCodePages("text/plain","Bir hata var, durum kodu: {0}");
                
                app.UseDatabaseErrorPage();
                //2.yol
                app.UseStatusCodePages(async context =>
                {
                    context.HttpContext.Response.ContentType = "text/plain";
                    await context.HttpContext.Response.WriteAsync($"Bir hata var. Durum kodu: {context.HttpContext.Response.StatusCode}");
                });
                //3.yol
                //app.UseStatusCodePages();

            }
            if (!app.Environment.IsDevelopment())
            {
                //Yani development ortamda deðil kullanýcýlarda görünmesi gereken hatalar
                // app.UseExceptionHandler("/Home/Error");
                // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
                app.UseHsts();
            }
            //development ortamda da çalýþmasý için buaraya çýkardýk
            //app.UseExceptionHandler("/Home/Error");
            //app.UseExceptionHandler(context =>
            //{
            //    context.Run(async page =>
            //    {
            //        page.Response.StatusCode = 500;
            //        page.Response.ContentType = "text/html";
            //        await page.Response.WriteAsync($"<html><head></head><body><h1>Hata var: {page.Response.StatusCode} </h1></body></html>");
            //    });
            //});

            app.UseHttpsRedirection();
            app.UseStaticFiles();

            app.UseRouting();

            app.UseAuthorization();

            app.MapControllerRoute(
                name: "default",
                pattern: "{controller=Home}/{action=Index}/{id?}");

            app.Run();
        }
    }
}
