namespace MovieRating
{
    internal class Program
    {
        private static void Main(string[] args)
        {
            WritelineColor(ConsoleColor.DarkYellow, "---------------------");
            WritelineColor(ConsoleColor.Yellow, "   Computer studio   ");
            WritelineColor(ConsoleColor.Blue, "        Nida         ");
            WritelineColor(ConsoleColor.Yellow, "      presents       ");
            WritelineColor(ConsoleColor.Yellow, "movie rating program ");
            WritelineColor(ConsoleColor.DarkYellow, "---------------------");

            bool CloseApp = false;

            while (!CloseApp)
            {
                Console.WriteLine();
                WritelineColor(ConsoleColor.DarkGreen,
                    "1 - Add movie ratings to the program memory and show statistics\n" +
                    "2 - Add movie ratings to the .txt file and show statistics");
                WritelineColor(ConsoleColor.Red, "Q - Exit\n");

                WritelineColor(ConsoleColor.Yellow, "What you want to do? \nPress key 1, 2 or Q: ");
                var userInput = Console.ReadLine().ToUpper();

                switch (userInput)
                {
                    case "1":
                        AddRatingsToMemory();
                        break;

                    case "2":
                        AddRatingsToTxtFile();
                        break;

                    case "Q":
                        CloseApp = true;
                        break;

                    default:
                        WritelineColor(ConsoleColor.Red, "Invalid operation.\n");
                        continue;
                }
            }
            WritelineColor(ConsoleColor.DarkYellow, "\n\nSee you. Press any key to leave.");
            Console.ReadKey();
        }

        static void OnRating6(object sender, EventArgs args)
        {
            WritelineColor(ConsoleColor.DarkYellow, $"It's an excellent movie");
        }

        private static void AddRatingsToMemory()
        {
            string title = GetValueFromUser("Please insert film's title: ");
            if (!string.IsNullOrEmpty(title))
            {
                var inMemoryMovie = new MovieInMemory(title);
                inMemoryMovie.Rating6 += OnRating6;
                EnterRating(inMemoryMovie);
                inMemoryMovie.ShowStatistics();
            }
            else
            {
                WritelineColor(ConsoleColor.Red, "Movies title cannot be empty!");
            }
        }

        private static void AddRatingsToTxtFile()
        {
            string title = GetValueFromUser("Please insert movie's title: ");
            if (!string.IsNullOrEmpty(title))
            {
                var inFileMovie = new MovieInFile(title);
                inFileMovie.Rating6 += OnRating6;
                EnterRating(inFileMovie);
                inFileMovie.ShowStatistics();
            }
            else
            {
                WritelineColor(ConsoleColor.Red, "Movies title cannot be empty!");
            }
        }

        private static void EnterRating(IMovie movie)
        {
            while (true)
            {
                WritelineColor(ConsoleColor.Yellow, $"Enter rating for {movie.Title}:");
                var input = Console.ReadLine();

                if (input == "q" || input == "Q")
                {
                    break;
                }
                try
                {
                    movie.AddRating(input);
                }
                catch (FormatException ex)
                {
                    WritelineColor(ConsoleColor.Red, ex.Message);
                }
                catch (ArgumentException ex)
                {
                    WritelineColor(ConsoleColor.Red, ex.Message);
                }
                catch (NullReferenceException ex)
                {
                    WritelineColor(ConsoleColor.Red, ex.Message);
                }
                finally
                {
                    WritelineColor(ConsoleColor.DarkMagenta, $"To leave and show {movie.Title} statistics enter 'q'.");
                }
            }
        }

        private static void WritelineColor(ConsoleColor color, string text)
        {
            Console.ForegroundColor = color;
            Console.WriteLine(text);
            Console.ResetColor();
        }

        private static string GetValueFromUser(string comment)
        {
            WritelineColor(ConsoleColor.Yellow, comment);
            string userInput = Console.ReadLine();
            return userInput;
        }
    }
}
