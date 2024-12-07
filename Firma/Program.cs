using System;
using System.Collections.Generic;
using System.Linq;

namespace Firma
{
    class Company
    {
        public string Name { get; set; }
        public DateTime Birthday { get; set; }
        public string BisinessProfile { get; set; }
        public string Direktor { get; set; }
        public int Employee_numbers { get; set; }
        public string Adress { get; set; }
        public List<Employee> Employees { get; set; } = new List<Employee>();
        public override string ToString()
        {
            return $"Name: {Name}\n" +
                   $"Birthday: {Birthday.ToShortDateString()}\n" +
                   $"Business Profile: {BisinessProfile}\n" +
                   $"Director: {Direktor}\n" +
                   $"Employees: {Employee_numbers}\n" +
                   $"Address: {Adress}\n";
        }
    }
    class Employee
    {
        public string FullName { get; set; }
        public string Position { get; set; }
        public string Phone { get; set; }
        public string Email { get; set; }
        public decimal Salary { get; set; }
        public override string ToString()
        {
            return $"Name: {FullName}, Position: {Position}, Phone: {Phone}, Email: {Email}, Salary: {Salary}";
        }
    }
    internal class Program
    {
        static void Main(string[] args)
        {
            List<Company> companies = new List<Company>
            {
                new Company
                {
                    Name = "IT Big Ben",
                    Birthday = new DateTime(2007, 5, 18),
                    BisinessProfile = "IT",
                    Direktor = "White",
                    Employee_numbers = 200,
                    Adress = "London",
                    Employees = new List<Employee>
                    {
                        new Employee { FullName = "John Doe", Position = "Manager", Phone = "2312345678", Email = "john@bigben.com", Salary = 5000 },
                        new Employee { FullName = "Jane Smith", Position = "Developer", Phone = "2456781234", Email = "jane@bigben.com", Salary = 4500 }
                    }
                },
                new Company
                {
                    Name = "Food England",
                    Birthday = new DateTime(2023, 8, 12),
                    BisinessProfile = "Food Delivery",
                    Direktor = "Petrov",
                    Employee_numbers = 4000,
                    Adress = "London"
                },
                new Company
                {
                    Name = "Blue Apple",
                    Birthday = new DateTime(2018, 1, 10),
                    BisinessProfile = "Marketing",
                    Direktor = "White",
                    Employee_numbers = 450,
                    Adress = "New York",
                    Employees = new List<Employee>
                    {
                        new Employee { FullName = "Lionel Messi", Position = "Analyst", Phone = "2345671234", Email = "lionel@blueapple.com", Salary = 6000 }
                    }
                },
                new Company
                {
                    Name = "Grey Flower",
                    Birthday = new DateTime(2024, 10, 17),
                    BisinessProfile = "Marketing",
                    Direktor = "Ivanov",
                    Employee_numbers = 150,
                    Adress = "New York"
                },
                new Company
                {
                    Name = "IT players",
                    Birthday = new DateTime(2024, 9, 28),
                    BisinessProfile = "IT",
                    Direktor = "Henry",
                    Employee_numbers = 250,
                    Adress = "Paris"
                }
            };
            Console.WriteLine("Все фирмы:");
            companies.ToList().ForEach(company => Console.WriteLine(company));
            Console.WriteLine("\nФирмы со словом Food в названии:");
            companies.Where(q => q.Name.Contains("Food")).ToList()
                     .ForEach(company => Console.WriteLine(company));
            Console.WriteLine("\nМаркетинговые фирмы:");
            companies.Where(q => q.BisinessProfile == "Marketing").ToList()
                     .ForEach(company => Console.WriteLine(company));
            Console.WriteLine("\nМаркетинговые и IT фирмы:");
            companies.Where(q => q.BisinessProfile == "Marketing" || q.BisinessProfile == "IT").ToList()
                     .ForEach(company => Console.WriteLine(company));
            Console.WriteLine("\nФирмы с количеством сотрудников больше 100:");
            companies.Where(q => q.Employee_numbers > 100).ToList()
                     .ForEach(company => Console.WriteLine(company));
            Console.WriteLine("\nФирмы с количеством сотрудников от 100 до 300:");
            companies.Where(q => q.Employee_numbers >= 100 && q.Employee_numbers <= 300).ToList()
                     .ForEach(company => Console.WriteLine(company));
            Console.WriteLine("\nФирмы из Лондона:");
            companies.Where(q => q.Adress == "London").ToList()
                     .ForEach(company => Console.WriteLine(company));
            Console.WriteLine("\nФирмы с директором White:");
            companies.Where(q => q.Direktor == "White").ToList()
                     .ForEach(company => Console.WriteLine(company));
            Console.WriteLine("\nФирмы которым больше двух лет:");
            companies.Where(q => (DateTime.Now - q.Birthday).TotalDays > 2 * 365).ToList()
                     .ForEach(company => Console.WriteLine(company));
            Console.WriteLine("\nФирмы которым больше или ровно 123 дня:");
            companies.Where(q => (DateTime.Now - q.Birthday).TotalDays >= 123).ToList()
                     .ForEach(company => Console.WriteLine(company));
            Console.WriteLine("\nСотрудники компании IT Big Ben:");
            companies.First(c => c.Name == "IT Big Ben").Employees
                     .ForEach(employee => Console.WriteLine(employee));
            Console.WriteLine("\nСотрудники с зарплатой больше 4000:");
            companies.SelectMany(c => c.Employees).Where(e => e.Salary > 4000).ToList()
                     .ForEach(employee => Console.WriteLine(employee));
            Console.WriteLine("\nСотрудники с должностью менеджер:");
            companies.SelectMany(c => c.Employees).Where(e => e.Position.Contains("Manager")).ToList()
                     .ForEach(employee => Console.WriteLine(employee));
            Console.WriteLine("\nСотрудники с телефоном, начинающимся на 23:");
            companies.SelectMany(c => c.Employees).Where(e => e.Phone.StartsWith("23")).ToList()
                     .ForEach(employee => Console.WriteLine(employee));
            Console.WriteLine("\nСотрудники с Email, начинающимся на 'di':");
            companies.SelectMany(c => c.Employees).Where(e => e.Email.StartsWith("di")).ToList()
                     .ForEach(employee => Console.WriteLine(employee));
            Console.WriteLine("\nСотрудники с именем Lionel:");
            companies.SelectMany(c => c.Employees).Where(e => e.FullName.Contains("Lionel")).ToList()
                     .ForEach(employee => Console.WriteLine(employee));
        }
    }
}

