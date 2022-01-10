using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace APIMercador.Models
{
    [Table("Categorias")]
    public class Categoria
    {
        //---
        [Key]
        public int CategoriaId { get; set; }
        [Required]
        [MaxLength(20)]
        public string Nome { get; set; }
        //---
        public ICollection<Produto> Produtos { get; set; }
        //---
    }
}
