using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using ODataAutoId.Tests.ODataAutoId.Models;
using ODataAutoId.Tests.Default;

namespace ODataAutoId.Tests {
    [TestClass]
    public class PersonTests {
        [TestMethod]
        public void AddingPersonTransportsServerGeneratedIdBackToClientSideModel() {

            var person = new Person() {
                Name = Guid.NewGuid().ToString()
            };


            var container = new Container(new Uri("http://localhost/ODataAutoId/odata"));
            container.AddToPersons(person);
            container.SaveChanges();

            var actual = person.Id;
            var unexpected = 0;

            Assert.AreNotEqual(unexpected, actual);
        }
    }
}
