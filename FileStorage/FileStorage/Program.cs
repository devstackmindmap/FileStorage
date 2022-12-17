// A request can access .jpg file by configuring the Static File Middleware as follows:
using Microsoft.Extensions.FileProviders;


// code generated
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using FileStorage.Data;

// The CreateBuilder method sets the content root to the current directory.
var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
// Create a WebApplicationBuilder with preconfigured defaults, add Razor Pages support to the Dependency Injection (DI) container, and builds the app:
builder.Services.AddRazorPages();

// code generated
builder.Services.AddDbContext<UserContext>(options =>
    options.UseSqlServer(builder.Configuration.GetConnectionString("UserContext") ?? throw new InvalidOperationException("Connection string 'UserContext' not found.")));

var app = builder.Build();

// Configure the HTTP request pipeline.
if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Error");
    // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
    app.UseHsts();
}

// Redirects HTTP requests to HTTPS.
app.UseHttpsRedirection();



// Enables static files, such as HTML, CSS, images, and JavaScript to be served. For more information, see Static files in ASP.NET Core.
// The parameterless UseStaticFiles method overload marks the files in web root as servable.
app.UseStaticFiles();
// Serve files outside of web root
app.UseStaticFiles(new StaticFileOptions
{
    FileProvider = new PhysicalFileProvider(
        Path.Combine(builder.Environment.ContentRootPath, "MyStaticFiles")), 
    RequestPath = "/StaticFiles"
});

// Adds route matching to the middleware pipeline. For more information, see Routing in ASP.NET Core
app.UseRouting();

// Authorizes a user to access secure resources. This app doesn't use authorization, therefore this line could be removed.
app.UseAuthorization();

// Configures endpoint routing for Razor Pages.
app.MapRazorPages();

// Runs the app.
app.Run();
