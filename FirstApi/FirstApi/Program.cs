using Asp.Versioning;
using FirstApi.Context;
using FirstApi.DTOs.Mapping;
using FirstApi.Filters;
using FirstApi.Logging;
using FirstApi.Middlewares.ExceptionsMiddlewares;
using FirstApi.Models;
using FirstApi.Repositories.Implementations;
using FirstApi.Repositories.Interfaces;
using FirstApi.Services.Implementations;
using FirstApi.Services.Interfaces;
using FirstApi.UnitOfWork;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Microsoft.IdentityModel.Tokens;
using Microsoft.OpenApi.Models;
using System.Text;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen( c => {
    c.SwaggerDoc("v1", new OpenApiInfo { Title = "FirstApi", Version = "v1" });
} );

var connectionString = builder.Configuration.GetConnectionString("MySQL2");
builder.Services.AddDbContext<ApiContext>(options => {
    options.UseMySql(connectionString,
        ServerVersion.AutoDetect(connectionString));

});

builder.Services.AddScoped<ICategoriaRepository, CategoriaRepository>();
builder.Services.AddScoped<IProdutoRepository, ProdutoRepository>();
builder.Services.AddScoped<IUnitOfWork, UnitOfWork>();
builder.Services.AddScoped(typeof(IRepository<>), typeof(Repository<>));
builder.Services.AddScoped<ApiLoggingFilter>();
builder.Services.AddScoped<ITokenService, TokenService>();

builder.Logging.AddProvider(new CustomLoggerProvider(new CustomLoggerProviderConfiguration {
    LogLevel = LogLevel.Information
}));

var secretKey = builder.Configuration["JWT:SecretKey"] ?? throw new ArgumentException("Invalid Secret Key");

builder.Services.AddAuthentication(options => {
    options.DefaultAuthenticateScheme = JwtBearerDefaults.AuthenticationScheme;
    options.DefaultChallengeScheme = JwtBearerDefaults.AuthenticationScheme;
}).AddJwtBearer(options => {
    options.SaveToken = true;
    options.RequireHttpsMetadata = false;
    options.TokenValidationParameters = new TokenValidationParameters() {
        ValidateIssuer = true,
        ValidateAudience = true,
        ValidateLifetime = true,
        ValidateIssuerSigningKey = true,
        ClockSkew = TimeSpan.Zero,
        ValidAudience = builder.Configuration["JWT:ValidAudience"],
        ValidIssuer = builder.Configuration["JWT:ValidIssuer"],
        IssuerSigningKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(secretKey))
    };
});

builder.Services.AddAuthorization(options => {
    options.AddPolicy("AdminOnly", policy => policy.RequireRole("Admin"));

    options.AddPolicy("SuperAdminOnly", policy => policy.RequireRole("Admin").RequireClaim("id", "Iuri"));

    options.AddPolicy("UserOnly", policy => policy.RequireRole("User"));

    options.AddPolicy("ExclusiveOnly", policy => policy.RequireAssertion(context => context.User.HasClaim(claim => claim.Type == "id" &&
                                                                                                                    claim.Value == "Iuri") ||
                                                                                                                    context.User.IsInRole("SuperAdmin")));


});


builder.Services.AddApiVersioning(options => {

    options.DefaultApiVersion = new ApiVersion(1, 0);
    options.AssumeDefaultVersionWhenUnspecified = true;
    options.ReportApiVersions = true;
    options.ApiVersionReader = ApiVersionReader.Combine(
        new QueryStringApiVersionReader(),
        new UrlSegmentApiVersionReader());
}).AddApiExplorer( options => {
    options.GroupNameFormat = "'v'VVV";
    options.SubstituteApiVersionInUrl = true;
} );



builder.Services.AddAutoMapper(typeof(MappingProfile));
builder.Services.AddIdentity<ApplicationUser, IdentityRole>()
    .AddEntityFrameworkStores<ApiContext>()
    .AddDefaultTokenProviders(); 

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment()) {
    app.UseSwagger();
    app.UseSwaggerUI();
    app.ConfigureExceptionHandler();
}

app.UseHttpsRedirection();

app.UseAuthentication();

app.UseAuthorization();

app.MapControllers();

app.Run();
