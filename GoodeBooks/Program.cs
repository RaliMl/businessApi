using GoodeBooks.Data;
using GoodeBooks.Database;
using GoodeBooks.Models.Entities;
using GoodeBooks.Services.ViewModels.Volumes;
using Microsoft.AspNetCore.Cors.Infrastructure;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using GoodeBooks.Services.ServiceContracts.Volumes;
using GoodeBooks.Services.ServiceImplementations;
using GoodeBooks.Services.ServiceContracts.VolumeInfos;
using GoodeBooks.Services.ViewModels.SaleInfos;
using GoodeBooks.Services.ViewModels.SearchInfos;
using GoodeBooks.Services.ViewModels.VolumeInfos;
using GoodeBooks.Services.ServiceContracts.SaleInfos;
using GoodeBooks.Services.ServiceContracts.SearchInfos;
using GoodeBooks.Services.ViewModels.Authors;
using GoodeBooks.Services.ServiceContracts.Authors;
using GoodeBooks.Services.ServiceContracts.Bookshelves;
using GoodeBooks.Services.ViewModels.Bookshelves;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
var connectionString = builder.Configuration.GetConnectionString("DefaultConnection") ?? throw new InvalidOperationException("Connection string 'DefaultConnection' not found.");
builder.Services.AddDbContext<BookstoreDbContext>(options =>
options.UseLazyLoadingProxies().UseSqlServer(connectionString));

builder.Services.AddControllersWithViews();
builder.Services.AddScoped<IVolumeService, VolumeService>();
builder.Services.AddScoped<IVolumeInfoService, VolumeInfoService>();
builder.Services.AddScoped<ISaleInfoService, SaleInfoService>();
builder.Services.AddScoped<ISearchInfoService, SearchInfoService>();
builder.Services.AddScoped<IAuthorService, AuthorService>();
builder.Services.AddScoped<IBookshelfService, BookshelfService>();

builder.Services.AddAutoMapper(o =>
{
    o.CreateMap<Volume, VolumeViewModel>().ReverseMap();
    o.CreateMap<Volume, VolumeUpdateViewModel>().ReverseMap();
    o.CreateMap<Volume, VolumeCreateViewModel>().ReverseMap();

    o.CreateMap<VolumeInfo, VolumeInfoCreateViewModel>().ReverseMap();
    o.CreateMap<VolumeInfo, VolumeInfoViewModel>().ReverseMap();

    o.CreateMap<SaleInfo, SaleInfoCreateViewModel>().ReverseMap();
    o.CreateMap<SaleInfo, SaleInfoViewModel>().ReverseMap();
    o.CreateMap<SaleInfo, SaleInfoUpdateViewModel>().ReverseMap();

    o.CreateMap<SearchInfo, SearchInfoCreateViewModel>().ReverseMap();
    o.CreateMap<SearchInfo, SearchInfoViewModel>().ReverseMap();

    o.CreateMap<Author, AuthorCreateViewModel>().ReverseMap();
    o.CreateMap<Author, AuthorViewModel>().ReverseMap();

    o.CreateMap<Bookshelf, BookshelfCreateViewModel>().ReverseMap();
    o.CreateMap<Bookshelf, BookshelfViewModel>().ReverseMap();
});

//builder.Services.AddDatabaseDeveloperPageExceptionFilter();

builder.Services.AddDefaultIdentity<IdentityUser>(options => options.SignIn.RequireConfirmedAccount = true)
    .AddEntityFrameworkStores<BookstoreDbContext>();
//builder.Services.AddControllersWithViews();

var app = builder.Build();



// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseMigrationsEndPoint();
}
else
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
//app.MapRazorPages();

app.Run();
