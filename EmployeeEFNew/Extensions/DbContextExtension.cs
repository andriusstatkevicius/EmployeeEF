using EmployeeEF.DBContexts;
using EmployeeEF.Models;
using System.Linq;

namespace EmployeeEF.Extensions
{
    public static class DbContextExtension
    {
        public static void SeedData(this EmployeeContext context)
        {
            SeedEmployees(context);
        }

        private static void SeedEmployees(EmployeeContext context)
        {
            if (context.Employees.Any())
                return;

            Employee[] employees =
            {
                new Employee {
                    EmployeeId = 1,
                    Name = "Sample1",
                    Email = "Sample@sample.com"
               },
                new Employee
                {
                    EmployeeId = 2,
                    Name = "Sample2",
                    Email = "Sample2@sample.com"
                }
            };

            context.Employees.AddRange(employees);
            Address[] addresses =
            {
                new Address
                {
                    AddressId = 1,
                    City = "City1",
                    EmployeeId = 1
                },
                new Address
                {
                    AddressId = 2,
                    City = "City2",
                    EmployeeId = 1
                },
                new Address
                {
                    AddressId = 3,
                    City = "City1",
                    EmployeeId = 2
                }
            };

            context.Addresses.AddRange(addresses);
            context.SaveChanges();
        }
    }
}
