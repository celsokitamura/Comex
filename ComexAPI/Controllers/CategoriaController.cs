using ComexAPI.Repository;
using ComexLibrary;
using Microsoft.AspNetCore.Mvc;
using System.Data;
using System.Data.SqlClient;

namespace ComexAPI.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class CategoriaController : ControllerBase
    {
        public CategoriaController() { }

        CategoriaRepository categoriaRepository = new CategoriaRepository();

        [HttpGet(Name = "GetCategoria")]
        public IEnumerable<Categoria> Get()
        {
            return categoriaRepository.ListaCategoria();
        }

        [HttpPost(Name = "IncluiCategoria")]
        [ProducesResponseType(StatusCodes.Status201Created)]
        public void Inclui([FromBody] Categoria categoria)
        {
            categoriaRepository.IncluiCategoria(categoria);
        }

        [HttpPut(Name = "AlteraCategoria")]
        [ProducesResponseType(StatusCodes.Status202Accepted)]
        public void Altera([FromBody] Categoria categoria)
        {
            categoriaRepository.AlteraCategoria(categoria);
        }

        [HttpDelete(Name = "ExcluiCategoria{id}")]
        public void Exclui(int id)
        {
            categoriaRepository.ExcluiCategoria(id);
        }
    }
}
