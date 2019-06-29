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
    public class OffresController : ApiController
    {
        private API_DPFContext db = new API_DPFContext();

        // GET: api/Offres
        public IQueryable<Offre> GetOffres()
        {
            return db.Offres;
        }

        // GET: api/Offres/5
        [ResponseType(typeof(Offre))]
        public async Task<IHttpActionResult> GetOffre(int id)
        {
            Offre offre = await db.Offres.FindAsync(id);
            if (offre == null)
            {
                return NotFound();
            }

            return Ok(offre);
        }

        // PUT: api/Offres/5
        [ResponseType(typeof(void))]
        public async Task<IHttpActionResult> PutOffre(int id, Offre offre)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (id != offre.Id)
            {
                return BadRequest();
            }

            db.Entry(offre).State = EntityState.Modified;

            try
            {
                await db.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!OffreExists(id))
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

        // POST: api/Offres
        [ResponseType(typeof(Offre))]
        public async Task<IHttpActionResult> PostOffre(Offre offre)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            db.Offres.Add(offre);
            await db.SaveChangesAsync();

            return CreatedAtRoute("DefaultApi", new { id = offre.Id }, offre);
        }

        // DELETE: api/Offres/5
        [ResponseType(typeof(Offre))]
        public async Task<IHttpActionResult> DeleteOffre(int id)
        {
            Offre offre = await db.Offres.FindAsync(id);
            if (offre == null)
            {
                return NotFound();
            }

            db.Offres.Remove(offre);
            await db.SaveChangesAsync();

            return Ok(offre);
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }

        private bool OffreExists(int id)
        {
            return db.Offres.Count(e => e.Id == id) > 0;
        }
    }
}