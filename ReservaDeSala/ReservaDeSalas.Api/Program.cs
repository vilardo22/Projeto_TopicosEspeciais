using ReservaDeSalas.Api.Models;
var builder = WebApplication.CreateBuilder(args);

var app = builder.Build();

app.UseHttpsRedirection();

// ✅ LISTA GLOBAL (IMPORTANTE)
var salas = new List<Sala>();

app.MapGet("/salas", () => salas);

app.MapPost("/salas", (Sala sala) =>
{
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