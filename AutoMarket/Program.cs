using AutoMarket.Data;
using AutoMarket.Services.Core.Contracts;
using AutoMarket.Services.Core.Services;
using Microsoft.EntityFrameworkCore;

WebApplicationBuilder builder = WebApplication.CreateBuilder(args);

string connectionString = builder.Configuration.GetConnectionString("SqlServerDev")
                         ?? throw new InvalidOperationException("Connection string 'SqlServerDev' was not found! Please try again");

builder.Services.AddDbContext<AutoMarketDbContext>(opt =>
{
    opt.UseSqlServer(connectionString);
});

builder.Services.AddScoped<ICarListingService, CarListingService>();

builder.Services.AddControllersWithViews();

WebApplication app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseDeveloperExceptionPage();
}
else
{
    app.UseExceptionHandler("/Home/Error");
    app.UseHsts();
}

app.UseHttpsRedirection();
app.UseStaticFiles();

app.UseRouting();

app.UseAuthorization();

app.MapControllerRoute(
    name: "default",
    pattern: "{controller=Home}/{action=Index}/{id?}")
    .WithStaticAssets();


app.Run();
