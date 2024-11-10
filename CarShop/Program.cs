
using Blazorise;

using Blazorise.Material;
using CarShop.Components;
using CarShop.Service;
using Microsoft.AspNetCore.Antiforgery;
using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.AspNetCore.Components.Authorization;
using Microsoft.Data.SqlClient;
using Radzen;
using Repository;
using System.Data;
using Blazorise.Bootstrap;
using Blazorise.Icons.FontAwesome;

var builder = WebApplication.CreateBuilder(args);


//*************************************************************

// Configure authentication
builder.Services.AddAuthentication(CookieAuthenticationDefaults.AuthenticationScheme)
    .AddCookie(options => 
    {   
        options.Cookie.Name = "auth_token";
        options.LoginPath = "/login";
        options.Cookie.MaxAge = TimeSpan.FromMinutes(30);
        options.AccessDeniedPath = "/access-denied";
      //  options.Cookie.SameSite = SameSiteMode.None; // Permitir cookies entre sitios
      // options.Cookie.SecurePolicy = CookieSecurePolicy.Always; // Solo enviar cookies sobre HTTPS

    });

builder.Services.AddAuthorization();
builder.Services.AddCascadingAuthenticationState();

//*************************************************************

// Add services to the container.
builder.Services.AddRazorComponents()
    .AddInteractiveServerComponents();

//Radzen services
builder.Services.AddRadzenComponents();
builder.Services.AddScoped<DialogService>();
builder.Services.AddScoped<NotificationService>();
builder.Services.AddScoped<TooltipService>();
builder.Services.AddScoped<ContextMenuService>();

builder.Services
    .AddBlazorise(options =>
    {
        options.Immediate = true;
        //options.ChangesTextOnkeyPress = true;
    })
    .AddMaterialProviders()
    .AddBootstrapProviders()
   .AddFontAwesomeIcons();

//app services
builder.Services.AddScoped<ICars, CarsDAO>();
builder.Services.AddScoped<IPerson_Car, Person_CarDAO>();
builder.Services.AddScoped<ICarService, CarService>();
builder.Services.AddScoped<IUser, UserDAO>();
builder.Services.AddScoped<IPerson, PersonDAO>();
builder.Services.AddScoped<IPersonService, PersonService>();
builder.Services.AddScoped<IUserService, UserService>();
builder.Services.AddScoped<IMechanic, MechanicDAO>();
builder.Services.AddScoped<IMechanicService, MechanicService>();
builder.Services.AddScoped<IDocumentTypes, DocumentTypesDAO>();
builder.Services.AddScoped<ICarCategory, CarCategoryDAO>();
builder.Services.AddScoped<ISpecializations, SpecializationsDAO>();
builder.Services.AddScoped<IRoles, RolesDAO>();
builder.Services.AddScoped<IAuxiliaryListsService, AuxiliaryListsService>();

builder.Services.AddHttpContextAccessor(); // Asegúrate de agregar esto

//builder.Services.Configure<AntiforgeryOptions>(options =>
//{
  //  options.SuppressXFrameOptionsHeader = true; // Opción para suprimir el encabezado X-Frame-Options
  //  options.Cookie.SameSite = SameSiteMode.None; // Esto desactiva la validación CSRF
//});


//*************************************************************

//conexion BD
//builder.Services.AddSingleton<IDbConnection>((sp) => new OracleConnection(builder.Configuration.GetConnectionString("CONEXIONSQL")));
builder.Services.AddSingleton<IDbConnection>((sp) => new SqlConnection(builder.Configuration.GetConnectionString("CONEXIONSQL")));


var app = builder.Build();

// Configure the HTTP request pipeline.
if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Error", createScopeForErrors: true);
    // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
    app.UseHsts();
}

app.UseHttpsRedirection();

app.UseStaticFiles();
//app.UseRouting();

app.UseAuthentication();
app.UseAuthorization();
app.UseAntiforgery();

app.UseDeveloperExceptionPage();


app.MapRazorComponents<App>()
    .AddInteractiveServerRenderMode();
 

app.Run();
