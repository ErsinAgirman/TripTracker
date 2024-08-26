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

//// Identity yap�land�rmas�
//builder.Services.AddIdentity<Staff, AppRole>(options =>
//{
//	// �ifre k�s�tlamalar�
//	options.Password.RequireDigit = true; // Say� gerektir
//	options.Password.RequireLowercase = true; // K���k harf gerektir
//	options.Password.RequireNonAlphanumeric = false; // Alfan�merik olmayan karakterler gerektir
//	options.Password.RequireUppercase = true; // B�y�k harf gerektir
//	options.Password.RequiredLength = 6; // En az 6 karakter uzunlu�unda olmal�d�r

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

app.UseAuthentication(); // Kimlik do�rulama ekleyin
app.UseAuthorization();

app.MapControllerRoute(
	name: "default",
	pattern: "{controller=Home}/{action=Index}/{id?}");

app.Run();
