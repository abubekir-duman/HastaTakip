using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace DataAccess.Migrations
{
    /// <inheritdoc />
    public partial class v3 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_DoktorHasta_Doktorlar_DoktorId",
                table: "DoktorHasta");

            migrationBuilder.DropForeignKey(
                name: "FK_DoktorHasta_Hastalar_HastaId",
                table: "DoktorHasta");

            migrationBuilder.DropPrimaryKey(
                name: "PK_DoktorHasta",
                table: "DoktorHasta");

            migrationBuilder.RenameTable(
                name: "DoktorHasta",
                newName: "DoktorHastalar");

            migrationBuilder.RenameIndex(
                name: "IX_DoktorHasta_HastaId",
                table: "DoktorHastalar",
                newName: "IX_DoktorHastalar_HastaId");

            migrationBuilder.RenameIndex(
                name: "IX_DoktorHasta_DoktorId",
                table: "DoktorHastalar",
                newName: "IX_DoktorHastalar_DoktorId");

            migrationBuilder.AddPrimaryKey(
                name: "PK_DoktorHastalar",
                table: "DoktorHastalar",
                column: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_DoktorHastalar_Doktorlar_DoktorId",
                table: "DoktorHastalar",
                column: "DoktorId",
                principalTable: "Doktorlar",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_DoktorHastalar_Hastalar_HastaId",
                table: "DoktorHastalar",
                column: "HastaId",
                principalTable: "Hastalar",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_DoktorHastalar_Doktorlar_DoktorId",
                table: "DoktorHastalar");

            migrationBuilder.DropForeignKey(
                name: "FK_DoktorHastalar_Hastalar_HastaId",
                table: "DoktorHastalar");

            migrationBuilder.DropPrimaryKey(
                name: "PK_DoktorHastalar",
                table: "DoktorHastalar");

            migrationBuilder.RenameTable(
                name: "DoktorHastalar",
                newName: "DoktorHasta");

            migrationBuilder.RenameIndex(
                name: "IX_DoktorHastalar_HastaId",
                table: "DoktorHasta",
                newName: "IX_DoktorHasta_HastaId");

            migrationBuilder.RenameIndex(
                name: "IX_DoktorHastalar_DoktorId",
                table: "DoktorHasta",
                newName: "IX_DoktorHasta_DoktorId");

            migrationBuilder.AddPrimaryKey(
                name: "PK_DoktorHasta",
                table: "DoktorHasta",
                column: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_DoktorHasta_Doktorlar_DoktorId",
                table: "DoktorHasta",
                column: "DoktorId",
                principalTable: "Doktorlar",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_DoktorHasta_Hastalar_HastaId",
                table: "DoktorHasta",
                column: "HastaId",
                principalTable: "Hastalar",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
