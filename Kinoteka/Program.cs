using Data;
using Microsoft.EntityFrameworkCore;
using Repository;
using Repository.ActorRepo;
using Repository.DirectorRepo;
using Repository.FilmRepo;
using Repository.GenreRepo;
using Servise.FilmSer;
using Service.ActorSer;
using Service.DirectorSer;
using Service.GenreSer;

var builder = WebApplication.CreateBuilder(args);

string connection = builder.Configuration.GetConnectionString("DefaultConnection");

builder.Services.AddDbContext<ApplicationContext>(options => options.UseSqlServer(connection));

// Add services to the container.
builder.Services.AddControllersWithViews();

builder.Services.AddScoped(typeof(IFilmRepository), typeof(FilmRepository));
builder.Services.AddScoped(typeof(IActorRepository), typeof(ActorRepository));
builder.Services.AddScoped(typeof(IDirectorRepository), typeof(DirectorRepository));
builder.Services.AddScoped(typeof(IGenreRepository), typeof(GenreRepository));

builder.Services.AddTransient<IFilmService, FilmService>();
builder.Services.AddTransient<IActorService, ActorService>();
builder.Services.AddTransient<IDirectorService, DirectorService>();
builder.Services.AddTransient<IGenreService, GenreService>();

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