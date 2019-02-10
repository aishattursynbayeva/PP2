using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;

namespace Task4
{
    class Program
    {
        static void Main(string[] args)
        {
            string name = "aaa.txt"; 
            string path = @"C:\Users\Айшат\Desktop\PP2";
            string path1 = @"C:/Users/Айшат/Desktop/PP2/Week2";
            path=Path.Combine(path, name);//скомбинируем пути
            FileStream fs = File.Create(path);// создаем файл
            fs.Close();//остановим работу файла, чтобы скопировать и удалить его
            path1 = Path.Combine(path1, name);//скомбинируем путь, куда мы должны скопировать
            File.Copy(path, path1);//скопируем файл
            File.Delete(path);//удаляем оригинал
        }
    }
}
