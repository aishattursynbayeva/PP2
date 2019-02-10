using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;

namespace Task3
{
    class Program
    {
        //создаем функцию, которая оставляет пробелы между уровнями папок
        public static void probel(int num)
        {
            for (int i = 0; i < num; i++)
            {
                Console.Write("    ");
            }
        }
        //создаем рекурсивную функцию, которая выводит названия файлов и папок и все содержимое в папке
        public static void Ex(DirectoryInfo dir, int a)
        {
            foreach(FileInfo f in dir.GetFiles())
            {
                probel(a);
                Console.WriteLine(f.Name);
            }
            foreach(DirectoryInfo d in dir.GetDirectories())
            {
                probel(a);
                Console.WriteLine(d.Name);
                Ex(d, a + 1);
            }
        }     

        static void Main(string[] args)
        {
            DirectoryInfo dir = new DirectoryInfo("C:/Users/Айшат/Desktop/PP2");
            //вызовем функцию
            Ex(dir, 0);
        }
    }
}
