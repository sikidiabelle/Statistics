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
    public class CommentairesController : ApiController
    {
        private API_DPFContext db = new API_DPFContext();

        // GET: api/Commentaires
        public IQueryable<Commentaire> GetCommentaires()
        {
            return db.Commentaires;
        }

        // GET: api/Commentaires/5
        [ResponseType(typeof(Commentaire))]
        public async Task<IHttpActionResult> GetCommentaire(int id)
        {
            Commentaire commentaire = await db.Commentaires.FindAsync(id);
            if (commentaire == null)
            {
                return NotFound();
            }

            return Ok(commentaire);
        }

        // PUT: api/Commentaires/5
        [ResponseType(typeof(void))]
        public async Task<IHttpActionResult> PutCommentaire(int id, Commentaire commentaire)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (id != commentaire.Id)
            {
                return BadRequest();
            }

            db.Entry(commentaire).State = EntityState.Modified;

            try
            {
                await db.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!CommentaireExists(id))
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

        // POST: api/Commentaires
        [ResponseType(typeof(Commentaire))]
        public async Task<IHttpActionResult> PostCommentaire(Commentaire commentaire)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            db.Commentaires.Add(commentaire);
            await db.SaveChangesAsync();

            return CreatedAtRoute("DefaultApi", new { id = commentaire.Id }, commentaire);
        }

        // DELETE: api/Commentaires/5
        [ResponseType(typeof(Commentaire))]
        public async Task<IHttpActionResult> DeleteCommentaire(int id)
        {
            Commentaire commentaire = await db.Commentaires.FindAsync(id);
            if (commentaire == null)
            {
                return NotFound();
            }

            db.Commentaires.Remove(commentaire);
            await db.SaveChangesAsync();

            return Ok(commentaire);
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }

        private bool CommentaireExists(int id)
        {
            return db.Commentaires.Count(e => e.Id == id) > 0;
        }
    }
}