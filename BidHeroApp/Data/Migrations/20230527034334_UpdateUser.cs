using BidHeroApp.Models;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace BidHeroApp.Data.Migrations
{
    /// <inheritdoc />
    public partial class UpdateUser : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(name: "GivenName", table: "AspNetUsers", type: "nvarchar(100)", maxLength: 100, nullable: true);
            migrationBuilder.AddColumn<string>(name: "FamilyName", table: "AspNetUsers", type: "nvarchar(100)", maxLength: 100, nullable: true);
            migrationBuilder.AddColumn<int>(name: "Gender", table: "AspNetUsers", type: "int", nullable: true);
            migrationBuilder.AddColumn<int>(name: "BirthDate", table: "AspNetUsers", type: "date", nullable: true);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(name: "GivenName", table: "AspNetUsers");
            migrationBuilder.DropColumn(name: "FamilyName", table: "AspNetUsers");
            migrationBuilder.DropColumn(name: "Gender", table: "AspNetUsers");
            migrationBuilder.DropColumn(name: "BirthDate", table: "AspNetUsers");
        }
    }
}
