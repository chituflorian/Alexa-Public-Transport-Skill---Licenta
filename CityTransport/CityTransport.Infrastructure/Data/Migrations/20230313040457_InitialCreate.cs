using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace CityTransport.Infrastructure.Data.Migrations
{
    public partial class InitialCreate : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Bus",
                columns: table => new
                {
                    BusID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    BusName = table.Column<string>(type: "varchar(255)", unicode: false, maxLength: 255, nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK__Bus__6A0F609575E632E3", x => x.BusID);
                });

            migrationBuilder.CreateTable(
                name: "MetropolitanArea",
                columns: table => new
                {
                    MetropolitanAreaID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    MetropolitanAreaName = table.Column<string>(type: "varchar(50)", unicode: false, maxLength: 50, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_MetropolitanArea", x => x.MetropolitanAreaID);
                });

            migrationBuilder.CreateTable(
                name: "City",
                columns: table => new
                {
                    CityID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    CityName = table.Column<string>(type: "varchar(50)", unicode: false, maxLength: 50, nullable: false),
                    MetropolitanAreaID = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_City", x => x.CityID);
                    table.ForeignKey(
                        name: "FK__City__Metropolit__6B24EA82",
                        column: x => x.MetropolitanAreaID,
                        principalTable: "MetropolitanArea",
                        principalColumn: "MetropolitanAreaID");
                });

            migrationBuilder.CreateTable(
                name: "Area",
                columns: table => new
                {
                    AreaID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    AreaName = table.Column<string>(type: "varchar(255)", unicode: false, maxLength: 255, nullable: true),
                    CityID = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Area", x => x.AreaID);
                    table.ForeignKey(
                        name: "FK__Area__CityID__6E01572D",
                        column: x => x.CityID,
                        principalTable: "City",
                        principalColumn: "CityID");
                });

            migrationBuilder.CreateTable(
                name: "BusStation",
                columns: table => new
                {
                    StationID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    StationName = table.Column<string>(type: "varchar(255)", unicode: false, maxLength: 255, nullable: true),
                    AreaID = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK__BusStati__E0D8A6DDC8727232", x => x.StationID);
                    table.ForeignKey(
                        name: "FK__BusStatio__AreaI__70DDC3D8",
                        column: x => x.AreaID,
                        principalTable: "Area",
                        principalColumn: "AreaID");
                });

            migrationBuilder.CreateTable(
                name: "Schedule",
                columns: table => new
                {
                    ScheduleID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    BusID = table.Column<int>(type: "int", nullable: true),
                    StationID = table.Column<int>(type: "int", nullable: true),
                    ArrivalTime = table.Column<string>(type: "varchar(10)", unicode: false, maxLength: 10, nullable: true),
                    ArrivalTimeExplicit = table.Column<TimeSpan>(type: "time", nullable: true),
                    DayOfWeek = table.Column<string>(type: "varchar(10)", unicode: false, maxLength: 10, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Schedule", x => x.ScheduleID);
                    table.ForeignKey(
                        name: "FK__Schedule__BusID__75A278F5",
                        column: x => x.BusID,
                        principalTable: "Bus",
                        principalColumn: "BusID");
                    table.ForeignKey(
                        name: "FK__Schedule__Statio__76969D2E",
                        column: x => x.StationID,
                        principalTable: "BusStation",
                        principalColumn: "StationID");
                });

            migrationBuilder.CreateIndex(
                name: "IX_Area_CityID",
                table: "Area",
                column: "CityID");

            migrationBuilder.CreateIndex(
                name: "IX_BusStation_AreaID",
                table: "BusStation",
                column: "AreaID");

            migrationBuilder.CreateIndex(
                name: "IX_City_MetropolitanAreaID",
                table: "City",
                column: "MetropolitanAreaID");

            migrationBuilder.CreateIndex(
                name: "IX_Schedule_BusID",
                table: "Schedule",
                column: "BusID");

            migrationBuilder.CreateIndex(
                name: "IX_Schedule_StationID",
                table: "Schedule",
                column: "StationID");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Schedule");

            migrationBuilder.DropTable(
                name: "Bus");

            migrationBuilder.DropTable(
                name: "BusStation");

            migrationBuilder.DropTable(
                name: "Area");

            migrationBuilder.DropTable(
                name: "City");

            migrationBuilder.DropTable(
                name: "MetropolitanArea");
        }
    }
}
