using MediatR;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.OpenApi.Models;
using MorvieReview.Application.Interfaces;
using MorvieReview.Infrastructure.Repositories;
using CommandsMediatR = MorvieReview.Application.Commands;
using QueriesMediatR = MorvieReview.Application.Queries;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen(c =>
{
    c.SwaggerDoc("v1", new OpenApiInfo { Title = "Morvie-Keycloak", Version = "v1" });

    //First we define the security scheme
    c.AddSecurityDefinition("Bearer", //Name the security scheme
    new OpenApiSecurityScheme
    {
        Description = "JWT Authorization header using the Bearer scheme.",
        Type = SecuritySchemeType.Http, //We set the scheme type to http since we're using bearer authentication
        Scheme = JwtBearerDefaults.AuthenticationScheme //The name of the HTTP Authorization scheme to be used in the Authorization header. In this case "bearer".
    });

    c.AddSecurityRequirement(new OpenApiSecurityRequirement{
            {
                new OpenApiSecurityScheme{
                    Reference = new OpenApiReference{
                    Id = JwtBearerDefaults.AuthenticationScheme, //The name of the previously defined security scheme.
                    Type = ReferenceType.SecurityScheme
                }
            },new List<string>()
        }
    });
});

// Dependency injections via MediatR:
builder.Services.AddMediatR(new Type[]
{
    typeof(CommandsMediatR.CreateReviewCommand),
    typeof(QueriesMediatR.GetAllReviews.GetAllReviewsQuery),
    typeof(QueriesMediatR.GetReview.GetReviewQuery)
});

// Inject normal dependencies:
builder.Services.AddScoped<ICommandReviewRepository, MockCommandReviewRepository>();
builder.Services.AddScoped<IQueryReviewRepository, MockQueryReviewRepository>();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

app.UseAuthentication();
app.UseAuthorization();

app.MapControllers();
app.Run();
