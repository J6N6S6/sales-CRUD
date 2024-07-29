using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Routing.Constraints;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using Sales_CRUD.Context;
using Sales_CRUD.Models;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;

namespace Sales_CRUD.Controllers
{
    [Route("api/ProdutoTipos")]
    [ApiController]
    public class ProdutoTiposController : ControllerBase
    {
        private readonly SalesCRUDDbContext _context;

        public ProdutoTiposController(SalesCRUDDbContext context)
        {
            _context = context;
        }

        //Get: api/ProdutoTipos - Get List
        [HttpGet]
        public async Task<ActionResult<IEnumerable<ProdutoTipo>>> GetProdutoTipos()
        {
            return await _context.ProdutoTipos.ToListAsync();
        }

        //Get: api/ProdutoTipos/5 - Get by Id
        [HttpGet("{id}")]
        public async Task<ActionResult<ProdutoTipo>> GetProdutoTipo(int id)
        {
            var produtoTipo = await _context.ProdutoTipos.FindAsync(id);

            if (produtoTipo == null)
            {
                return NotFound();
            }

            return produtoTipo;
        }


        //Post: api/ProdutoTipos
        [HttpPost]
        public async Task<ActionResult<ProdutoTipo>> PostProdutoTipo(ProdutoTipo produtoTipo)
        {
            _context.ProdutoTipos.Add(produtoTipo);
            await _context.SaveChangesAsync();
            
            return CreatedAtAction(nameof(GetProdutoTipo), new { id = produtoTipo.Id}, produtoTipo);
        }


        //Put: api/ProdutoTipos/5
        [HttpPut("id")]
        public async Task<ActionResult> PutProdutoTipo(int id, ProdutoTipo produtoTipo)
        {
            if (id != produtoTipo.Id)
            {
                return BadRequest();
            }

            _context.Entry(produtoTipo).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DBConcurrencyException)
            {
                if (!ProdutoTipoExiste(id))
                {
                    return NotFound();
                }
                throw;
            }
            return NoContent();
        }

        //Delete: api/ProdutoTipos/5
        [HttpDelete("{id}")]

        private bool ProdutoTipoExiste(int id)
        {
            return _context.ProdutoTipos.Any(x => x.Id == id);   
        }
    }
}
