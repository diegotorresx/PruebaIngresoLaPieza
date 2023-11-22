using SQLitePCL;

var builder = WebApplication.CreateBuilder(args);

// Inicializaci�n de SQLitePCL
Batteries.Init();

// Add services to the container.
builder.Services.AddControllers();

// Configuraci�n de CORS
builder.Services.AddCors(options =>
{
    options.AddPolicy("MyAllowSpecificOrigins",
        corsBuilder =>
        {
            corsBuilder.AllowAnyOrigin() // Ajusta seg�n la URL de tu cliente
                       .AllowAnyHeader()
                       .AllowAnyMethod();
        });
});

// Configuraci�n de Swagger
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

// Usa CORS
app.UseCors("MyAllowSpecificOrigins"); // Aseg�rate de llamar a UseCors antes de UseRouting y UseAuthorization

app.UseAuthorization();

app.MapControllers();

app.Run();
