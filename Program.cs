using FormulaUno.Services;

var builder = WebApplication.CreateBuilder(args);

// HttpClient apuntando a F1 API
builder.Services.AddHttpClient<F1Service>(c =>
{
    c.BaseAddress = new Uri("https://f1api.dev/api/");
});

builder.Services.AddControllersWithViews();

var app = builder.Build();

if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Home/Error");
    app.UseHsts();
}

app.UseHttpsRedirection();
app.UseStaticFiles();

app.UseRouting();
app.UseAuthorization();

// Ruta por defecto: Home/Index
app.MapControllerRoute(
    name: "default",
    pattern: "{controller=Home}/{action=Index}/{id?}");

app.Run();
