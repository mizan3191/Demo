using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace Demo.Web.Data.Migrations
{
    public partial class UserTable : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(name: "FK_AspNetUserTokens_AspNetUsers_UserId",
                table: "AspNetUserTokens");
            migrationBuilder.DropForeignKey(name: "FK_AspNetUserRoles_AspNetUsers_UserId",
                table: "AspNetUserRoles");
            migrationBuilder.DropForeignKey(name: "FK_AspNetUserLogins_AspNetUsers_UserId",
                table: "AspNetUserLogins");
            migrationBuilder.DropForeignKey(name: "FK_AspNetUserClaims_AspNetUsers_UserId",
                table: "AspNetUserClaims");
            migrationBuilder.DropForeignKey(name: "FK_AspNetUserRoles_AspNetRoles_RoleId",
                table: "AspNetUserRoles");
            migrationBuilder.DropForeignKey(name: "FK_AspNetRoleClaims_AspNetRoles_RoleId",
                table: "AspNetRoleClaims");
            migrationBuilder.DropPrimaryKey(name: "PK_AspNetUsers", table: "AspNetUsers");
            migrationBuilder.DropPrimaryKey(name: "PK_AspNetUserTokens", table: "AspNetUserTokens");
            migrationBuilder.DropPrimaryKey(name: "PK_AspNetUserRoles", table: "AspNetUserRoles");
            migrationBuilder.DropPrimaryKey(name: "PK_AspNetRoles", table: "AspNetRoles");

            migrationBuilder.AlterColumn<string>(
                name: "Name",
                table: "AspNetUserTokens",
                type: "nvarchar(450)",
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(128)",
                oldMaxLength: 128);

            migrationBuilder.AlterColumn<string>(
                name: "LoginProvider",
                table: "AspNetUserTokens",
                type: "nvarchar(450)",
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(128)",
                oldMaxLength: 128);

            migrationBuilder.AlterColumn<Guid>(
                name: "UserId",
                table: "AspNetUserTokens",
                type: "uniqueidentifier",
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(450)");

            migrationBuilder.AlterColumn<Guid>(
                name: "Id",
                table: "AspNetUsers",
                type: "uniqueidentifier",
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(450)");

            migrationBuilder.AddColumn<string>(
                name: "FullName",
                table: "AspNetUsers",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AlterColumn<Guid>(
                name: "RoleId",
                table: "AspNetUserRoles",
                type: "uniqueidentifier",
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(450)");

            migrationBuilder.AlterColumn<Guid>(
                name: "UserId",
                table: "AspNetUserRoles",
                type: "uniqueidentifier",
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(450)");

            migrationBuilder.AlterColumn<Guid>(
                name: "UserId",
                table: "AspNetUserLogins",
                type: "uniqueidentifier",
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(450)");

            migrationBuilder.AlterColumn<string>(
                name: "ProviderKey",
                table: "AspNetUserLogins",
                type: "nvarchar(450)",
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(128)",
                oldMaxLength: 128);

            migrationBuilder.AlterColumn<string>(
                name: "LoginProvider",
                table: "AspNetUserLogins",
                type: "nvarchar(450)",
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(128)",
                oldMaxLength: 128);

            migrationBuilder.AlterColumn<Guid>(
                name: "UserId",
                table: "AspNetUserClaims",
                type: "uniqueidentifier",
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(450)");

            migrationBuilder.AlterColumn<Guid>(
                name: "Id",
                table: "AspNetRoles",
                type: "uniqueidentifier",
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(450)");

            migrationBuilder.AlterColumn<Guid>(
                name: "RoleId",
                table: "AspNetRoleClaims",
                type: "uniqueidentifier",
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(450)");

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[] { new Guid("c920988a-47c2-49a5-a14a-6f7163324301"), "a4d9d789-2b78-4218-9f1a-4bd3c29412a4", "SuperAdmin", "SUPERADMIN" });

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[] { new Guid("87d4fe2e-4f6a-43da-acf7-23dfbcb7d411"), "e76a9d19-05b2-4f23-a3b0-cb6a70bfdde3", "Manager", "MANAGER" });

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[] { new Guid("3d560c91-87ba-49c9-9b47-1a0036c27291"), "d3952bca-e96a-4afd-99eb-f7a7d1d37d24", "User", "USER" });


            migrationBuilder.AddPrimaryKey(name: "PK_AspNetRoles", table: "AspNetRoles", column: "Id");
            migrationBuilder.AddPrimaryKey(name: "PK_AspNetUserRoles", table: "AspNetUserRoles", columns: new[] { "UserId", "RoleId" });
            migrationBuilder.AddPrimaryKey(name: "PK_AspNetUserTokens", table: "AspNetUserTokens", columns: new[] { "UserId", "LoginProvider", "Name" });
            migrationBuilder.AddPrimaryKey(name: "PK_AspNetUsers", table: "AspNetUsers", column: "Id");
            migrationBuilder.AddForeignKey(name: "FK_AspNetRoleClaims_AspNetRoles_RoleId",
                table: "AspNetRoleClaims", column: "RoleId", principalTable: "AspNetRoles", principalColumn: "Id");
            migrationBuilder.AddForeignKey(name: "FK_AspNetUserRoles_AspNetRoles_RoleId",
                table: "AspNetUserRoles", column: "RoleId", principalTable: "AspNetRoles", principalColumn: "Id");
            migrationBuilder.AddForeignKey(name: "FK_AspNetUserClaims_AspNetUsers_UserId",
                table: "AspNetUserClaims", column: "UserId", principalTable: "AspNetUsers", principalColumn: "Id");
            migrationBuilder.AddForeignKey(name: "FK_AspNetUserLogins_AspNetUsers_UserId",
                table: "AspNetUserLogins", column: "UserId", principalTable: "AspNetUsers", principalColumn: "Id");
            migrationBuilder.AddForeignKey(name: "FK_AspNetUserRoles_AspNetUsers_UserId",
                table: "AspNetUserRoles", column: "UserId", principalTable: "AspNetUsers", principalColumn: "Id");
            migrationBuilder.AddForeignKey(name: "FK_AspNetUserTokens_AspNetUsers_UserId",
                table: "AspNetUserTokens", column: "UserId", principalTable: "AspNetUsers", principalColumn: "Id");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: new Guid("3d560c91-87ba-49c9-9b47-1a0036c27291"));

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: new Guid("87d4fe2e-4f6a-43da-acf7-23dfbcb7d411"));

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: new Guid("c920988a-47c2-49a5-a14a-6f7163324301"));

            migrationBuilder.DropColumn(
                name: "FullName",
                table: "AspNetUsers");

            migrationBuilder.AlterColumn<string>(
                name: "Name",
                table: "AspNetUserTokens",
                type: "nvarchar(128)",
                maxLength: 128,
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(450)");

            migrationBuilder.AlterColumn<string>(
                name: "LoginProvider",
                table: "AspNetUserTokens",
                type: "nvarchar(128)",
                maxLength: 128,
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(450)");

            migrationBuilder.AlterColumn<string>(
                name: "UserId",
                table: "AspNetUserTokens",
                type: "nvarchar(450)",
                nullable: false,
                oldClrType: typeof(Guid),
                oldType: "uniqueidentifier");

            migrationBuilder.AlterColumn<string>(
                name: "Id",
                table: "AspNetUsers",
                type: "nvarchar(450)",
                nullable: false,
                oldClrType: typeof(Guid),
                oldType: "uniqueidentifier");

            migrationBuilder.AlterColumn<string>(
                name: "RoleId",
                table: "AspNetUserRoles",
                type: "nvarchar(450)",
                nullable: false,
                oldClrType: typeof(Guid),
                oldType: "uniqueidentifier");

            migrationBuilder.AlterColumn<string>(
                name: "UserId",
                table: "AspNetUserRoles",
                type: "nvarchar(450)",
                nullable: false,
                oldClrType: typeof(Guid),
                oldType: "uniqueidentifier");

            migrationBuilder.AlterColumn<string>(
                name: "UserId",
                table: "AspNetUserLogins",
                type: "nvarchar(450)",
                nullable: false,
                oldClrType: typeof(Guid),
                oldType: "uniqueidentifier");

            migrationBuilder.AlterColumn<string>(
                name: "ProviderKey",
                table: "AspNetUserLogins",
                type: "nvarchar(128)",
                maxLength: 128,
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(450)");

            migrationBuilder.AlterColumn<string>(
                name: "LoginProvider",
                table: "AspNetUserLogins",
                type: "nvarchar(128)",
                maxLength: 128,
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(450)");

            migrationBuilder.AlterColumn<string>(
                name: "UserId",
                table: "AspNetUserClaims",
                type: "nvarchar(450)",
                nullable: false,
                oldClrType: typeof(Guid),
                oldType: "uniqueidentifier");

            migrationBuilder.AlterColumn<string>(
                name: "Id",
                table: "AspNetRoles",
                type: "nvarchar(450)",
                nullable: false,
                oldClrType: typeof(Guid),
                oldType: "uniqueidentifier");

            migrationBuilder.AlterColumn<string>(
                name: "RoleId",
                table: "AspNetRoleClaims",
                type: "nvarchar(450)",
                nullable: false,
                oldClrType: typeof(Guid),
                oldType: "uniqueidentifier");
        }
    }
}
