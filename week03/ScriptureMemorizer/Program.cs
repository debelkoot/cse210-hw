using System;
using System.Collections.Generic;

namespace ScriptureMemorizer;

class Program
{
    static void Main(string[] args)
    {
        // EXCEEDING REQUIREMENTS:
        // 1. Multiple Scripture Library:
        // I created more than one scripture in a list. The program randomly
        // chooses one scripture when it starts, so the user can practice
        // different scriptures.
        // 2. Improved Word Selection:
        // The program only hides words that are still visible. This prevents
        // hiding the same word again and helps the user make progress.
        // 3. Punctuation Handling:
        // I improved the Word class so punctuation marks remain visible when
        // words are replaced with underscores.
        // 4. User Experience:
        // I added a quit option so the user can stop the program anytime.
        List<Scripture> scriptureLibrary = new List<Scripture>();
        scriptureLibrary.Add(new Scripture(
            new Reference("Proverbs", 3, 5, 6),
            "Trust in the LORD with all thine heart; and lean not unto thine own understanding. In all thy ways acknowledge him, and he shall direct thy paths."
        ));
        scriptureLibrary.Add(new Scripture(
            new Reference("John", 3, 16),
            "For God so loved the world, that he gave his only begotten Son, that whosoever believeth in him should not perish, but have everlasting life."
        ));
        scriptureLibrary.Add(new Scripture(
            new Reference("Doctrine and Covenants", 6, 36),
            "Look unto me in every thought; look not doubt not fear not."
        ));
        Random random = new Random();
        int randomNumber = random.Next(scriptureLibrary.Count);
        Scripture selectedScripture = scriptureLibrary[randomNumber];
        while (true)
        {
            Console.Clear();
            Console.WriteLine(selectedScripture.GetDisplayText());
            Console.WriteLine();
            if (selectedScripture.IsCompletelyHidden())
            {
                Console.WriteLine("Congratulations! You finished memorizing the scripture.");
                break;
            }
            Console.Write("Press Enter to hide words or type quit: ");
            string input = Console.ReadLine();
            if (input != null && input.ToLower() == "quit")
            {
                break;
            }
            selectedScripture.HideRandomWords(3);
        }
    }
}
