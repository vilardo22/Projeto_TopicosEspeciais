using ReservaDeSalas.Api.Models;
var builder = WebApplication.CreateBuilder(args);

var app = builder.Build();

app.UseHttpsRedirection();

// ✅ LISTA GLOBAL (IMPORTANTE)
var salas = new List<Sala>();

app.MapGet("/salas/{id}", (int id) =>
{
    var sala = salas.FirstOrDefault(s => s.Id == id);
    return sala is not null ? Results.Ok(sala) : Results.NotFound();
});

app.MapPost("/salas", (Sala sala) =>
{
    if (string.IsNullOrWhiteSpace(sala.Nome))
        return Results.BadRequest("Nome é obrigatório");

    if (sala.Capacidade <= 0)
        return Results.BadRequest("Capacidade deve ser maior que 0");

    sala.Id = salas.Count + 1;
    salas.Add(sala);

    return Results.Created($"/salas/{sala.Id}", sala);
});

app.MapPut("/salas/{id}", (int id, Sala salaAtualizada) =>
{
    var sala = salas.FirstOrDefault(s => s.Id == id);

    if (sala is null)
        return Results.NotFound();

    sala.Nome = salaAtualizada.Nome;
    sala.Capacidade = salaAtualizada.Capacidade;

    return Results.Ok(sala);
});

app.MapDelete("/salas/{id}", (int id) =>
{
    var sala = salas.FirstOrDefault(s => s.Id == id);

    if (sala is null)
        return Results.NotFound();

    salas.Remove(sala);

    return Results.NoContent();
});

app.Run();