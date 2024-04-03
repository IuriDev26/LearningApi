using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace FirstApi.Migrations
{
    /// <inheritdoc />
    public partial class PopulaProdutos : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder mb)
        {
            mb.Sql("Insert into produtos(Descricao, Preco, CategoriaID) " +
                   "Values('Coca-Cola', 20, 1)");
            
            mb.Sql("Insert into produtos(Descricao, Preco, CategoriaID) " +
                   "Values('Pastel de Forno', 20, 2)");
            
            mb.Sql("Insert into produtos(Descricao, Preco, CategoriaID) " +
                   "Values('Pudim', 20, 3)");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder mb)
        {
            mb.Sql("Delete from produtos");
        }
    }
}
