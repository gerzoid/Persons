using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Infrastructure.Migrations
{
    /// <inheritdoc />
    public partial class Rename_fields : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_SettingsTables_Tables_ListTableId",
                table: "SettingsTables");

            migrationBuilder.RenameColumn(
                name: "ListTableId",
                table: "SettingsTables",
                newName: "TableId");

            migrationBuilder.RenameIndex(
                name: "IX_SettingsTables_ListTableId_Name",
                table: "SettingsTables",
                newName: "IX_SettingsTables_TableId_Name");

            migrationBuilder.AddForeignKey(
                name: "FK_SettingsTables_Tables_TableId",
                table: "SettingsTables",
                column: "TableId",
                principalTable: "Tables",
                principalColumn: "TableId",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_SettingsTables_Tables_TableId",
                table: "SettingsTables");

            migrationBuilder.RenameColumn(
                name: "TableId",
                table: "SettingsTables",
                newName: "ListTableId");

            migrationBuilder.RenameIndex(
                name: "IX_SettingsTables_TableId_Name",
                table: "SettingsTables",
                newName: "IX_SettingsTables_ListTableId_Name");

            migrationBuilder.AddForeignKey(
                name: "FK_SettingsTables_Tables_ListTableId",
                table: "SettingsTables",
                column: "ListTableId",
                principalTable: "Tables",
                principalColumn: "TableId",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
