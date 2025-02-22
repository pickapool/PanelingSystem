using Blazored.LocalStorage;
using Microsoft.AspNetCore.Components;
using Microsoft.AspNetCore.Components.Web;
using Microsoft.AspNetCore.Http.Features;
using Microsoft.EntityFrameworkCore;
using MudBlazor.Extensions;
using MudBlazor.Services;
using PanelingSystem.Commons;
using PanelingSystem.DatabaseContext;
using PanelingSystem.Services.AccountServices;
using PanelingSystem.Services.CapstoneFilesServices;
using PanelingSystem.Services.CommentServices;
using PanelingSystem.Services.DefenseVerdictServices;
using PanelingSystem.Services.FileServices;
using PanelingSystem.Services.GradeServices;
using PanelingSystem.Services.GroupServices;
using PanelingSystem.Services.MemberServices;
using PanelingSystem.Services.PanelGradeServices;
using PanelingSystem.Services.PanelistServices;
using PanelingSystem.Services.ReportServices;
using PanelingSystem.Services.ScheduleServices;
using Radzen;
using Radzen.Blazor;
using System;
using System.Text.Json.Serialization;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddRazorPages();
builder.Services.AddMudServices();
builder.Services.AddBlazoredLocalStorage();
builder.Services.AddServerSideBlazor();
builder.Services.AddRazorComponents();
builder.Services.AddMudServicesWithExtensions();
builder.Services.AddMudExtensions();
builder.Services.AddScoped<Radzen.DialogService>();
builder.Services.AddScoped<Radzen.NotificationService>();
builder.Services.AddScoped<Radzen.ContextMenuService>();
builder.Services.AddScoped<Radzen.TooltipService>();
builder.Services.AddSingleton<AppState>();
builder.Services.AddRazorComponents();
builder.Services.AddScoped<IAccountService, AccountService>();
builder.Services.AddScoped<IGroupService, GroupService>();
builder.Services.AddScoped<IMemberService, MemberService>();
builder.Services.AddScoped<IFileService, FileService>();
builder.Services.AddScoped<ICapstoneFileService, CapstoneFileService>();
builder.Services.AddScoped<IGradeService, GradeService>();
builder.Services.AddScoped<ICommentService, CommentService>();
builder.Services.AddScoped<IScheduleService, ScheduleService>();
builder.Services.AddScoped<IPanelistService, PanelistService>();
builder.Services.AddScoped<IReportService,  ReportService>();
builder.Services.AddScoped<IVerdictService, VerdictService>();
builder.Services.AddScoped<IPanelGradeService, PanelGradeService>();

builder.Services.AddDbContext<AppDBContext>(options =>
{
    options.UseSqlServer(builder.Configuration.GetConnectionString("Connection"));
});
//  builder.Services.AddDbContext<AppDBContext>(options =>
//                         options.UseSqlServer(builder.Configuration.GetConnectionString("Connection")),
//              ServiceLifetime.Transient);
builder.Services.AddControllers().AddJsonOptions(x => x.JsonSerializerOptions.ReferenceHandler = ReferenceHandler.IgnoreCycles);
builder.Services.AddCors(policy =>
{
    policy.AddPolicy("NewPolicy", opt => opt
    .AllowAnyOrigin()
    .AllowAnyHeader()
    .AllowAnyMethod());
});
builder.Services.Configure<FormOptions>(options =>
{
    options.MultipartBodyLengthLimit = 209715200; // Set to 200 MB (200 * 1024 * 1024 bytes)
});
var app = builder.Build();
if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Error");
    // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
    app.UseHsts();
}
app.UseCors("NewPolicy");
app.UseHttpsRedirection();

app.UseStaticFiles();

app.UseRouting();

app.MapBlazorHub();
app.MapFallbackToPage("/_Host");

app.Run();
