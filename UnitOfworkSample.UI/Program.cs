using Microsoft.CodeAnalysis.CSharp.Syntax;
using UnitOfWorkSample.Dal;
using UnitOfWorkSample.Dal.Entities;
using UnitOfWorkSample.Dal.Interfaces;
using UnitOfWorkSample.Dal.Repositories;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddControllersWithViews();
//builder.Services.AddScoped<IRepository<ClientEntity, int>>
//    ((s) => { return new ClientRepository(builder.Configuration.GetConnectionString("Dev"));});
//builder.Services.AddScoped<IRepository<FactureEntity, int>>
//    ((s) => { return new FactureRepository(builder.Configuration.GetConnectionString("Dev")); });
builder.Services.AddScoped<IUnitOfWork>
    ((s) => { return new UnitOfWork(builder.Configuration.GetConnectionString("Dev")); });

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
