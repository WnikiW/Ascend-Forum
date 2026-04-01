using Ascend_Forum.Core.Contracts;
using Ascend_Forum.Core.Implementations;
using Ascend_Forum.Infrastructure;
using Ascend_Forum.Infrastructure.Data;
using Ascend_Forum.Infrastructure.Data.Models;
using Ganss.Xss;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);
var connectionString = builder.Configuration.GetConnectionString("DefaultConnection") ?? throw new InvalidOperationException("Connection string 'DefaultConnection' not found.");

builder.Services.AddDbContext<AscendForumDbContext>(
    options =>
        options.UseSqlServer(
            connectionString, x => x.MigrationsAssembly("Ascend-Forum.Infrastructure")));

builder.Services.AddDatabaseDeveloperPageExceptionFilter();

builder.Services
    .AddDefaultIdentity<User>(
    options =>
    {
        options.SignIn.RequireConfirmedAccount = false;
        options.Password.RequireDigit = false;
        options.Password.RequireLowercase = false;
        options.Password.RequireNonAlphanumeric = false;
        options.Password.RequireUppercase = false;
        options.SignIn.RequireConfirmedEmail = false;
    })
    .AddRoles<IdentityRole>()
    .AddEntityFrameworkStores<AscendForumDbContext>();

builder.Services.AddControllersWithViews(options =>
{
    options.Filters.Add<GlobalExceptionFilter>();
    options.Filters.Add(new AutoValidateAntiforgeryTokenAttribute());
});

builder.Services.AddTransient<ICategoryService, CategoryService>();
builder.Services.AddTransient<IPostService, PostService>();
builder.Services.AddTransient<ICommentService, CommentService>();
builder.Services.AddTransient<IReactionService, ReactionService>();
builder.Services.AddTransient<IMemberService, MemberService>();

builder.Services.AddSingleton<IHtmlSanitizer, HtmlSanitizer>();

var app = builder.Build();

app
    .SeedDatabase();

if (app.Environment.IsDevelopment())
{
    app.UseMigrationsEndPoint();
}
else
{
    app.UseExceptionHandler("/Error/500");
    app.UseHsts();
}

app.UseStatusCodePagesWithReExecute("/Error/{0}");

app.UseHttpsRedirection();
app.UseRouting();

app.UseAuthentication();
app.UseAuthorization();

app.MapStaticAssets();

app
    .MapControllerRoute(
        name: "Areas", 
        pattern: "{area:exists}/{controller=Home}/{action=Index}/{id?}");

app.MapControllerRoute(
    name: "default",
    pattern: "{controller=Home}/{action=Index}/{id?}")
    .WithStaticAssets();

app.MapRazorPages()
   .WithStaticAssets();

app.Run();
