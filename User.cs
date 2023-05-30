using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace UCL_Programmering_Eksamen
{
    internal class User
    {
        private string _name;
        private int _employeeNumber;
        public string Name { get { return _name; } }
        public int Number { get { return _employeeNumber; } }


        public User(string name, int employeeNumber)
        {
            _name = name;
            _employeeNumber = employeeNumber;
        }

        public void Edit(string newName)
        {
            //ifAuth do
            _name= newName;
        }
        public void Edit(int newNum)
        {
            //ifAuth do
            _employeeNumber= newNum;
        }
        public void Delete() { }    // find by ID and delete in DB
        public override string ToString()
        {
            return $"User: {Name} \nNumber: {Number}";
        }

    }
}
