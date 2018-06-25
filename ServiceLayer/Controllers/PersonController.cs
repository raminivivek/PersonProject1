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
using MVC.Models;
using ServiceLayer;

namespace ServiceLayer.Controllers
{
    public class PersonController : ApiController
    {
        private ReqprojectEntities db = new ReqprojectEntities();

        // GET: api/Person
        public IQueryable<Person_T> GetPerson_T()
        {
            return db.Person_T;
        }

        // GET: api/Person/5
		public WholeClass GetPerson_T(int id)
        {
			 Person_T person= db.Person_T.Find(id);
			Address_T address = db.Address_T.Find(person.Address_IDNO);
			var key = address.Address_IDNO;
			Phone_T phone = db.Phone_T.First(x=>x.Address_IDNO==key);
			List<WholeClass> whole1 =new List<WholeClass>();
			WholeClass whole = new WholeClass();
			whole.FirstName = person.FirstName;
			whole.LastName = person.LastName;
			whole.AddressLine1 = address.AddressLine1;
			whole.AddressLine2 = address.AddressLine2;
			whole.City = address.City;
			whole.State = address.State;
			whole.ZipCode = address.ZipCode;
			whole.PhoneNumber = phone.PhoneNumber;
			whole.PhoneType = phone.PhoneType;
			whole.Person_IDNO = person.Person_IDNO;
			whole.Address_IDNO = address.Address_IDNO;
			whole.Phone_IDNO = phone.Phone_IDNO;
			whole1.Add(whole);
			return whole;
        }

        // PUT: api/Person/5
        [ResponseType(typeof(WholeClass))]
        public IHttpActionResult PutPerson_T(int id, WholeClass whole)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (id != whole.Person_IDNO)
            {
                return BadRequest();
            }
			Person_T person = db.Person_T.Find(whole.Person_IDNO);
			person.FirstName = whole.FirstName;
			person.LastName = whole.LastName;
			person.UpdatedDate = DateTime.Now;
			Address_T address = db.Address_T.Find(whole.Address_IDNO);
			address.AddressLine1 = whole.AddressLine1;
			address.AddressLine2 = whole.AddressLine2;
			address.State = whole.State;
			address.City = whole.City;
			address.ZipCode = whole.ZipCode;
			address.UpdatedDate = DateTime.Now;
			Phone_T phone = db.Phone_T.Find(whole.Phone_IDNO);
			phone.PhoneNumber = whole.PhoneNumber;
			phone.PhoneType = whole.PhoneType;
			phone.UpdatedDate = DateTime.Now;
            db.Entry(person).State = EntityState.Modified;
			db.Entry(address).State = EntityState.Modified;
			db.Entry(phone).State = EntityState.Modified;
			try
            {
                db.SaveChanges();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!Person_TExists(id))
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

        // POST: api/Person
        [ResponseType(typeof(Person_T))]
        public IHttpActionResult PostPerson_T(WholeClass whole)
        {
			if (!ModelState.IsValid)
			{
				return BadRequest(ModelState);
			}
			Person_T person = new Person_T();
			person.FirstName = whole.FirstName;
			person.LastName = whole.LastName;
			person.CreatedDate = DateTime.Now;
			db.Person_T.Add(person);

			Address_T address = new Address_T();
			address.AddressLine1 = whole.AddressLine1;
			address.AddressLine2 = whole.AddressLine2;
			address.AddressLine2 = whole.AddressLine2;
			address.State = whole.State;
			address.City = whole.City;
			address.ZipCode = whole.ZipCode;
			address.CreatedDate = DateTime.Now;
			db.Address_T.Add(address);

			Phone_T phone = new Phone_T();
			phone.PhoneNumber = whole.PhoneNumber;
			phone.PhoneType = whole.PhoneType;
			phone.CreatedDate = DateTime.Now;
			phone.Address_IDNO = address.Address_IDNO;
			db.Phone_T.Add(phone);


			try
			{
				db.SaveChanges();
			}
			catch (DbUpdateException)
			{
				if (Person_TExists(person.Person_IDNO))
				{
					return Conflict();
				}
				else
				{
					throw;
				}
			}

			//return CreatedAtRoute("DefaultApi", new { id = person_T.Person_IDNO }, person_T);
			return null;
        }

        // DELETE: api/Person/5
        [ResponseType(typeof(Person_T))]
        public IHttpActionResult DeletePerson_T(int id)
        {
            Person_T person_T = db.Person_T.Find(id);
			Address_T address = db.Address_T.Find(person_T.Address_IDNO);
			Phone_T phone = db.Phone_T.First(x => x.Address_IDNO == address.Address_IDNO);
            if (person_T == null)
            {
                return NotFound();
            }

            db.Person_T.Remove(person_T);
			db.Address_T.Remove(address);
			db.Phone_T.Remove(phone);
			db.SaveChanges();

            return Ok(person_T);
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }

        private bool Person_TExists(int id)
        {
            return db.Person_T.Count(e => e.Person_IDNO == id) > 0;
        }
    }
}