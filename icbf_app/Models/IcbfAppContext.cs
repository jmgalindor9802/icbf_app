using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;

namespace icbf_app.Models;

public partial class IcbfAppContext : DbContext
{
    public IcbfAppContext()
    {
    }

    public IcbfAppContext(DbContextOptions<IcbfAppContext> options)
        : base(options)
    {
    }

    public virtual DbSet<AspNetRole> AspNetRoles { get; set; }

    public virtual DbSet<AspNetRoleClaim> AspNetRoleClaims { get; set; }

    public virtual DbSet<AspNetUser> AspNetUsers { get; set; }

    public virtual DbSet<AspNetUserClaim> AspNetUserClaims { get; set; }

    public virtual DbSet<AspNetUserLogin> AspNetUserLogins { get; set; }

    public virtual DbSet<AspNetUserToken> AspNetUserTokens { get; set; }

    public virtual DbSet<Jardin> Jardines { get; set; }

    public virtual DbSet<MadreComunitaria> MadresComunitarias { get; set; }

    public virtual DbSet<Nino> Ninos { get; set; }

    public virtual DbSet<RegistroAsistencia> RegistrosAsistencia { get; set; }

    public virtual DbSet<RegistroAvanceAcademico> RegistrosAvanceAcademicos { get; set; }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
#warning To protect potentially sensitive information in your connection string, you should move it out of source code. You can avoid scaffolding the connection string by using the Name= syntax to read it from configuration - see https://go.microsoft.com/fwlink/?linkid=2131148. For more guidance on storing connection strings, see https://go.microsoft.com/fwlink/?LinkId=723263.
        => optionsBuilder.UseSqlServer("Data Source=DESKTOP-HP\\SQLEXPRESS;Initial Catalog=icbf_app;Integrated Security=True;Connect Timeout=30;Encrypt=True;Trust Server Certificate=True;Application Intent=ReadWrite;Multi Subnet Failover=False");

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<AspNetRole>(entity =>
        {
            entity.HasIndex(e => e.NormalizedName, "RoleNameIndex")
                .IsUnique()
                .HasFilter("([NormalizedName] IS NOT NULL)");

            entity.Property(e => e.Name).HasMaxLength(256);
            entity.Property(e => e.NormalizedName).HasMaxLength(256);
        });

        modelBuilder.Entity<AspNetRoleClaim>(entity =>
        {
            entity.HasIndex(e => e.RoleId, "IX_AspNetRoleClaims_RoleId");

            entity.HasOne(d => d.Role).WithMany(p => p.AspNetRoleClaims).HasForeignKey(d => d.RoleId);
        });

        modelBuilder.Entity<AspNetUser>(entity =>
        {
            entity.HasIndex(e => e.NormalizedEmail, "EmailIndex");

            entity.HasIndex(e => e.NormalizedUserName, "UserNameIndex")
                .IsUnique()
                .HasFilter("([NormalizedUserName] IS NOT NULL)");

            entity.Property(e => e.Email).HasMaxLength(256);
            entity.Property(e => e.NormalizedEmail).HasMaxLength(256);
            entity.Property(e => e.NormalizedUserName).HasMaxLength(256);
            entity.Property(e => e.UserName).HasMaxLength(256);

            entity.HasMany(d => d.Roles).WithMany(p => p.Users)
                .UsingEntity<Dictionary<string, object>>(
                    "AspNetUserRole",
                    r => r.HasOne<AspNetRole>().WithMany().HasForeignKey("RoleId"),
                    l => l.HasOne<AspNetUser>().WithMany().HasForeignKey("UserId"),
                    j =>
                    {
                        j.HasKey("UserId", "RoleId");
                        j.ToTable("AspNetUserRoles");
                        j.HasIndex(new[] { "RoleId" }, "IX_AspNetUserRoles_RoleId");
                    });
        });

        modelBuilder.Entity<AspNetUserClaim>(entity =>
        {
            entity.HasIndex(e => e.UserId, "IX_AspNetUserClaims_UserId");

            entity.HasOne(d => d.User).WithMany(p => p.AspNetUserClaims).HasForeignKey(d => d.UserId);
        });

        modelBuilder.Entity<AspNetUserLogin>(entity =>
        {
            entity.HasKey(e => new { e.LoginProvider, e.ProviderKey });

            entity.HasIndex(e => e.UserId, "IX_AspNetUserLogins_UserId");

            entity.HasOne(d => d.User).WithMany(p => p.AspNetUserLogins).HasForeignKey(d => d.UserId);
        });

        modelBuilder.Entity<AspNetUserToken>(entity =>
        {
            entity.HasKey(e => new { e.UserId, e.LoginProvider, e.Name });

            entity.HasOne(d => d.User).WithMany(p => p.AspNetUserTokens).HasForeignKey(d => d.UserId);
        });

        modelBuilder.Entity<Jardin>(entity =>
        {
            entity.HasKey(e => e.IdJardin).HasName("PK__Jardines__7E67FC6D40476AAA");

            entity.Property(e => e.DireccionJardin).HasColumnName("direccionJardin");
            entity.Property(e => e.EstadoJardin)
                .HasMaxLength(50)
                .IsUnicode(false)
                .HasColumnName("estadoJardin");
            entity.Property(e => e.NombreJardin)
                .HasMaxLength(50)
                .IsUnicode(false)
                .HasColumnName("nombreJardin");
        });

        modelBuilder.Entity<MadreComunitaria>(entity =>
        {
            entity.HasKey(e => e.IdMadreComunitaria).HasName("PK__MadresCo__A3BE9115D749A139");

            entity.Property(e => e.IdMadreComunitaria).ValueGeneratedNever();
            entity.Property(e => e.FechaNacimientoMadre).HasColumnName("fechaNacimientoMadre");
            entity.Property(e => e.IdUsuario).HasMaxLength(450);

            entity.HasOne(d => d.IdJardinNavigation).WithMany(p => p.MadresComunitaria)
                .HasForeignKey(d => d.IdJardin)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_Jardin");

            entity.HasOne(d => d.IdUsuarioNavigation).WithMany(p => p.MadresComunitaria)
                .HasForeignKey(d => d.IdUsuario)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_Usuario");
        });

        modelBuilder.Entity<Nino>(entity =>
        {
            entity.HasKey(e => e.IdNino).HasName("PK__Ninos__4059CA1FC61F3A7A");

            entity.Property(e => e.IdNino).ValueGeneratedNever();
            entity.Property(e => e.CiudadNacimientoNino)
                .HasMaxLength(50)
                .IsUnicode(false)
                .HasColumnName("ciudadNacimientoNino");
            entity.Property(e => e.DireccionNino)
                .HasMaxLength(50)
                .IsUnicode(false)
                .HasColumnName("direccionNino");
            entity.Property(e => e.EpsNino)
                .HasMaxLength(50)
                .IsUnicode(false)
                .HasColumnName("epsNino");
            entity.Property(e => e.FechaNacimientoNino).HasColumnName("fechaNacimientoNino");
            entity.Property(e => e.IdAcudiente)
                .HasMaxLength(450)
                .HasColumnName("idAcudiente");
            entity.Property(e => e.IdJardin).HasColumnName("idJardin");
            entity.Property(e => e.NombreNino)
                .HasMaxLength(10)
                .IsFixedLength()
                .HasColumnName("nombreNino");
            entity.Property(e => e.TelefonoNino)
                .HasMaxLength(50)
                .IsUnicode(false)
                .HasColumnName("telefonoNino");
            entity.Property(e => e.TipoSangreNino)
                .HasMaxLength(10)
                .IsFixedLength()
                .HasColumnName("tipoSangreNino");

            entity.HasOne(d => d.IdAcudienteNavigation).WithMany(p => p.Ninos)
                .HasForeignKey(d => d.IdAcudiente)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_NinoAcudiente");

            entity.HasOne(d => d.IdJardinNavigation).WithMany(p => p.Ninos)
                .HasForeignKey(d => d.IdJardin)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_JardinNino");
        });

        modelBuilder.Entity<RegistroAsistencia>(entity =>
        {
            entity.HasKey(e => e.IdRegistroAsistencia).HasName("PK__Registro__D29C5314CB323579");

            entity.Property(e => e.IdRegistroAsistencia).ValueGeneratedNever();
            entity.Property(e => e.EstadoNinoRegistro)
                .HasMaxLength(10)
                .IsFixedLength()
                .HasColumnName("estadoNinoRegistro");
            entity.Property(e => e.FechaRegistro).HasColumnName("fechaRegistro");
            entity.Property(e => e.IdNino).HasColumnName("idNino");

            entity.HasOne(d => d.IdNinoNavigation).WithMany(p => p.RegistrosAsistencia)
                .HasForeignKey(d => d.IdNino)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_RegistrosAsistencia_Ninos");
        });

        modelBuilder.Entity<RegistroAvanceAcademico>(entity =>
        {
            entity.HasKey(e => e.IdAvance).HasName("PK__Registro__D83056646D1EE765");

            entity.ToTable("RegistrosAvanceAcademico");

            entity.Property(e => e.IdAvance).ValueGeneratedNever();
            entity.Property(e => e.AnioEscolarAvance).HasColumnName("anioEscolarAvance");
            entity.Property(e => e.DescripcionAvance)
                .HasColumnType("text")
                .HasColumnName("descripcionAvance");
            entity.Property(e => e.FechaEntregaAvance).HasColumnName("fechaEntregaAvance");
            entity.Property(e => e.IdNino).HasColumnName("idNino");
            entity.Property(e => e.NivelAvance)
                .HasMaxLength(50)
                .IsUnicode(false)
                .HasColumnName("nivelAvance");
            entity.Property(e => e.NotaAvance)
                .HasMaxLength(1)
                .IsFixedLength()
                .HasColumnName("notaAvance");

            entity.HasOne(d => d.IdNinoNavigation).WithMany(p => p.RegistrosAvanceAcademicos)
                .HasForeignKey(d => d.IdNino)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_RegistrosAvanceAcademico_Ninos");
        });

        OnModelCreatingPartial(modelBuilder);
    }

    partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
}
