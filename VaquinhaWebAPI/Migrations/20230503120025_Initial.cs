using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace VaquinhaWebAPI.Migrations
{
    /// <inheritdoc />
    public partial class Initial : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "CATEGORIA_ITEM_DESPESA",
                columns: table => new
                {
                    ID_CATEGORIA_ITEM_DESPESA = table.Column<int>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    NM_CATEGORIA_ITEM_DESPESA = table.Column<string>(type: "TEXT", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_CATEGORIA_ITEM_DESPESA", x => x.ID_CATEGORIA_ITEM_DESPESA);
                });

            migrationBuilder.CreateTable(
                name: "PAGANTE",
                columns: table => new
                {
                    ID_PAGANTE = table.Column<int>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    NM_NOME = table.Column<string>(type: "TEXT", nullable: false),
                    NM_SOBRENOME = table.Column<string>(type: "TEXT", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_PAGANTE", x => x.ID_PAGANTE);
                });

            migrationBuilder.CreateTable(
                name: "TIPO_ITEM_DESPESA",
                columns: table => new
                {
                    ID_TIPO_ITEM_DESPESA = table.Column<int>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    NM_TIPO_ITEM_DESPESA = table.Column<string>(type: "TEXT", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_TIPO_ITEM_DESPESA", x => x.ID_TIPO_ITEM_DESPESA);
                });

            migrationBuilder.CreateTable(
                name: "ITEM_DESPESA",
                columns: table => new
                {
                    ID_ITEM_DESPESA = table.Column<int>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    DS_ITEM_DESPESA = table.Column<string>(type: "TEXT", nullable: false),
                    NR_VALOR = table.Column<decimal>(type: "TEXT", nullable: false),
                    ID_TIPO_ITEM_DESPESA = table.Column<int>(type: "INTEGER", nullable: false),
                    ID_CATEGORIA_ITEM_DESPESA = table.Column<int>(type: "INTEGER", nullable: false),
                    DT_ITEM_DESPESA = table.Column<DateTime>(type: "TEXT", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ITEM_DESPESA", x => x.ID_ITEM_DESPESA);
                    table.ForeignKey(
                        name: "FK_ITEM_DESPESA_CATEGORIA_ITEM_DESPESA_ID_CATEGORIA_ITEM_DESPESA",
                        column: x => x.ID_CATEGORIA_ITEM_DESPESA,
                        principalTable: "CATEGORIA_ITEM_DESPESA",
                        principalColumn: "ID_CATEGORIA_ITEM_DESPESA",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_ITEM_DESPESA_TIPO_ITEM_DESPESA_ID_TIPO_ITEM_DESPESA",
                        column: x => x.ID_TIPO_ITEM_DESPESA,
                        principalTable: "TIPO_ITEM_DESPESA",
                        principalColumn: "ID_TIPO_ITEM_DESPESA",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "PAGAMENTO",
                columns: table => new
                {
                    ID_ITEM_DESPESA = table.Column<int>(type: "INTEGER", nullable: false),
                    ID_PAGANTE = table.Column<int>(type: "INTEGER", nullable: false),
                    ID_PAGAMENTO = table.Column<int>(type: "INTEGER", nullable: false),
                    NR_PERCENTUAL_PAGO = table.Column<int>(type: "INTEGER", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_PAGAMENTO", x => new { x.ID_PAGANTE, x.ID_ITEM_DESPESA });
                    table.ForeignKey(
                        name: "FK_PAGAMENTO_ITEM_DESPESA_ID_ITEM_DESPESA",
                        column: x => x.ID_ITEM_DESPESA,
                        principalTable: "ITEM_DESPESA",
                        principalColumn: "ID_ITEM_DESPESA",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_PAGAMENTO_PAGANTE_ID_PAGANTE",
                        column: x => x.ID_PAGANTE,
                        principalTable: "PAGANTE",
                        principalColumn: "ID_PAGANTE",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_ITEM_DESPESA_ID_CATEGORIA_ITEM_DESPESA",
                table: "ITEM_DESPESA",
                column: "ID_CATEGORIA_ITEM_DESPESA");

            migrationBuilder.CreateIndex(
                name: "IX_ITEM_DESPESA_ID_TIPO_ITEM_DESPESA",
                table: "ITEM_DESPESA",
                column: "ID_TIPO_ITEM_DESPESA");

            migrationBuilder.CreateIndex(
                name: "IX_PAGAMENTO_ID_ITEM_DESPESA",
                table: "PAGAMENTO",
                column: "ID_ITEM_DESPESA");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "PAGAMENTO");

            migrationBuilder.DropTable(
                name: "ITEM_DESPESA");

            migrationBuilder.DropTable(
                name: "PAGANTE");

            migrationBuilder.DropTable(
                name: "CATEGORIA_ITEM_DESPESA");

            migrationBuilder.DropTable(
                name: "TIPO_ITEM_DESPESA");
        }
    }
}
