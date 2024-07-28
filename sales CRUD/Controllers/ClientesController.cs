using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Sales_CRUD.Context;
using Sales_CRUD.Models;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Sales_CRUD.Controllers
{
    [Route("api/Clientes")]
    [ApiController]
    public class ClientesController : ControllerBase
    {
        private readonly SalesCRUDDbContext _context;

        public ClientesController(SalesCRUDDbContext context)
        {
            _context = context;
        }

        //Get: api/Clientes - Lista de Clientes
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Cliente>>> GetClientes()
        {
            return await _context.Clientes.ToListAsync();
        }


        //Get: api/Clientes/5 - Cliente específico por id
        [HttpGet("{id}")]
        public async Task<ActionResult<Cliente>> GetCliente(int id)
        {
            var cliente = await _context.Clientes.FindAsync(id);

            if (cliente == null)
            {
                return NotFound();
            }
            return cliente;
        }
        

        //Post: api/Clientes
        [HttpPost]
        public async Task<ActionResult<Cliente>> PostCliente(Cliente cliente)
        {
            _context.Clientes.Add(cliente);
            await _context.SaveChangesAsync();

            // Para construir a URL que será retornada, referente ao novo item criado, 
            // é necessário informar ao ASP.NET Core qual endpoint deve ser utilizado para essa construção.
            // Esse endpoint deve identificar especificamente o item criado, por isso usamos GetCliente e não GetClientes.
            // O uso de nameof proporciona proteção em casos onde o nome do método que identifica o item muda.
            // Se o método for renomeado, o Visual Studio emitirá um aviso de erro, pois nameof verifica a existência do método.
            // Se o nome do método fosse usado diretamente como uma string, o Visual Studio não validaria a string, 
            // o que poderia levar a erros que só seriam detectados em tempo de execução.
            return CreatedAtAction(nameof(GetCliente), new { id = cliente.Id }, cliente);
        }


        //PUT: api/Clientes/5
        [HttpPut("id")]
        public async Task<IActionResult> PutCliente(int id, Cliente cliente)
        {
            if (id != cliente.Id)
            {
                return BadRequest();
            }

            _context.Entry(cliente).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!ClienteExists(id))
                {
                    return NotFound();
                }
                else
                {
                    throw;
                }
            }

            return NoContent();

        }


        //DELETE: api/Clientes/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteCliente(int id)
        {
            var cliente = await _context.Clientes.FindAsync(id);
            
            if(cliente == null)
            {
                return NotFound();
            }
            
            _context.Clientes.Remove(cliente);
            await _context.SaveChangesAsync();

            return NoContent();
        }


        private bool ClienteExists(int id)
        {
            return _context.Clientes.Any(cliente => cliente.Id == id);
        }
    }
}
