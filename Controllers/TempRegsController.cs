using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using FinalWebApi.Models;
using Microsoft.AspNetCore.Authorization;
using System.Security.Claims;
using System.Collections;

namespace FinalWebApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class TempRegsController : ControllerBase
    {
        private readonly RestdotnetContext _context;

        public TempRegsController(RestdotnetContext context)
        {
            _context = context;
        }

        // GET: api/TempRegs
        [HttpGet]
        [Authorize]
        public async Task<ActionResult<IEnumerable<TempReg>>> GetTempRegs()
        {
            var identity = HttpContext.User.Identity as ClaimsIdentity;

            var Valid = Funciones_Varias.ValidarToken(identity);
      

            try
            {
                return await _context.TempRegs.ToListAsync();
            }
            catch (Exception ex)
            {
                return StatusCode(StatusCodes.Status404NotFound, new { mensaje = "No se encontraron Datos" });

            }
        }

        // GET: api/TempRegs/5
        [HttpGet("{id}")]
        public async Task<ActionResult<TempReg>> GetTempReg(int id)
        {
            var tempReg = await _context.TempRegs.FindAsync(id);

            if (tempReg == null)
            {
                return NotFound();
            }

            return tempReg;
        }

        // PUT: api/TempRegs/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<IActionResult> PutTempReg(int id, TempReg tempReg)
        {
            if (id != tempReg.Id)
            {
                return BadRequest();
            }

            _context.Entry(tempReg).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!TempRegExists(id))
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

        // POST: api/TempRegs
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<TempReg>> PostTempReg(TempReg tempReg)
        {
            _context.TempRegs.Add(tempReg);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetTempReg", new { id = tempReg.Id }, tempReg);
        }

        // DELETE: api/TempRegs/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteTempReg(int id)
        {
            var tempReg = await _context.TempRegs.FindAsync(id);
            if (tempReg == null)
            {
                return NotFound();
            }

            _context.TempRegs.Remove(tempReg);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool TempRegExists(int id)
        {
            return _context.TempRegs.Any(e => e.Id == id);
        }
    }
}
