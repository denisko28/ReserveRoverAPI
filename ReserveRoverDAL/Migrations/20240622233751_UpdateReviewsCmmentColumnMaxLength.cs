using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace ReserveRoverDAL.Migrations
{
    /// <inheritdoc />
    public partial class UpdateReviewsCmmentColumnMaxLength : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<decimal>(
                name: "mark",
                table: "reviews",
                type: "numeric(1)",
                precision: 1,
                nullable: false,
                oldClrType: typeof(decimal),
                oldType: "numeric(1,0)",
                oldPrecision: 1);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<decimal>(
                name: "mark",
                table: "reviews",
                type: "numeric(1,0)",
                precision: 1,
                nullable: false,
                oldClrType: typeof(decimal),
                oldType: "numeric(1)",
                oldPrecision: 1);
        }
    }
}
