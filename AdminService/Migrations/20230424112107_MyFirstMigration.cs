using System;
using Microsoft.EntityFrameworkCore.Migrations;
using Npgsql.EntityFrameworkCore.PostgreSQL.Metadata;

#nullable disable

namespace AdminService.Migrations
{
    public partial class MyFirstMigration : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Roles",
                columns: table => new
                {
                    Id = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    Description = table.Column<string>(type: "character varying(100)", maxLength: 100, nullable: false),
                    CreatedOn = table.Column<DateTime>(type: "timestamp with time zone", nullable: false),
                    CreatedById = table.Column<int>(type: "integer", nullable: true),
                    ModifiedOn = table.Column<DateTime>(type: "timestamp with time zone", nullable: true),
                    ModifiedById = table.Column<int>(type: "integer", nullable: true),
                    IsActive = table.Column<bool>(type: "boolean", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Roles", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Users",
                columns: table => new
                {
                    Id = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    Name = table.Column<string>(type: "character varying(100)", unicode: false, maxLength: 100, nullable: false),
                    UserName = table.Column<string>(type: "character varying(100)", unicode: false, maxLength: 100, nullable: false),
                    Password = table.Column<string>(type: "character varying(100)", unicode: false, maxLength: 100, nullable: false),
                    EmailId = table.Column<string>(type: "character varying(100)", unicode: false, maxLength: 100, nullable: false),
                    RoleId = table.Column<int>(type: "integer", nullable: false),
                    CreatedOn = table.Column<DateTime>(type: "timestamp with time zone", nullable: false),
                    ModifiedOn = table.Column<DateTime>(type: "timestamp with time zone", nullable: true),
                    IsActive = table.Column<bool>(type: "boolean", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Users", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Users_Roles_RoleId",
                        column: x => x.RoleId,
                        principalTable: "Roles",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.InsertData(
                table: "Roles",
                columns: new[] { "Id", "CreatedById", "CreatedOn", "Description", "IsActive", "ModifiedById", "ModifiedOn" },
                values: new object[,]
                {
                    { 1, null, new DateTime(2023, 4, 24, 11, 21, 6, 847, DateTimeKind.Utc).AddTicks(7887), "Admin", true, null, null },
                    { 2, null, new DateTime(2023, 4, 24, 11, 21, 6, 847, DateTimeKind.Utc).AddTicks(7892), "Normal", true, null, null }
                });

            migrationBuilder.InsertData(
                table: "Users",
                columns: new[] { "Id", "CreatedOn", "EmailId", "IsActive", "ModifiedOn", "Name", "Password", "RoleId", "UserName" },
                values: new object[] { 1, new DateTime(2023, 4, 24, 11, 21, 6, 847, DateTimeKind.Utc).AddTicks(7918), "mak.thevar@outlook.com", true, null, "mak thevar", "25d55ad283aa400af464c76d713c07ad", 1, "mak-thevar" });

            migrationBuilder.CreateIndex(
                name: "IX_Roles_CreatedById",
                table: "Roles",
                column: "CreatedById");

            migrationBuilder.CreateIndex(
                name: "IX_Roles_ModifiedById",
                table: "Roles",
                column: "ModifiedById");

            migrationBuilder.CreateIndex(
                name: "IX_Users_EmailId",
                table: "Users",
                column: "EmailId",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_Users_RoleId",
                table: "Users",
                column: "RoleId");

            migrationBuilder.CreateIndex(
                name: "IX_Users_UserName",
                table: "Users",
                column: "UserName",
                unique: true);

            migrationBuilder.AddForeignKey(
                name: "FK_Roles_Users_CreatedById",
                table: "Roles",
                column: "CreatedById",
                principalTable: "Users",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_Roles_Users_ModifiedById",
                table: "Roles",
                column: "ModifiedById",
                principalTable: "Users",
                principalColumn: "Id");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Roles_Users_CreatedById",
                table: "Roles");

            migrationBuilder.DropForeignKey(
                name: "FK_Roles_Users_ModifiedById",
                table: "Roles");

            migrationBuilder.DropTable(
                name: "Users");

            migrationBuilder.DropTable(
                name: "Roles");
        }
    }
}
