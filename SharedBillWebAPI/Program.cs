using Microsoft.AspNetCore.DataProtection;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using VaquinhaWebAPI.Data;
using VaquinhaWebAPI.Models;
using VaquinhaWebAPI.Repositories;
using VaquinhaWebAPI.Repositories.Interfaces;

var builder = WebApplication.CreateBuilder(args);


DirectoryInfo GetKyRingDirectoryInfo()
{
    string applicationBasePath = System.AppContext.BaseDirectory;
    DirectoryInfo directoryInof = new DirectoryInfo(applicationBasePath);
    string keyRingPath = builder.Configuration.GetSection("AppKeys").GetValue<string>("keyRingPath");
    do
    {
        directoryInof = directoryInof.Parent.Parent.Parent.Parent;
        DirectoryInfo keyRingDirectoryInfo = new DirectoryInfo(directoryInof.FullName + keyRingPath);
        if (keyRingDirectoryInfo.Exists)
        {
            return keyRingDirectoryInfo;
        }
    }
    while (directoryInof.Parent != null);
    throw new Exception("key ring path not found");
}
// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

var connectionString = builder.Configuration.GetConnectionString("Default") ?? throw new InvalidOperationException("Connection string 'DefaultConnection' not found.");


builder.Services.AddDbContext<VaquinhaContext>(options =>
    options.UseSqlServer(connectionString));



builder.Services.AddAutoMapper(AppDomain.CurrentDomain.GetAssemblies());


builder.Services.AddDataProtection().PersistKeysToFileSystem(GetKyRingDirectoryInfo()).SetApplicationName("SharedCookieApp");

builder.Services.Configure<CookiePolicyOptions>(options =>
{
    // This lambda determines whether user consent for nonessential cookies is needed for a given request.
    options.CheckConsentNeeded = context => true;
    options.MinimumSameSitePolicy = SameSiteMode.None;
});



builder.Services.AddAuthentication("Identity.Application").AddCookie("Identity.Application", option =>
{
    option.Cookie.Name = ".AspNet.SharedCookie";
    option.Events.OnRedirectToLogin = (context) =>
    {
        context.Response.StatusCode = 401;
        return Task.CompletedTask;
    };
});

//Habilita o CORS para aceitar requisições de outros domínios.
builder.Services.AddCors(options =>
{
    options.AddPolicy("CorsPolicy", builder => builder    
    .AllowCredentials()
    .WithOrigins("http://localhost:4200", "http://localhost:5247")
            .AllowAnyHeader()
            .AllowAnyMethod());
});

//builder.Services.AddScoped<IRepository<Pagante>, Repository<Pagante>>();
builder.Services.AddScoped(typeof(IRepository<>), typeof(Repository<>));
builder.Services.AddScoped<IDespesaRepository, DespesaRepository>();



var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}
app.UseCors("CorsPolicy");
app.UseHttpsRedirection();
app.UseCookiePolicy();

app.UseAuthentication();
app.UseAuthorization();

app.MapControllers();
app.Run();
