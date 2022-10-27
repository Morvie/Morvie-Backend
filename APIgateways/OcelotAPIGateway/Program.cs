using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.IdentityModel.Tokens;
using Microsoft.OpenApi.Models;
using Ocelot.DependencyInjection;
using Ocelot.Middleware;
using OcelotAPIGateway;

var builder = WebApplication.CreateBuilder(args);


const string corsPolicyName = "cors-app-policy";

builder.Configuration.AddJsonFile("Ocelot.json");

//Add services to the container.
//Add Ocelot configurations.

builder.Services.AddCors(c => c.AddPolicy("CORS_policy", corsPolicyBuilder =>
{
    corsPolicyBuilder.WithOrigins("http://localhost:3000")
        .AllowAnyMethod()
        .AllowAnyHeader();
}));

//Configure JWT
builder.Services.ConfigureJWT(builder.Environment.IsDevelopment(), "MIIBIjANBgkqhkiG9w0BAQEFAAOCAQ8AMIIBCgKCAQEAidhPtqqZxoWtonBScBTh5PU5aj5gB9rMzpqeuohOnBLxIS8k+bxR4hM4SG2cFAiF/A/e7fJmhk7Xz8OtK8W0tUFc4ilnqOJvVtI8J39++ZU3PmTu3p+hyjjB96rF0O2Y3suOz8fxQSgUTMbTp2V0pJyStmC+8MlSptIQ7NvZA3dJgUiqF5L/u06huSEstpGhld1QZU4zu7QUKCBs/qn6orjxido3+rfaLIlUlnohFrdqRGBXDVQcfrR+09FirdMc/0xCKmkuwUZUMRZLqXk4ZkhxO1GGieOifCTPt1bV0KUDYsxXZny+rb8+Fl8FO1UFNcmuCtEZNLblD7mJJK9Z+wIDAQAB");

builder.Services.AddControllers();
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

builder.Services.AddOcelot(builder.Configuration);


var app = builder.Build();

app.UseCors("CORS_policy");

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseRouting();
app.UseAuthentication();
app.UseAuthorization();
app.UseEndpoints(endpoints =>
{
    app.MapControllers();
});
app.UseOcelot().Wait();
app.Run();