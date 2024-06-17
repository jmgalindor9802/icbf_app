using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace icbf_app.Migrations
{
    /// <inheritdoc />
    public partial class segundaMigracion : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "AspNetRoles",
                columns: table => new
                {
                    Id = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    Name = table.Column<string>(type: "nvarchar(256)", maxLength: 256, nullable: true),
                    NormalizedName = table.Column<string>(type: "nvarchar(256)", maxLength: 256, nullable: true),
                    ConcurrencyStamp = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AspNetRoles", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "AspNetUsers",
                columns: table => new
                {
                    Id = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    UserName = table.Column<string>(type: "nvarchar(256)", maxLength: 256, nullable: true),
                    NormalizedUserName = table.Column<string>(type: "nvarchar(256)", maxLength: 256, nullable: true),
                    Email = table.Column<string>(type: "nvarchar(256)", maxLength: 256, nullable: true),
                    NormalizedEmail = table.Column<string>(type: "nvarchar(256)", maxLength: 256, nullable: true),
                    EmailConfirmed = table.Column<bool>(type: "bit", nullable: false),
                    PasswordHash = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    SecurityStamp = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    ConcurrencyStamp = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    PhoneNumber = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    PhoneNumberConfirmed = table.Column<bool>(type: "bit", nullable: false),
                    TwoFactorEnabled = table.Column<bool>(type: "bit", nullable: false),
                    LockoutEnd = table.Column<DateTimeOffset>(type: "datetimeoffset", nullable: true),
                    LockoutEnabled = table.Column<bool>(type: "bit", nullable: false),
                    AccessFailedCount = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AspNetUsers", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Jardines",
                columns: table => new
                {
                    IdJardin = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    nombreJardin = table.Column<string>(type: "varchar(50)", unicode: false, maxLength: 50, nullable: false),
                    direccionJardin = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    estadoJardin = table.Column<string>(type: "varchar(50)", unicode: false, maxLength: 50, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK__Jardines__7E67FC6D40476AAA", x => x.IdJardin);
                });

            migrationBuilder.CreateTable(
                name: "AspNetRoleClaims",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    RoleId = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    ClaimType = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    ClaimValue = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AspNetRoleClaims", x => x.Id);
                    table.ForeignKey(
                        name: "FK_AspNetRoleClaims_AspNetRoles_RoleId",
                        column: x => x.RoleId,
                        principalTable: "AspNetRoles",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "AspNetUserClaims",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    UserId = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    ClaimType = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    ClaimValue = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AspNetUserClaims", x => x.Id);
                    table.ForeignKey(
                        name: "FK_AspNetUserClaims_AspNetUsers_UserId",
                        column: x => x.UserId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "AspNetUserLogins",
                columns: table => new
                {
                    LoginProvider = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    ProviderKey = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    ProviderDisplayName = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    UserId = table.Column<string>(type: "nvarchar(450)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AspNetUserLogins", x => new { x.LoginProvider, x.ProviderKey });
                    table.ForeignKey(
                        name: "FK_AspNetUserLogins_AspNetUsers_UserId",
                        column: x => x.UserId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "AspNetUserRoles",
                columns: table => new
                {
                    UserId = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    RoleId = table.Column<string>(type: "nvarchar(450)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AspNetUserRoles", x => new { x.UserId, x.RoleId });
                    table.ForeignKey(
                        name: "FK_AspNetUserRoles_AspNetRoles_RoleId",
                        column: x => x.RoleId,
                        principalTable: "AspNetRoles",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_AspNetUserRoles_AspNetUsers_UserId",
                        column: x => x.UserId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "AspNetUserTokens",
                columns: table => new
                {
                    UserId = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    LoginProvider = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    Name = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    Value = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AspNetUserTokens", x => new { x.UserId, x.LoginProvider, x.Name });
                    table.ForeignKey(
                        name: "FK_AspNetUserTokens_AspNetUsers_UserId",
                        column: x => x.UserId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "MadresComunitarias",
                columns: table => new
                {
                    IdMadreComunitaria = table.Column<int>(type: "int", nullable: false),
                    fechaNacimientoMadre = table.Column<DateOnly>(type: "date", nullable: false),
                    IdJardin = table.Column<int>(type: "int", nullable: false),
                    IdUsuario = table.Column<string>(type: "nvarchar(450)", maxLength: 450, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK__MadresCo__A3BE9115D749A139", x => x.IdMadreComunitaria);
                    table.ForeignKey(
                        name: "FK_Jardin",
                        column: x => x.IdJardin,
                        principalTable: "Jardines",
                        principalColumn: "IdJardin");
                    table.ForeignKey(
                        name: "FK_Usuario",
                        column: x => x.IdUsuario,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateTable(
                name: "Ninos",
                columns: table => new
                {
                    IdNino = table.Column<long>(type: "bigint", nullable: false),
                    nombreNino = table.Column<string>(type: "nchar(10)", fixedLength: true, maxLength: 10, nullable: false),
                    fechaNacimientoNino = table.Column<DateOnly>(type: "date", nullable: false),
                    tipoSangreNino = table.Column<string>(type: "nchar(10)", fixedLength: true, maxLength: 10, nullable: false),
                    ciudadNacimientoNino = table.Column<string>(type: "varchar(50)", unicode: false, maxLength: 50, nullable: false),
                    idAcudiente = table.Column<string>(type: "nvarchar(450)", maxLength: 450, nullable: false),
                    telefonoNino = table.Column<string>(type: "varchar(50)", unicode: false, maxLength: 50, nullable: false),
                    direccionNino = table.Column<string>(type: "varchar(50)", unicode: false, maxLength: 50, nullable: false),
                    epsNino = table.Column<string>(type: "varchar(50)", unicode: false, maxLength: 50, nullable: false),
                    idJardin = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK__Ninos__4059CA1FC61F3A7A", x => x.IdNino);
                    table.ForeignKey(
                        name: "FK_JardinNino",
                        column: x => x.idJardin,
                        principalTable: "Jardines",
                        principalColumn: "IdJardin");
                    table.ForeignKey(
                        name: "FK_NinoAcudiente",
                        column: x => x.idAcudiente,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateTable(
                name: "RegistrosAsistencia",
                columns: table => new
                {
                    IdRegistroAsistencia = table.Column<int>(type: "int", nullable: false),
                    idNino = table.Column<long>(type: "bigint", nullable: false),
                    fechaRegistro = table.Column<DateOnly>(type: "date", nullable: false),
                    estadoNinoRegistro = table.Column<string>(type: "nchar(10)", fixedLength: true, maxLength: 10, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK__Registro__D29C5314CB323579", x => x.IdRegistroAsistencia);
                    table.ForeignKey(
                        name: "FK_RegistrosAsistencia_Ninos",
                        column: x => x.idNino,
                        principalTable: "Ninos",
                        principalColumn: "IdNino");
                });

            migrationBuilder.CreateTable(
                name: "RegistrosAvanceAcademico",
                columns: table => new
                {
                    IdAvance = table.Column<int>(type: "int", nullable: false),
                    idNino = table.Column<long>(type: "bigint", nullable: false),
                    anioEscolarAvance = table.Column<int>(type: "int", nullable: false),
                    nivelAvance = table.Column<string>(type: "varchar(50)", unicode: false, maxLength: 50, nullable: false),
                    notaAvance = table.Column<string>(type: "nchar(1)", fixedLength: true, maxLength: 1, nullable: false),
                    descripcionAvance = table.Column<string>(type: "text", nullable: false),
                    fechaEntregaAvance = table.Column<DateOnly>(type: "date", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK__Registro__D83056646D1EE765", x => x.IdAvance);
                    table.ForeignKey(
                        name: "FK_RegistrosAvanceAcademico_Ninos",
                        column: x => x.idNino,
                        principalTable: "Ninos",
                        principalColumn: "IdNino");
                });

            migrationBuilder.CreateIndex(
                name: "IX_AspNetRoleClaims_RoleId",
                table: "AspNetRoleClaims",
                column: "RoleId");

            migrationBuilder.CreateIndex(
                name: "RoleNameIndex",
                table: "AspNetRoles",
                column: "NormalizedName",
                unique: true,
                filter: "([NormalizedName] IS NOT NULL)");

            migrationBuilder.CreateIndex(
                name: "IX_AspNetUserClaims_UserId",
                table: "AspNetUserClaims",
                column: "UserId");

            migrationBuilder.CreateIndex(
                name: "IX_AspNetUserLogins_UserId",
                table: "AspNetUserLogins",
                column: "UserId");

            migrationBuilder.CreateIndex(
                name: "IX_AspNetUserRoles_RoleId",
                table: "AspNetUserRoles",
                column: "RoleId");

            migrationBuilder.CreateIndex(
                name: "EmailIndex",
                table: "AspNetUsers",
                column: "NormalizedEmail");

            migrationBuilder.CreateIndex(
                name: "UserNameIndex",
                table: "AspNetUsers",
                column: "NormalizedUserName",
                unique: true,
                filter: "([NormalizedUserName] IS NOT NULL)");

            migrationBuilder.CreateIndex(
                name: "IX_MadresComunitarias_IdJardin",
                table: "MadresComunitarias",
                column: "IdJardin");

            migrationBuilder.CreateIndex(
                name: "IX_MadresComunitarias_IdUsuario",
                table: "MadresComunitarias",
                column: "IdUsuario");

            migrationBuilder.CreateIndex(
                name: "IX_Ninos_idAcudiente",
                table: "Ninos",
                column: "idAcudiente");

            migrationBuilder.CreateIndex(
                name: "IX_Ninos_idJardin",
                table: "Ninos",
                column: "idJardin");

            migrationBuilder.CreateIndex(
                name: "IX_RegistrosAsistencia_idNino",
                table: "RegistrosAsistencia",
                column: "idNino");

            migrationBuilder.CreateIndex(
                name: "IX_RegistrosAvanceAcademico_idNino",
                table: "RegistrosAvanceAcademico",
                column: "idNino");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "AspNetRoleClaims");

            migrationBuilder.DropTable(
                name: "AspNetUserClaims");

            migrationBuilder.DropTable(
                name: "AspNetUserLogins");

            migrationBuilder.DropTable(
                name: "AspNetUserRoles");

            migrationBuilder.DropTable(
                name: "AspNetUserTokens");

            migrationBuilder.DropTable(
                name: "MadresComunitarias");

            migrationBuilder.DropTable(
                name: "RegistrosAsistencia");

            migrationBuilder.DropTable(
                name: "RegistrosAvanceAcademico");

            migrationBuilder.DropTable(
                name: "AspNetRoles");

            migrationBuilder.DropTable(
                name: "Ninos");

            migrationBuilder.DropTable(
                name: "Jardines");

            migrationBuilder.DropTable(
                name: "AspNetUsers");
        }
    }
}
