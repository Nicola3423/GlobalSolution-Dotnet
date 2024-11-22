using Microsoft.EntityFrameworkCore;
using Sessions_app.Mapeamento;
using Sessions_app.Service;
using SeuProjeto.Data;
using SeuProjeto.Repositories;
using Sessions_app.Repositories;
using SeuProjeto.Services;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddDbContext<OracleDbContext>(options =>
    options.UseOracle(builder.Configuration.GetConnectionString("OracleConnection")));

builder.Services.AddAutoMapper(typeof(ConteudoProfile).Assembly);

builder.Services.AddScoped<IConteudoRepository, ConteudoRepository>();
builder.Services.AddScoped<IDicaEconomiaRepository, DicaEconomiaRepository>();
builder.Services.AddScoped<IFeedbackUsuarioRepository, FeedbackUsuarioRepository>();
builder.Services.AddScoped<IInteracaoRepository, InteracaoRepository>();
builder.Services.AddScoped<IPontuacaoQuizRepository, PontuacaoQuizRepository>();
builder.Services.AddScoped<IUsuarioRepository, UsuarioRepository>();

builder.Services.AddScoped<IConteudoService, ConteudoService>();
builder.Services.AddScoped<IDicaEconomiaService, DicaEconomiaService>();
builder.Services.AddScoped<IFeedbackUsuarioService, FeedbackUsuarioService>();
builder.Services.AddScoped<IInteracaoService, InteracaoService>();
builder.Services.AddScoped<IPontuacaoQuizService, PontuacaoQuizService>();
builder.Services.AddScoped<IUsuarioService, UsuarioService>();

builder.Services.AddControllersWithViews();

builder.Logging.ClearProviders();
builder.Logging.AddConsole();

builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen(options =>
{
    options.SwaggerDoc("v1", new Microsoft.OpenApi.Models.OpenApiInfo
    {
        Title = "API DOTNET",
        Version = "v1",
        Description = "Documentação da API do meu projeto usando Swagger",
        Contact = new Microsoft.OpenApi.Models.OpenApiContact
        {
            Name = "Nicolas",
            Email = "email@exemplo.com",
            Url = new Uri("https://seusite.com")
        }
    });
});

var app = builder.Build();

if (app.Environment.IsDevelopment())
{
    app.UseDeveloperExceptionPage();
}
else
{
    app.UseExceptionHandler("/Home/Error");
    app.UseHsts();
}

app.MapGet("/", context =>
{
    context.Response.Redirect("/Usuario");
    return Task.CompletedTask;
});
app.MapControllerRoute(
    name: "default",
    pattern: "{controller=Usuario}/{action=Index}/{id?}");
app.UseSwagger();
app.UseSwaggerUI(options =>
{
    options.SwaggerEndpoint("/swagger/v1/swagger.json", "API do Seu Projeto v1");
    options.RoutePrefix = "api-docs";
});

app.UseHttpsRedirection();
app.UseStaticFiles();

app.UseRouting();

app.UseAuthorization();


app.Run();
