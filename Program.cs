using System;

namespace RhythmsGonnaGetYou
{
    class Program
    {
        static void DisplayGreeting()
        {
            Console.WriteLine("----------------------------------------------------");
            Console.WriteLine("    Welcome to the Music database   ");
            Console.WriteLine("----------------------------------------------------");
            Console.WriteLine();
            Console.WriteLine();
        }

        static string PromptForString(string prompt)
        {
            Console.Write(prompt);
            var userInput = Console.ReadLine();

            return userInput;
        }

        static int PromptForInteger(string prompt)
        {
            Console.Write(prompt);
            int userInput;
            var isThisGoodInput = Int32.TryParse(Console.ReadLine(), out userInput);

            if (isThisGoodInput)
            {
                return userInput;
            }
            else
            {
                Console.WriteLine("Sorry, that isn't a valid input, I'm using 0 as your answer.");
                return 0;
            }
        }
        // ^^^^^^^^^^^^^^^^^^^^ methods and stuff ^^^^^^^^^^^^^^^^^^^^^^^^

        static void Main(string[] args)
        {
            var context = new RhythmsGonnaGetYouContext();

            // Should we keep showing out menu
            var keepGoing = true;

            DisplayGreeting();

            while (keepGoing)
            {

                Console.WriteLine();
                Console.WriteLine("Please choose from the menu");
                Console.WriteLine("(A)dd a new data to database");
                Console.WriteLine("(D)isplay database information");
                Console.WriteLine("(U)pdate signed status of band");
                Console.WriteLine("(Q)uit to exit menu");
                var choice = Console.ReadLine().ToUpper();

                switch (choice)
                {
                    case "A":
                        Console.WriteLine();
                        Console.WriteLine("1. Please choose from the menu");
                        Console.WriteLine("2. Add a new band to database");
                        Console.WriteLine("3. Add a new album to database");
                        Console.WriteLine("4. Add a new song and to database");
                        Console.WriteLine("5. Quit to exit menu");
                        var addChoice = Console.ReadLine().ToUpper();
                        if (addChoice == "1")
                        {

                        }
                        else if (addChoice == "2")
                        {

                        }
                        else if (addChoice == "3")
                        {

                        }
                        else if (addChoice == "4")
                        {

                        }
                        else
                        {
                            Console.WriteLine("Goodbye!");
                        }

                        break;
                    case "D":
                        break;
                    case "U":
                        break;
                    case "Q":
                        keepGoing = false;
                        break;
                    default:
                        Console.WriteLine("That was not a valid selection! Please Try again");
                        break;
                }
            }
        }
    }
}
