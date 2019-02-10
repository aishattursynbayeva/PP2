using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;

namespace Task1
{
    class Program
    {
        //создаем функцию, которая проверяет строку на палиндром
        public static bool Ex(string s)
        { 
            for(int i=0; i<s.Length/2; i++)
            {
                if (s[i] != s[s.Length-i-1])
                {
                    return false;
                }
            }
            return true;
        }

        //создаем функцию, которая читает строку из файла
        public static string Ex1()
        {
            StreamReader sr = new StreamReader("input.txt");
            string s = sr.ReadToEnd();
            sr.Close();
            return s;
        }

        static void Main(string[] args)
        {
            string s = Ex1();
            //выводим ответ в другом файле
            StreamWriter sw = new StreamWriter("output.txt");
            if (Ex(s) == true)
            {
                sw.WriteLine("YES");
            }
            else
            {
                sw.WriteLine("NO");
            }
            sw.Close();
        }
    }
}
