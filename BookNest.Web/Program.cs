using BookNest.Web.Data;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);
builder.Services.AddControllersWithViews();
builder.Services.AddDbContext<BookNestContext>(options =>
    options.UseSqlite(builder.Configuration.GetConnectionString("BookNest") ?? "Data Source=booknest.db"));

var app = builder.Build();

// An intentionally simple local-first portfolio application. A production application
// should use EF Core migrations, user accounts and per-user data isolation.
using (var scope = app.Services.CreateScope())
{
    var db = scope.ServiceProvider.GetRequiredService<BookNestContext>();
    db.Database.EnsureCreated();
}
if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Home/Error");
    app.UseHsts();
}
app.UseHttpsRedirection();
app.UseStaticFiles();
app.UseRouting();
app.MapControllerRoute(name:"default", pattern:"{controller=Books}/{action=Index}/{id?}");
app.Run();
