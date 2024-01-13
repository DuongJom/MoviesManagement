using MongoDB.Driver;
using MoviesManagement.Models;
using MoviesManagement.Repositories.Accounts;
using MoviesManagement.Services.Accounts;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddControllersWithViews();
builder.Services.Configure<DBSetting>(builder.Configuration.GetSection("DbSetting"));
builder.Services.AddSingleton<IMongoClient>(_ =>
{
    var connectionStr = builder.Configuration.GetSection("DbSetting:ConnectionString").Value;
    return new MongoClient(connectionStr);
});
builder.Services.AddSingleton<IAccountService, AccountService>();
builder.Services.AddSingleton<IAccountRepository, AccountRepository>();

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

app.UseAuthentication();
app.UseAuthorization();

app.MapControllerRoute(
    name: "default",
    pattern: "{controller=Home}/{action=Index}/{id?}");
app.MapControllerRoute(
    name: "Account",
    pattern: "{controller=Account}/{action=Index}");
app.MapControllerRoute(
    name: "Account",
    pattern: "{controller=Account}/{action=SignUp}");

app.Run();
