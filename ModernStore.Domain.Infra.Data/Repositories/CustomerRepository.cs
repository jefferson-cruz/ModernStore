using Dapper;
using ModernStore.Domain.Entities;
using ModernStore.Domain.Repositories;
using ModernStore.Domain.ValueObjects;
using ModernStore.Infra.Data.Contexts;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;

namespace ModernStore.Infra.Data.Repositories
{
    public class CustomerRepository : ICustomerRepository
    {
        private readonly ModernStoreContext context;

        public CustomerRepository(ModernStoreContext context)
        {
            this.context = context;
        }

        public void Insert(Customer customer)
        {
            context.Set<Customer>().Add(customer);
        }

        public void Update(Customer customer)
        {
            context.Entry(customer).State = System.Data.Entity.EntityState.Modified;
        }

        public Customer GetById(Guid id)
        {
            return context.Set<Customer>().Find(id);
        }

        public bool VerifyIfDocumentExists(string documentNumber)
        {
            return context.Set<Customer>().Any(x => x.Document.Number.Equals(documentNumber));
        }

        public bool VerifyIfDocumentExists(Guid id, string documentNumber)
        {
            return context.Set<Customer>().Any(x => x.Document.Number.Equals(documentNumber) && x.Id != id);
        }

        public IEnumerable<Customer> GetAll()
        {
            var customers = new List<Customer>();

            using (var connection = new SqlConnection(context.Database.Connection.ConnectionString))
            {
                var records = connection.Query<Models.CustomerRecord>(
                    @"SELECT 
                        Id,
                        Name_FirstName ,
                        Name_LastName,
                        BirthDate,
                        Document_Number,
                        CreatedDate
                    FROM Customer");

                foreach (var record in records)
                {
                    var customer = new Customer(
                        record.Id, 
                        record.Name_FirstName, 
                        record.Name_LastName, 
                        record.Document_Number
                    );

                    customers.Add(customer);
                }

                return customers;
            }
        }
    }
}
