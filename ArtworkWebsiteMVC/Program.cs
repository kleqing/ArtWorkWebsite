using Services;

namespace ProductManagementWebClient
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var builder = WebApplication.CreateBuilder(args);
            void ConfigureHttpClient(HttpClient client)
            {
                client.BaseAddress = new Uri("https://localhost:7089/odata/");
            }
            builder.Services.AddHttpClient<IArtistServices, ArtistServices>(ConfigureHttpClient);
            builder.Services.AddHttpClient<IArtworkServices, ArtworkServices>(ConfigureHttpClient);
            builder.Services.AddHttpClient<INewsServices, NewsServices>(ConfigureHttpClient);

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

            app.MapControllerRoute(
                name: "default",
                pattern: "{controller=Home}/{action=Index}/{id?}");

            app.MapControllerRoute(
                name: "areas",
                pattern: "{area:exists}/{controller=Home}/{action=Index}/{id?}");


            app.Run();
        }
    }
}
