using MovieRating;
using System;

namespace MovieRating
{
    public abstract class MovieBase : Movie, IMovie
    {
        public delegate void RatingAdded6Delegade(object sender, EventArgs args);
        public event RatingAdded6Delegade Rating6;
        public override string Title { get; set; }

        public MovieBase(string title) : base(title)
        {
        }

        public abstract void AddRating(double rating);

        public void AddRating(string rating)
        {
            double convertedRatingToDouble = char.GetNumericValue(rating[0]);
            if (rating.Length == 2 && char.IsDigit(rating[0]) && rating[0] <= '6' && (rating[1] == '+' || rating[1] == '-'))
            {
                switch (rating[1])
                {
                    case '+':
                        double ratingPlus = convertedRatingToDouble + 0.50;
                        if (ratingPlus > 1 && ratingPlus <= 6)
                        {
                            AddRating(ratingPlus);
                        }
                        else
                        {
                            throw new ArgumentException($"Only ratings from 1 to 6 are allowed!");
                        }
                        break;

                    case '-':
                        double ratingMinus = convertedRatingToDouble - 0.50;
                        if (ratingMinus > 1 && ratingMinus <= 6)
                        {
                            AddRating(ratingMinus);
                        }
                        else
                        {
                            throw new ArgumentException($"Only ratings from 1 to 6 are allowed!");
                        }
                        break;

                    default:
                        throw new ArgumentException($"Only ratings from 1 to 6 are allowed!");
                }
            }
            else
            {
                double ratingDouble = 0;
                var isParsed = double.TryParse(rating, out ratingDouble);
                if (isParsed && ratingDouble > 0 && ratingDouble <= 6)
                {
                    AddRating(ratingDouble);
                }
                else
                {
                    throw new ArgumentException($"Only ratings from 1 to 6 are allowed!");
                }
            }
        }

        public abstract void ShowRatings();

        public abstract Statistics GetStatistics();

        public void ShowStatistics()
        {
            var stat = GetStatistics();
            if (stat.Count != 0)
            {
                ShowRatings();
                Console.WriteLine($"{Title} statistics:");
                Console.ForegroundColor = ConsoleColor.DarkGray;
                Console.WriteLine($"Total ratings: {stat.Count}");
                Console.ForegroundColor = ConsoleColor.Green;
                Console.WriteLine($"Highest rating: {stat.High:N2}");
                Console.ForegroundColor = ConsoleColor.Red;
                Console.WriteLine($"Lowest rating: {stat.Low:N2}");
                Console.ForegroundColor = ConsoleColor.Blue;
                Console.WriteLine($"Average: {stat.Average:N2}");
                Console.WriteLine();
                Console.ResetColor();
            }
            else
            {
                Console.ForegroundColor = ConsoleColor.Red;
                Console.WriteLine($"Couldn't get statistics for {this.Title} because no rating has been added.");
                Console.ResetColor();
            }
        }

        protected void CheckEventRating6()
        {
            if (Rating6 != null)
            {
                Rating6(this, new EventArgs());
            }
        }

    }
}

