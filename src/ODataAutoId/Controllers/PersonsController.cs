using ODataAutoId.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Http;
using System.Web.Http.Description;
using System.Web.OData;
using System.Web.OData.Results;

namespace ODataAutoId.Controllers {
    public class PersonsController : ODataController {



        private readonly SampleContext _Db;

        public PersonsController() {
            _Db = new SampleContext();
        }


        protected override void Dispose(bool disposing) {
            base.Dispose(disposing);

            if (disposing) {
                _Db.Dispose();
            }
        }


        [EnableQuery]
        public IEnumerable<Person> Get() {
            return _Db.Persons;
        }

        [EnableQuery]
        public Person Get(int key) {
            return _Db.Persons.Find(key);
        }

        [ResponseType(typeof(CreatedODataResult<Person>))]
        public IHttpActionResult Post(Person p) {
            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            var inserted = _Db.Persons.Add(p);

            _Db.SaveChanges();

            return Created(inserted);
        }

    }
}