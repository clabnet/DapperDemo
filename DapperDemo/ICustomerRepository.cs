using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace DapperDemo
{
    public interface ICustomerRepository
    {
        Customer Get();

        IEnumerable<Customer> GetList();

        IEnumerable<Film> GetFilms();

        IEnumerable<Customer> GetListWithCondition();

        IEnumerable<Customer> GetQueryWithCondition();

        IEnumerable<Category> GetQueryMultipleRecordset();

        IEnumerable<Country> ExecStoredProcedureGetCountries();

        int? Insert();

        Customer Insert(Customer customer);

        Customer Update(Customer customer);

        int Delete(Customer customer);

        string GetJson();

        string SerializeUsingServiceStackText();

        IEnumerable<Customer> DeserializeUsingServiceStackText();



    }
}
