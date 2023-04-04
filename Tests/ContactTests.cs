using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Projekt_Lukasz_Motak.Tests
{
    [TestFixture]
    public class ContactTests
    {
        [Test]
        public void TestContactConstructor()
        {
            // Arrange
            Contact originalContact = new Contact()
            {
                Id = 1,
                FirstName = "John",
                LastName = "Doe",
                PhoneNumber = "555-1234",
                Email = "john.doe@example.com",
                Birthday = "1980-01-01"
            };

            // Act
            Contact copiedContact = new Contact(originalContact);

            // Assert
            Assert.AreEqual(originalContact.Id, copiedContact.Id);
            Assert.AreEqual(originalContact.FirstName, copiedContact.FirstName);
            Assert.AreEqual(originalContact.LastName, copiedContact.LastName);
            Assert.AreEqual(originalContact.PhoneNumber, copiedContact.PhoneNumber);
            Assert.AreEqual(originalContact.Email, copiedContact.Email);
            Assert.AreEqual(originalContact.Birthday, copiedContact.Birthday);
        }
    }
}
