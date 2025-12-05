

var builder = WebApplication.CreateBuilder(args);


// Registra HttpClient
builder.Services.AddHttpClient();

// Aggiungi i controllers
builder.Services.AddControllers();

// Opzionale: configura JSON
builder.Services.AddControllers()
    .AddJsonOptions(options =>
    {
        options.JsonSerializerOptions.PropertyNamingPolicy = null; // Mantiene nomi originali
        options.JsonSerializerOptions.WriteIndented = true; // JSON formattato
    });

var app = builder.Build();

// Configura la pipeline
app.UseHttpsRedirection();
app.UseAuthorization();
app.MapControllers(); // IMPORTANTE: mappa i controllers
app.MapGet("/", () => "API funzionante! Vai su /api/prodotti/lista");
app.Run();