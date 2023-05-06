using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace BookMechanicWorkshop_.Migrations
{
    /// <inheritdoc />
    public partial class DbAppointmentsMechanicWorkshop : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "ServiceMechanicWorkshopId",
                table: "Appointments",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.CreateIndex(
                name: "IX_Appointments_ServiceMechanicWorkshopId",
                table: "Appointments",
                column: "ServiceMechanicWorkshopId");

            migrationBuilder.AddForeignKey(
                name: "FK_Appointments_ServicesMechanicWorkshop_ServiceMechanicWorkshopId",
                table: "Appointments",
                column: "ServiceMechanicWorkshopId",
                principalTable: "ServicesMechanicWorkshop",
                principalColumn: "ServiceId",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Appointments_ServicesMechanicWorkshop_ServiceMechanicWorkshopId",
                table: "Appointments");

            migrationBuilder.DropIndex(
                name: "IX_Appointments_ServiceMechanicWorkshopId",
                table: "Appointments");

            migrationBuilder.DropColumn(
                name: "ServiceMechanicWorkshopId",
                table: "Appointments");
        }
    }
}
