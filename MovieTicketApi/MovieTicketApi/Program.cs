using MovieTicketApi.Repositories;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.IdentityModel.Tokens;
using System.Text;
using MovieTicketApi.Services;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();
builder.Services.AddSingleton<IUserRepository, UserRepository>();
builder.Services.AddSingleton<IMovieRepository, MovieRepository>();
builder.Services.AddSingleton<ITokenService, TokenService>();

builder.Services.AddCors(options =>
{
    options.AddPolicy("Policy", policy =>
    {
        policy.AllowAnyHeader()
        .AllowAnyMethod()
        .AllowAnyOrigin();
    });
});

builder.Services.AddAuthentication(JwtBearerDefaults.AuthenticationScheme)
    .AddJwtBearer(options =>
    {
        //object Configuration = null;
        //IConfiguration configuration;


        options.TokenValidationParameters = new TokenValidationParameters
        {
            ValidateIssuer = true,
            ValidateAudience = true,
            ValidateLifetime = true,
            ValidateIssuerSigningKey = true,
            ValidIssuer = builder.Configuration.GetSection("Jwt").GetValue<string>("Issuer"),
            ValidAudience = builder.Configuration.GetSection("Jwt").GetValue<string>("Audience"),
            IssuerSigningKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(builder.Configuration.GetSection("Jwt").GetValue<string>("Key")))



        };
    });



var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

app.UseCors();

app.UseAuthentication();
app.UseAuthorization();

app.MapControllers();

app.Run();

