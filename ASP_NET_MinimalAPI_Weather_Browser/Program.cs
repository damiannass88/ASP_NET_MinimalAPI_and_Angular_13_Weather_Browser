using FluentValidation; 
using Microsoft.IdentityModel.Tokens;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;
using MinimalAPI_Weather_Browser;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
var configuration = new ConfigurationBuilder()
               .SetBasePath(Directory.GetCurrentDirectory())
               .AddJsonFile("appsettings.json")
               .Build();
builder.Services.AddDbContext<WeatherEntityDB>(options =>
        options.UseSqlServer(
        configuration.GetConnectionString("DefaultConnection"),
        ef => ef.MigrationsAssembly(typeof(Weather).Assembly.FullName)));
 
  
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();
builder.Services.AddValidatorsFromAssemblyContaining(typeof(WeatherValidator));
builder.Services.AddAuthentication("Bearer")
    .AddJwtBearer(cfg =>
    {
        cfg.TokenValidationParameters = new Microsoft.IdentityModel.Tokens.TokenValidationParameters
        {
            ValidIssuer = builder.Configuration["JwtIssuer"],
            ValidAudience = builder.Configuration["JwtIssuer"],
            IssuerSigningKey = new SymmetricSecurityKey(
                Encoding.UTF8.GetBytes(builder.Configuration["JwtKey"]))
        };
    });

//CORS Configuration
var MyAllowSpecificOrigins = "_myAllowSpecificOrigins";
builder.Services.AddCors(options =>
{
    options.AddPolicy(name: MyAllowSpecificOrigins,
                      builder =>
                      {
                          builder.WithOrigins("https://localhost:4200", "https://127.0.0.1:4200",
                                              "http://localhost:4200", "http://127.0.0.1:4200");
                      });
});


builder.Services.AddAuthorization();

var app = builder.Build();

app.UseCors(MyAllowSpecificOrigins);

app.UseAuthentication();
app.UseAuthorization();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

app.RegisterEndpoints();

app.MapGet("/token", () =>
{
    var claims = new[]
    {
        new Claim(ClaimTypes.NameIdentifier, "user-id"),
        new Claim(ClaimTypes.Name, "Administrator"),
        new Claim(ClaimTypes.Role, "Admin"),
    };

    var token = new JwtSecurityToken
    (
        issuer: builder.Configuration["JwtIssuer"],
        audience: builder.Configuration["JwtIssuer"],
        claims: claims,
        expires: DateTime.UtcNow.AddDays(10),
        notBefore: DateTime.UtcNow,
        signingCredentials: new SigningCredentials(
            new SymmetricSecurityKey(Encoding.UTF8.GetBytes(builder.Configuration["JwtKey"])),
            SecurityAlgorithms.HmacSha256)
    );

    var jwtToken = new JwtSecurityTokenHandler().WriteToken(token);
    return jwtToken;
});

app.MapGet("/identification", (ClaimsPrincipal user) =>
{
    var userName = user.Identity.Name;
    return $"Hello {userName}";
});

app.Run();