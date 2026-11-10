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
        migrationBuilder.Sql("""
            IF COL_LENGTH(N'dbo.Personas', N'edad') IS NULL
            BEGIN
                ALTER TABLE [dbo].[Personas]
                ADD [edad] int NOT NULL
                    CONSTRAINT [DF_Personas_edad] DEFAULT (0);
            END;
            """);

        migrationBuilder.AlterColumn<string>(
            name: "password",
            table: "Personas",
            type: "nvarchar(max)",
            nullable: false,
            oldClrType: typeof(int),
            oldType: "int");
    }

    protected override void Down(MigrationBuilder migrationBuilder)
    {
        throw new NotSupportedException(
            "No se revierte esta migración porque las contraseñas pueden contener hashes BCrypt no convertibles a int.");
    }
}
