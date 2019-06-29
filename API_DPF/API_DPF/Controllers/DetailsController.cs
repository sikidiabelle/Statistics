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
    public class DetailsController : ApiController
    {
        private API_DPFContext db = new API_DPFContext();

        // GET: api/Details
        public IQueryable<Detail> GetDetails()
        {
            return db.Details;
        }

        // GET: api/Details/5
        [ResponseType(typeof(Detail))]
        public async Task<IHttpActionResult> GetDetail(int id)
        {
            Detail detail = await db.Details.FindAsync(id);
            if (detail == null)
            {
                return NotFound();
            }

            return Ok(detail);
        }

        // PUT: api/Details/5
        [ResponseType(typeof(void))]
        public async Task<IHttpActionResult> PutDetail(int id, Detail detail)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (id != detail.Id)
            {
                return BadRequest();
            }

            db.Entry(detail).State = EntityState.Modified;

            try
            {
                await db.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!DetailExists(id))
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

        // POST: api/Details
        [ResponseType(typeof(Detail))]
        public async Task<IHttpActionResult> PostDetail(Detail detail)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            db.Details.Add(detail);
            await db.SaveChangesAsync();

            return CreatedAtRoute("DefaultApi", new { id = detail.Id }, detail);
        }

        // DELETE: api/Details/5
        [ResponseType(typeof(Detail))]
        public async Task<IHttpActionResult> DeleteDetail(int id)
        {
            Detail detail = await db.Details.FindAsync(id);
            if (detail == null)
            {
                return NotFound();
            }

            db.Details.Remove(detail);
            await db.SaveChangesAsync();

            return Ok(detail);
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }

        private bool DetailExists(int id)
        {
            return db.Details.Count(e => e.Id == id) > 0;
        }
    }
}