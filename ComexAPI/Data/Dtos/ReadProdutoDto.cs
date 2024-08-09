namespace ComexAPI.Data.Dtos
{
    public class ReadProdutoDto
    {
        public int id_produto {  get; set; }
        public string nm_produto { get; set; }
        public decimal vl_preco { get; set; }
        public string ds_descricao { get; set; }
        public string url_imagem { get; set; }
        public int id_categoria { get; set; }
    }
}
