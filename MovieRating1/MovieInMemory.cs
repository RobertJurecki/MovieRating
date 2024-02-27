using System.Text;

namespace MovieRating
{
    public class MovieInMemory : MovieBase
    {
        private List<double> ratings;
        private string title;


        public override string Title
        {
            get
            {
                return $"{char.ToUpper(title[0])}{title.Substring(1, title.Length - 1).ToLower()}";
            }
            set
            {
                if (!string.IsNullOrEmpty(value))
                {
                    title = value;
                }
            }
        }

        public MovieInMemory(string title) : base(title)
        {
            ratings = new List<double>();
        }

        public void ChangeMovieTitle(string newTitle)
        {
            string oldTitle = this.Title;
            foreach (char c in newTitle)
            {
                if (char.IsDigit(c))
                {
                    this.Title = oldTitle;
                    break;
                }
                else
                {
                    this.Title = newTitle;
                }
            }
        }

        public override void AddRating(double rating)
        {
            if (rating > 0 && rating <= 6)
            {
                ratings.Add(rating);
                if (rating == 6)
                {
                    CheckEventRating6();
                }
            }
            else
            {
                throw new ArgumentException($"Only ratings from 1 to 6 are allowed!");
            }
        }

        public override void ShowRatings()
        {
            StringBuilder sb = new StringBuilder($"{this.Title} rating are: ");
            for (int i = 0; i < ratings.Count; i++)
            {
                if (i == ratings.Count - 1)
                {
                    sb.Append($"{ratings[i]}.");
                }
                else
                {
                    sb.Append($"{ratings[i]}; ");
                }
            }
            Console.WriteLine($"\n{sb}");
        }

        public override Statistics GetStatistics()
        {
            var result = new Statistics();

            foreach (var rating in ratings)
            {
                result.Add(rating);
            }
            return result;
        }
    }
}

