using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using ODataAutoId.Tests.ODataAutoId.Models;
using ODataAutoId.Tests.Default;

namespace ODataAutoId.Tests {
    [TestClass]
    public class ItemTests {
        [TestMethod]
        public void AddingItemTransportsServerGeneratedIdBackToClientSideModel() {

            var item = new Item() {
                Name = Guid.NewGuid().ToString()
            };

            var container = new Container(new Uri("http://localhost/ODataAutoId/odata"));
            container.AddToItems(item);
            container.SaveChanges();

            var actual = item.Id;
            var unexpected = 0;

            Assert.AreNotEqual(unexpected, actual);
        }
    }
}
