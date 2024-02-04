using Asp.Versioning;
using blog_web_api_shared.DataTransferObjects;

namespace blog_web_api
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var builder = WebApplication.CreateBuilder(args);

            // Add services to the container.
            builder.Services.Configure<ConnectionDb>(builder.Configuration.GetSection("ConnectionDb"));
            builder.Services.ConfigureTransientService();
            builder.Services.ConfigureScopedService();
            builder.Services.AddControllers();
            builder.Services.ConfigureSwagger();
            builder.Services.ConfigureApiVersion();

            var app = builder.Build();

            app.UseSwagger();
            app.UseSwaggerUI();

            app.UseAuthorization();


            app.MapControllers();

            app.Run();
        }
    }
}
