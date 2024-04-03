﻿using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace FirstApi.Migrations
{
    /// <inheritdoc />
    public partial class PopulaCategoria : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder mb)
        {
            mb.Sql("Insert into categorias(Nome) Values('Bebidas')");
            mb.Sql("Insert into categorias(Nome) Values('Lanches')");
            mb.Sql("Insert into categorias(Nome) Values('Sobremesas')");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder mb)
        {
            mb.Sql("Delete from categorias");
        }
    }
}
