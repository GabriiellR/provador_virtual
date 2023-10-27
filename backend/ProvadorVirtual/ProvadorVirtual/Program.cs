using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.EntityFrameworkCore;
using Microsoft.IdentityModel.Tokens;
using ProvadorVirtual.Adaptadores.Profiles;
using ProvadorVirtual.Aplicacao.Interfaces.Administracao;
using ProvadorVirtual.Aplicacao.Services;
using ProvadorVirtual.Data;
using ProvadorVirtual.Nucleo.Interfaces.Repositorio.Administracao;
using ProvadorVirtual.Nucleo.Interfaces.Services.Administracao;
using ProvadorVirtual.Repositorio.Administracao;
using ProvadorVirtual.Servicos.Services.Administracao;
using System.Text;
using System.Text.Json.Serialization;
//using ProvadorVirtual.Infraestrutura.


var builder = WebApplication.CreateBuilder(args);

builder.Services.AddControllers();
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
//builder.Services.RegisterModules();

builder.Services.AddScoped<IApplicationServiceUsuario, ApplicationServiceUsuario>();
builder.Services.AddScoped<IApplicationServiceTokenService, ApplicationServiceTokenService>();
builder.Services.AddScoped<IServiceUsuario, ServiceUsuario>();
builder.Services.AddScoped<IRepositoryUsuario, RepositoryUsuario>();


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
