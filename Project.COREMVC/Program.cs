using Project.BLL.ServiceInjections;

WebApplicationBuilder builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddControllersWithViews();

builder.Services.AddDistributedMemoryCache(); //Eger Session kompleks yapýlarlar calýsmak icin Extension metodu eklenme durumuna marýz kalmýssa bu kod projenizin saglýklý calýsmasý icin gereklidir...

builder.Services.AddSession(x =>
{
    x.IdleTimeout = TimeSpan.FromDays(1); //Projeyi kiþinin bos durma süresi eger 5 dakikalýk bir süre olursa Session bosa cýksýn
    x.Cookie.IsEssential = true;
});

builder.Services.AddIdentityServices();
builder.Services.AddDbContextService(); //DbContextService'imizi BLL'den alarak middleware'e entegre ettik...

builder.Services.AddCookieServices();

builder.Services.AddRepServices();
builder.Services.AddManagerServices();

WebApplication app = builder.Build();

// Configure the HTTP request pipeline.
if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Home/Error");
}
app.UseStaticFiles();

app.UseRouting();

app.UseSession();

app.UseAuthentication();

app.UseAuthorization();

app.MapControllerRoute(
    name: "default",
    pattern: "{controller=Home}/{action=Index}/{id?}");

app.Run();
