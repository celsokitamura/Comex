using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ComexLibrary
{
    public class Categoria
    {
        [Key]
        [Required]
        public int id_categoria { get; set; }

        [Required(ErrorMessage = "A Descrição da categoria é obrigatória")]
        public string ds_categoria { get; set; }
    }
}
