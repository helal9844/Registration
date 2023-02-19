using Microsoft.EntityFrameworkCore;
using DAL;
using BL;


namespace API_for_MobileAPP
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var builder = WebApplication.CreateBuilder(args);

            // Add services to the container.

            builder.Services.AddControllers();
            // Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
            builder.Services.AddEndpointsApiExplorer();
            builder.Services.AddSwaggerGen();

            //Database
            var connectionStrings = builder.Configuration.GetConnectionString("SkyCrowDB");
            builder.Services.AddDbContext<SkyContext>(options => options.UseSqlServer(connectionStrings));
            //builder.Services.AddDbContext<UserAuthContext>(options => options.UseSqlServer(connectionStrings));

            //Repos
            builder.Services.AddScoped<IUserRepo, UserRepo>();
            builder.Services.AddScoped<ICountryRepo, CountryRepo>();
            //automapper
            builder.Services.AddAutoMapper(typeof(AutoMapperProfile).Assembly);
            //Manager
            builder.Services.AddScoped<IUserManager, UserManager>();
            builder.Services.AddScoped<ICountryManager, CountryManager>();

            var app = builder.Build();

            // Configure the HTTP request pipeline.
            if (app.Environment.IsDevelopment())
            {
                app.UseSwagger();
                app.UseSwaggerUI();
            }

            app.UseHttpsRedirection();

            app.UseAuthorization();


            app.MapControllers();

            app.Run();
        }
    }
}