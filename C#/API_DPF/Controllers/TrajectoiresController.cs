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
    public class TrajectoiresController : ApiController
    {
        private API_DPFContext db = new API_DPFContext();

        // GET: api/Trajectoires
        public IQueryable<Trajectoire> GetTrajectoires()
        {
            return db.Trajectoires;
        }

        // GET: api/Trajectoires/5
        [ResponseType(typeof(Trajectoire))]
        public async Task<IHttpActionResult> GetTrajectoire(int id)
        {
            Trajectoire trajectoire = await db.Trajectoires.FindAsync(id);
            if (trajectoire == null)
            {
                return NotFound();
            }

            return Ok(trajectoire);
        }

        // PUT: api/Trajectoires/5
        [ResponseType(typeof(void))]
        public async Task<IHttpActionResult> PutTrajectoire(int id, Trajectoire trajectoire)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (id != trajectoire.Id)
            {
                return BadRequest();
            }

            db.Entry(trajectoire).State = EntityState.Modified;

            try
            {
                await db.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!TrajectoireExists(id))
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

        // POST: api/Trajectoires
        [ResponseType(typeof(Trajectoire))]
        public async Task<IHttpActionResult> PostTrajectoire(Trajectoire trajectoire)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            db.Trajectoires.Add(trajectoire);
            await db.SaveChangesAsync();

            return CreatedAtRoute("DefaultApi", new { id = trajectoire.Id }, trajectoire);
        }

        // DELETE: api/Trajectoires/5
        [ResponseType(typeof(Trajectoire))]
        public async Task<IHttpActionResult> DeleteTrajectoire(int id)
        {
            Trajectoire trajectoire = await db.Trajectoires.FindAsync(id);
            if (trajectoire == null)
            {
                return NotFound();
            }

            db.Trajectoires.Remove(trajectoire);
            await db.SaveChangesAsync();

            return Ok(trajectoire);
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }

        private bool TrajectoireExists(int id)
        {
            return db.Trajectoires.Count(e => e.Id == id) > 0;
        }
    }
}