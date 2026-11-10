using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Migrations;
using WebApi2026New.Data;

namespace WebApi2026New.Migrations;

[DbContext(typeof(AppDBContext))]
[Migration("20261110190000_AgregarEdadPersona")]
public partial class AgregarEdadPersona : Migration
{
    protected override void Up(MigrationBuilder migrationBuilder)
    {
        migrationBuilder.AddColumn<int>(
            name: "edad",
            table: "Personas",
            type: "int",
            nullable: false,
            defaultValue: 0);
    }

    protected override void Down(MigrationBuilder migrationBuilder)
    {
        migrationBuilder.DropColumn(
            name: "edad",
            table: "Personas");
    }
}
