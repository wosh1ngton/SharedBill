using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace VaquinhaWebAPI.Migrations
{
    /// <inheritdoc />
    public partial class initial : Migration
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
                    ID_PAGAMENTO = table.Column<int>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    NR_PERCENTUAL_PAGO = table.Column<int>(type: "INTEGER", nullable: false),
                    ID_ITEM_DESPESA = table.Column<int>(type: "INTEGER", nullable: false),
                    ID_PAGANTE = table.Column<int>(type: "INTEGER", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_PAGAMENTO", x => x.ID_PAGAMENTO);
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

            migrationBuilder.InsertData(
                table: "CATEGORIA_ITEM_DESPESA",
                columns: new[] { "ID_CATEGORIA_ITEM_DESPESA", "NM_CATEGORIA_ITEM_DESPESA" },
                values: new object[,]
                {
                    { 1, "Supermercado" },
                    { 2, "Carne" },
                    { 3, "Outros" }
                });

            migrationBuilder.InsertData(
                table: "PAGANTE",
                columns: new[] { "ID_PAGANTE", "NM_NOME", "NM_SOBRENOME" },
                values: new object[,]
                {
                    { 1, "Woshington", "Silva" },
                    { 2, "Charline", "Rocha" }
                });

            migrationBuilder.InsertData(
                table: "TIPO_ITEM_DESPESA",
                columns: new[] { "ID_TIPO_ITEM_DESPESA", "NM_TIPO_ITEM_DESPESA" },
                values: new object[,]
                {
                    { 1, "Custeio Mensal" },
                    { 2, "Outros" }
                });

            migrationBuilder.InsertData(
                table: "ITEM_DESPESA",
                columns: new[] { "ID_ITEM_DESPESA", "ID_CATEGORIA_ITEM_DESPESA", "DS_ITEM_DESPESA", "DT_ITEM_DESPESA", "ID_TIPO_ITEM_DESPESA", "NR_VALOR" },
                values: new object[,]
                {
                    { 1, 1, "Pão de Açúcar", new DateTime(2023, 5, 25, 0, 0, 0, 0, DateTimeKind.Unspecified), 1, 250m },
                    { 2, 1, "Swift", new DateTime(2023, 3, 25, 0, 0, 0, 0, DateTimeKind.Unspecified), 2, 350m },
                    { 3, 2, "Viagem", new DateTime(2023, 2, 21, 0, 0, 0, 0, DateTimeKind.Unspecified), 1, 50m },
                    { 4, 1, "Pão de Açúcar", new DateTime(2023, 4, 25, 0, 0, 0, 0, DateTimeKind.Unspecified), 2, 58m },
                    { 5, 2, "HortiFrutti", new DateTime(2022, 8, 2, 0, 0, 0, 0, DateTimeKind.Unspecified), 1, 20m },
                    { 6, 2, "Pão de Açúcar", new DateTime(2022, 1, 18, 0, 0, 0, 0, DateTimeKind.Unspecified), 2, 250m }
                });

            migrationBuilder.InsertData(
                table: "PAGAMENTO",
                columns: new[] { "ID_PAGAMENTO", "ID_ITEM_DESPESA", "ID_PAGANTE", "NR_PERCENTUAL_PAGO" },
                values: new object[,]
                {
                    { 1, 1, 1, 60 },
                    { 2, 2, 1, 60 },
                    { 3, 3, 1, 60 },
                    { 4, 4, 1, 70 },
                    { 5, 1, 2, 40 },
                    { 6, 2, 2, 40 },
                    { 7, 3, 2, 40 },
                    { 8, 4, 2, 30 }
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

            migrationBuilder.CreateIndex(
                name: "IX_PAGAMENTO_ID_PAGANTE",
                table: "PAGAMENTO",
                column: "ID_PAGANTE");
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
