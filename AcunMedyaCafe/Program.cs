
using AcunMedyaCafe.Context;
using FluentValidation;
using FluentValidation.AspNetCore;
using Microsoft.AspNetCore.Authentication.Cookies;
using System.Reflection;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddControllersWithViews();

builder.Services.AddDbContext<CafeContext>();
builder.Services.AddFluentValidationAutoValidation(). //ModelState is valid fluent validation entegresi
    AddFluentValidationClientsideAdapters(). //taray?c? taraf?nda hata göstermek için
    AddValidatorsFromAssembly(Assembly.GetExecutingAssembly()); // validator s?n?flar?n? tan?mas? için

//login için
builder.Services.AddAuthentication(CookieAuthenticationDefaults.AuthenticationScheme).AddCookie(options =>
{
    options.LoginPath = "/Login/";
    //LogOut EKLENÝLECEK
});



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
app.UseAuthentication();

app.UseEndpoints(endpoints =>
{
    endpoints.MapControllerRoute(
        name: "areas",
        pattern: "{area:exists}/{controller=Home}/{action=Index}/{id?}");
});


app.MapControllerRoute(
    name: "default",
    pattern: "{controller=Default}/{action=Index}/{id?}");



app.Run();


//var builder = WebApplication.CreateBuilder(args);

//builder.Services.AddAuthentication("AdminId")
//    .AddCookie("AdminId", options =>
//    {
//        options.LoginPath = "/Login/Index";
//        options.LogoutPath = "/Login/Logout";
//        options.AccessDeniedPath = "/Login/Index/";
//    });
//builder.Services.AddAuthorization();

//// Add services to the container.
//builder.Services.AddControllersWithViews();
//builder.Services.AddFluentValidationAutoValidation()
//    .AddFluentValidationClientsideAdapters()
//    .AddValidatorsFromAssembly(Assembly.GetExecutingAssembly());

//builder.Services.AddValidatorsFromAssemblyContaining<Category>();
////builder.Services.AddScoped<IValidator<Category>, CategoryValidator>();
////builder.Services.AddScoped<IValidator<Product>, ProductValidator>();
////builder.Services.AddScoped<IValidator<About>, AboutValidator>();
////builder.Services.AddScoped<IValidator<Address>, AddressValidator>();
////builder.Services.AddScoped<IValidator<Feature>, FeatureValidator>();
////builder.Services.AddScoped<IValidator<Testimonial>, TestimonialValidator>();
////builder.Services.AddScoped<IValidator<SocialMedia>, SocialMediaValidator>();
////builder.Services.AddScoped<IValidator<Gallery>, GalleryValidator>();
////builder.Services.AddScoped<IValidator<Admin>, AdminValidator>();
//builder.Services.AddDbContext<CafeContext>();

//var app = builder.Build();

//// Configure the HTTP request pipeline.
//if (!app.Environment.IsDevelopment())
//{
//    app.UseExceptionHandler("/Home/Error");
//    // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
//    app.UseHsts();
//}

//app.UseHttpsRedirection();
//app.UseStaticFiles();
//app.UseRouting();
//app.UseAuthentication();
//app.UseAuthorization();
//app.UseStatusCodePagesWithReExecute("/Error/Error404");



//app.MapControllerRoute(
//    name: "areas",
//    pattern: "{area:exists}/{controller=Home}/{action=Index}/{id?}"
//);


//app.MapControllerRoute(
//    name: "default",
//    pattern: "{controller=Default}/{action=Index}/{id?}");

//app.Run();