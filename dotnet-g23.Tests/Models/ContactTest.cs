using dotnet_g23.Models.Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Xunit;

namespace dotnet_g23.Tests.Models {
    public class ContactTest {
        [Fact]
        public void ConstructorShouldCreateNewContact() {
            String title = "Mr.";
            String fN = "Foo";
            String lN = "Bar";
            String func = "CEO";
            String email = "foo.bar@gar.com";
            Company comp = new Company("Foobar", "Foobar", "Foobar", "foobar.com", "foobar@foobar.com");
            Contact contact = new Contact(title, fN, lN, func, email, comp);

            Assert.Equal(comp, contact.Company);
            Assert.Equal(title, contact.Title);
            Assert.Equal(fN, contact.FirstName);
            Assert.Equal(lN, contact.LastName);
            Assert.Equal(email, contact.Email);
        }
    }
}
