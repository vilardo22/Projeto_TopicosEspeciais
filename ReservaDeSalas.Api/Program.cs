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

app.MapPost("/reservas", (Reserva reserva, AppDbContext db) =>
{
    // ✅ 1. Validar se Sala existe
    var salaExiste = db.Salas.Any(s => s.Id == reserva.SalaId);
    if (!salaExiste)
        return Results.BadRequest("Sala não existe");

    // ✅ 2. Validar se Usuário existe
    var usuarioExiste = db.Usuarios.Any(u => u.Id == reserva.UsuarioId);
    if (!usuarioExiste)
        return Results.BadRequest("Usuário não existe");

    // ✅ 3. Validar horário
    if (reserva.HoraInicio >= reserva.HoraFim)
    {
        return Results.BadRequest("HoraInicio deve ser menor que HoraFim");
    }

    // 🔴 4. Regra de conflito (a sua já tava certa 👏)
    var conflito = db.Reservas.Any(r =>
        r.SalaId == reserva.SalaId &&
        r.Data == reserva.Data &&
        reserva.HoraInicio < r.HoraFim &&
        reserva.HoraFim > r.HoraInicio
    );

    if (conflito)
    {
        return Results.BadRequest(new
        {
            erro = "Já existe uma reserva para esta sala neste horário."
        });
    }

    // ✅ 5. Salvar
    db.Reservas.Add(reserva);
    db.SaveChanges();

    return Results.Ok(reserva);
});

app.MapGet("/reservas", (AppDbContext db) =>
{
    return db.Reservas
    .Include(r => r.Sala)
    .Include(r => r.Usuario)
    .ToList();
});

app.MapDelete("/reservas/{id}", (int id, AppDbContext db) =>
{
    var reserva = db.Reservas.Find(id);

    if (reserva == null)
        return Results.NotFound();

    db.Reservas.Remove(reserva);
    db.SaveChanges();

    return Results.Ok(new { mensagem = "Reserva removida com sucesso" });
});
app.MapPost("/usuarios", (Usuario usuario, AppDbContext db) =>
{
    if (string.IsNullOrWhiteSpace(usuario.Nome))
        return Results.BadRequest("Nome é obrigatório");

    if (string.IsNullOrWhiteSpace(usuario.Email))
        return Results.BadRequest("Email é obrigatório");

    db.Usuarios.Add(usuario);
    db.SaveChanges();

    return Results.Ok(usuario);
});

app.MapGet("/usuarios", (AppDbContext db) =>
{
    return db.Usuarios.ToList();
});
app.Run();