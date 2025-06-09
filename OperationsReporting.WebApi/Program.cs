using OperationsReporting.Services.Interfaces;
using OperationsReporting.Services;
using Microsoft.EntityFrameworkCore;
using OperationsReporting.DAL;
using OperationsReporting.Services.Mapping;
using OperationsReporting.DAL.Interfaces;
using OperationsReporting.DAL.Repositories;

var builder = WebApplication.CreateBuilder(args);


builder.Services.AddDbContext<OperationsReportingContext>(options =>
    options.UseNpgsql(builder.Configuration.GetConnectionString("DefaultConnection")));

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

var app = builder.Build();

if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();