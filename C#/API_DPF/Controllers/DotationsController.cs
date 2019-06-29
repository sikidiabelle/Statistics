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
    public class DotationsController : ApiController
    {
        private API_DPFContext db = new API_DPFContext();

        // GET: api/Dotations
        public IQueryable<Dotation> GetDotations()
        {
            return db.Dotations;
        }

        // GET: api/Dotations/5
        [ResponseType(typeof(Dotation))]
        public async Task<IHttpActionResult> GetDotation(int id)
        {
            Dotation dotation = await db.Dotations.FindAsync(id);
            if (dotation == null)
            {
                return NotFound();
            }

            return Ok(dotation);
        }

        // PUT: api/Dotations/5
        [ResponseType(typeof(void))]
        public async Task<IHttpActionResult> PutDotation(int id, Dotation dotation)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (id != dotation.Id)
            {
                return BadRequest();
            }

            db.Entry(dotation).State = EntityState.Modified;

            try
            {
                await db.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!DotationExists(id))
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

        // POST: api/Dotations
        [ResponseType(typeof(Dotation))]
        public async Task<IHttpActionResult> PostDotation(Dotation dotation)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            db.Dotations.Add(dotation);
            await db.SaveChangesAsync();

            return CreatedAtRoute("DefaultApi", new { id = dotation.Id }, dotation);
        }

        // DELETE: api/Dotations/5
        [ResponseType(typeof(Dotation))]
        public async Task<IHttpActionResult> DeleteDotation(int id)
        {
            Dotation dotation = await db.Dotations.FindAsync(id);
            if (dotation == null)
            {
                return NotFound();
            }

            db.Dotations.Remove(dotation);
            await db.SaveChangesAsync();

            return Ok(dotation);
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }

        private bool DotationExists(int id)
        {
            return db.Dotations.Count(e => e.Id == id) > 0;
        }
    }
}