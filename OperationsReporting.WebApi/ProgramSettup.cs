using OperationsReporting.DAL.Interfaces;
using OperationsReporting.DAL.Repositories;
using OperationsReporting.DAL;
using OperationsReporting.Services.Interfaces;
using OperationsReporting.Services.Mapping;
using OperationsReporting.Services;
using Microsoft.EntityFrameworkCore;
using OperationsReporting.WebApi.Middleware;


namespace OperationsReporting.WebApi
{
    internal static class ProgramSettup
    {
        public static WebApplication ConfigureServices(this WebApplicationBuilder builder)
        {
            builder.Services.AddDbContext<OperationsReportingContext>(options =>
                options.UseNpgsql(builder.Configuration.GetConnectionString("DefaultConnection")).UseSnakeCaseNamingConvention());

            builder.Services.AddControllers();

            builder.Services.AddEndpointsApiExplorer();
            builder.Services.AddSwaggerGen();

            // AutoMapper
            builder.Services.AddAutoMapper(typeof(TransactionMappingProfile).Assembly);

            //services
            builder.Services.AddScoped<IMerchantService, MerchantService>();
            builder.Services.AddScoped<IPartnerService, PartnerService>();
            builder.Services.AddScoped<ITransactionService, TransactionService>();
            builder.Services.AddScoped<IExportService, ExportService>();

            // repositories
            builder.Services.AddScoped<IPartnerRepository, PartnerRepository>();
            builder.Services.AddScoped<IMerchantRepository, MerchantRepository>();
            builder.Services.AddScoped<ITransactionRepository, TransactionRepository>();

            return builder.Build();
        }
        public static WebApplication ConfigurePipeline(this WebApplication app)
        {
            if (app.Environment.IsDevelopment())
            {
                app.UseSwagger();
                app.UseSwaggerUI();
            }

            app.UseMiddleware<GlobalErrorHandler>();

            app.UseHttpsRedirection();

            app.UseAuthorization();

            app.MapControllers();

            return app;
        }
    }
}
