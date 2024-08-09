using System.ComponentModel.DataAnnotations;

namespace ComexAPI.Data.Dtos
{
    public class UpdateProdutoDto
    {
        [Required(ErrorMessage = "O id do produto é obrigatório")]
        public int id_produto {  get; set; }
        [Required(ErrorMessage = "O nome do produto é obrigatório")]
        public string nm_produto { get; set; }
        [Required(ErrorMessage = "O preço do produto é obrigatório")]
        public decimal vl_preco { get; set; }
        public string ds_descricao {  get; set; }
        public string url_imagem { get; set; }
        public int id_categoria {  get; set; }
    }
}
