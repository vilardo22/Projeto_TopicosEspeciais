namespace ReservaDeSalas.Api.Models;


public class Reserva
{
    public int Id { get; set; }

    public int SalaId { get; set; }
    public Sala? Sala { get; set; }

    public int UsuarioId { get; set; }
    public Usuario? Usuario { get; set; }

    public DateTime DataReserva { get; set; }
}