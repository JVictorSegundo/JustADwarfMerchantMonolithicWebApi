using Microsoft.EntityFrameworkCore.Migrations;

namespace APIMercador.Migrations
{
    public partial class Mercadorias001 : Migration
    {
        //---
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            //---
            migrationBuilder.Sql("Insert into Categorias (Nome) Values ('Armas')");
            migrationBuilder.Sql("Insert into Categorias (Nome) Values ('Vestimentas')");
            migrationBuilder.Sql("Insert into Categorias (Nome) Values ('Materiais')");
            //---
            migrationBuilder.Sql("Insert into Produtos (Nome,Tipo,Descricao,Estoque,Atributos,Preco,CategoriaId) Values ('Espada de Ferro','Espada','Excelente espada para novos aventureiros','13','15 de ataque verdadeiro','12',(Select CategoriaId from Categorias where Nome='Armas'))");
            migrationBuilder.Sql("Insert into Produtos (Nome,Tipo,Descricao,Estoque,Atributos,Preco,CategoriaId) Values ('Cajado de Madeira','Cajado','Cajado simples com um ambar em sua ponta','4','13 de ataque mágico','30',(Select CategoriaId from Categorias where Nome='Armas'))");
            migrationBuilder.Sql("Insert into Produtos (Nome,Tipo,Descricao,Estoque,Atributos,Preco,CategoriaId) Values ('Arco de Madeira','Arco','Arco padrão para caçadores','20','10 de ataque verdadeiro','10',(Select CategoriaId from Categorias where Nome='Armas'))");
            migrationBuilder.Sql("Insert into Produtos (Nome,Tipo,Descricao,Estoque,Atributos,Preco,CategoriaId) Values ('Armadura','Armadura Pesada','Para aqueles que buscam proteção','3','20 de defesa - 2 de mobilidade','60',(Select CategoriaId from Categorias where Nome='Vestimentas'))");
            migrationBuilder.Sql("Insert into Produtos (Nome,Tipo,Descricao,Estoque,Atributos,Preco,CategoriaId) Values ('Armadura','Armadura Leve','Para aqueles que buscam mobilidade','5','10 de defesa - 10 de mobilidade','33',(Select CategoriaId from Categorias where Nome='Vestimentas'))");
            migrationBuilder.Sql("Insert into Produtos (Nome,Tipo,Descricao,Estoque,Atributos,Preco,CategoriaId) Values ('Roupas Comuns','Roupas','Para aqueles que buscam apenas esconder as vergonhas','6','2 de defesa - 15 de mobilidade','15',(Select CategoriaId from Categorias where Nome='Vestimentas'))");
            migrationBuilder.Sql("Insert into Produtos (Nome,Tipo,Descricao,Estoque,Atributos,Preco,CategoriaId) Values ('Madeira','Material Comum','Madeira comumente achada nos Vales de Montireal','30','Tronco','1',(Select CategoriaId from Categorias where Nome='Materiais'))");
            migrationBuilder.Sql("Insert into Produtos (Nome,Tipo,Descricao,Estoque,Atributos,Preco,CategoriaId) Values ('Ferro','Material Simples','Opaco e denso','14','Lingote de Ferro','4',(Select CategoriaId from Categorias where Nome='Materiais'))");
            migrationBuilder.Sql("Insert into Produtos (Nome,Tipo,Descricao,Estoque,Atributos,Preco,CategoriaId) Values ('Prata','Material Raro','Reluzente como uma estrela da noite','8','Lingote de Prata','9',(Select CategoriaId from Categorias where Nome='Materiais'))");

        }
        //---
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.Sql("Delete from Categorias");
            migrationBuilder.Sql("Delete from Produtos");
        }
        //---
    }
}
