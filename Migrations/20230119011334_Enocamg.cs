using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Enoca.netChallenge.Migrations
{
    /// <inheritdoc />
    public partial class Enocamg : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Firma",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Firmaadi = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Onaydurumu = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Siparisizinbaslangicsaat = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Siparisizinbitissaat = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Firma", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Siparis",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Siparisverenad = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Siparistarihi = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    FirmaId = table.Column<int>(type: "int", nullable: false),
                    UrunId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Siparis", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Siparis_Firma_FirmaId",
                        column: x => x.FirmaId,
                        principalTable: "Firma",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Urunler",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Urunadi = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    stok = table.Column<int>(type: "int", nullable: false),
                    fiyat = table.Column<int>(type: "int", nullable: false),
                    FirmaId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Urunler", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Urunler_Firma_FirmaId",
                        column: x => x.FirmaId,
                        principalTable: "Firma",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Siparis_FirmaId",
                table: "Siparis",
                column: "FirmaId");

            migrationBuilder.CreateIndex(
                name: "IX_Urunler_FirmaId",
                table: "Urunler",
                column: "FirmaId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Siparis");

            migrationBuilder.DropTable(
                name: "Urunler");

            migrationBuilder.DropTable(
                name: "Firma");
        }
    }
}
