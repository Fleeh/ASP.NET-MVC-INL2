using ASPNETWEBCORE.Helpers;
using ASPNETWEBCORE.Models.data;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddControllersWithViews();
builder.Services.AddDbContext<AppDbContext>(x => x.UseSqlServer(builder.Configuration.GetConnectionString("Sql")));

builder.Services.AddScoped<IAddressManager, AddressManager>();
/*
builder.Services.AddScoped<IRoleManager, RoleManager>();
*/
builder.Services.AddIdentity<AppUser, IdentityRole>( x =>
{
    x.User.RequireUniqueEmail = true;
    x.Password.RequiredLength = 8;
}).AddEntityFrameworkStores<AppDbContext>();

builder.Services.ConfigureApplicationCookie(x =>
{
    x.LoginPath = "/authentication/signin";
});

builder.Services.AddScoped<IUserClaimsPrincipalFactory<AppUser>, ApplicationUserClaims>();

builder.Services.AddAuthorization(x =>
{
    x.AddPolicy("Admins", x => x.RequireRole("admin"));
    x.AddPolicy("AuthenticatedUsers", x => x.RequireRole("admin", "user"));
});



var app = builder.Build();

// Configure the HTTP request pipeline.
if (!app.Environment.IsDevelopment())
{
    app.UseDeveloperExceptionPage();
}
else
{
    app.UseStatusCodePagesWithReExecute("/Error/{0}");
    // app.UseExceptionHandler("/Home/Error"); //
    // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
    app.UseHsts();
}

app.UseHttpsRedirection();
app.UseStaticFiles();

app.UseRouting();

app.UseAuthentication();

app.UseAuthorization();

app.MapControllerRoute(
    name: "default",
    pattern: "{controller=Home}/{action=Index}/{id?}");

app.Run();
