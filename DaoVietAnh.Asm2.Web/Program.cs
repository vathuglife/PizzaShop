using DaoVietAnh.Asm2.Repo.Services;
using DaoVietAnh.Asm2.Repo.Services.Implementation.AccountServiceImpl;
using DaoVietAnh.Asm2.Repo.Services.Implementation.CategoryServiceImpl;
using DaoVietAnh.Asm2.Repo.Services.Implementation.PizzaServiceImpl;
using DaoVietAnh.Asm2.Repo.Services.Implementation.SupplierServiceImpl;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddRazorPages();
builder.Services.AddScoped<IAccountService,AccountService>();
builder.Services.AddScoped<IPizzaService, PizzaService>();
builder.Services.AddScoped<ISupplierService,SupplierService>();
builder.Services.AddScoped<ICategoryService, CategoryService>();
builder.Services.AddSession(options =>
{
    options.IdleTimeout = TimeSpan.FromMinutes(30);
});

builder.Services.AddAntiforgery(o => o.HeaderName = "XSRF-TOKEN");
var app = builder.Build();

// Configure the HTTP request pipeline.
if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Error");
    // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
    app.UseHsts();
}

app.UseHttpsRedirection();
app.UseStaticFiles();

app.UseRouting();

app.UseAuthorization();
app.UseSession();
app.MapRazorPages();

app.Run();
