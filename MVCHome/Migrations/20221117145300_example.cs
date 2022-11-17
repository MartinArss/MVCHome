using Microsoft.EntityFrameworkCore.Migrations;

namespace MVCHome.Migrations
{
    public partial class example : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "ArticuloDb",
                columns: table => new
                {
                    PkArticulo = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Nombre = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Descripcion = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    UrlImg = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ArticuloDb", x => x.PkArticulo);
                });

            migrationBuilder.CreateTable(
                name: "RolDb",
                columns: table => new
                {
                    PkRol = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Nombre = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_RolDb", x => x.PkRol);
                });

            migrationBuilder.CreateTable(
                name: "UsuarioDb",
                columns: table => new
                {
                    PkUser = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Nombre = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    User = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Password = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    FkRol = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_UsuarioDb", x => x.PkUser);
                    table.ForeignKey(
                        name: "FK_UsuarioDb_RolDb_FkRol",
                        column: x => x.FkRol,
                        principalTable: "RolDb",
                        principalColumn: "PkRol",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateIndex(
                name: "IX_UsuarioDb_FkRol",
                table: "UsuarioDb",
                column: "FkRol");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "ArticuloDb");

            migrationBuilder.DropTable(
                name: "UsuarioDb");

            migrationBuilder.DropTable(
                name: "RolDb");
        }
    }
}
