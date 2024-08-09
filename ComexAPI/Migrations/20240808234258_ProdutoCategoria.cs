using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace ComexAPI.Migrations
{
    /// <inheritdoc />
    public partial class ProdutoCategoria : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Categoria",
                columns: table => new
                {
                    id_categoria = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    ds_categoria = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Categoria", x => x.id_categoria);
                });

            migrationBuilder.CreateTable(
                name: "Produto",
                columns: table => new
                {
                    id_produto = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    nm_produto = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    vl_preco = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    ds_descricao = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    id_categoria = table.Column<int>(type: "int", nullable: false),
                    url_imagem = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Produto", x => x.id_produto);
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Categoria");

            migrationBuilder.DropTable(
                name: "Produto");
        }
    }
}
