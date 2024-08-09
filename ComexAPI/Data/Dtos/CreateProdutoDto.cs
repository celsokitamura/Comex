using System.ComponentModel.DataAnnotations;

namespace ComexAPI.Data.Dtos
{
    public class CreateProdutoDto
    {
        [Required(ErrorMessage = "O nome do produto é obrigatório")]
        public string nm_produto {  get; set; }
        [Required(ErrorMessage = "O preço do produto e obrigatório")]
        public decimal vl_preco {  get; set; }
        public string ds_descricao { get; set; }
        public string url_imagem {  get; set; }
        public int id_categoria { get; set; }

    }
}
