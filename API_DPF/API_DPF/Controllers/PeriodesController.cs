using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Data.Entity.Infrastructure;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Threading.Tasks;
using System.Web.Http;
using System.Web.Http.Description;
using API_DPF.Models;

namespace API_DPF.Controllers
{
    public class PeriodesController : ApiController
    {
        private API_DPFContext db = new API_DPFContext();

        // GET: api/Periodes
        public IQueryable<Periode> GetPeriodes()
        {
            return db.Periodes;
        }

        // GET: api/Periodes/5
        [ResponseType(typeof(Periode))]
        public async Task<IHttpActionResult> GetPeriode(int id)
        {
            Periode periode = await db.Periodes.FindAsync(id);
            if (periode == null)
            {
                return NotFound();
            }

            return Ok(periode);
        }

        // PUT: api/Periodes/5
        [ResponseType(typeof(void))]
        public async Task<IHttpActionResult> PutPeriode(int id, Periode periode)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (id != periode.Id)
            {
                return BadRequest();
            }

            db.Entry(periode).State = EntityState.Modified;

            try
            {
                await db.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!PeriodeExists(id))
                {
                    return NotFound();
                }
                else
                {
                    throw;
                }
            }

            return StatusCode(HttpStatusCode.NoContent);
        }

        // POST: api/Periodes
        [ResponseType(typeof(Periode))]
        public async Task<IHttpActionResult> PostPeriode(Periode periode)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            db.Periodes.Add(periode);
            await db.SaveChangesAsync();

            return CreatedAtRoute("DefaultApi", new { id = periode.Id }, periode);
        }

        // DELETE: api/Periodes/5
        [ResponseType(typeof(Periode))]
        public async Task<IHttpActionResult> DeletePeriode(int id)
        {
            Periode periode = await db.Periodes.FindAsync(id);
            if (periode == null)
            {
                return NotFound();
            }

            db.Periodes.Remove(periode);
            await db.SaveChangesAsync();

            return Ok(periode);
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }

        private bool PeriodeExists(int id)
        {
            return db.Periodes.Count(e => e.Id == id) > 0;
        }
    }
}