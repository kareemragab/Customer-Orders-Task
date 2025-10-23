using CustomerOrders.Models;
using DevExpress.Xpo;
using System;

namespace CustomerOrders.Services
{
    public class DataSeeder
    {
        public static void SeedData()
        {
            using (var uow = new UnitOfWork())
            {
                if (new XPQuery<Customer>(uow).Count() > 0)
                {
                    return; 
                }

                var customer1 = new Customer(uow)
                {
                    CustomerId = "CUST-001",
                    Name = "John Smith",
                    Email = "john.smith@example.com",
                    PhoneNumber = "555-0101"
                };

                var customer2 = new Customer(uow)
                {
                    CustomerId = "CUST-002",
                    Name = "Sarah Johnson",
                    Email = "sarah.johnson@example.com",
                    PhoneNumber = "555-0102"
                };

                var customer3 = new Customer(uow)
                {
                    CustomerId = "CUST-003",
                    Name = "Michael Brown",
                    Email = "michael.brown@example.com",
                    PhoneNumber = "555-0103"
                };

                var customer4 = new Customer(uow)
                {
                    CustomerId = "CUST-004",
                    Name = "Emily Davis",
                    Email = "emily.davis@example.com",
                    PhoneNumber = "555-0104"
                };

                var customer5 = new Customer(uow)
                {
                    CustomerId = "CUST-005",
                    Name = "Robert Wilson",
                    Email = "robert.wilson@example.com",
                    PhoneNumber = "555-0105"
                };

                new Order(uow)
                {
                    OrderNumber = "ORD-10001",
                    OrderDate = DateTime.Now.AddDays(-30),
                    Description = "Office supplies package",
                    Amount = 250.50m,
                    Customer = customer1
                };

                new Order(uow)
                {
                    OrderNumber = "ORD-10002",
                    OrderDate = DateTime.Now.AddDays(-28),
                    Description = "Computer accessories",
                    Amount = 450.75m,
                    Customer = customer1
                };

                new Order(uow)
                {
                    OrderNumber = "ORD-10003",
                    OrderDate = DateTime.Now.AddDays(-25),
                    Description = "Software licenses",
                    Amount = 1200.00m,
                    Customer = customer2
                };

                new Order(uow)
                {
                    OrderNumber = "ORD-10004",
                    OrderDate = DateTime.Now.AddDays(-20),
                    Description = "Desk furniture set",
                    Amount = 850.25m,
                    Customer = customer2
                };

                new Order(uow)
                {
                    OrderNumber = "ORD-10005",
                    OrderDate = DateTime.Now.AddDays(-18),
                    Description = "Networking equipment",
                    Amount = 675.50m,
                    Customer = customer3
                };

                new Order(uow)
                {
                    OrderNumber = "ORD-10006",
                    OrderDate = DateTime.Now.AddDays(-15),
                    Description = "Printer and supplies",
                    Amount = 320.00m,
                    Customer = customer3
                };

                new Order(uow)
                {
                    OrderNumber = "ORD-10007",
                    OrderDate = DateTime.Now.AddDays(-12),
                    Description = "Conference room equipment",
                    Amount = 1500.00m,
                    Customer = customer4
                };

                new Order(uow)
                {
                    OrderNumber = "ORD-10008",
                    OrderDate = DateTime.Now.AddDays(-10),
                    Description = "Mobile devices",
                    Amount = 2200.00m,
                    Customer = customer4
                };

                new Order(uow)
                {
                    OrderNumber = "ORD-10009",
                    OrderDate = DateTime.Now.AddDays(-8),
                    Description = "Security system upgrade",
                    Amount = 3100.50m,
                    Customer = customer5
                };

                new Order(uow)
                {
                    OrderNumber = "ORD-10010",
                    OrderDate = DateTime.Now.AddDays(-5),
                    Description = "Cloud storage subscription",
                    Amount = 199.99m,
                    Customer = customer5
                };

                new Order(uow)
                {
                    OrderNumber = "ORD-10011",
                    OrderDate = DateTime.Now.AddDays(-3),
                    Description = "Backup power supplies",
                    Amount = 550.00m,
                    Customer = customer1
                };

                new Order(uow)
                {
                    OrderNumber = "ORD-10012",
                    OrderDate = DateTime.Now.AddDays(-1),
                    Description = "Training materials",
                    Amount = 175.25m,
                    Customer = customer3
                };

                uow.CommitChanges();
            }
        }
    }
}
