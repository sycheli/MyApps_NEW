﻿using System;
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
using MyAppAPI.Models;

namespace MyAppAPI.Controllers
{
    public class SpecialitiesController : ApiController
    {
        private MyAppAPIContext db = new MyAppAPIContext();

        // GET: api/Specialities
        public IQueryable<Speciality> GetSpecialities()
        {
            return db.Specialities;
        }

        // GET: api/Specialities/5
        [ResponseType(typeof(Speciality))]
        public async Task<IHttpActionResult> GetSpeciality(int id)
        {
            Speciality speciality = await db.Specialities.FindAsync(id);
            if (speciality == null)
            {
                return NotFound();
            }
           
            
            return Ok(speciality);
        }

        // PUT: api/Specialities/5
        [ResponseType(typeof(void))]
        public async Task<IHttpActionResult> PutSpeciality(int id, Speciality speciality)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (id != speciality.id)
            {
                return BadRequest();
            }

            db.Entry(speciality).State = EntityState.Modified;

            try
            {
                await db.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!SpecialityExists(id))
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

        // POST: api/Specialities
        [ResponseType(typeof(Speciality))]
        public async Task<IHttpActionResult> PostSpeciality(Speciality speciality)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            db.Specialities.Add(speciality);
            await db.SaveChangesAsync();

            return CreatedAtRoute("DefaultApi", new { id = speciality.id }, speciality);
        }

        // DELETE: api/Specialities/5
        [ResponseType(typeof(Speciality))]
        public async Task<IHttpActionResult> DeleteSpeciality(int id)
        {
            Speciality speciality = await db.Specialities.FindAsync(id);
            if (speciality == null)
            {
                return NotFound();
            }

            db.Specialities.Remove(speciality);
            await db.SaveChangesAsync();

            return Ok(speciality);
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }

        private bool SpecialityExists(int id)
        {
            return db.Specialities.Count(e => e.id == id) > 0;
        }
    }
}