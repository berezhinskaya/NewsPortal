using NewsPortal.Services;
using NewsPortal.Data;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);

// Добавляем базу данных
builder.Services.AddDbContext<AppDbContext>(options =>
    options.UseSqlite("Data Source=news.db"));

// РЕШЕНИЕ ОШИБКИ CS1929:
// Если AddInteractiveServerComponents не работает, используем базовую регистрацию
builder.Services.AddRazorComponents()
    .AddInteractiveServerComponents();

builder.Services.AddScoped<NewsService>();
builder.Services.AddScoped(sp => new HttpClient { Timeout = TimeSpan.FromSeconds(30) });

var app = builder.Build();

if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Error", createScopeForErrors: true);
    app.UseHsts();
}

app.UseHttpsRedirection();
app.UseStaticFiles();
app.UseAntiforgery();

// РЕШЕНИЕ ОШИБКИ С КНОПКАМИ:
// Если этот блок подчеркивается красным, замени его на app.MapRazorComponents<NewsPortal.Components.App>();
app.MapRazorComponents<NewsPortal.Components.App>()
    .AddInteractiveServerRenderMode();

app.Run();