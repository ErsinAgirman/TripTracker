using Autofac;
using Autofac.Extensions.DependencyInjection;
using FluentValidation.AspNetCore;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Options;
using System.Reflection;
using TripTrackerAPI.Filters;
using TripTrackerAPI.Middlewares;
using TripTrackerAPI.Modules;
using TripTrackerCore.Repositories;
using TripTrackerCore.Services;
using TripTrackerCore.UnitOfWorks;
using TripTrackerRepository;
using TripTrackerRepository.Repositories;
using TripTrackerRepository.UnitOfWorks;
using TripTrackerService.Mapping;
using TripTrackerService.Services;
using TripTrackerService.Validations;


var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers(options=> { options.Filters.Add(new ValidateFilterAttribute());  })
	.AddFluentValidation(x => x.RegisterValidatorsFromAssemblyContaining<AdminDtoValidator>()); //??

builder.Services.Configure<ApiBehaviorOptions>(options =>
{
	options.SuppressModelStateInvalidFilter = true;
});

// Add services to the container.
builder.Services.AddControllers();
builder.Services.AddCors(options =>
{
    options.AddPolicy("AllowSpecificOrigin",
        builder => builder.WithOrigins("https://localhost:7195")
                          .AllowAnyHeader()
                          .AllowAnyMethod());
});



// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();


builder.Services.AddScoped(typeof(NotFoundFilter<>));
builder.Services.AddAutoMapper(typeof(MapProfile));

//builder.Services.AddScoped<IUnitOfWork, UnitOfWork>();
//builder.Services.AddScoped(typeof(IGenericRepository<>), typeof(GenericRepository<>));
//builder.Services.AddScoped(typeof(IService<>), typeof(Service<>));

//builder.Services.AddScoped<ITravelRepository, TravelRepository>();  //
//builder.Services.AddScoped<ITravelService, TravelService>();       //

builder.Services.AddDbContext<AppDbContext>(x =>
{
	x.UseSqlServer(builder.Configuration.GetConnectionString("SqlConnection"), options =>
	{
		options.MigrationsAssembly(Assembly.GetAssembly(typeof(AppDbContext)).GetName().Name);
	});
});



builder.Host.UseServiceProviderFactory
	(new AutofacServiceProviderFactory()); 

builder.Host.ConfigureContainer<ContainerBuilder>(containerBuilder => containerBuilder.RegisterModule(new RepoServiceModule()));	
		


var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseDeveloperExceptionPage();
}




// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
	app.UseSwagger();
	app.UseSwaggerUI();
}

app.UseHttpsRedirection(); //middleware's

app.UseRouting();

app.UseCors("AllowSpecificOrigin");

app.UseCustomException();

app.UseAuthorization();

app.MapControllers();

app.Run();
