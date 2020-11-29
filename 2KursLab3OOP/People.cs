using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using System.Threading.Tasks;

namespace _2KursLab3OOP
{
   public class People :Person,IDateAndCopy
    {
        private Person _Person;
        private Science _Science;
        private int _Code_Spec;
         private List<Specialization> _specializations;
        private System.Collections.ArrayList arr = new System.Collections.ArrayList();
        
        public DateTime Date { get => throw new NotImplementedException(); set => throw new NotImplementedException(); }

        public People(Person person, Science science, int code_spec)
        {
            _Person = person;
            _Science = science;
            _Code_Spec = code_spec;
            _specializations = new List<Specialization>();

        }
        public People()
        {
            _Person = new Person("Bla","Blablabla", new DateTime(2000,1,1));
            _Science = Science.MasterStudent;
            _Code_Spec = 123123;
            _specializations = new List<Specialization>();
        }

        public double Rating()
        {
            Random rnd = new Random();
            int rating = rnd.Next(0, 100);
            if (_specializations.Count > 0)
            {
                return _specializations.Average(x => x.Code = rating);
            }
            else return 0;
        }

        public bool this[Science science] => science==_Science;

        public void AddSpecializator(params Specialization[] specialization)
        {
            _specializations.AddRange(specialization.ToList());
        }
        public override string ToString()
        {
            return $"{_Person}Science:{_Science} (Code: {_Code_Spec}) Rating: {Rating()}: - Specialization:\n {string.Join("\n\n", _specializations)}";
        }

        public virtual string ToShortString()
        {
            return $"{_Person}Science:{_Science} (Code: {_Code_Spec}) Rating: {Rating()}:  rating 1-100";
        }



        public object DeepCopy()
        {
            Person other = (Person)this.MemberwiseClone();
            other.Name = String.Copy(Name);
            other.Surname = String.Copy(Surname);
            return other;
        }
    }
}
