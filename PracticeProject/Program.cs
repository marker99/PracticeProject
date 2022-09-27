using Microsoft.AspNetCore.Components;
using Microsoft.AspNetCore.Components.Web;
using PracticeProject.Data;
using PracticeProject.Data.Implementations;
using PracticeProject.Database;
using PracticeProject.Repositories;
using PracticeProject.Repositories.Implementations;
using Radzen;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddRazorPages();
builder.Services.AddServerSideBlazor();
builder.Services.AddScoped<DialogService>();

builder.Services.AddDbContext<FamilyDbContext>(ServiceLifetime.Transient);
builder.Services.AddScoped<IPersonHandler, PersonHandler>();
builder.Services.AddScoped<IRelationHandler, RelationHandler>();
builder.Services.AddScoped<IPersonRepository, PersonRepository>();
builder.Services.AddScoped<IRelationRepository, RelationRepository>();


var app = builder.Build();

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
