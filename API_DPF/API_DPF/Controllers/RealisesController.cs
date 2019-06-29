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
    public class RealisesController : ApiController
    {
        private API_DPFContext db = new API_DPFContext();

        // GET: api/Realises
        public IQueryable<Realise> GetRealises()
        {
            return db.Realises;
        }

        // GET: api/Realises/5
        [ResponseType(typeof(Realise))]
        public async Task<IHttpActionResult> GetRealise(int id)
        {
            Realise realise = await db.Realises.FindAsync(id);
            if (realise == null)
            {
                return NotFound();
            }

            return Ok(realise);
        }

        // PUT: api/Realises/5
        [ResponseType(typeof(void))]
        public async Task<IHttpActionResult> PutRealise(int id, Realise realise)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (id != realise.Id)
            {
                return BadRequest();
            }

            db.Entry(realise).State = EntityState.Modified;

            try
            {
                await db.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!RealiseExists(id))
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

        // POST: api/Realises
        [ResponseType(typeof(Realise))]
        public async Task<IHttpActionResult> PostRealise(Realise realise)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            db.Realises.Add(realise);
            await db.SaveChangesAsync();

            return CreatedAtRoute("DefaultApi", new { id = realise.Id }, realise);
        }

        // DELETE: api/Realises/5
        [ResponseType(typeof(Realise))]
        public async Task<IHttpActionResult> DeleteRealise(int id)
        {
            Realise realise = await db.Realises.FindAsync(id);
            if (realise == null)
            {
                return NotFound();
            }

            db.Realises.Remove(realise);
            await db.SaveChangesAsync();

            return Ok(realise);
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }

        private bool RealiseExists(int id)
        {
            return db.Realises.Count(e => e.Id == id) > 0;
        }
    }
}