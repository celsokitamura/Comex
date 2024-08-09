using System.ComponentModel.DataAnnotations;

namespace ComexAPI.Data.Dtos
{
    public class UpdateCategoriaDto
    {
        [Required(ErrorMessage = "Id da categoria é obrigatória")]
        public int id_categoria { get; set; }
        [Required(ErrorMessage = "Descrição da categoria é obrigatória")]
        public string ds_categoria { get; set; }
    }
}
