using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.EntityFrameworkCore;
using Microsoft.IdentityModel.Tokens;
using Microsoft.OpenApi.Models;
using Newtonsoft.Json;
using System.Text;
using TouristNavigator.Application.Interfaces.Repositories;
using TouristNavigator.Application.Interfaces.Services;
using TouristNavigator.Application.Security.Interfaces;
using TouristNavigator.Application.Security.Models;
using TouristNavigator.Application.Services;
using TouristNavigator.Domain.Entities;
using TouristNavigator.Infrastructure;
using TouristNavigator.Infrastructure.Repositories;
using TouristNavigator.Infrastructure.Security.Manager;
using TouristNavigator.Infrastructure.Security.Services;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
var section = builder.Configuration.GetSection("JsonTokensSettings");
builder.Services.Configure<JsonTokensSettings>(section);

var connectionString = builder.Configuration.GetConnectionString("DefaultConnection");

builder.Services.AddDbContext<ApplicationDbContext>(options =>
    options.UseSqlServer(connectionString));

builder.Services.AddScoped<IUserRepository, UserRepository>();
builder.Services.AddScoped<IPlaceRepository, PlaceRepository>();
builder.Services.AddScoped<IReviewRepository, ReviewRepository>();
builder.Services.AddScoped<ICategoryRepository, CategoryRepository>();
builder.Services.AddScoped<ICategoryIconRepository, CategoryIconRepository>();

builder.Services.AddScoped<IUserManager<ApplicationUser>, UserManager>();
builder.Services.AddScoped<ISignInManager<ApplicationUser>, SignInManager>();
builder.Services.AddScoped<IAuthenticationService, AuthenticationService>();

builder.Services.AddScoped<IUserService, UserService>();
builder.Services.AddScoped<IPlaceService, PlaceService>();
builder.Services.AddScoped<IReviewService, ReviewService>();
builder.Services.AddScoped<ICategoryService, CategoryService>();

builder.Services.AddAuthentication(options =>
{
    options.DefaultAuthenticateScheme = JwtBearerDefaults.AuthenticationScheme;
    options.DefaultChallengeScheme = JwtBearerDefaults.AuthenticationScheme;
}).AddJwtBearer(o =>
  {
      o.RequireHttpsMetadata = false;
      o.SaveToken = false;
      o.TokenValidationParameters = new TokenValidationParameters
      {
          ValidateIssuerSigningKey = true,
          ValidateIssuer = true,
          ValidateAudience = true,
          ValidateLifetime = true,
          ClockSkew = TimeSpan.Zero,
          ValidIssuer = builder.Configuration["JsonTokensSettings:Issuer"],
          ValidAudience = builder.Configuration["JsonTokensSettings:Audience"],
          IssuerSigningKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(builder.Configuration["JsonTokensSettings:Key"]))
      };

      o.Events = new JwtBearerEvents()
      {
          OnAuthenticationFailed = c =>
          {
              c.NoResult();
              c.Response.StatusCode = 500;
              c.Response.ContentType = "text/plain";
              return c.Response.WriteAsync(c.Exception.ToString());
          },
          OnChallenge = context =>
          {
              context.HandleResponse();
              context.Response.StatusCode = 401;
              context.Response.ContentType = "application/json";
              var result = JsonConvert.SerializeObject("401 Not authorized");
              return context.Response.WriteAsync(result);
          },
          OnForbidden = context =>
          {
              context.Response.StatusCode = 403;
              context.Response.ContentType = "application/json";
              var result = JsonConvert.SerializeObject("403 Not authorized");
              return context.Response.WriteAsync(result);
          },
      };
  });

builder.Services.AddControllers();
builder.Services.AddCors(options =>
{
    options.AddPolicy("Open",
        builder => builder.AllowAnyOrigin().AllowAnyHeader().AllowAnyMethod());
});
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen(c =>
{
    c.AddSecurityDefinition("Bearer", new OpenApiSecurityScheme
    {
        Description = @"JWT Authorization header using the Bearer scheme. \r\n\r\n 
              Enter 'Bearer' [space] and then your token in the text input below.
              \r\n\r\nExample: 'Bearer 12345abcdef'",
        Name = "Authorization",
        In = ParameterLocation.Header,
        Type = SecuritySchemeType.ApiKey,
        Scheme = "Bearer"
    });

    c.AddSecurityRequirement(new OpenApiSecurityRequirement()
          {
            {
              new OpenApiSecurityScheme
              {
                Reference = new OpenApiReference
                  {
                    Type = ReferenceType.SecurityScheme,
                    Id = "Bearer"
                  },
                  Scheme = "oauth2",
                  Name = "Bearer",
                  In = ParameterLocation.Header,

                },
                new List<string>()
              }
            });

    c.SwaggerDoc("v1", new OpenApiInfo
    {
        Version = "v1",
        Title = "TouristNavigator API",
    });

});

var app = builder.Build();

// Configure the HTTP request pipeline.
app.UseSwagger();
app.UseSwaggerUI();
   




//app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();