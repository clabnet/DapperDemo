using DapperDemo;
using FluentAssertions;
using NUnit.Framework;
using System.Collections.Generic;
using System.Linq;

using System.Diagnostics;

using ServiceStack.Text;

namespace Dapper.myUnitTest
{
    [TestFixture]
    public class Test_to_demo_Dapper_Net
    {

        ICustomerRepository customerRepository;

        [TestFixtureSetUp]
        public void Init()
        {
            customerRepository = new CustomerRepository();
        }
        
        [SetUp]
        public void It_run_before_each_test()
        {
        }

        [Test]
        public void GetJsonTest()
        {
            string json = customerRepository.GetJson();
            json.PrintDump();
        }

        [Test]
        public void SerializeUsingServiceStackText()
        {
            var json = customerRepository.SerializeUsingServiceStackText();
            json.PrintDump();           
        }

        [Test]
        public void DeserializeUsingServiceStackText()
        {
            IEnumerable<Customer> customers = customerRepository.DeserializeUsingServiceStackText();
            customers.First().last_name.Should().Be("Ely");
        }
        
        [Test]
        public void GetCustomerTest()
        {
            Customer customer = customerRepository.Get();
            customer.last_name.Should().Be("Ely");
        }

        [Test]
        public void GetListCustomerTest()
        {
            IEnumerable<Customer> customers = customerRepository.GetList();
            customers.First().last_name.Should().Be("Ely");
        }

        [Test]
        public void GetListFilmsTest()
        {
            IEnumerable<Film> films = customerRepository.GetFilms();
            Assert.AreEqual(films.Count(), 4);
        }

        [Test]
        public void GetListWithConditionTest()
        {
            IEnumerable<Customer> customers = customerRepository.GetListWithCondition();
            customers.First().last_name.Should().Be("Ely");
        }

        [Test]
        public void ExecStoredProcedureGetCountriesTest()
        {
            IEnumerable<Country> countries = customerRepository.ExecStoredProcedureGetCountries();
            countries.Should().HaveCount(1);
        }

        [Test]
        public void GetQueryWithConditionTest()
        {
            IEnumerable<Customer> customers = customerRepository.GetQueryWithCondition();
            customers.Should().HaveCount(326);
        }

        [Test]
        public void GetQueryMultipleRecordsetTest()
        {
            IEnumerable<Category> categories = customerRepository.GetQueryMultipleRecordset();
            categories.Should().HaveCount(16);
        }

        [Test]
        public void UpdateCustomerEntityTest()
        {
            Customer customer = new Customer { first_name = "Miriam", last_name = "Barca", address_id = 530 };
            customer = customerRepository.Insert(customer);
            customer.first_name = "Clara";
            customerRepository.Update(customer);
            customer.first_name.Should().Be("Clara");
        }

        [Test]
        public void InsertCustomerEntityTest()
        {
            Customer customer = new Customer { first_name = "Miriam", last_name = "Barca", address_id = 530 };
            customer = customerRepository.Insert(customer);
            customer.customer_id.Should().BeGreaterThan(0);
        }
        
        [Test]
        public void InsertCustomerTest()
        {
            int? newId = customerRepository.Insert();
            newId.Should().BeGreaterThan(0);
        }

        [Test]
        public void DeleteCustomerTest()
        {
            Customer customer = new Customer { first_name = "Claudio", last_name = "Barca", address_id = 530 };
            customer = customerRepository.Insert(customer);
            customer.customer_id.Should().BeGreaterThan(0);

            int? rowsAffected = customerRepository.Delete(customer);
            rowsAffected.Should().Be(1);
        }

        [TearDown]
        public void It_run_after_each_test()
        {
        }

        [TestFixtureTearDown]
        public void Dispose()
        { /* ... */ }

    }
}