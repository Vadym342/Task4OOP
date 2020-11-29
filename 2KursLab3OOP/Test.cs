using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _2KursLab3OOP
{
   public class Test
    {
        public string Name_Spec { get; set; }
        public bool Skill { get; set; }
       
        public Test(string Name, bool skill)
        {
            this.Name_Spec = Name;
            this.Skill = skill; 
        }
        public Test()
        {
            Name_Spec = "Programmer";
            Skill = true;
        }
        public override string ToString()
        {
            return $"Name spec: {Name_Spec}Skill:{Skill}";
        }

        public virtual string ToShortString()
        {
            return $"Name spec: {Name_Spec}Skill:{Skill}";
        }

    }

}
