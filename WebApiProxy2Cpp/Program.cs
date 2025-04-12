
using DotNetStandardCppWrapper;
using MathLibContract;

namespace WebApiProxy2Cpp
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var builder = WebApplication.CreateBuilder(args);

            // Add services to the container.
            builder.Services.AddSingleton<IMathLibService>(new SumIntsCallWrapper("CppSourceCodeProject.dll"));

                builder.Services.AddControllers();
            //  register Nswag services
            builder.Services.AddOpenApiDocument();

            var app = builder.Build();

            // Configure the HTTP request pipeline.
            if (app.Environment.IsDevelopment())
            {
                app.UseOpenApi();
                app.UseSwaggerUi();

            }

            app.UseHttpsRedirection();

            app.UseAuthorization();


            app.MapControllers();

            app.Run();
        }
    }
}
