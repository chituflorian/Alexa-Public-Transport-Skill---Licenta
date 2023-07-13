using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace CityTransport.Infrastructure.Data.Migrations
{
    public partial class AddFavoriteBusRoute : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "FavoriteBusRoute",
                columns: table => new
                {
                    RouteID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    BusName = table.Column<string>(type: "varchar(255)", unicode: false, maxLength: 255, nullable: true),
                    StationFrom = table.Column<string>(type: "varchar(255)", unicode: false, maxLength: 255, nullable: true),
                    StationTo = table.Column<string>(type: "varchar(255)", unicode: false, maxLength: 255, nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK__FavoriteBusRoute__E0D8A6DDC8427532", x => x.RouteID);
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "FavoriteBusRoute");
        }
    }
}
