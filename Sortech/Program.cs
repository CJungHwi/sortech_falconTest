using Sortech.Data;
using Sortech.DBConn;
using Sortech.Model_SqlServerDB;
using Sortech.Model_MariaDB;
using Syncfusion.Blazor;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddRazorPages();
builder.Services.AddServerSideBlazor();
builder.Services.AddSingleton<WeatherForecastService>();
builder.Services.AddSyncfusionBlazor();

builder.Services.Addsortech_SqlServerDBContext();
builder.Services.Addsortech_MariaDBContext();

builder.Services.AddTransient<IRepository_GroupCodeInfo, Repository_GroupCodeInfo>();
builder.Services.AddTransient<IRepository_CodeInfo, Repository_CodeInfo>();
builder.Services.AddTransient<IRepository_EmpInfo, Repository_EmpInfo>();
builder.Services.AddTransient<IRepository_M_Menulist, Repository_M_Menulist>();
builder.Services.AddTransient<IRepository_Menulist, Repository_Menulist>();

var app = builder.Build();

Syncfusion.Licensing.SyncfusionLicenseProvider.RegisterLicense("NzkxNDgxQDMyMzAyZTM0MmUzMGFsMEhMTWxSS1h4YWV6aVpFcnd6bGZ3Zm94eFBTbUlQdXZWQTZ2bEJ5KzA9");

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

app.MapBlazorHub();
app.MapFallbackToPage("/_Host");

app.Run();
