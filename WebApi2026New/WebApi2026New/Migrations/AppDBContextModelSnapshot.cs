using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using WebApi2026New.Data;
using WebApi2026New.Models;

namespace WebApi2026New.Migrations;

[DbContext(typeof(AppDBContext))]
public partial class AppDBContextModelSnapshot : ModelSnapshot
{
    protected override void BuildModel(ModelBuilder modelBuilder)
    {
        modelBuilder
            .HasAnnotation("ProductVersion", "10.0.13")
            .HasAnnotation("Relational:MaxIdentifierLength", 128);

        modelBuilder.Entity<Persona>(entity =>
        {
            entity.Property(persona => persona.idPersona)
                .ValueGeneratedOnAdd()
                .UseIdentityColumn()
                .HasColumnType("int");
            entity.Property(persona => persona.nombre)
                .IsRequired()
                .HasColumnType("nvarchar(max)");
            entity.Property(persona => persona.apellido)
                .IsRequired()
                .HasColumnType("nvarchar(max)");
            entity.Property(persona => persona.edad)
                .HasColumnType("int");
            entity.Property(persona => persona.correo)
                .IsRequired()
                .HasColumnType("nvarchar(max)");
            entity.Property(persona => persona.password)
                .IsRequired()
                .HasColumnType("nvarchar(max)");
            entity.HasKey(persona => persona.idPersona);
            entity.ToTable("Personas");
        });

        modelBuilder.Entity<Direccion>(entity =>
        {
            entity.Property(direccion => direccion.idDireccion)
                .ValueGeneratedOnAdd()
                .UseIdentityColumn()
                .HasColumnType("int");
            entity.Property(direccion => direccion.calle)
                .HasColumnType("nvarchar(max)");
            entity.Property(direccion => direccion.ciudad)
                .HasColumnType("nvarchar(max)");
            entity.Property(direccion => direccion.departamento)
                .HasColumnType("nvarchar(max)");
            entity.Property(direccion => direccion.pais)
                .HasColumnType("nvarchar(max)");
            entity.Property(direccion => direccion.codigoPostal)
                .HasColumnType("nvarchar(max)");
            entity.Property(direccion => direccion.PersonaId)
                .HasColumnType("int");
            entity.HasKey(direccion => direccion.idDireccion);
            entity.HasIndex(direccion => direccion.PersonaId);
            entity.ToTable("Direcciones");
        });

        modelBuilder.Entity<Direccion>()
            .HasOne(direccion => direccion.persona)
            .WithMany(persona => persona.Direcciones)
            .HasForeignKey(direccion => direccion.PersonaId)
            .OnDelete(DeleteBehavior.Cascade)
            .IsRequired();
    }
}
