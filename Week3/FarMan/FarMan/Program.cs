using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;

namespace FarMan
{
    class FarManager                                                  //создаем новый класс
    {
        public int cursor;
        public int size;
        public bool ok;

        public FarManager()
        {
            cursor = 0;
            ok = true;
        }

        public void Delete(FileSystemInfo fs)                                   // функция для удаления
        {
            if (fs.GetType() == typeof(DirectoryInfo))
                Directory.Delete(fs.FullName, true);                      //удаляем папку даже если она содержит что-либо
            else
            {
                FileInfo file = new FileInfo(fs.FullName);                      //удаляем файл
                fs.Delete();
            }
        }

        public void TextFile(string path)                                       //для чтения тектовых файлов 
        {
            Console.Clear();                                                    //очистить консоль
            StreamReader sr = new StreamReader(path);
            string s = sr.ReadToEnd();                                          //read all
            Console.WriteLine(s);                                               //пишем в консоле
            ConsoleKeyInfo k = Console.ReadKey();
            if (k.Key == ConsoleKey.Escape)                                     //ESC, чтобы закрыть текстовый фаул
            {
                sr.Close();
                return;
            }
            else
                TextFile(path);                                //иначе показать текстовый файл
        }

        public void Up()                                        //курсор вверх- кнопка ввверх
        {
            cursor--;
            if (cursor < 0)
                cursor = size - 1;
        }

        public void Down()                                 //курсор вниз - кнопка вниз
        {
            cursor++;
            if (cursor == size)
                cursor = 0;
        }

        public void Color(FileSystemInfo file, int index)            //создаем функцию,которая менят цвета
        {
            if (index == cursor)
                Console.BackgroundColor = ConsoleColor.Red;
            else if (file.GetType() == typeof(DirectoryInfo))
            {
                Console.ForegroundColor = ConsoleColor.White;
                Console.BackgroundColor = ConsoleColor.Black;
            }
            else
            {
                Console.ForegroundColor = ConsoleColor.Yellow;
                Console.BackgroundColor = ConsoleColor.Black;
            }
        }

        public void Show(string path)                         //создаем функцию, которая показывает файлы
        {
            DirectoryInfo directory = new DirectoryInfo(path);
            FileSystemInfo[] files = directory.GetFileSystemInfos();
            size = files.Length;
            int index = 0;
            foreach (FileSystemInfo fs in files)
            {
                Color(fs, index);
                Console.WriteLine(index + 1 + ". " + fs.Name);
                index++;
            }
        }

        public void Start(string path)
        {

            ConsoleKeyInfo consoleKey = Console.ReadKey();
            FileSystemInfo fs = null;
            while (consoleKey.Key != ConsoleKey.Spacebar)                      //работает до тех пор пока не нажмем на Space
            {
                DirectoryInfo directory = new DirectoryInfo(path);
                Console.BackgroundColor = ConsoleColor.Black;
                Console.Clear();
                Show(path);                                              //вызываем функцию Show
                if (size != 0)
                {
                    consoleKey = Console.ReadKey();
                    fs = directory.GetFileSystemInfos()[cursor];          //файл на который указан курсор
                    if (consoleKey.Key == ConsoleKey.Enter)
                    {
                        if (fs.GetType() == typeof(DirectoryInfo))
                        {
                            cursor = 0;
                            path = fs.FullName;
                        }
                        else if (fs.Name.EndsWith(".txt"))
                            TextFile(fs.FullName);

                    }
                    else if (consoleKey.Key == ConsoleKey.Escape)
                    {
                        directory = directory.Parent;
                        path = directory.FullName;
                        cursor = 0;
                    }
                    else if (consoleKey.Key == ConsoleKey.Delete)
                    {

                        Delete(fs);
                        FileSystemInfo[] files = directory.GetFileSystemInfos();
                        size = files.Length;
                        cursor = 0;
                    }
                    else if (consoleKey.Key == ConsoleKey.S)
                    {
                        Console.Clear();
                        Console.BackgroundColor = ConsoleColor.Black;
                        string s = Console.ReadLine();
                        ConsoleKeyInfo k = Console.ReadKey();
                        s = Path.Combine(directory.FullName, s);
                        if (fs.GetType() == typeof(DirectoryInfo))
                            Directory.Move(fs.FullName, s);
                        else
                            File.Move(fs.FullName, s);             //чтобы переименовать была использована функция move
                    }
                    else if (consoleKey.Key == ConsoleKey.UpArrow)
                        Up();
                    else if (consoleKey.Key == ConsoleKey.DownArrow)
                        Down();
                }
                else
                {
                    consoleKey = Console.ReadKey();
                    if (consoleKey.Key == ConsoleKey.Escape)
                    {
                        directory = directory.Parent;// выходит из папки
                        path = directory.FullName;
                        cursor = 0;
                    }

                }
            }
        }
    }

    class Program
    {
        static void Main(string[] args)
        {
            FarManager farManager = new FarManager();
            farManager.Start(@"C:\Users\Айшат\Desktop\PP2");
        }
    }
}
