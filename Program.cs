﻿using System;
using System.Text;
using System.Numerics;
using System.Collections.Generic;
using System.Linq;

partial class Program
{
    static void DoBlock_1()
    {
        // Введення дробів користувачем
        Console.WriteLine("Введіть чисельник та знаменник для першого дробу (через пробіл):");
        string[] input1 = Console.ReadLine().Split();
        long nom1 = long.Parse(input1[0]);
        long denom1 = long.Parse(input1[1]);

        Console.WriteLine("Введіть чисельник та знаменник для другого дробу (через пробіл):");
        string[] input2 = Console.ReadLine().Split();
        long nom2 = long.Parse(input2[0]);
        long denom2 = long.Parse(input2[1]);

        // Створення дробів
        MyFrac frac1 = new MyFrac(nom1, denom1);
        MyFrac frac2 = new MyFrac(nom2, denom2);

        Console.WriteLine("Перший дріб: " + frac1);
        Console.WriteLine("Другий дріб: " + frac2);

        // Виконання арифметичних операцій
        MyFrac sum = Plus(frac1, frac2);
        MyFrac difference = Minus(frac1, frac2);
        MyFrac product = Multiply(frac1, frac2);
        MyFrac quotient = Divide(frac1, frac2);

        // Виведення результатів
        Console.WriteLine("Сума: " + sum);
        Console.WriteLine("Різниця: " + difference);
        Console.WriteLine("Добуток: " + product);
        Console.WriteLine("Частка: " + quotient);

        Console.WriteLine("Подання з цілою частиною дроба 1: " + ToStringWithIntPart(frac1));
        Console.WriteLine("Дійсне значення дроба 1: " + DoubleValue(frac1));
        Console.WriteLine("Подання з цілою частиною дроба 2: " + ToStringWithIntPart(frac2));
        Console.WriteLine("Дійсне значення дроба 2: " + DoubleValue(frac2));

        Console.WriteLine("Введіть n:");
        int n = Convert.ToInt32(Console.ReadLine());
        Console.WriteLine("Результат CalcExpr1(5): " + CalcExpr1(n));
        Console.WriteLine("Результат CalcExpr2(5): " + CalcExpr2(n));
        Console.WriteLine();
    }
    // Метод для перетворення дробу у строкове представлення з виділеною цілою частиною
    static string ToStringWithIntPart(MyFrac f)
    {
        long intPart = f.nom / f.denom;
        long remainder = f.nom % f.denom;
        char symbol = intPart >= 0 ? '+' : '-';

        if (remainder == 0)
        {
            return $"{symbol}({Math.Abs(intPart)})";
        }
        else
        {
            return $"{symbol}({Math.Abs(intPart)} + {Math.Abs(remainder)}/{Math.Abs(f.denom)})";
        }
    }

    // Метод для обчислення дійсного значення дробу
    static double DoubleValue(MyFrac f)
    {
        return (double)f.nom / f.denom;
    }

    // Метод для обчислення суми двох дробів
    static MyFrac Plus(MyFrac f1, MyFrac f2)
    {
        long newNom = f1.nom * f2.denom + f1.denom * f2.nom;
        long newDenom = f1.denom * f2.denom;
        return new MyFrac(newNom, newDenom);
    }

    // Метод для обчислення різниці двох дробів
    static MyFrac Minus(MyFrac f1, MyFrac f2)
    {
        long newNom = f1.nom * f2.denom - f1.denom * f2.nom;
        long newDenom = f1.denom * f2.denom;
        return new MyFrac(newNom, newDenom);
    }

    // Метод для обчислення добутку двох дробів
    static MyFrac Multiply(MyFrac f1, MyFrac f2)
    {
        long newNom = f1.nom * f2.nom;
        long newDenom = f1.denom * f2.denom;
        return new MyFrac(newNom, newDenom);
    }

    // Метод для обчислення частки двох дробів
    static MyFrac Divide(MyFrac f1, MyFrac f2)
    {
        long newNom = f1.nom * f2.denom;
        long newDenom = f1.denom * f2.nom;
        return new MyFrac(newNom, newDenom);
    }

    // Метод для обчислення виразу CalcExpr1
    static MyFrac CalcExpr1(int n)
    {
        MyFrac result = new MyFrac(0, 1);
        for (int i = 1; i <= n; i++)
        {
            MyFrac addend = new MyFrac(1, i * (i + 1));
            result = Plus(result, addend);
        }
        return result;
    }

    // Метод для обчислення виразу CalcExpr2
    static MyFrac CalcExpr2(int n)
    {
        MyFrac result = new MyFrac(1, 1);
        for (int i = 2; i <= n; i++)
        {
            MyFrac factor = new MyFrac((i * i - 1), (i * i));
            result = Multiply(result, factor);
        }
        return result;
    }
    static void DoBlock_2()
    {
        Console.WriteLine("Чи бажаєте ви зчитати дані з файлу чи ввести вручну? (зчитати - 1/вручну - 2)");
        int choice = Convert.ToInt32(Console.ReadLine());

        List<Student> students;
        if (choice == 1)
        {
            students = ReadData("input.txt");
        }
        else
        {
            students = new List<Student>();
            Console.WriteLine("Введіть кількість студентів:");
            int howmuch = Convert.ToInt32(Console.ReadLine());
            Console.WriteLine("Введіть дані про студентів ([Ім'я] [Прізвище] [По-батькову] [Стать(Ч, якщо чоловіча, Ж, якщо жіноча)] [Дата народження дд.мм.рррр] [оцінка 1(від 2 до 5 або просто \"-\")] [оцінка 2(від 2 до 5 або просто \"-\")] [оцінка 3(від 2 до 5 або просто \"-\")] [Стипендія, ціле число або від 1234 до 4321 («одержує таку-то стипендію»), або 0]):");
            for (int i = 0; i < howmuch; i++)
            {
                var input = Console.ReadLine();
                students.Add(new Student(input));
            }
        }
        Console.WriteLine("Результат:");
        RunMenu(students);
        Console.WriteLine();
    }
    static List<Student> ReadData(string fileName)
    {
        var students = new List<Student>();
        foreach (var line in File.ReadLines(fileName))
        {
            students.Add(new Student(line));
        }
        return students;
    }

    static void RunMenu(List<Student> studs)
    {
        var filteredStudents = studs.Where(s =>
            (s.mathematicsMark == '5' || s.physicsMark == '5' || s.informaticsMark == '5') &&
            (s.mathematicsMark == '-' || s.physicsMark == '-' || s.informaticsMark == '-'))
            .ToList();

        foreach (var student in filteredStudents)
        {
            Console.WriteLine($"{student.surName} {student.firstName} {student.mathematicsMark} {student.physicsMark} {student.informaticsMark}");
        }
    }
    static void Main(string[] args)
    {
        System.Threading.Thread.CurrentThread.CurrentCulture = new System.Globalization.CultureInfo("en-US");
        Console.OutputEncoding = UTF8Encoding.UTF8;
        Console.ForegroundColor = ConsoleColor.Black;
        Console.BackgroundColor = ConsoleColor.White;
        Console.Clear();
        int choice;
        do
        {
            Console.WriteLine("-Для виконання блоку 1 варіант 2 введіть 1");
            Console.WriteLine("-Для виконання блоку 2 (23. Вивести прізвища, імена та всі оцінки всіх студентів, які здали хоча б один іспит на \"5\" і при цьому не з’явилися на хоча б один (інший) іспит) введіть 2");
            Console.WriteLine("-Для виходу з програми введіть 0");

            choice = int.Parse(Console.ReadLine());

            switch (choice)
            {
                case 1:
                    Console.WriteLine("Виконую блок 1");
                    DoBlock_1();
                    break;
                case 2:
                    Console.WriteLine("Виконую блок 2");
                    DoBlock_2();
                    break;
                case 0:
                    Console.WriteLine("Зараз завершимо, тільки натисніть будь ласка ще раз Enter");
                    Console.ReadLine();
                    break;
                default:
                    Console.WriteLine("Команда ``{0}'' не розпізнана. Зробіь, будь ласка, вибір із 1, 2 і 0.", choice);
                    break;
            }
        } while (choice != 0);
    }
}