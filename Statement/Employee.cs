using System;

namespace Statement
{
    public class Employee{
        public Employee(string name, string role)
        {
            Name = name;
            Role = role;
        }
        public string Name {get;set;}
        public string Role {get;set;}
    }
}
