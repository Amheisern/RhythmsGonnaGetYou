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
            Console.WriteLine("         Welcome to the Music database   ");
            Console.WriteLine("----------------------------------------------------");
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
                        Console.WriteLine("3. Add a new song to database");
                        var addChoice = Console.ReadLine().ToUpper();

                        if (addChoice == "1")
                        {
                            var name = PromptForString("What is the name of the band?:");
                            var contactName = PromptForString("What is the name of the band's manager?: ");
                            var genre = PromptForString("What genre is the band?: ");
                            var countryOfOrigin = PromptForString("What country is the band from?:");
                            var website = PromptForString("What is the band's website?: ");
                            var numberOfMembers = PromptForInteger("Type the number of band members.:");
                            Console.WriteLine("is the band signed Y/N");
                            var isSigned = bool.Parse(Console.ReadLine());

                            var newBand = new Band
                            {
                                Name = name,
                                ContactName = contactName,
                                Genre = genre,
                                CountryOfOrigin = countryOfOrigin,
                                Website = website,
                                NumberOfMembers = numberOfMembers,
                                IsSigned = isSigned,
                            };
                            context.Bands.Add(newBand);
                            context.SaveChanges();

                        }
                        else if (addChoice == "2")
                        {
                            var title = PromptForString("What is the title of the album?:");
                            Console.WriteLine("Is the album explicit true/false");
                            var isExplicit = bool.Parse(Console.ReadLine());
                            Console.WriteLine("What was the date the album's release(DD/MM/YYY)?");
                            var releaseDate = DateTime.Parse(Console.ReadLine());
                            var bandId = PromptForInteger("What is the band id of the album?");

                            var newAlbum = new Album
                            {
                                Title = title,
                                IsExplicit = isExplicit,
                                ReleaseDate = releaseDate,
                                BandId = bandId
                            };
                            context.Albums.Add(newAlbum);
                            context.SaveChanges();
                        }
                        else if (addChoice == "3")
                        {
                            var title = PromptForString("What is the title of the album?:");
                            var trackNumber = PromptForInteger("What is the track number?:");
                            var duration = PromptForString("What is the track duration MM:SS");
                            var albumId = PromptForInteger("What is the album id of the album?");

                            var newSong = new Song
                            {
                                Title = title,
                                TrackNumber = trackNumber,
                                Duration = duration,
                                AlbumId = albumId
                            };
                            context.Songs.Add(newSong);
                            context.SaveChanges();

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
                        Console.WriteLine("6. View all albums in a genre");
                        Console.WriteLine("7. view all members in band");
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
                            DisplaySigned(context);
                        }
                        else if (dChoice == "3")
                        {
                            DisplayUnsigned(context);
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
                            // there is a problem with join code
                            Band foundBand = FindBand(context);
                            var albumsAndBands = context.Albums.Include(album => album.Band)
                            .Where(album => album.Band == foundBand);

                            // var albumAndBand = context.Band.Where(band => band.Name == foundBand);
                            //var allAlbumsForBand = context.Album.include(album => album.Band);
                            // var allAlbumsForBand = context.Album.Include(album => album.BandId).
                            //ThenInclude;
                            //.ThenInclude(band => band.Name);
                            if (foundBand == null)
                            {
                                Console.WriteLine("No match found in database!");
                            }
                            else
                            {
                                foreach (var album in albumsAndBands)
                                {
                                    Console.WriteLine($"{album.Title} ");
                                }
                            }
                        }
                        else if (dChoice == "6")
                        {
                            // view all albums in a genre
                            // var genre = context.Albums.Include(album => album.ReleaseDate);

                            // foreach (var album in albumByRelease)
                            // {
                            //     Console.WriteLine($"These are the albums by release date {album.Title} - {album.ReleaseDate}");
                            // }
                        }

                        else if (dChoice == "7")
                        {

                        }

                        else
                        {
                            Console.WriteLine("Goodbye!");
                        }

                        break;
                    case "U":
                        Console.WriteLine();
                        Console.WriteLine("Please choose from the menu");
                        Console.WriteLine("1. Sign a band");
                        Console.WriteLine("2. Drop a band");
                        Console.WriteLine("3. Display signed bands");
                        Console.WriteLine("4. Display unsigned bands");
                        var UChoice = Console.ReadLine().ToUpper();
                        if (UChoice == "1")
                        {
                            Band foundBand = FindBand(context);
                            if (foundBand != null)
                            {
                                Console.WriteLine($"{foundBand} is now signed!");
                                foundBand.IsSigned = true;
                            }
                        }
                        else if (UChoice == "2")
                        {
                            Band foundBand = FindBand(context);
                            if (foundBand != null)
                            {
                                Console.WriteLine($"{foundBand} is no longer signed!");

                                foundBand.IsSigned = false;
                            }
                        }
                        else if (UChoice == "3")
                        {
                            DisplaySigned(context);

                        }
                        else if (UChoice == "4")
                        {
                            DisplayUnsigned(context);
                        }
                        else
                        {
                            Console.WriteLine("Goodbye!");
                        }
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

        private static Band FindBand(RhythmsGonnaGetYouContext context)
        {
            var result = PromptForString("Please type the name of a band: ");
            var foundBand = context.Bands.FirstOrDefault(band => band.Name.ToUpper().Contains(result.ToUpper()));
            return foundBand;
        }

        private static void DisplaySigned(RhythmsGonnaGetYouContext context)
        {
            foreach (var band in context.Bands)
            {
                if (band.IsSigned == true)
                {
                    Console.WriteLine($"{band.Name} Is signed");
                }

            }
        }

        private static void DisplayUnsigned(RhythmsGonnaGetYouContext context)
        {
            foreach (var band in context.Bands)
            {
                if (band.IsSigned == false)
                {
                    Console.WriteLine($"{band.Name} Is unsigned");
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
