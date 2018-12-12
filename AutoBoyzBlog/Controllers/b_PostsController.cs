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
using BlogDataAccess;

namespace AutoBoyzBlog.Controllers
{
    public class b_PostsController : ApiController
    {
        private AutoBoyz_BlogEntities db = new AutoBoyz_BlogEntities();

        // GET: api/b_Posts
        [Route("api/GetBlogs")]
        public IQueryable<b_Posts> Getb_Posts()
        {
            return db.b_Posts;
        }

        // GET: api/b_Posts/5
        [ResponseType(typeof(b_Posts))]
        [Route("api/GetBlog")]
        public IHttpActionResult Getb_Posts(int id)
        {
            b_Posts b_Posts = db.b_Posts.Find(id);
            if (b_Posts == null)
            {
                return NotFound();
            }

            return Ok(b_Posts);
        }

        // PUT: api/b_Posts/5
        [ResponseType(typeof(void))]
        [Route("api/PutBlog/{id}")]
        public IHttpActionResult Putb_Posts(int id, b_Posts b_Posts)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (id != b_Posts.Id)
            {
                return BadRequest();
            }

            db.Entry(b_Posts).State = EntityState.Modified;

            try
            {
                db.SaveChanges();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!b_PostsExists(id))
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

        // POST: api/b_Posts
        [ResponseType(typeof(b_Posts))]
        [Route("api/PostBlog",Name ="SendBlog")]
        public IHttpActionResult Postb_Posts(b_Posts b_Posts)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            db.b_Posts.Add(b_Posts);
            db.SaveChanges();

            return CreatedAtRoute("SendBlog", new { id = b_Posts.Id }, b_Posts);
        }

        // DELETE: api/b_Posts/5
        [Route("api/DeleteBlog/{id}")]
        [ResponseType(typeof(b_Posts))]
        public IHttpActionResult Deleteb_Posts(int id)
        {
            b_Posts b_Posts = db.b_Posts.Find(id);
            if (b_Posts == null)
            {
                return NotFound();
            }

            db.b_Posts.Remove(b_Posts);
            db.SaveChanges();

            return Ok(b_Posts);
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }

        private bool b_PostsExists(int id)
        {
            return db.b_Posts.Count(e => e.Id == id) > 0;
        }
    }
}