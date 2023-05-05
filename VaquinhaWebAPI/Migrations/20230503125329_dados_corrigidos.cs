using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace VaquinhaWebAPI.Migrations
{
    /// <inheritdoc />
    public partial class dados_corrigidos : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.UpdateData(
                table: "PAGAMENTO",
                keyColumns: new[] { "ID_ITEM_DESPESA", "ID_PAGANTE" },
                keyValues: new object[] { 2, 1 },
                column: "ID_PAGAMENTO",
                value: 2);

            migrationBuilder.UpdateData(
                table: "PAGAMENTO",
                keyColumns: new[] { "ID_ITEM_DESPESA", "ID_PAGANTE" },
                keyValues: new object[] { 3, 1 },
                column: "ID_PAGAMENTO",
                value: 3);

            migrationBuilder.UpdateData(
                table: "PAGAMENTO",
                keyColumns: new[] { "ID_ITEM_DESPESA", "ID_PAGANTE" },
                keyValues: new object[] { 4, 1 },
                column: "ID_PAGAMENTO",
                value: 4);

            migrationBuilder.UpdateData(
                table: "PAGAMENTO",
                keyColumns: new[] { "ID_ITEM_DESPESA", "ID_PAGANTE" },
                keyValues: new object[] { 1, 2 },
                column: "ID_PAGAMENTO",
                value: 5);

            migrationBuilder.UpdateData(
                table: "PAGAMENTO",
                keyColumns: new[] { "ID_ITEM_DESPESA", "ID_PAGANTE" },
                keyValues: new object[] { 2, 2 },
                column: "ID_PAGAMENTO",
                value: 6);

            migrationBuilder.UpdateData(
                table: "PAGAMENTO",
                keyColumns: new[] { "ID_ITEM_DESPESA", "ID_PAGANTE" },
                keyValues: new object[] { 3, 2 },
                column: "ID_PAGAMENTO",
                value: 7);

            migrationBuilder.UpdateData(
                table: "PAGAMENTO",
                keyColumns: new[] { "ID_ITEM_DESPESA", "ID_PAGANTE" },
                keyValues: new object[] { 4, 2 },
                column: "ID_PAGAMENTO",
                value: 8);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.UpdateData(
                table: "PAGAMENTO",
                keyColumns: new[] { "ID_ITEM_DESPESA", "ID_PAGANTE" },
                keyValues: new object[] { 2, 1 },
                column: "ID_PAGAMENTO",
                value: 1);

            migrationBuilder.UpdateData(
                table: "PAGAMENTO",
                keyColumns: new[] { "ID_ITEM_DESPESA", "ID_PAGANTE" },
                keyValues: new object[] { 3, 1 },
                column: "ID_PAGAMENTO",
                value: 1);

            migrationBuilder.UpdateData(
                table: "PAGAMENTO",
                keyColumns: new[] { "ID_ITEM_DESPESA", "ID_PAGANTE" },
                keyValues: new object[] { 4, 1 },
                column: "ID_PAGAMENTO",
                value: 1);

            migrationBuilder.UpdateData(
                table: "PAGAMENTO",
                keyColumns: new[] { "ID_ITEM_DESPESA", "ID_PAGANTE" },
                keyValues: new object[] { 1, 2 },
                column: "ID_PAGAMENTO",
                value: 1);

            migrationBuilder.UpdateData(
                table: "PAGAMENTO",
                keyColumns: new[] { "ID_ITEM_DESPESA", "ID_PAGANTE" },
                keyValues: new object[] { 2, 2 },
                column: "ID_PAGAMENTO",
                value: 1);

            migrationBuilder.UpdateData(
                table: "PAGAMENTO",
                keyColumns: new[] { "ID_ITEM_DESPESA", "ID_PAGANTE" },
                keyValues: new object[] { 3, 2 },
                column: "ID_PAGAMENTO",
                value: 1);

            migrationBuilder.UpdateData(
                table: "PAGAMENTO",
                keyColumns: new[] { "ID_ITEM_DESPESA", "ID_PAGANTE" },
                keyValues: new object[] { 4, 2 },
                column: "ID_PAGAMENTO",
                value: 1);
        }
    }
}
