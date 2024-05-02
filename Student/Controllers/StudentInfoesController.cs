using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Student.Models;

namespace Student.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class StudentInfoesController : ControllerBase
    {
        private readonly StudentContext _context;

        public StudentInfoesController(StudentContext context)
        {
            _context = context;
        }

        // GET: api/StudentInfoes
        [HttpGet]
        public async Task<ActionResult<IEnumerable<StudentInfo>>> GetStudentInfos()
        {
          if (_context.StudentInfos == null)
          {
              return NotFound();
          }
            return await _context.StudentInfos.ToListAsync();
        }

        // GET: api/StudentInfoes/5
        [HttpGet("{id}")]
        public async Task<ActionResult<StudentInfo>> GetStudentInfo(int id)
        {
          if (_context.StudentInfos == null)
          {
              return NotFound();
          }
            var studentInfo = await _context.StudentInfos.FindAsync(id);

            if (studentInfo == null)
            {
                return NotFound();
            }

            return studentInfo;
        }

        // PUT: api/StudentInfoes/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<IActionResult> PutStudentInfo(int id, StudentInfo studentInfo)
        {
            if (id != studentInfo.Id)
            {
                return BadRequest();
            }

            _context.Entry(studentInfo).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!StudentInfoExists(id))
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

        // POST: api/StudentInfoes
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<StudentInfo>> PostStudentInfo(StudentInfo studentInfo)
        {
          if (_context.StudentInfos == null)
          {
              return Problem("Entity set 'StudentContext.StudentInfos'  is null.");
          }
            _context.StudentInfos.Add(studentInfo);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetStudentInfo", new { id = studentInfo.Id }, studentInfo);
        }

        // DELETE: api/StudentInfoes/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteStudentInfo(int id)
        {
            if (_context.StudentInfos == null)
            {
                return NotFound();
            }
            var studentInfo = await _context.StudentInfos.FindAsync(id);
            if (studentInfo == null)
            {
                return NotFound();
            }

            _context.StudentInfos.Remove(studentInfo);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool StudentInfoExists(int id)
        {
            return (_context.StudentInfos?.Any(e => e.Id == id)).GetValueOrDefault();
        }
    }
}
