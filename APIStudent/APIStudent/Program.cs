using SQLitePCL;

var builder = WebApplication.CreateBuilder(args);

// Inicialización de SQLitePCL
Batteries.Init();

// Add services to the container.
builder.Services.AddControllers();

// Configuración de CORS
builder.Services.AddCors(options =>
{
    options.AddPolicy("MyAllowSpecificOrigins",
        corsBuilder =>
        {
            corsBuilder.AllowAnyOrigin() // Ajusta según la URL de tu cliente
                       .AllowAnyHeader()
                       .AllowAnyMethod();
        });
});

// Configuración de Swagger
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
app.UseCors("MyAllowSpecificOrigins"); // Asegúrate de llamar a UseCors antes de UseRouting y UseAuthorization

app.UseAuthorization();

app.MapControllers();

app.Run();
