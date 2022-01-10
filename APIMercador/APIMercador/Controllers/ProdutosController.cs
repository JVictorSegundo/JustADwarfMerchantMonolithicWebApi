using APIMercador.Context;
using APIMercador.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
//---
namespace APIMercador.Controllers
{
    [Route("Loja/[Controller]")]
    [ApiController]
    public class ProdutosController : ControllerBase
    {

        private readonly MercadorDbContext _contexto;
        //---
        public ProdutosController(MercadorDbContext context)
        {
            _contexto = context;
        }
        //---
        [HttpGet("{nome}")]
        public ActionResult<IEnumerable<Produto>> Get_PegaProdutosPorCategoria(string nome)
        {
            try
            {
                switch (nome)
                {
                    case "Armas":
                        return _contexto.Produtos.AsNoTracking().Where(p => p.CategoriaId == 1).ToList();
                    case "Vestimentas":
                        return _contexto.Produtos.AsNoTracking().Where(p => p.CategoriaId == 2).ToList();
                    case "Materiais":
                        return _contexto.Produtos.AsNoTracking().Where(p => p.CategoriaId == 3).ToList();
                    default:
                        return NotFound("Não temos esse tipo de esquisitice aqui na loja, cai fora!");
                }
            }
            catch (Exception)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, "Erro ao tentar obter os produtos por categoria");
            }
        }
        //---
        [HttpGet("Mercadorias/{nome}")]
        public ActionResult<Produto> Get_PegaProdutoPeloNome(string nome)
        {
            try
            {
                switch (nome)
                {
                    case "Espada de Ferro":
                        return _contexto.Produtos.AsNoTracking().FirstOrDefault(x => x.ProdutosId == 1);
                    case "Arco de Madeira":
                        return _contexto.Produtos.AsNoTracking().FirstOrDefault(x => x.ProdutosId == 3);
                    case "Cajado de Madeira":
                        return _contexto.Produtos.AsNoTracking().FirstOrDefault(x => x.ProdutosId == 2);
                    case "Armadura Leve":
                        return _contexto.Produtos.AsNoTracking().FirstOrDefault(x => x.ProdutosId == 5);
                    case "Armadura Pesada":
                        return _contexto.Produtos.AsNoTracking().FirstOrDefault(x => x.ProdutosId == 4);
                    case "Roupa":
                        return _contexto.Produtos.AsNoTracking().FirstOrDefault(x => x.ProdutosId == 6);
                    case "Madeira":
                        return _contexto.Produtos.AsNoTracking().FirstOrDefault(x => x.ProdutosId == 7);
                    case "Ferro":
                        return _contexto.Produtos.AsNoTracking().FirstOrDefault(x => x.ProdutosId == 8);
                    case "Prata":
                        return _contexto.Produtos.AsNoTracking().FirstOrDefault(x => x.ProdutosId == 9);
                    default:
                        return NotFound("Não temos esse tipo de esquisitice aqui na loja, cai fora!");
                }
            }
            catch (Exception)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, "Erro ao tentar obter os produtos pelo nome");
            }
        }
        //---
        [HttpPut("Comprar/{nome}/{quantidade}")]
        public ActionResult<Produto> Put_ComprarMercadoria(string nome,int quantidade)
        {
            try
            {
                var estoque = _contexto.Produtos.FirstOrDefault(x => x.Nome == nome);
                //-
                if (quantidade> 0 && quantidade <= estoque.Estoque)
                {
                    estoque.Estoque -= quantidade;
                    //---
                    _contexto.SaveChanges();
                    //---
                    return Ok("Obrigado pela preferência, camarada. Lhe desejo prosperidade em suas aventuras!");
                }
                else if (quantidade > estoque.Estoque)
                {
                    return BadRequest("Você está pedindo demais... Não tenho isso tudo isso no estoque, panaca!");
                }
                else
                {
                    return BadRequest("Está querendo fazer piada comigo, malandro? SEM VENDAS PRA VC!");
                }
            }
            //--
            catch (Exception)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, "Erro ao tentar 'Comprar'. Verifique o nome do produto requisitado");
            }
        }
    }
}
