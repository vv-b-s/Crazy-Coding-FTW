using System;
using static System.Console;

class Program
{

    static void Main()
    {
        int age = (int)ReadNum();
        double washingMachine = (double)ReadNum();
        int toyPrice = (int)ReadNum();

        int toysGained = (int)Math.Ceiling((double)age / 2);
        int timesMoney = age / 2;

        double money = toysGained * toyPrice - timesMoney;
        for (int i = 0, j = 1; i < timesMoney; i++, j++)
            money += j * 10;
        WriteLine((money >= washingMachine) ? $"Yes! {Math.Round(money - washingMachine, 2):0.00}" : $"No! {Math.Round(washingMachine - money, 2):0.00}");
    }
    static decimal ReadNum()
    {
        string input = ReadLine();
        decimal output;
        decimal.TryParse(input, out output);
        return output;
    }
}