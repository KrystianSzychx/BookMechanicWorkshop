using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace BookMechanicWorkshop_.Migrations
{
    /// <inheritdoc />
    public partial class InitialCreateServiceMechanicWorkshop : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "ServicesMechanicWorkshop",
                columns: table => new
                {
                    ServiceId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    ExpectedTime = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    PriceRange = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    MechanicWorkshopId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ServicesMechanicWorkshop", x => x.ServiceId);
                    table.ForeignKey(
                        name: "FK_ServicesMechanicWorkshop_MechanicWorkshops_MechanicWorkshopId",
                        column: x => x.MechanicWorkshopId,
                        principalTable: "MechanicWorkshops",
                        principalColumn: "MechanicWorkshopId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_ServicesMechanicWorkshop_MechanicWorkshopId",
                table: "ServicesMechanicWorkshop",
                column: "MechanicWorkshopId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "ServicesMechanicWorkshop");
        }
    }
}
