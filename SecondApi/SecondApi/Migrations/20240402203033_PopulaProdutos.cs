using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace SecondApi.Migrations
{
    /// <inheritdoc />
    public partial class PopulaProdutos : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder mb)
        {
            mb.Sql("Insert into produtos(Descricao, Preco, CategoriaId) Values('Coca-Cola', '5.5', '1')");
            mb.Sql("Insert into produtos(Descricao, Preco, CategoriaId) Values('Pastel', '7.5', '2')");
            mb.Sql("Insert into produtos(Descricao, Preco, CategoriaId) Values('PetitGateau', '21', '3')");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder mb)
        {
            mb.Sql("Delete from produtos");
        }
    }
}
