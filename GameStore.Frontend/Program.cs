using GameStore.Frontend.Clients;
using GameStore.Frontend.Components;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddRazorComponents()
    .AddInteractiveServerComponents();

    var gameStoreApiUrl = builder.Configuration["GameStoreApiUrl"]??
        throw new Exception("GameStoreApiUrl is not set");

    builder.Services.AddHttpClient<GamesClient>(
        client => client.BaseAddress = new Uri(gameStoreApiUrl));  //we registered our httpClient instance / this method to receive the type of the client class that we are going to  use for interacting with the httpclient

    builder.Services.AddHttpClient<GenresClient>(
        client => client.BaseAddress = new Uri(gameStoreApiUrl));

//now we will delete those two cz at the httpClient is going to register both gameClient and GenresClient with the correspondeing httpClient
//builder.Services.AddSingleton<GamesClient>(); //we added this just to register the services so the service provider knows about them 
//builder.Services.AddSingleton<GenresClient>(); //we added this just to register the services so the service provider knows about them 

var app = builder.Build();

// Configure the HTTP request pipeline.
if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Error", createScopeForErrors: true);
    // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
    app.UseHsts();
}

// app.UseHttpsRedirection();

app.UseStaticFiles();
app.UseAntiforgery();

app.MapRazorComponents<App>()
    .AddInteractiveServerRenderMode();

app.Run();
