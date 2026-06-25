using Microsoft.SemanticKernel;
using System.ComponentModel;
using System.Text;

namespace SementicAI
{
    public class Employee
    {
        public string Name { get; set; } = string.Empty;
        public int Age { get; set; }
        public string Address { get; set; } = string.Empty;
        public string Department { get; set; } = string.Empty;
        public string Position { get; set; } = string.Empty;
        public string Email { get; set; } = string.Empty;
        public double Salary { get; set; }

        private static readonly List<Employee> Employees =
        [
            new() { Name = "Alice Johnson",  Age = 32, Address = "123 Main St, New York",    Department = "Engineering", Position = "Senior Developer",    Email = "alice.johnson@company.com",  Salary = 95000 },
            new() { Name = "Bob Smith",      Age = 45, Address = "456 Oak Ave, Los Angeles", Department = "Marketing",   Position = "Marketing Manager",   Email = "bob.smith@company.com",      Salary = 85000 },
            new() { Name = "Carol White",    Age = 28, Address = "789 Pine Rd, Chicago",     Department = "HR",          Position = "HR Specialist",        Email = "carol.white@company.com",    Salary = 65000 },
            new() { Name = "David Brown",    Age = 38, Address = "321 Elm St, Houston",      Department = "Engineering", Position = "DevOps Engineer",      Email = "david.brown@company.com",    Salary = 90000 },
            new() { Name = "Eva Martinez",   Age = 35, Address = "654 Maple Dr, Phoenix",    Department = "Finance",     Position = "Financial Analyst",    Email = "eva.martinez@company.com",   Salary = 80000 },
        ];

        [KernelFunction, Description("Gets the list of all employees with their details")]
        public string GetAllEmployees()
        {
            var sb = new StringBuilder();
            foreach (var emp in Employees)
                sb.AppendLine($"Name: {emp.Name}, Age: {emp.Age}, Department: {emp.Department}, Position: {emp.Position}, Email: {emp.Email}");
            return sb.ToString();
        }

        [KernelFunction, Description("Gets the full details of a specific employee by their name")]
        public string GetEmployeeByName([Description("The full or partial name of the employee")] string name)
        {
            var emp = Employees.FirstOrDefault(e => e.Name.Contains(name, StringComparison.OrdinalIgnoreCase));
            if (emp is null)
                return $"No employee found with name '{name}'.";
            return $"Name: {emp.Name}, Age: {emp.Age}, Address: {emp.Address}, Department: {emp.Department}, Position: {emp.Position}, Email: {emp.Email}, Salary: ${emp.Salary:N0}";
        }

        [KernelFunction, Description("Gets all employees belonging to a specific department")]
        public string GetEmployeesByDepartment([Description("The department name, e.g. Engineering, HR, Finance, Marketing")] string department)
        {
            var list = Employees.Where(e => e.Department.Contains(department, StringComparison.OrdinalIgnoreCase)).ToList();
            if (list.Count == 0)
                return $"No employees found in department '{department}'.";
            var sb = new StringBuilder();
            foreach (var emp in list)
                sb.AppendLine($"Name: {emp.Name}, Position: {emp.Position}, Email: {emp.Email}");
            return sb.ToString();
        }

        [KernelFunction, Description("Gets the total number of employees")]
        public int GetEmployeeCount() => Employees.Count;
    }
}
