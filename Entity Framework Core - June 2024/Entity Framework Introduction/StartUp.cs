using System.Text;
using SoftUni.Data;
using SoftUni.Models;

namespace SoftUni
{
    public class StartUp
    {
        static void Main()
        {
            SoftUniContext context = new SoftUniContext();
            Console.WriteLine(RemoveTown(context));
        }

        public static string GetEmployeesFullInformation(SoftUniContext context)
        {
            var info = context.Employees.Select(entity => new
            {
                entity.FirstName,
                entity.LastName,
                entity.MiddleName,
                entity.JobTitle,
                entity.Salary
            }).ToList();
            StringBuilder result = new StringBuilder();

            foreach (var obj in info)
            {
                result.AppendLine($"{obj.FirstName} {obj.LastName} {obj.MiddleName} {obj.JobTitle} {obj.Salary:f2}");
            }

            return result.ToString().TrimEnd();
        }
        public static string GetEmployeesWithSalaryOver50000(SoftUniContext context)
        {
            var info = context.Employees.Select(entity => new
            {
                entity.FirstName,
                entity.Salary
            }).Where(e => e.Salary > 50000).OrderBy(x => x.FirstName).ToList();
            StringBuilder result = new StringBuilder();

            foreach (var obj in info)
            {
                result.AppendLine($"{obj.FirstName} - {obj.Salary:f2}");
            }

            return result.ToString().TrimEnd();
        }
        public static string GetEmployeesFromResearchAndDevelopment(SoftUniContext context)
        {
            var info = context.Employees.Select(entity => new
            {
                entity.FirstName,
                entity.LastName,
                entity.Department,
                entity.Salary
            }).Where(e => e.Department.Name == "Research and Development")
                .OrderBy(x => x.Salary).ThenByDescending(x => x.FirstName).ToList();
            StringBuilder result = new StringBuilder();

            foreach (var obj in info)
            {
                result.AppendLine($"{obj.FirstName} {obj.LastName} from {obj.Department.Name} - ${obj.Salary:f2}");
            }

            return result.ToString().TrimEnd();
        }
        public static string AddNewAddressToEmployee(SoftUniContext context)
        {
            Address newAddress = new Address() { AddressText = "Vitoshka 15", TownId = 4 };
            Employee employee = context.Employees.FirstOrDefault(x => x.LastName == "Nakov");

            if (employee != null)
            {
                employee.Address = newAddress;
                context.SaveChanges();
            }

            var info = context.Employees.Select(entity => new
            {
                entity.Address,
                entity.AddressId
            })
                .OrderByDescending(x => x.AddressId).Take(10).ToList();

            StringBuilder result = new StringBuilder();

            foreach (var item in info)
            {
                result.AppendLine(item.Address.AddressText);
            }

            return result.ToString().TrimEnd();
        }
        public static string GetEmployeesInPeriod(SoftUniContext context)
        {
            var info = context.Employees
                .Take(10)
                .Select(e => new
                {
                    EmployeeNames = $"{e.FirstName} {e.LastName}",
                    ManagerNames = $"{e.Manager.FirstName} {e.Manager.LastName}",
                    Projects = e.EmployeesProjects
                        .Where(ep => ep.Project.StartDate.Year >= 2001 &&
                                                    ep.Project.StartDate.Year <= 2003)
                        .Select(ep => new
                        {
                            ProjectName = ep.Project.Name,
                            ep.Project.StartDate,
                            EndDate = ep.Project.EndDate.HasValue ? ep.Project.EndDate.Value.ToString("M/d/yyyy h:mm:ss tt") :
                                "not finished"
                        })
                });

            StringBuilder result = new StringBuilder();

            foreach (var e in info)
            {
                result.AppendLine(e.EmployeeNames + " - Manager: " + e.ManagerNames);
                if (e.Projects.Any())
                {
                    foreach (var p in e.Projects)
                    {
                        result.AppendLine($"--{p.ProjectName} - {p.StartDate} - {p.EndDate}");
                    }
                }
            }

            return result.ToString().TrimEnd();
        }
        public static string GetAddressesByTown(SoftUniContext context)
        {
            var infoAddress = context.Addresses.Select(e => new
            {
                e.AddressText,
                Town = e.Town.Name,
                e.Employees.Count
            }).OrderByDescending(e => e.Count).ThenBy(e => e.Town).ThenBy(e => e.AddressText).Take(10).ToList();

            var result = new StringBuilder();

            foreach (var address in infoAddress)
            {
                result.AppendLine($"{address.AddressText}, {address.Town} - {address.Count} employees");
            }

            return result.ToString().TrimEnd();
        }
        public static string GetEmployee147(SoftUniContext context)
        {
            Employee emp = context.Employees.FirstOrDefault(e => e.EmployeeId == 147);
            var employeeProjects = context.EmployeesProjects.Where(e => e.EmployeeId == 147).Select(e => e.Project).OrderBy(x => x.Name).ToList();
            StringBuilder result = new StringBuilder();

            result.AppendLine($"{emp.FirstName} {emp.LastName} - {emp.JobTitle}");

            foreach (var p in employeeProjects)
            {
                result.AppendLine(p.Name);
            }
            return result.ToString().TrimEnd();
        }
        public static string GetDepartmentsWithMoreThan5Employees(SoftUniContext context)
        {
            var departments = context.Departments
                .Where(d => d.Employees.Count > 5)
                .Select(d => new
                {
                    d.Name,
                    ManagerFirstName = d.Manager.FirstName,
                    ManagerLastName = d.Manager.LastName,
                    Employees = d.Employees
                        .OrderBy(e => e.FirstName)
                        .ThenBy(e => e.LastName)
                        .Select(e => new
                        {
                            e.FirstName,
                            e.LastName,
                            e.JobTitle
                        }).ToList()
                })
                .OrderBy(d => d.Employees.Count)
                .ThenBy(d => d.Name)
                .ToList();

            StringBuilder result = new StringBuilder();

            foreach (var department in departments)
            {
                result.AppendLine($"{department.Name} - {department.ManagerFirstName} {department.ManagerLastName}");

                foreach (var employee in department.Employees)
                {
                    result.AppendLine($"{employee.FirstName} {employee.LastName} - {employee.JobTitle}");
                }
            }

            return result.ToString().TrimEnd();
        }
        public static string GetLatestProjects(SoftUniContext context)
        {
            var projects = context.Projects.OrderByDescending(p => p.StartDate).Take(10).Select(p => new
            {
                p.Name,
                p.Description,
                p.StartDate
            }).OrderBy(p => p.Name).ToList();

            StringBuilder result = new StringBuilder();

            foreach (var p in projects)
            {
                result.AppendLine(p.Name);
                result.AppendLine(p.Description);
                result.AppendLine(p.StartDate.ToString("M/d/yyyy h:mm:ss tt"));
            }
            return result.ToString().TrimEnd();
        }
        public static string IncreaseSalaries(SoftUniContext context)
        {
            var increaseSalary = context.Employees.Where(e => e.Department.Name == "Engineering" ||
                                                              e.Department.Name == "Tool Design" ||
                                                              e.Department.Name == "Marketing" ||
                                                              e.Department.Name == "Information Services")
                .Select(e => new
                {
                    e.FirstName,
                    e.LastName,
                    Salary = (double)e.Salary * 1.12
                })
                .OrderBy(e => e.FirstName)
                .ThenBy(e => e.LastName).ToList();
            context.SaveChanges();

            StringBuilder result = new StringBuilder();

            foreach (var e in increaseSalary)
            {
                result.AppendLine($"{e.FirstName} {e.LastName} (${e.Salary:f2})");
            }

            return result.ToString().TrimEnd();
        }
        public static string GetEmployeesByFirstNameStartingWithSa(SoftUniContext context)
        {
            var info = context.Employees.Where(e => e.FirstName.ToLower().StartsWith("sa")).Select(e => new
            {
                e.FirstName,
                e.LastName,
                e.JobTitle,
                Salary = $"{e.Salary:f2}"
            }).OrderBy(e=>e.FirstName).ThenBy(e=>e.LastName).ToList();

           var result = new StringBuilder();

           foreach (var e in info)
           {
               result.AppendLine($"{e.FirstName} {e.LastName} - {e.JobTitle} - (${e.Salary})");
           }

           return result.ToString().TrimEnd();
        }
        public static string DeleteProjectById(SoftUniContext context)
        {
            var employeeProjects = context.EmployeesProjects
                .Where(ep => ep.ProjectId == 2)
                .ToList();

            if (employeeProjects.Any())
            {
                context.EmployeesProjects.RemoveRange(employeeProjects);
            }

            var projectToDelete = context.Projects.Find(2);
            if (projectToDelete != null)
            {
                context.Projects.Remove(projectToDelete);
                context.SaveChanges();
            }

            var projectsNames = context.Projects
                .Take(10)
                .Select(p => p.Name)
                .ToList();

            var sb = new StringBuilder();
            foreach (var name in projectsNames)
            {
                sb.AppendLine($"{name}");
            }

            return sb.ToString().TrimEnd();
        }
        public static string RemoveTown(SoftUniContext context)
        {
            var cityEmployees = context.Employees.Where(e => e.Address.Town.Name == "Seattle").ToList();
            foreach (var e in cityEmployees)
            {
                e.Address = null;
            }

            context.SaveChanges();

            var cityAddresses = context.Addresses.Where(e => e.Town.Name == "Seattle").ToList();
            int count = cityAddresses.Count;

            if (cityAddresses.Any())
            {
                context.Addresses.RemoveRange(cityAddresses);
            }
            context.SaveChanges();
            Town town = context.Towns.FirstOrDefault(e => e.Name == "Seattle");
            context.Towns.Remove(town);
            context.SaveChanges();

            StringBuilder result = new StringBuilder();

            result.AppendLine($"{count} addresses in Seattle were deleted");
            return result.ToString().TrimEnd();
        }
    }
}
