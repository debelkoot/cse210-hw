using System;

class Program
{
    static void Main(string[] args)
    {
        Console.WriteLine("Hello World! This is the Exercise1 Project.");
        Console.WriteLine("What is your first name? ");
        string first = Console.Readline();

        Console.Write("What is your last name? ");
        string last = Console.Readline();
        Console.WriteLine($"Your name is {last},{first},{last}.")

    }
}