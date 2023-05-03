using Domain.Entities;
using Domain.Enums;
using Microsoft.AspNetCore.Builder;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;

namespace Persistence.Context
{
    public static class BaseDBSeed
    {       
        static public IApplicationBuilder SeedClient(this IApplicationBuilder app)
        {
            using (var scope = app.ApplicationServices.CreateScope())
            {
                var db = scope.ServiceProvider.GetRequiredService<BaseDbContext>();
                db.Database.Migrate();
                if (!db.Departments.Any())
                {
                    List<Department> departments = new() {
                     new Department()
                    {
                         ShortName = "Hr",
                         FullName = "Human Resourse",
                         DateOfEntry = DateTime.UtcNow,
                         Record = "<p>Human Resourse<p/>"
                    },
                        new Department()
                    {
                         ShortName = "IT",
                         FullName = "Information Technology",
                         DateOfEntry = DateTime.UtcNow,
                         Record = "<p>Information Technology<p/>"
                    },
              
                };

                    db.Departments.AddRange(departments);
                    db.SaveChanges();
                };  
                if (!db.Positions.Any())
                {
                    List<Position> positions = new() {
                     new Position()
                    {
                         Title = "Admin",
                         DateOfEntry = DateTime.UtcNow,
                         DepartmentId = 1,
                    },
                     new Position()
                    {
                         Title = "User",
                         DateOfEntry = DateTime.UtcNow,
                         DepartmentId = 2,
                    }

                };

                    db.Positions.AddRange(positions);
                    db.SaveChanges();
                }; 
                if (!db.Employees.Any())
                {
                    List<Employee> employees = new () {
                     new Employee()
                    {
                         Name = "Admin",
                         Surname = "Admin",
                         DateOfEntry = DateTime.UtcNow,
                         PositionId = 1,
                    },
                     new Employee()
                    {
                         Name = "User",
                         Surname = "User",
                         DateOfEntry = DateTime.UtcNow,
                         PositionId = 2,
                    }

                };

                    db.Employees.AddRange(employees);
                    db.SaveChanges();
                };
                if (!db.Accounts.Any())
                {
                    List<Account> accounts = new () {
                        new Account()
                    {
                        Email = "admin@mail.com",
                        Password = "N78Z3UquX7wa6/CasJcz+cZki995N4TjpHWSIrNAUw+nbueH9YPF6csMruDaIEPB",// 123
                        Role = Role.Admin,
                        EmployeeId = 1
                    },
                        new Account()
                    {
                        Email =  "user@mail.com",
                        Password = "N78Z3UquX7wa6/CasJcz+cZki995N4TjpHWSIrNAUw+nbueH9YPF6csMruDaIEPB",// 123
                        Role = Role.User,
                        EmployeeId = 2
                    }
                        };
                    db.Accounts.AddRange(accounts);
                    db.SaveChanges();
                }

            }

            return app;
        }
    }
}