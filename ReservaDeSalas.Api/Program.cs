using ReservaDeSalas.Api.Data;
using Microsoft.EntityFrameworkCore;
using ReservaDeSalas.Api.Models;

var builder = WebApplication.CreateBuilder(args);

// Swagger
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

// Banco
builder.Services.AddDbContext<AppDbContext>(options =>
    options.UseSqlite("Data Source=reservas.db"));

var app = builder.Build();

// Swagger (DEPOIS do build)
app.UseSwagger();
app.UseSwaggerUI();

app.UseHttpsRedirection();

// ✅ LISTA GLOBAL (IMPORTANTE)


app.MapGet("/salas/{id}", (int id, AppDbContext db) =>
{
    var sala = db.Salas.Find(id);
    return sala is not null ? Results.Ok(sala) : Results.NotFound();
});
app.MapGet("/salas", (AppDbContext db) =>
{
    return db.Salas.ToList();
});

app.MapPost("/salas", (Sala sala, AppDbContext db) =>
{
    if (string.IsNullOrWhiteSpace(sala.Nome))
        return Results.BadRequest("Nome é obrigatório");

    if (sala.Capacidade <= 0)
        return Results.BadRequest("Capacidade deve ser maior que 0");

    db.Salas.Add(sala);
    db.SaveChanges();

    return Results.Created($"/salas/{sala.Id}", sala);
});

app.MapPut("/salas/{id}", (int id, Sala salaAtualizada, AppDbContext db) =>
{
    var sala = db.Salas.Find(id);

    if (sala is null)
        return Results.NotFound();

    sala.Nome = salaAtualizada.Nome;
    sala.Capacidade = salaAtualizada.Capacidade;

    db.SaveChanges();

    return Results.Ok(sala);
});

app.MapDelete("/salas/{id}", (int id, AppDbContext db) =>
{
    var sala = db.Salas.Find(id);

    if (sala is null)
        return Results.NotFound();

    db.Salas.Remove(sala);
    db.SaveChanges();

    return Results.NoContent();
});


app.Run();