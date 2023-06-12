using LoginAPI.Data;
using LoginAPI.Models;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Microsoft.AspNetCore.DataProtection;


 
var builder = WebApplication.CreateBuilder(args);


DirectoryInfo GetKyRingDirectoryInfo() {
    string applicationBasePath = System.AppContext.BaseDirectory;
    DirectoryInfo directoryInof = new DirectoryInfo(applicationBasePath);
    string keyRingPath = builder.Configuration.GetSection("AppKeys").GetValue<string>("keyRingPath");
    do {
        directoryInof = directoryInof.Parent.Parent.Parent;
        DirectoryInfo keyRingDirectoryInfo = new DirectoryInfo(directoryInof.FullName + keyRingPath);
        if (keyRingDirectoryInfo.Exists) {
            return keyRingDirectoryInfo;
        }
    }
    while (directoryInof.Parent != null);
    throw new Exception("key ring path not found");
}

// Add services to the container.
var connectionStringIdentity = builder.Configuration.GetConnectionString("DefaultConnection") ?? throw new InvalidOperationException("Connection string 'DefaultConnection' not found.");

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

builder.Services.AddDbContext<ApplicationDbContext>(options => 
    options.UseSqlServer(connectionStringIdentity));


 builder.Services.AddIdentity<ApplicationUser, IdentityRole>(options => {  
   }).AddEntityFrameworkStores<ApplicationDbContext>().AddDefaultTokenProviders(); 

builder.Services.Configure<IdentityOptions>(options => {

    //Configurações de senha
    options.Password.RequireDigit = true;
    options.Password.RequireLowercase = true;
    options.Password.RequireNonAlphanumeric = true;
    options.Password.RequireUppercase = true;
    options.Password.RequiredLength = 6;

    // Lockout settings.
    options.Lockout.DefaultLockoutTimeSpan = TimeSpan.FromMinutes(5);    
    options.Lockout.MaxFailedAccessAttempts = 5;
    options.Lockout.AllowedForNewUsers = true;
});

builder.Services.AddDataProtection()
    .PersistKeysToFileSystem(GetKyRingDirectoryInfo())
    .SetApplicationName("SharedCookieApp");

builder.Services.Configure<CookiePolicyOptions>(options => {
    options.ConsentCookieValue = "true";
    options.MinimumSameSitePolicy = SameSiteMode.None;    
});

builder.Services.AddAuthentication("Identity.Application");

builder.Services.ConfigureApplicationCookie(options => {
    //Configurações de cookies
    options.Cookie.HttpOnly = true;
    options.ExpireTimeSpan = TimeSpan.FromMinutes(5);
     //options.Cookie.Domain = "http://localhost";
     //options.LoginPath = "/Identity";
    // options.AccessDeniedPath = "/Identity/Account/AccessDenied";
   // options.SlidingExpiration = true;
    options.Cookie.Name = ".AspNet.SharedCookie"; 
    
});


builder.Services.AddCors(options =>
{
    options.AddPolicy("CorsPolicyLogin", builder => builder
    .AllowCredentials()
    .WithOrigins("http://localhost:4200", "http://localhost:5008")
            .AllowAnyHeader()
            .AllowAnyMethod());
});
var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}
app.UseCors("CorsPolicyLogin");
app.UseHttpsRedirection();

app.UseAuthentication();
app.UseAuthorization();
app.MapControllers();
app.Run(); 
