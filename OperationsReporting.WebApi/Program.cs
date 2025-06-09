using OperationsReporting.WebApi;

var app = WebApplication
                .CreateBuilder(args)
                .ConfigureServices()
                .ConfigurePipeline();

app.Run();