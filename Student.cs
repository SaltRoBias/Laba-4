﻿using System;
using System.Text;
using System.Numerics;
using System.Collections.Generic;
using System.Linq;

struct Student
{
    public string surName;
    public string firstName;
    public string patronymic;
    public char sex;
    public string dateOfBirth;
    public char mathematicsMark;
    public char physicsMark;
    public char informaticsMark;
    public int scholarship;

    public Student(string lineWithAllData)
    {
        var parts = lineWithAllData.Split(new char[] { ' ', '\t' }, StringSplitOptions.RemoveEmptyEntries);
        surName = parts[0];
        firstName = parts[1];
        patronymic = parts[2];
        sex = parts[3][0];
        dateOfBirth = parts[4];
        mathematicsMark = parts[5][0];
        physicsMark = parts[6][0];
        informaticsMark = parts[7][0];
        scholarship = int.Parse(parts[8]);
    }
}