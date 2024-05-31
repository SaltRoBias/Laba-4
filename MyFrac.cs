﻿using System;
using System.Text;
using System.Numerics;
using System.Collections.Generic;
using System.Linq;

struct MyFrac
{
    public long nom;
    public long denom;

    // Конструктор для створення дробу з чисельником і знаменником
    public MyFrac(long nom_, long denom_)
    {
        if (denom_ == 0)
        {
            throw new ArgumentException("Знаменник не може бути нульовим.");
        }

        // Переконуємось, що знаменник додатній
        if (denom_ < 0)
        {
            nom_ = -nom_;
            denom_ = -denom_;
        }

        // Скорочуємо дріб
        long gcd = GCD(Math.Abs(nom_), Math.Abs(denom_));
        nom = nom_ / gcd;
        denom = denom_ / gcd;
    }

    // Метод для перетворення дробу у строкове представлення
    public override string ToString()
    {
        return $"{nom}/{denom}";
    }

    // Метод для знаходження НСД (найбільший спільний дільник)
    private static long GCD(long a, long b)
    {
        while (b != 0)
        {
            long temp = b;
            b = a % b;
            a = temp;
        }
        return a;
    }
}