using System;
using System.Linq;
using Microsoft.EntityFrameworkCore;

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
                        Console.WriteLine("Please choose from the menu");
                        Console.WriteLine("1. Add a new band to database");
                        Console.WriteLine("2. Add a new album to database");
                        Console.WriteLine("3. Add a new song and to database");
                        Console.WriteLine("4. Quit to exit menu");
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
                        // else if (addChoice == "4")
                        // {

                        // }
                        else
                        {
                            Console.WriteLine("Goodbye!");
                        }

                        break;
                    case "D":
                        Console.WriteLine();
                        Console.WriteLine("Please choose from the menu");
                        Console.WriteLine("1. View all bands in database");
                        Console.WriteLine("2. View all bands signed in database");
                        Console.WriteLine("3. View all bands unsigned in database");
                        Console.WriteLine("4. View all albums by release date database");
                        Console.WriteLine("5. View all albums by band");
                        var dChoice = Console.ReadLine().ToUpper();
                        if (dChoice == "1")
                        {
                            foreach (var band in context.Bands)
                            {
                                Console.WriteLine($"There is a band named {band.Name}");
                            }

                        }
                        else if (dChoice == "2")
                        {
                            // var bandSigned = context.Bands.Include(band => band.IsSigned);
                            foreach (var band in context.Bands)
                            {
                                if (band.IsSigned == true)
                                {
                                    Console.WriteLine($"{band.Name} Is signed");
                                }

                            }
                        }
                        else if (dChoice == "3")
                        {
                            foreach (var band in context.Bands)
                            {
                                if (band.IsSigned == false)
                                {
                                    Console.WriteLine($"{band.Name} Is unsigned");
                                }

                            }
                        }
                        else if (dChoice == "4")
                        {
                            var albumByRelease = context.Albums.OrderBy(album => album.ReleaseDate);

                            foreach (var album in albumByRelease)
                            {
                                Console.WriteLine($"These are the albums by release date {album.Title} - {album.ReleaseDate}");
                            }
                            // foreach (var album in context.Albums)
                            // {
                            //     Console.WriteLine($"There is a band named {album.Title}");
                            // }
                        }

                        else if (dChoice == "5")
                        {
                            var result = PromptForString("Please type the name of a band: ");
                            var foundBand = context.Bands.FirstOrDefault(band => band.Name.ToUpper().Contains(result.ToUpper()));
                            var allAlbumsForBand = context.Albums.Include(album => album.BandId).ThenInclude(band => band);
                            //.ThenInclude(band => band.Name);
                            if (foundBand == null)
                            {
                                Console.WriteLine("No match found in database!");
                            }
                            else
                            {
                                foreach (var album in allAlbumsForBand)
                                {
                                    Console.WriteLine($"{foundBand} have these {album.Title}");
                                }
                            }
                            // foreach (var band in bandSearch)
                            // {

                            // }
                        }
                        else
                        {
                            Console.WriteLine("Goodbye!");
                        }

                        break;
                    case "U":
                        break;
                    case "Q":
                        Console.WriteLine("Goodbye!");
                        keepGoing = false;
                        break;
                    default:
                        Console.WriteLine("That was not a valid selection! Please Try again");
                        break;
                }
            }
        }
        // static RhythmsGonnaGetYouContext FindBand(string bandSearch)
        // {
        //     RhythmsGonnaGetYouContext FindBand = Context.Bands.FirstOrDefault((band => band.Name.ToUpper().Contains(band.Name.ToUpper()));
        //     return FindBand;
        //}
    }
}
