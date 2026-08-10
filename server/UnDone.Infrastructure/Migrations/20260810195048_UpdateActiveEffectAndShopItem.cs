using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace UnDone.Infrastructure.Migrations
{
    /// <inheritdoc />
    public partial class UpdateActiveEffectAndShopItem : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "isActive",
                table: "ShopItems",
                newName: "IsActive");

            migrationBuilder.RenameColumn(
                name: "EffectType",
                table: "ActiveEffects",
                newName: "Type");

            migrationBuilder.AddColumn<int>(
                name: "EffectDurationHours",
                table: "ShopItems",
                type: "integer",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "Type",
                table: "ShopItems",
                type: "integer",
                nullable: false,
                defaultValue: 0);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "EffectDurationHours",
                table: "ShopItems");

            migrationBuilder.DropColumn(
                name: "Type",
                table: "ShopItems");

            migrationBuilder.RenameColumn(
                name: "IsActive",
                table: "ShopItems",
                newName: "isActive");

            migrationBuilder.RenameColumn(
                name: "Type",
                table: "ActiveEffects",
                newName: "EffectType");
        }
    }
}
