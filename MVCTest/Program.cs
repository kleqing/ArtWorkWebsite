using Services;

namespace MVCTest
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
            builder.Services.AddHttpClient<IFeedbackServices, FeedbackServices>(ConfigureHttpClient);
            builder.Services.AddHttpClient<IDiscountServices, DiscountServices>(ConfigureHttpClient);
            builder.Services.AddHttpClient<IOrderDetailServices, OrderDetailServices>(ConfigureHttpClient);
            builder.Services.AddHttpClient<IOrderServices, OrderServices>(ConfigureHttpClient);
            builder.Services.AddHttpClient<IRolesServices, RolesServices>(ConfigureHttpClient);
            builder.Services.AddHttpClient<IUsersServices, UsersServices>(ConfigureHttpClient);
            builder.Services.AddHttpClient<IUserDetailsServices, UserDetailsServices>(ConfigureHttpClient);
            builder.Services.AddHttpClient<IUserRolesServices, UserRolesServices>(ConfigureHttpClient);
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

            app.Run();
        }
    }
}
