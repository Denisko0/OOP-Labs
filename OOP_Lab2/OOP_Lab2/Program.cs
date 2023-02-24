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
            
            string connectionString = "Server=localhost;Database=StudentsDB;Trusted_Connection=True;";
            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                connection.Open();

                string query = "SELECT * FROM Students";
                SqlCommand command = new SqlCommand(query, connection);
                SqlDataReader reader = command.ExecuteReader();

                List<Student> students = new List<Student>();
                while (reader.Read())
                {
                    int id = (int)reader["Id"];
                    string name = (string)reader["Name"];
                    int grade1 = (int)reader["Grade1"];
                    int grade2 = (int)reader["Grade2"];
                    int grade3 = (int)reader["Grade3"];
                    Student student = new Student(id, name, grade1, grade2, grade3);
                    students.Add(student);
                }

                
                List<Student> filteredStudents = students.Where(s => s.AverageGrade() > 80).ToList();

                
                Console.WriteLine("Список студентів з середнім балом більше 80:");
                foreach (Student student in filteredStudents)
                {
                    Console.WriteLine(student.ToString());
                }
            }
        }
    }

    class Student
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public int Grade1 { get; set; }
        public int Grade2 { get; set; }
        public int Grade3 { get; set; }

        public Student(int id, string name, int grade1, int grade2, int grade3)
        {
            Id = id;
            Name = name;
            Grade1 = grade1;
            Grade2 = grade2;
            Grade3 = grade3;
        }

        public double AverageGrade()
        {
            return (Grade1 + Grade2 + Grade3) / 3.0;
        }

        public override string ToString()
        {
            return $"Id: {Id}, Name: {Name}, Average Grade: {AverageGrade()}";
        }
    }
}

