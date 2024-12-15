using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace CentralAdminApp.Infra.Data.Migrations
{
    /// <inheritdoc />
    public partial class AddColumnComplementoCliente : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<string>(
                name: "LOGRADOURO",
                table: "TB_CLIENTE",
                type: "varchar(100)",
                maxLength: 100,
                nullable: false,
                oldClrType: typeof(string),
                oldType: "varchar(50)",
                oldMaxLength: 50)
                .Annotation("MySql:CharSet", "utf8mb4")
                .OldAnnotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.AddColumn<string>(
                name: "COMPLEMENTO",
                table: "TB_CLIENTE",
                type: "longtext",
                nullable: true)
                .Annotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.UpdateData(
                table: "TB_API",
                keyColumn: "ID",
                keyValue: 1,
                columns: new[] { "DATA_ALTERACAO", "DATA_INCLUSAO" },
                values: new object[] { new DateTime(2024, 12, 14, 17, 43, 38, 108, DateTimeKind.Local).AddTicks(191), new DateTime(2024, 12, 14, 17, 43, 38, 108, DateTimeKind.Local).AddTicks(191) });

            migrationBuilder.UpdateData(
                table: "TB_CLIENTE",
                keyColumn: "ID",
                keyValue: 1,
                columns: new[] { "COMPLEMENTO", "DATA_ALTERACAO", "DATA_INCLUSAO" },
                values: new object[] { null, new DateTime(2024, 12, 14, 17, 43, 38, 108, DateTimeKind.Local).AddTicks(191), new DateTime(2024, 12, 14, 17, 43, 38, 108, DateTimeKind.Local).AddTicks(191) });

            migrationBuilder.UpdateData(
                table: "TB_CLIENTE_SISTEMA",
                keyColumn: "ID",
                keyValue: 1,
                columns: new[] { "DATA_ALTERACAO", "DATA_INCLUSAO" },
                values: new object[] { new DateTime(2024, 12, 14, 17, 43, 38, 108, DateTimeKind.Local).AddTicks(191), new DateTime(2024, 12, 14, 17, 43, 38, 108, DateTimeKind.Local).AddTicks(191) });

            migrationBuilder.UpdateData(
                table: "TB_PERFIL",
                keyColumn: "ID",
                keyValue: 1,
                columns: new[] { "DATA_ALTERACAO", "DATA_INCLUSAO" },
                values: new object[] { new DateTime(2024, 12, 14, 17, 43, 38, 108, DateTimeKind.Local).AddTicks(191), new DateTime(2024, 12, 14, 17, 43, 38, 108, DateTimeKind.Local).AddTicks(191) });

            migrationBuilder.UpdateData(
                table: "TB_PERFIL_API",
                keyColumn: "ID",
                keyValue: 1,
                columns: new[] { "DATA_ALTERACAO", "DATA_INCLUSAO" },
                values: new object[] { new DateTime(2024, 12, 14, 17, 43, 38, 108, DateTimeKind.Local).AddTicks(191), new DateTime(2024, 12, 14, 17, 43, 38, 108, DateTimeKind.Local).AddTicks(191) });

            migrationBuilder.UpdateData(
                table: "TB_SISTEMA",
                keyColumn: "ID",
                keyValue: 1,
                columns: new[] { "DATA_ALTERACAO", "DATA_INCLUSAO" },
                values: new object[] { new DateTime(2024, 12, 14, 17, 43, 38, 108, DateTimeKind.Local).AddTicks(191), new DateTime(2024, 12, 14, 17, 43, 38, 108, DateTimeKind.Local).AddTicks(191) });

            migrationBuilder.UpdateData(
                table: "TB_USUARIO",
                keyColumn: "ID",
                keyValue: 1,
                columns: new[] { "DATA_ALTERACAO", "DATA_INCLUSAO" },
                values: new object[] { new DateTime(2024, 12, 14, 17, 43, 38, 108, DateTimeKind.Local).AddTicks(191), new DateTime(2024, 12, 14, 17, 43, 38, 108, DateTimeKind.Local).AddTicks(191) });

            migrationBuilder.UpdateData(
                table: "TB_USUARIO",
                keyColumn: "ID",
                keyValue: 2,
                columns: new[] { "DATA_ALTERACAO", "DATA_INCLUSAO" },
                values: new object[] { new DateTime(2024, 12, 14, 17, 43, 38, 108, DateTimeKind.Local).AddTicks(191), new DateTime(2024, 12, 14, 17, 43, 38, 108, DateTimeKind.Local).AddTicks(191) });

            migrationBuilder.UpdateData(
                table: "TB_USUARIO_PERFIL",
                keyColumn: "ID",
                keyValue: 1,
                columns: new[] { "DATA_ALTERACAO", "DATA_INCLUSAO" },
                values: new object[] { new DateTime(2024, 12, 14, 17, 43, 38, 108, DateTimeKind.Local).AddTicks(191), new DateTime(2024, 12, 14, 17, 43, 38, 108, DateTimeKind.Local).AddTicks(191) });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "COMPLEMENTO",
                table: "TB_CLIENTE");

            migrationBuilder.AlterColumn<string>(
                name: "LOGRADOURO",
                table: "TB_CLIENTE",
                type: "varchar(50)",
                maxLength: 50,
                nullable: false,
                oldClrType: typeof(string),
                oldType: "varchar(100)",
                oldMaxLength: 100)
                .Annotation("MySql:CharSet", "utf8mb4")
                .OldAnnotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.UpdateData(
                table: "TB_API",
                keyColumn: "ID",
                keyValue: 1,
                columns: new[] { "DATA_ALTERACAO", "DATA_INCLUSAO" },
                values: new object[] { new DateTime(2024, 12, 9, 23, 34, 8, 20, DateTimeKind.Local).AddTicks(5365), new DateTime(2024, 12, 9, 23, 34, 8, 20, DateTimeKind.Local).AddTicks(5365) });

            migrationBuilder.UpdateData(
                table: "TB_CLIENTE",
                keyColumn: "ID",
                keyValue: 1,
                columns: new[] { "DATA_ALTERACAO", "DATA_INCLUSAO" },
                values: new object[] { new DateTime(2024, 12, 9, 23, 34, 8, 20, DateTimeKind.Local).AddTicks(5365), new DateTime(2024, 12, 9, 23, 34, 8, 20, DateTimeKind.Local).AddTicks(5365) });

            migrationBuilder.UpdateData(
                table: "TB_CLIENTE_SISTEMA",
                keyColumn: "ID",
                keyValue: 1,
                columns: new[] { "DATA_ALTERACAO", "DATA_INCLUSAO" },
                values: new object[] { new DateTime(2024, 12, 9, 23, 34, 8, 20, DateTimeKind.Local).AddTicks(5365), new DateTime(2024, 12, 9, 23, 34, 8, 20, DateTimeKind.Local).AddTicks(5365) });

            migrationBuilder.UpdateData(
                table: "TB_PERFIL",
                keyColumn: "ID",
                keyValue: 1,
                columns: new[] { "DATA_ALTERACAO", "DATA_INCLUSAO" },
                values: new object[] { new DateTime(2024, 12, 9, 23, 34, 8, 20, DateTimeKind.Local).AddTicks(5365), new DateTime(2024, 12, 9, 23, 34, 8, 20, DateTimeKind.Local).AddTicks(5365) });

            migrationBuilder.UpdateData(
                table: "TB_PERFIL_API",
                keyColumn: "ID",
                keyValue: 1,
                columns: new[] { "DATA_ALTERACAO", "DATA_INCLUSAO" },
                values: new object[] { new DateTime(2024, 12, 9, 23, 34, 8, 20, DateTimeKind.Local).AddTicks(5365), new DateTime(2024, 12, 9, 23, 34, 8, 20, DateTimeKind.Local).AddTicks(5365) });

            migrationBuilder.UpdateData(
                table: "TB_SISTEMA",
                keyColumn: "ID",
                keyValue: 1,
                columns: new[] { "DATA_ALTERACAO", "DATA_INCLUSAO" },
                values: new object[] { new DateTime(2024, 12, 9, 23, 34, 8, 20, DateTimeKind.Local).AddTicks(5365), new DateTime(2024, 12, 9, 23, 34, 8, 20, DateTimeKind.Local).AddTicks(5365) });

            migrationBuilder.UpdateData(
                table: "TB_USUARIO",
                keyColumn: "ID",
                keyValue: 1,
                columns: new[] { "DATA_ALTERACAO", "DATA_INCLUSAO" },
                values: new object[] { new DateTime(2024, 12, 9, 23, 34, 8, 20, DateTimeKind.Local).AddTicks(5365), new DateTime(2024, 12, 9, 23, 34, 8, 20, DateTimeKind.Local).AddTicks(5365) });

            migrationBuilder.UpdateData(
                table: "TB_USUARIO",
                keyColumn: "ID",
                keyValue: 2,
                columns: new[] { "DATA_ALTERACAO", "DATA_INCLUSAO" },
                values: new object[] { new DateTime(2024, 12, 9, 23, 34, 8, 20, DateTimeKind.Local).AddTicks(5365), new DateTime(2024, 12, 9, 23, 34, 8, 20, DateTimeKind.Local).AddTicks(5365) });

            migrationBuilder.UpdateData(
                table: "TB_USUARIO_PERFIL",
                keyColumn: "ID",
                keyValue: 1,
                columns: new[] { "DATA_ALTERACAO", "DATA_INCLUSAO" },
                values: new object[] { new DateTime(2024, 12, 9, 23, 34, 8, 20, DateTimeKind.Local).AddTicks(5365), new DateTime(2024, 12, 9, 23, 34, 8, 20, DateTimeKind.Local).AddTicks(5365) });
        }
    }
}
