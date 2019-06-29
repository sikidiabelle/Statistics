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
    public class AnneesController : ApiController
    {
        private API_DPFContext db = new API_DPFContext();

        // GET: api/Annees
        public IQueryable<Annee> GetAnnees()
        {
            return db.Annees;
        }

        // GET: api/Annees/5
        [ResponseType(typeof(Annee))]
        public async Task<IHttpActionResult> GetAnnee(int id)
        {
            Annee annee = await db.Annees.FindAsync(id);
            if (annee == null)
            {
                return NotFound();
            }

            return Ok(annee);
        }

        // PUT: api/Annees/5
        [ResponseType(typeof(void))]
        public async Task<IHttpActionResult> PutAnnee(int id, Annee annee)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (id != annee.Id)
            {
                return BadRequest();
            }

            db.Entry(annee).State = EntityState.Modified;

            try
            {
                await db.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!AnneeExists(id))
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

        // POST: api/Annees
        [ResponseType(typeof(Annee))]
        public async Task<IHttpActionResult> PostAnnee(Annee annee)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            db.Annees.Add(annee);
            await db.SaveChangesAsync();

            return CreatedAtRoute("DefaultApi", new { id = annee.Id }, annee);
        }

        // DELETE: api/Annees/5
        [ResponseType(typeof(Annee))]
        public async Task<IHttpActionResult> DeleteAnnee(int id)
        {
            Annee annee = await db.Annees.FindAsync(id);
            if (annee == null)
            {
                return NotFound();
            }

            db.Annees.Remove(annee);
            await db.SaveChangesAsync();

            return Ok(annee);
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }

        private bool AnneeExists(int id)
        {
            return db.Annees.Count(e => e.Id == id) > 0;
        }
    }
}