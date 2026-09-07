using System;

class Program
{
    static void Main(string[] args)
    {
        Console.Write("What is your grade percentage? ");
        string answer = Console.ReadLine();
        int percent = int.Parse(answer);

        string letter = "";

        if (percent >= 95)
        {
            letter = "A+";
        }
        else if (percent >= 90)
        {
            letter = "A";
        }
        else if (percent >= 85)
        {
            letter = "A-";
        }
        else if (percent >= 80)
        {
            letter = "B+";
        }
        else if (percent >= 75)
        {
            letter = "B";
        }
        else if (percent >= 70)
        {
            letter = "B-";
       else if (percent >= 65)
        {
            letter = "C+";
        }
        else if (percent >= 60)
        {
            letter = "C";
        else if (percent >= 55)
        {
            letter = "C-";
        }
        else if (percent >= 50)
        {
            letter = "D+";
        else if (percent >= 45)
        {
            letter = "D";
        }
        else if (percent >= 40)
        {
            letter = "D-";
        else
        {
            letter = "F";
        }

        Console.WriteLine($"Your grade is: {letter}");
        
        if (percent >= 70)
        {
            Console.WriteLine("You passed!");
        }
        else
        {
            Console.WriteLine("You will try next time!");
        }
    }
}
