using dotnet_g23.Models.Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Xunit;

namespace dotnet_g23.Tests.Models
{
    public class CompanyTest
    {
        [Fact]
        public void ConstructorShouldCreateNewCompany() {
            String name = "foo";
            String descr = "foobar";
            String address = "foo bar";
            String website = "foo.bar";
            String email = "foo@bar";

            Company company = new Company(name, descr, address, website, email);
            Assert.True(company.Contacts.Count() == 0);
        }
    }
}
