using AutoMapper;
using ComexAPI.Data;
using ComexAPI.Data.Dtos;
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
        private ComexContext _context;
        private IMapper _mapper;

        public CategoriaController(ComexContext context, IMapper mapper) 
        {
            _context = context;
            _mapper = mapper;
        }

        CategoriaRepository categoriaRepository = new CategoriaRepository();

        [HttpGet(Name = "GetCategoria")]
        public IEnumerable<ReadCategoriaDto> Get()
        {
            return _mapper.Map<List<ReadCategoriaDto>>(_context.Categoria);
        }

        [HttpPost(Name = "IncluiCategoria")]
        [ProducesResponseType(StatusCodes.Status201Created)]
        public IActionResult Inclui([FromBody] CreateCategoriaDto categoriaDto)
        {
            Categoria categoria = _mapper.Map<Categoria>(categoriaDto);
            _context.Categoria.Add(categoria);
            _context.SaveChanges();
            return CreatedAtAction(nameof(RecuperaCategoriaPorId),
                new { id = categoria.id_categoria },
                categoria);
        }

        [HttpGet("{id}")]
        public IActionResult RecuperaCategoriaPorId(int id)
        {
            var categoria = _context.Categoria
                .FirstOrDefault(categoria => categoria.id_categoria == id);
            if (categoria == null) return NotFound();
            var categoriaDto = _mapper.Map<ReadCategoriaDto>(categoria);
            return Ok(categoriaDto);
        }

        [HttpPut(Name = "AlteraCategoria")]
        [ProducesResponseType(StatusCodes.Status202Accepted)]
        public IActionResult Altera([FromBody] UpdateCategoriaDto categoriaDto)
        {
            Categoria categoria = _mapper.Map<Categoria>(categoriaDto);
            _context.Categoria.Update(categoria);
            _context.SaveChanges();
            return AcceptedAtAction(nameof(RecuperaCategoriaPorId),
                new { id = categoria.id_categoria },
                categoria);
        }

        [HttpDelete(Name = "ExcluiCategoria{id}")]
        public IActionResult Exclui(int id)
        {
            var categoria = _context.Categoria.FirstOrDefault(
                categoria => categoria.id_categoria == id);
            if (categoria == null) return NotFound();
            _context.Remove(categoria);
            _context.SaveChanges();
            return NoContent();
        }
    }
}
