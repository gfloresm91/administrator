using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Administrator.Infrastructure.Migrations.PortfolioMigrations
{
    public partial class PortfolioThirdMigration : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_SkillsDetails_Skills_IdSkill",
                table: "SkillsDetails");

            migrationBuilder.DropForeignKey(
                name: "FK_SkillsItems_SkillsDetails_IdSkillDetail",
                table: "SkillsItems");

            migrationBuilder.RenameColumn(
                name: "IdSkillDetail",
                table: "SkillsItems",
                newName: "SkillDetailId");

            migrationBuilder.RenameIndex(
                name: "IX_SkillsItems_IdSkillDetail",
                table: "SkillsItems",
                newName: "IX_SkillsItems_SkillDetailId");

            migrationBuilder.RenameColumn(
                name: "IdSkill",
                table: "SkillsDetails",
                newName: "SkillId");

            migrationBuilder.RenameIndex(
                name: "IX_SkillsDetails_IdSkill",
                table: "SkillsDetails",
                newName: "IX_SkillsDetails_SkillId");

            migrationBuilder.AddColumn<int>(
                name: "UserInfoId",
                table: "Skills",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.CreateIndex(
                name: "IX_Skills_UserInfoId",
                table: "Skills",
                column: "UserInfoId");

            migrationBuilder.AddForeignKey(
                name: "FK_Skills_UsersInfo_UserInfoId",
                table: "Skills",
                column: "UserInfoId",
                principalTable: "UsersInfo",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_SkillsDetails_Skills_SkillId",
                table: "SkillsDetails",
                column: "SkillId",
                principalTable: "Skills",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_SkillsItems_SkillsDetails_SkillDetailId",
                table: "SkillsItems",
                column: "SkillDetailId",
                principalTable: "SkillsDetails",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Skills_UsersInfo_UserInfoId",
                table: "Skills");

            migrationBuilder.DropForeignKey(
                name: "FK_SkillsDetails_Skills_SkillId",
                table: "SkillsDetails");

            migrationBuilder.DropForeignKey(
                name: "FK_SkillsItems_SkillsDetails_SkillDetailId",
                table: "SkillsItems");

            migrationBuilder.DropIndex(
                name: "IX_Skills_UserInfoId",
                table: "Skills");

            migrationBuilder.DropColumn(
                name: "UserInfoId",
                table: "Skills");

            migrationBuilder.RenameColumn(
                name: "SkillDetailId",
                table: "SkillsItems",
                newName: "IdSkillDetail");

            migrationBuilder.RenameIndex(
                name: "IX_SkillsItems_SkillDetailId",
                table: "SkillsItems",
                newName: "IX_SkillsItems_IdSkillDetail");

            migrationBuilder.RenameColumn(
                name: "SkillId",
                table: "SkillsDetails",
                newName: "IdSkill");

            migrationBuilder.RenameIndex(
                name: "IX_SkillsDetails_SkillId",
                table: "SkillsDetails",
                newName: "IX_SkillsDetails_IdSkill");

            migrationBuilder.AddForeignKey(
                name: "FK_SkillsDetails_Skills_IdSkill",
                table: "SkillsDetails",
                column: "IdSkill",
                principalTable: "Skills",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_SkillsItems_SkillsDetails_IdSkillDetail",
                table: "SkillsItems",
                column: "IdSkillDetail",
                principalTable: "SkillsDetails",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
