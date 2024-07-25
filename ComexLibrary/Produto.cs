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
        public int Id { get; set; }

        /// <summary>
        /// Obtém ou define o nome do produto
        /// </summary>
        public string Nome { get; set; }

        /// <summary>
        /// Obtém ou define o preço do produto
        /// </summary>
        public decimal Preco { get; set; }

        /// <summary>
        /// Obtém ou define a descrição do produto
        /// </summary>
        public string Descricao { get; set; }

        /// <summary>
        /// Obtém ou define a categoria do produto
        /// </summary>
        public string Categoria { get; set; }

        /// <summary>
        /// Calcula o preço com desconto
        /// </summary>
        /// <param name="percentualDesconto">O percentual de desconto a ser aplicado</param>
        /// <returns>O preço do produto com o desconto aplicado</returns>
        public decimal CalcularPrecoComDesconto(decimal percentualDesconto)
        {
            return Preco - (Preco * percentualDesconto / 100);
        }
    }
}
