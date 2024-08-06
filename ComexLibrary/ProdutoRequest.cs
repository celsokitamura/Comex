namespace ComexLibrary
{
    /// <summary>
    /// Representa um produto na biblioteca Comex.
    /// </summary>
    public class ProdutoRequest
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
        public int IdCategoria { get; set; }

    }
}
