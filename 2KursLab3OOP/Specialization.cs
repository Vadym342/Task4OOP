using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _2KursLab3OOP
{
   public class Specialization:IDateAndCopy
    {
        public string Name_Spec { get; set; }
        public int Code { get; set; }
        public DateTime EndDate { get; set; }
        public DateTime Date { get => throw new NotImplementedException(); set => throw new NotImplementedException(); }

        public Specialization()
        {
            this.Name_Spec = "Proger";
            this.Code = 123;
            this.EndDate = new DateTime(2222, 6, 6);
        }
        public Specialization(string name_spec, int code, DateTime enddate)
        {
            this.Name_Spec = name_spec;
            this.Code = code;
            this.EndDate = enddate;
        }
        public override string ToString()
        {
            return $"{ToShortString()} End-day: {EndDate.ToShortDateString()}\n";
        }

        public string ToShortString()
        {
            return $"{Name_Spec} {Code}";
        }

        public object DeepCopy()
        {
            Person other = (Person)this.MemberwiseClone();
            other.Name = String.Copy(Name_Spec);
            return other;
        }
    }
}
