using System;
using System.Threading;

class Program
{
    static volatile bool stopThreads = false;

    static void Main(string[] args)
    {
        Console.WriteLine("Введите верхнюю границу: ");
        int upperBound = int.Parse(Console.ReadLine());

       
        Thread thread1 = new Thread(() =>
        {
            for (int i = 2; i <= upperBound && !stopThreads; i += 2)
            {
                Console.WriteLine($"Четное число: {i}");
                Thread.Sleep(500); 
            }
        });

        
        Thread thread2 = new Thread(() =>
        {
            int a = 0, b = 1;
            while (a <= upperBound && !stopThreads)
            {
                Console.WriteLine($"Число Фибоначчи: {a}");
                int temp = a;
                a = b;
                b = temp + b;
                Thread.Sleep(500); 
            }
        });

      
        Thread thread3 = new Thread(() =>
        {
            int powerOfTwo = 1;
            while (powerOfTwo <= upperBound && !stopThreads)
            {
                Console.WriteLine($"Степень двойки: {powerOfTwo}");
                powerOfTwo *= 2;
                Thread.Sleep(500);
            }
        });

       
        Thread thread4 = new Thread(() =>
        {
            string stars = "*";
            while (!stopThreads)
            {
                Console.WriteLine(stars);
                stars += "*";
                Thread.Sleep(500); 
            }
        });

       
        thread1.Start();
        thread2.Start();
        thread3.Start();
        thread4.Start();

        Console.ReadKey(); 
        stopThreads = true; 
    }
}
