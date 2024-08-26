using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using TripTrackerCore.Models;
using TripTrackerRepository;

// UI Program.cs
var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddControllersWithViews();

// DbContext'i ekleyin
builder.Services.AddDbContext<AppDbContext>(options =>
	options.UseSqlServer(builder.Configuration.GetConnectionString("SqlConnection")));

// Identity'yi ekleyin
builder.Services.AddIdentity<Staff, AppRole>()
	.AddEntityFrameworkStores<AppDbContext>()
	.AddDefaultTokenProviders();

//// Identity yapýlandýrmasý
//builder.Services.AddIdentity<Staff, AppRole>(options =>
//{
//	// Þifre kýsýtlamalarý
//	options.Password.RequireDigit = true; // Sayý gerektir
//	options.Password.RequireLowercase = true; // Küçük harf gerektir
//	options.Password.RequireNonAlphanumeric = false; // Alfanümerik olmayan karakterler gerektir
//	options.Password.RequireUppercase = true; // Büyük harf gerektir
//	options.Password.RequiredLength = 6; // En az 6 karakter uzunluðunda olmalýdýr

//	options.User.RequireUniqueEmail = true;
//})
//.AddEntityFrameworkStores<AppDbContext>()
//.AddDefaultTokenProviders();





// Add other services
builder.Services.AddControllersWithViews();

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

app.UseAuthentication(); // Kimlik doðrulama ekleyin
app.UseAuthorization();

app.MapControllerRoute(
	name: "default",
	pattern: "{controller=Home}/{action=Index}/{id?}");

app.Run();
