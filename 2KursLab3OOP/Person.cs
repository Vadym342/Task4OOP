using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _2KursLab3OOP
{
    public class Person
    {
        private string _Name;
        private string _Surname;
        private DateTime _Date;
        public Person()
        {
            _Name = "Vasyan";
            _Surname = "Surname";
            _Date = new DateTime(2000, 6, 1);
        }
        public Person(string name, string surname, DateTime date)
        {
          _Name = name;
          _Surname = surname;
          _Date = date;
        }
        public string Name
        {
            get { return _Name; }
            set { _Name = value; }
        }
        public string Surname
        {
            get { return _Surname; }
            set { _Surname = value; }
        }
        public int BirthYear
        {
            get { return BirthDate.Year; }
            set { BirthDate = new DateTime(value, BirthDate.Month, BirthDate.Day); }
        }
        public DateTime BirthDate
        {
            get { return _Date; }
            set { _Date = value; }
        }

        public override string ToString()
        {
            return $"{ToShortString()} B-day: {BirthDate.ToShortDateString()}\n";
        }
        public string ToShortString()
        {
            return $"{_Name} {_Surname}";
        }



    }
}
