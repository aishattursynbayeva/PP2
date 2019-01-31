using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Task2
{
    class Student
    {
        string name;
        string id;
        int Year = 1;

        public Student(string name, string id)
        {
            this.name = name;
            this.id = id;
        }
        public void NewYear()
        {
            while (Year <= 4)
            {
                Console.WriteLine(name + " " + id + " " + Year);
                Year++;
            }
        }
    }

    class Program
    {
            static void Main(string[] args)
            {
                Student s1 = new Student("Aishat Tursynbayeva", "18BD555555");
                s1.NewYear();
            }
        }
    }

