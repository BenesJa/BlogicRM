using Microsoft.EntityFrameworkCore.Migrations;

namespace BlogicRM.Migrations
{
    public partial class mig14 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "ID",
                table: "Consultant",
                newName: "ConsultantID");

            migrationBuilder.RenameColumn(
                name: "ID",
                table: "Client",
                newName: "ClientID");

            migrationBuilder.CreateIndex(
                name: "IX_Contract_ClientID",
                table: "Contract",
                column: "ClientID");

            migrationBuilder.CreateIndex(
                name: "IX_Contract_ConsultantID",
                table: "Contract",
                column: "ConsultantID");

            migrationBuilder.AddForeignKey(
                name: "FK_Contract_Client_ClientID",
                table: "Contract",
                column: "ClientID",
                principalTable: "Client",
                principalColumn: "ClientID",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Contract_Consultant_ConsultantID",
                table: "Contract",
                column: "ConsultantID",
                principalTable: "Consultant",
                principalColumn: "ConsultantID",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Contract_Client_ClientID",
                table: "Contract");

            migrationBuilder.DropForeignKey(
                name: "FK_Contract_Consultant_ConsultantID",
                table: "Contract");

            migrationBuilder.DropIndex(
                name: "IX_Contract_ClientID",
                table: "Contract");

            migrationBuilder.DropIndex(
                name: "IX_Contract_ConsultantID",
                table: "Contract");

            migrationBuilder.RenameColumn(
                name: "ConsultantID",
                table: "Consultant",
                newName: "ID");

            migrationBuilder.RenameColumn(
                name: "ClientID",
                table: "Client",
                newName: "ID");
        }
    }
}
