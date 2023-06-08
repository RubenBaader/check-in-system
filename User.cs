using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace UCL_Programmering_Eksamen
{
    internal class User
    {
        //private string Name;
        private int _employeeNumber;
        public string Name { get; set; }
        public int Number { get; set; }


        public User(string name, int employeeNumber)
        {
            Name = name;
            _employeeNumber = employeeNumber;
        }
        public User()
        {
            Name = "JohnnyNoName";
            _employeeNumber = -1;
        }

        public void Edit(string input)
        {
            Name= input;
        }
        public void Edit(int input)
        {
            _employeeNumber= input;
        }
        // public void Delete() { }    <= find by ID and delete in list, then DB
        public override string ToString()
        {
            return $"User: {Name} \n" +
                   $"Number: {Number}";
        }
    }
}
