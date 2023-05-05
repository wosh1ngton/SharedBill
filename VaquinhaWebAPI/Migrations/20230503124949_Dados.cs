using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace VaquinhaWebAPI.Migrations
{
    /// <inheritdoc />
    public partial class Dados : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
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
                columns: new[] { "ID_ITEM_DESPESA", "ID_PAGANTE", "ID_PAGAMENTO", "NR_PERCENTUAL_PAGO" },
                values: new object[,]
                {
                    { 1, 1, 1, 60 },
                    { 2, 1, 2, 60 },
                    { 3, 1, 3, 60 },
                    { 4, 1, 4, 70 },
                    { 1, 2, 5, 40 },
                    { 2, 2, 6, 40 },
                    { 3, 2, 7, 40 },
                    { 4, 2, 8, 30 }
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "CATEGORIA_ITEM_DESPESA",
                keyColumn: "ID_CATEGORIA_ITEM_DESPESA",
                keyValue: 3);

            migrationBuilder.DeleteData(
                table: "ITEM_DESPESA",
                keyColumn: "ID_ITEM_DESPESA",
                keyValue: 5);

            migrationBuilder.DeleteData(
                table: "ITEM_DESPESA",
                keyColumn: "ID_ITEM_DESPESA",
                keyValue: 6);

            migrationBuilder.DeleteData(
                table: "PAGAMENTO",
                keyColumns: new[] { "ID_ITEM_DESPESA", "ID_PAGANTE" },
                keyValues: new object[] { 1, 1 });

            migrationBuilder.DeleteData(
                table: "PAGAMENTO",
                keyColumns: new[] { "ID_ITEM_DESPESA", "ID_PAGANTE" },
                keyValues: new object[] { 2, 1 });

            migrationBuilder.DeleteData(
                table: "PAGAMENTO",
                keyColumns: new[] { "ID_ITEM_DESPESA", "ID_PAGANTE" },
                keyValues: new object[] { 3, 1 });

            migrationBuilder.DeleteData(
                table: "PAGAMENTO",
                keyColumns: new[] { "ID_ITEM_DESPESA", "ID_PAGANTE" },
                keyValues: new object[] { 4, 1 });

            migrationBuilder.DeleteData(
                table: "PAGAMENTO",
                keyColumns: new[] { "ID_ITEM_DESPESA", "ID_PAGANTE" },
                keyValues: new object[] { 1, 2 });

            migrationBuilder.DeleteData(
                table: "PAGAMENTO",
                keyColumns: new[] { "ID_ITEM_DESPESA", "ID_PAGANTE" },
                keyValues: new object[] { 2, 2 });

            migrationBuilder.DeleteData(
                table: "PAGAMENTO",
                keyColumns: new[] { "ID_ITEM_DESPESA", "ID_PAGANTE" },
                keyValues: new object[] { 3, 2 });

            migrationBuilder.DeleteData(
                table: "PAGAMENTO",
                keyColumns: new[] { "ID_ITEM_DESPESA", "ID_PAGANTE" },
                keyValues: new object[] { 4, 2 });

            migrationBuilder.DeleteData(
                table: "ITEM_DESPESA",
                keyColumn: "ID_ITEM_DESPESA",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "ITEM_DESPESA",
                keyColumn: "ID_ITEM_DESPESA",
                keyValue: 2);

            migrationBuilder.DeleteData(
                table: "ITEM_DESPESA",
                keyColumn: "ID_ITEM_DESPESA",
                keyValue: 3);

            migrationBuilder.DeleteData(
                table: "ITEM_DESPESA",
                keyColumn: "ID_ITEM_DESPESA",
                keyValue: 4);

            migrationBuilder.DeleteData(
                table: "PAGANTE",
                keyColumn: "ID_PAGANTE",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "PAGANTE",
                keyColumn: "ID_PAGANTE",
                keyValue: 2);

            migrationBuilder.DeleteData(
                table: "CATEGORIA_ITEM_DESPESA",
                keyColumn: "ID_CATEGORIA_ITEM_DESPESA",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "CATEGORIA_ITEM_DESPESA",
                keyColumn: "ID_CATEGORIA_ITEM_DESPESA",
                keyValue: 2);

            migrationBuilder.DeleteData(
                table: "TIPO_ITEM_DESPESA",
                keyColumn: "ID_TIPO_ITEM_DESPESA",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "TIPO_ITEM_DESPESA",
                keyColumn: "ID_TIPO_ITEM_DESPESA",
                keyValue: 2);
        }
    }
}
