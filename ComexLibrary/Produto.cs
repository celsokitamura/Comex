using System.ComponentModel.DataAnnotations;

namespace ComexLibrary
{
    /// <summary>
    /// Representa um produto na biblioteca Comex.
    /// </summary>
    public class Produto
    {
        /// <summary>
        /// Obtém ou define o identificador do produto
        /// </summary>
        [Key]
        [Required]
        public int id_produto { get; set; }

        /// <summary>
        /// Obtém ou define o nome do produto
        /// </summary>
        public string nm_produto { get; set; }

        /// <summary>
        /// Obtém ou define o preço do produto
        /// </summary>
        public decimal vl_preco { get; set; }

        /// <summary>
        /// Obtém ou define a descrição do produto
        /// </summary>
        public string ds_descricao { get; set; }

        /// <summary>
        /// Obtém ou define a categoria do produto
        /// </summary>
        public int id_categoria { get; set; }

        public string url_imagem { get; set; }

        /// <summary>
        /// Calcula o preço com desconto
        /// </summary>
        /// <param name="percentualDesconto">O percentual de desconto a ser aplicado</param>
        /// <returns>O preço do produto com o desconto aplicado</returns>
        public decimal CalcularPrecoComDesconto(decimal percentualDesconto)
        {
            return vl_preco - (vl_preco * percentualDesconto / 100);
        }
    }
}
