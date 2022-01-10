using System.ComponentModel.DataAnnotations;

namespace APIMercador.Models
{
    public class Produto
    {
        [Key]
        public int ProdutosId { get; set; }
        [Required]
        [MaxLength(30)]
        public string Nome { get; set; }
        [Required]
        [MaxLength(50)]
        public string Tipo { get; set; }
        [Required]
        [MaxLength(500)]
        public string Descricao { get; set; }
        [Required]
        public int Estoque { get; set; }
        [Required]
        [MaxLength(200)]
        public string Atributos { get; set; }
        [Required]
        public int Preco { get; set; }
        //---
        public Categoria Categoria { get; set; }
        public int CategoriaId { get; set; }
    }
}
