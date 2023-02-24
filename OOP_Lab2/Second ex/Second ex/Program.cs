using System;
using System.Collections.Generic;
using System.Linq;
using System.Data.SqlClient;

namespace OOP_Lab2
{
    class Program
    {
        static void Main(string[] args)
        {
            
            string connectionString = "Server=localhost;Database=EmployeesDB;Trusted_Connection=True;";
            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                connection.Open();
                string query = "SELECT * FROM Employees";
                SqlCommand command = new SqlCommand(query, connection);
                SqlDataReader reader = command.ExecuteReader();

                
                List<Employee> employees = new List<Employee>();
                while (reader.Read())
                {
                    int id = (int)reader["Id"];
                    string name = (string)reader["Name"];
                    int age = (int)reader["Age"];
                    double salary = (double)reader["Salary"];
                    int experience = (int)reader["Experience"];
                    Employee employee = new Employee(id, name, age, salary, experience);
                    employees.Add(employee);
                }

                
                List<Employee> sortedEmployees = employees.OrderByDescending(e => e.Salary).ToList();

                
                Console.WriteLine("Список співробітників, відсортований за зарплатою:");
                foreach (Employee employee in sortedEmployees)
                {
                    Console.WriteLine(employee.ToString());
                }
            }
        }
    }

    class Employee
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public int Age { get; set; }
        public double Salary { get; set; }
        public int Experience { get; set; }

        public Employee(int id, string name, int age, double salary, int experience)
        {
            Id = id;
            Name = name;
            Age = age;
            Salary = salary;
            Experience = experience;
        }

        public override string ToString()
        {
            return $"Id: {Id}, Name: {Name}, Salary: {Salary}";
        }
    }
}
