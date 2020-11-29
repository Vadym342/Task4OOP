using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _2KursLab3OOP
{
    class Program
    {
        public static object Random { get; internal set; }

        static void Main(string[] args)
        {
            var people = new People();

            //Console.WriteLine(people.ToString());
            //Console.WriteLine("########################################################");
            Console.WriteLine(people.ToShortString());
            Console.WriteLine($"MasterStudent: {people[Science.MasterStudent]}");
            Console.WriteLine($"PhDstudent: {people[Science.PhDAssistantProfessor]}");
            Console.WriteLine($"PhDAssistantProfessor: {people[Science.PhDstudent]}");

            people.AddSpecializator(new Specialization("Programmer", 123, new DateTime(2222, 3, 3)));
            Console.WriteLine(people);
            TestArray.RunArrayComparisons();
        }
       
           
        
    }
}
