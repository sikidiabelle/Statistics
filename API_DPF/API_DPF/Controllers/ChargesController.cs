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
    public class ChargesController : ApiController
    {
        private API_DPFContext db = new API_DPFContext();

        // GET: api/Charges
        public IQueryable<Charge> GetCharges()
        {
            return db.Charges;
        }

        // GET: api/Charges/5
        [ResponseType(typeof(Charge))]
        public async Task<IHttpActionResult> GetCharge(int id)
        {
            Charge charge = await db.Charges.FindAsync(id);
            if (charge == null)
            {
                return NotFound();
            }

            return Ok(charge);
        }

        // PUT: api/Charges/5
        [ResponseType(typeof(void))]
        public async Task<IHttpActionResult> PutCharge(int id, Charge charge)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (id != charge.Id)
            {
                return BadRequest();
            }

            db.Entry(charge).State = EntityState.Modified;

            try
            {
                await db.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!ChargeExists(id))
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

        // POST: api/Charges
        [ResponseType(typeof(Charge))]
        public async Task<IHttpActionResult> PostCharge(Charge charge)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            db.Charges.Add(charge);
            await db.SaveChangesAsync();

            return CreatedAtRoute("DefaultApi", new { id = charge.Id }, charge);
        }

        // DELETE: api/Charges/5
        [ResponseType(typeof(Charge))]
        public async Task<IHttpActionResult> DeleteCharge(int id)
        {
            Charge charge = await db.Charges.FindAsync(id);
            if (charge == null)
            {
                return NotFound();
            }

            db.Charges.Remove(charge);
            await db.SaveChangesAsync();

            return Ok(charge);
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }

        private bool ChargeExists(int id)
        {
            return db.Charges.Count(e => e.Id == id) > 0;
        }
    }
}