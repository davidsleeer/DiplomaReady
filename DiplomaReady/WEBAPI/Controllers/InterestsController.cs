using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Data.Entity.Infrastructure;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using System.Web.Http.Description;
using WEBAPI.Models;

namespace WEBAPI.Controllers
{
    public class InterestsController : ApiController
    {
        private SQLFinalEntities db = new SQLFinalEntities();

        // GET: api/Interests
        public IQueryable<Interests> GetInterests()
        {
            return db.Interests;
        }

        // GET: api/Interests/5
        [ResponseType(typeof(Interests))]
        public IHttpActionResult GetInterests(string id)
        {
            Interests interests = db.Interests.Find(id);
            if (interests == null)
            {
                return NotFound();
            }

            return Ok(interests);
        }

        // PUT: api/Interests/5
        [ResponseType(typeof(void))]
        public IHttpActionResult PutInterests(string id, Interests interests)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (id != interests.InterestCode)
            {
                return BadRequest();
            }

            db.Entry(interests).State = EntityState.Modified;

            try
            {
                db.SaveChanges();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!InterestsExists(id))
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

        // POST: api/Interests
        [ResponseType(typeof(Interests))]
        public IHttpActionResult PostInterests(Interests interests)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            db.Interests.Add(interests);

            try
            {
                db.SaveChanges();
            }
            catch (DbUpdateException)
            {
                if (InterestsExists(interests.InterestCode))
                {
                    return Conflict();
                }
                else
                {
                    throw;
                }
            }

            return CreatedAtRoute("DefaultApi", new { id = interests.InterestCode }, interests);
        }

        // DELETE: api/Interests/5
        [ResponseType(typeof(Interests))]
        public IHttpActionResult DeleteInterests(string id)
        {
            Interests interests = db.Interests.Find(id);
            if (interests == null)
            {
                return NotFound();
            }

            db.Interests.Remove(interests);
            db.SaveChanges();

            return Ok(interests);
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }

        private bool InterestsExists(string id)
        {
            return db.Interests.Count(e => e.InterestCode == id) > 0;
        }
    }
}