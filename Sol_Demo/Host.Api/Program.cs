using Module.Query.User;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle

// Add Framework Api.
builder.Services.AddFrameworkApi(builder.Configuration);

// Add Module
builder.Services.AddModuleCommandUser(builder.Configuration);
builder.Services.AddModuleQueryUser(builder.Configuration);

builder.Services.AddJson(true, true);

builder.Services.AddGzipResponseCompression(System.IO.Compression.CompressionLevel.Fastest);

builder.Services.AddJwtToken(builder.Configuration.GetValue<string>("SecretKey"));

builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseSecurityHeadersMiddleware();

app.UseResponseCompression();

app.UseException();

app.UseJwtToken();

app.UseAuthorization();

app.MapControllers();

app.Run();