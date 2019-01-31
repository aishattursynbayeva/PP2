﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Task1
{
    class Program
    {
        static void Main(string[] args)
        {
            int n = int.Parse(Console.ReadLine());//создав новую переменную, считываем ее со строки и превращаем ее в целое число
            int[] arr = new int[n];//создаю новый массив целых чисел
            string[] array = Console.ReadLine().Split();//считываем каждый элемент строки, как отдельный член массива
            for (int i=0; i<n; i++)//пробегаемся по массиву
            {
                arr[i] = int.Parse(array[i]);//превращаем каждый элемент массива со string в integer
            }
            int prime = 0;//создаем новую переменную, чтобы посчитать количество простых чисел
            for(int i=0; i<n; i++)
            {
                int k = 0;//создаем новую переменную, чтобы посчитать количество делителей числа
                for(int j=1; j<=arr[i]; j++)//пробегаемся от 1 до самого числа, чтобы найти делителей данного числа
                {
                    if (arr[i] % j == 0)
                    {
                        k++;
                    }//если число делится без остатков, то увеличиваем переменную k на 1
                }
                if (k == 2)
                {
                    prime++;
                }//если количество делителей равно 2, то число является простым, поэтому увеличиваем переменную prime на 1
            }
            Console.WriteLine(prime);//выводим общее количество простых чисел
            for (int i = 0; i < n; i++)
            {
                int k = 0;//создаем новую переменную, чтобы посчитать количество делителей числа
                for (int j = 1; j <= arr[i]; j++)//пробегаемся от 1 до самого числа, чтобы найти делителей данного числа
                {
                    if (arr[i] % j == 0)
                    {
                        k++;
                    }//если число делится без остатков, то увеличиваем переменную k на 1
                }
                if (k == 2)
                {
                    Console.Write(arr[i] + " ");
                }//если количество делителей равно 2, то число является простым и выводим это число
            }
        }
    }
}