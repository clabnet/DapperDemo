using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using Dapper;
using Npgsql;

using ServiceStack.Text;

namespace DapperDemo
{
    // Download NpgSql driver https://github.com/npgsql/npgsql/releases/download/v2.2.4.3/Setup_Npgsql-2.2.4.3-net45.exe
    // Dapper.NET https://github.com/StackExchange/dapper-dot-net
    // https://www.tritac.com/bp-24-dapper-net-by-example
    // Dapper.NET SimpleCrud Extension https://github.com/ericdc1/Dapper.SimpleCRUD
    // Use DvdRental Sample database Postgres https://github.com/robconery/dvdrental
    // Use Glimpse http://volaresystems.com/blog/post/2013/09/03/Getting-the-SQL-and-Parameters-out-of-Dapper-for-display-in-Glimpse
    // Master Child http://stackoverflow.com/questions/20710453/how-to-pull-back-all-parent-child-data-in-complex-object-using-dapper-orm-in-ne
    // ServiceStack.Text V3 https://github.com/ServiceStack/ServiceStack.Text/tree/v3
    // Json.NET vs ServiceStack.Text https://danielwertheim.wordpress.com/2011/02/07/json-net-vs-servicestack/

    public class CustomerRepository : ICustomerRepository
    {

        public CustomerRepository()
        {
            JsConfig.DateHandler = JsonDateHandler.ISO8601;
        }

        public Customer Get()
        {
            using (var connection = ConnectionFactory.GetOpenConnection())
            {
                return connection.Get<Customer>(524);
            }
        }

        public string SerializeUsingServiceStackText()
        {
            using (var connection = ConnectionFactory.GetOpenConnection())
            {
                return connection.GetList<Customer>().ToJson();
            }
        }

        public IEnumerable<Customer> DeserializeUsingServiceStackText()
        {
            using (var connection = ConnectionFactory.GetOpenConnection())
            {
                var json = connection.GetList<Customer>().ToJson();
                return  json.FromJson<IEnumerable<Customer>>();
            }
        }

        public string GetJson()
        {
            using (var connection = ConnectionFactory.GetOpenConnection())
            {
                Customer customer = connection.Get<Customer>(524);
                return TypeSerializer.SerializeToString<Customer>(customer);
            }
        }

        public IEnumerable<Customer> GetList()
        {
            using (var connection = ConnectionFactory.GetOpenConnection())
            {
                return connection.GetList<Customer>();
            }
        }

        public IEnumerable<Customer> GetListWithCondition()
        {
            using (var connection = ConnectionFactory.GetOpenConnection())
            {
                return connection.GetList<Customer>(new { store_id = 1, address_id = 530 });
            }
        }

        public IEnumerable<Customer> GetQueryWithCondition()
        {
            using (var connection = ConnectionFactory.GetOpenConnection())
            {
                return connection.Query<Customer>(@"SELECT * FROM CUSTOMER WHERE store_id = @store_id", new { store_id = 1 });
            }
        }

        public IEnumerable<Country> ExecStoredProcedureGetCountries()
        {
            using (var connection = ConnectionFactory.GetOpenConnection())
            {
                return connection.Query<Country>("get_countries", new { country_id = 1 }, commandType: CommandType.StoredProcedure);
            }
        }

        public IEnumerable<Film> GetFilms()
        {
            using (var connection = ConnectionFactory.GetOpenConnection())
            {
                string sql = @"SELECT
	                            film.film_id, title, description
                            FROM
	                            film
                            INNER JOIN film_actor ON film_actor.film_id = film.film_id
                            INNER JOIN film_category ON film_category.film_id = film.film_id
                            INNER JOIN inventory ON inventory.film_id = film.film_id
                            WHERE (length = @length) AND (release_year = @release_year) AND (title = @title) AND (actor_id = @actor_id)";

                return connection.Query<Film>(sql, new { release_year = 2006, length = 84, title = "Daisy Menagerie", actor_id = 5 });

            }
        }
        
        public IEnumerable<Category> GetQueryMultipleRecordset()
        {
            using (var connection = ConnectionFactory.GetOpenConnection())
            {
                string query = @"SELECT * FROM CUSTOMER; SELECT * FROM CATEGORY";

                Dapper.SqlMapper.GridReader gridreader = connection.QueryMultiple(query, null);

                // 1.st recordset
                IEnumerable<Customer> customers = gridreader.Read<Customer>();

                // 2.nd recordset
                return gridreader.Read<Category>();
            }

        }

        public Customer Update(Customer customer)
        {
            using (var connection = ConnectionFactory.GetOpenConnection())
            {
                connection.Update(customer);
                return customer;
            }
        }

        public int Delete(Customer customer)
        {
            using (var connection = ConnectionFactory.GetOpenConnection())
            {
                return connection.Delete(customer);
            }
        }

        public Customer Insert(Customer customer)
        {
            using (var connection = ConnectionFactory.GetOpenConnection())
            {
                var id = connection.Insert(customer);
                customer.customer_id = (int)id;
                return customer;
            }
        }

        public int? Insert()
        {
            using (var connection = ConnectionFactory.GetOpenConnection())
            {
                int? newId = connection.Insert(new Customer { first_name = "Claudio", last_name = "Barca", address_id = 530 });
                return newId;
            }

        }

    }

}

