using System;
using System.Collections.Generic;

namespace Statement
{
    class Program
    {
        public static List<Employee> employees;
        public static Stack<Employee> employeeStack;
        static void Main(string[] args)
        {
            employees = new List<Employee>();
            employeeStack = new Stack<Employee>();
            employees.Add(new Employee("Rudi Hartono", "Web Developer"));
            employees.Add(new Employee("Ade Rifaldi", "Android Developer"));

            employeeStack.Push(new Employee("Hegi Tri Saputra", "Web Developer"));
            employeeStack.Push(new Employee("Arik", "Android Developer"));

            Console.WriteLine($"Total employee : {employees.Count}");

            foreach(var employee in employees){
                Console.WriteLine($"Name: {employee.Name}");
                Console.WriteLine($"Position: {employee.Role}");
            }

            foreach(var item in employeeStack){
                Console.WriteLine($"Name: {item.Name}");
                Console.WriteLine($"Position: {item.Role}");
            }
   
            Console.WriteLine($"Total employee : {employeeStack.Count}");
            
            Employee arik = employeeStack.Pop();

            if(arik.Name.Equals("Arik", StringComparison.OrdinalIgnoreCase)){
                Console.WriteLine($"Arik has been removed from stack");
            }

            Console.WriteLine($"Total employee : {employeeStack.Count}");

        }
    }
}
