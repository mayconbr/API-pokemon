    using Pokedex.Repositories;
    using Pokedex.Interfaces;
    using Pokedex;
    using Microsoft.AspNetCore.Authentication.JwtBearer;
    using Microsoft.IdentityModel.Tokens;
    using System.Text;
    using Microsoft.EntityFrameworkCore;

    var builder = WebApplication.CreateBuilder(args);

// Configura a conexão com o banco de dados
var connectionString = builder.Configuration.GetConnectionString("Database");

// Exemplo: Se estiver usando Entity Framework Core
builder.Services.AddDbContext<Context>(options =>
    options.UseMySql(connectionString, ServerVersion.AutoDetect(connectionString)));

// Configurar o JWT
var jwtSettings = builder.Configuration.GetSection("JwtSettings").Get<JwtSettings>();
    builder.Services.AddAuthentication(options =>
    {
        options.DefaultAuthenticateScheme = JwtBearerDefaults.AuthenticationScheme;
        options.DefaultChallengeScheme = JwtBearerDefaults.AuthenticationScheme;
    }).AddJwtBearer(options =>
    {
        options.TokenValidationParameters = new TokenValidationParameters
        {
            ValidateIssuer = true,
            ValidateAudience = true,
            ValidateLifetime = true,
            ValidateIssuerSigningKey = true,
            ValidIssuer = jwtSettings.Issuer,
            ValidAudience = jwtSettings.Audience,
            IssuerSigningKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(jwtSettings.Secret))
        };
    });

    // Adicionar autenticação ao pipeline
    builder.Services.AddAuthorization();

    // Add services to the container.
    builder.Services.AddControllersWithViews();

    // Adicione o repositório ao container de serviços
    builder.Services.AddScoped<Context, Context>();
    builder.Services.AddScoped<IPokemonRepository, PokemonRepository>();
    builder.Services.AddScoped<ITreinadorepository, TreinadorRepository>();
    builder.Services.AddScoped<JwtTokenService>();
    builder.Services.AddScoped<LoginRepository>();
    var app = builder.Build();

    // Configure the HTTP request pipeline.
    if (!app.Environment.IsDevelopment())
    {
        app.UseExceptionHandler("/Home/Error");
        // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
        app.UseHsts();
    }

    app.UseHttpsRedirection();
    app.UseStaticFiles();

    app.UseRouting();

    app.UseAuthorization();

    app.MapControllerRoute(
        name: "default",
        pattern: "{controller=Home}/{action=Index}/{id?}");

    app.Run();
