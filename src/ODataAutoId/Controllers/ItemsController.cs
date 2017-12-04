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
    public class ItemsController : ODataController {



        private readonly SampleContext _Db;

        public ItemsController() {
            _Db = new SampleContext();
        }


        protected override void Dispose(bool disposing) {
            base.Dispose(disposing);

            if (disposing) {
                _Db.Dispose();
            }
        }


        [EnableQuery]
        public IEnumerable<Item> Get() {
            return _Db.Items;
        }

        [EnableQuery]
        public Item Get(int key) {
            return _Db.Items.Find(key);
        }

        [ResponseType(typeof(CreatedODataResult<Item>))]
        public IHttpActionResult Post(Item p) {
            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            var inserted = _Db.Items.Add(p);

            _Db.SaveChanges();

            return Created(inserted);
        }

    }
}