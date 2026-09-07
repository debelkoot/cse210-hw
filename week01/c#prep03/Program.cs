using System;

class Program
{
    static void Main(string[] args)
    {
      string KeepPlaying = "yes";
      while (keepPlaying.ToLower()=="yes"
    {
        Random randomGenerator = new Random();
        int magicNumber = randomGenerator.Next(1, 101);

        int guess = -1;
        int guessCount=0;

        while (guess != magicNumber)
        {
            Console.Write("What is your guess? ");
            guess = int.Parse(Console.ReadLine());
            guessCount++;

            if (magicNumber > guess)
            {
                Console.WriteLine("Higher");
            }
            else if (magicNumber < guess)
            {
                Console.WriteLine("Lower");
            }
            else
            {
                Console.WriteLine("You guessed it!");
            }
            
                Console.WriterLine($"It Tooks You{guessCount}guesses.");
                Console.WriteLine();
        }
          Console.WriteLine("Thanks for playing!");
        }                    
    }
}
