namespace ReservaDeSalas.Api.Models;


public class Reserva
{
    public int Id { get; set; }

    public int SalaId { get; set; }
    public Sala? Sala { get; set; }

    public int UsuarioId { get; set; }
    public Usuario? Usuario { get; set; }

    public DateOnly Data { get; set; }
    public TimeOnly HoraInicio { get; set; }
    public TimeOnly HoraFim { get; set; }
}