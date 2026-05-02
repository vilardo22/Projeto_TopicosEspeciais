using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace ReservaDeSalas.Api.Migrations
{
    /// <inheritdoc />
    public partial class UpdateReserva : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "DataReserva",
                table: "Reservas",
                newName: "HoraInicio");

            migrationBuilder.AddColumn<DateOnly>(
                name: "Data",
                table: "Reservas",
                type: "TEXT",
                nullable: false,
                defaultValue: new DateOnly(1, 1, 1));

            migrationBuilder.AddColumn<TimeOnly>(
                name: "HoraFim",
                table: "Reservas",
                type: "TEXT",
                nullable: false,
                defaultValue: new TimeOnly(0, 0, 0));
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Data",
                table: "Reservas");

            migrationBuilder.DropColumn(
                name: "HoraFim",
                table: "Reservas");

            migrationBuilder.RenameColumn(
                name: "HoraInicio",
                table: "Reservas",
                newName: "DataReserva");
        }
    }
}
