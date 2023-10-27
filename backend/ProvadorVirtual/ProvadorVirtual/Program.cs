using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.EntityFrameworkCore;
using Microsoft.IdentityModel.Tokens;
using ProvadorVirtual.Infraestrutura.Data;
using ProvadorVirtual.Infrastrutura.Crosscutting.Adaptadores.Profiles;
using ProvadorVirtual.Infrastrutura.Crosscutting.Ioc;
using System.Text;
using System.Text.Json.Serialization;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

builder.Services.AddAutoMapper(config => config.AddMaps(typeof(UsuarioProfile).Assembly));

var connectionString = builder.Configuration.GetConnectionString("sqlServer");
builder.Services.AddDbContext<Context>(prop => prop.UseSqlServer(connectionString,
                        assembly => assembly.MigrationsAssembly(typeof(Context).Assembly.FullName)));


var secret = builder.Configuration.GetSection("secret").Value;
builder.Services.AddAuthentication(options =>
{
    options.DefaultAuthenticateScheme = JwtBearerDefaults.AuthenticationScheme;
    options.DefaultChallengeScheme = JwtBearerDefaults.AuthenticationScheme;
    options.DefaultScheme = JwtBearerDefaults.AuthenticationScheme;
})
              .AddJwtBearer(options =>
              {
                  options.SaveToken = true;
                  options.RequireHttpsMetadata = false;
                  options.TokenValidationParameters = new TokenValidationParameters()
                  {
                      ValidateIssuer = false,
                      ValidateAudience = false,
                      IssuerSigningKey = new SymmetricSecurityKey(Encoding.ASCII.GetBytes(secret))
                  };
              });

builder.Services.AddControllers().AddJsonOptions(x =>
   x.JsonSerializerOptions.ReferenceHandler = ReferenceHandler.IgnoreCycles);

builder.Services.AddSwaggerGen();


builder.Services.RegisterModules();

var app = builder.Build();


if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseAuthentication();
app.UseAuthorization();

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();
