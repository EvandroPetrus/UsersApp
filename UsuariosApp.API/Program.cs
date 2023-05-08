using UsuariosApp.API.Extensions;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddControllers();
builder.Services.AddRouting(options => options.LowercaseUrls = true);
builder.Services.AddSwaggerDoc();

var app = builder.Build();

app.UseHttpsRedirection();

app.UseSwaggerDoc();
app.UseAuthorization();
app.MapControllers();

app.Run();
