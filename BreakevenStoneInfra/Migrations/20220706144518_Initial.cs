using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace BreakevenStoneInfra.Migrations
{
    public partial class Initial : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Equipment",
                columns: table => new
                {
                    Id_Equipment = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Name_Equipment = table.Column<string>(type: "varchar(50)", nullable: false),
                    Input_date = table.Column<string>(type: "varchar(50)", nullable: false),
                    Description_Equipment = table.Column<string>(type: "varchar(100)", nullable: true),
                    Price = table.Column<double>(type: "float", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Equipment", x => x.Id_Equipment);
                });

            migrationBuilder.CreateTable(
                name: "Product",
                columns: table => new
                {
                    Id_Product = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Input_Date = table.Column<DateTime>(type: "datetime", nullable: false),
                    Status_Product = table.Column<string>(type: "varchar(100)", nullable: false),
                    Name_Product = table.Column<string>(type: "varchar(50)", nullable: false),
                    Price_Product = table.Column<double>(type: "float", nullable: false),
                    Output_Date = table.Column<DateTime>(type: "datetime", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Product", x => x.Id_Product);
                });

            migrationBuilder.CreateTable(
                name: "User",
                columns: table => new
                {
                    Id_User = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Password = table.Column<string>(type: "varchar(50)", nullable: false),
                    First_Name = table.Column<string>(type: "varchar(20)", nullable: false),
                    Last_Name = table.Column<string>(type: "varchar(20)", nullable: false),
                    CPF = table.Column<string>(type: "varchar(11)", nullable: false),
                    Created = table.Column<DateTime>(type: "datetime2", nullable: false),
                    Birthday = table.Column<DateTime>(type: "datetime2", nullable: false),
                    Address = table.Column<string>(type: "varchar(200)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_User", x => x.Id_User);
                });

            migrationBuilder.CreateTable(
                name: "Employee",
                columns: table => new
                {
                    Id_User = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Id_Employee = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Function_Employee = table.Column<string>(type: "varchar(50)", nullable: false),
                    Salary = table.Column<double>(type: "float", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Employee", x => x.Id_User);
                    table.ForeignKey(
                        name: "FK_Employee_User_Id_User",
                        column: x => x.Id_User,
                        principalTable: "User",
                        principalColumn: "Id_User",
                        onDelete: ReferentialAction.Restrict);
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Employee");

            migrationBuilder.DropTable(
                name: "Equipment");

            migrationBuilder.DropTable(
                name: "Product");

            migrationBuilder.DropTable(
                name: "User");
        }
    }
}
