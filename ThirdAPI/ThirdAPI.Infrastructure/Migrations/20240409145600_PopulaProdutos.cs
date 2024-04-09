using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace ThirdAPI.Infrastructure.Migrations
{
    /// <inheritdoc />
    public partial class PopulaProdutos : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<decimal>(
                name: "Preco",
                table: "Produtos",
                type: "decimal(10)",
                precision: 10,
                nullable: false,
                oldClrType: typeof(decimal),
                oldType: "decimal(10,30)",
                oldPrecision: 10);

            migrationBuilder.AlterColumn<DateTime>(
                name: "DataCadastro",
                table: "Produtos",
                type: "datetime(6)",
                nullable: false,
                defaultValue: new DateTime(2024, 4, 9, 14, 55, 59, 859, DateTimeKind.Utc).AddTicks(8754),
                oldClrType: typeof(DateTime),
                oldType: "datetime(6)",
                oldDefaultValue: new DateTime(2024, 4, 9, 14, 52, 37, 129, DateTimeKind.Utc).AddTicks(365));

            migrationBuilder.Sql(" Insert into produtos(Nome, Descricao, Preco, ImagemUrl, Estoque, DataCadastro, CategoriaId) " + 
                                 "Values('Mochila', 'Mochila Escolar', 250, 'mochila.jpg', 20, now(), 1 )");
            
            migrationBuilder.Sql(" Insert into produtos(Nome, Descricao, Preco, ImagemUrl, Estoque, DataCadastro, CategoriaId) " + 
                                 "Values('Xiaomi POCO F3', 'SmartPhone', 2250, 'pocof3.jpg', 0, now(), 2 )");
            
            migrationBuilder.Sql(" Insert into produtos(Nome, Descricao, Preco, ImagemUrl, Estoque, DataCadastro, CategoriaId) " + 
                                 "Values('Garrafa de Água', 'Garrafa Tupperware 1l', 22, 'garrafa.jpg', 50, now(), 3 )");
        }

            

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<decimal>(
                name: "Preco",
                table: "Produtos",
                type: "decimal(10,30)",
                precision: 10,
                nullable: false,
                oldClrType: typeof(decimal),
                oldType: "decimal(10)",
                oldPrecision: 10);

            migrationBuilder.AlterColumn<DateTime>(
                name: "DataCadastro",
                table: "Produtos",
                type: "datetime(6)",
                nullable: false,
                defaultValue: new DateTime(2024, 4, 9, 14, 52, 37, 129, DateTimeKind.Utc).AddTicks(365),
                oldClrType: typeof(DateTime),
                oldType: "datetime(6)",
                oldDefaultValue: new DateTime(2024, 4, 9, 14, 55, 59, 859, DateTimeKind.Utc).AddTicks(8754));
        }
    }
}
