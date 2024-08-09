using System.ComponentModel.DataAnnotations;

namespace ComexAPI.Data.Dtos
{
    public class CreateCategoriaDto
    {
        [Required(ErrorMessage = "A descrição da categoria é obrigatória")]
        public string ds_categoria {  get; set; }
    }
}
