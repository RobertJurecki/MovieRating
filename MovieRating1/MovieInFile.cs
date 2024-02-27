using System.Text;

namespace MovieRating
{
    public class MovieInFile : MovieBase
    {
        private const string fileName = "_ratings.txt";

        private string title;
        private string fullFileName;

        public override string Title
        {
            get
            {
                return $"{char.ToUpper(title[0])}{title.Substring(1, title.Length - 1).ToLower()}";
            }
            set
            {
                title = value;
            }
        }

        public MovieInFile(string title) : base(title)
        {
            fullFileName = $"{title}_{fileName}";
        }

        public override void AddRating(double rating)
        {
            if (rating > 0 && rating <= 6)
            {
                using (var writer = File.AppendText($"{fullFileName}"))
                {
                    writer.WriteLine(rating);
                    if (rating == 6)
                    {
                        CheckEventRating6();
                    }
                }
            }
            else
            {
                throw new ArgumentException($"Invalid argument: {nameof(rating)}. Only ratings from 1 to 6 are allowed!");
            }
        }

        public override void ShowRatings()
        {
            StringBuilder sb = new StringBuilder($"{this.Title} rating are: ");

            using (var reader = File.OpenText(($"{fullFileName}")))
            {
                var line = reader.ReadLine();
                while (line != null)
                {
                    sb.Append($"{line}; ");
                    line = reader.ReadLine();
                }
            }
            Console.WriteLine($"\n{sb}");
        }

        public override Statistics GetStatistics()
        {
            var result = new Statistics();
            if (File.Exists($"{fullFileName}"))
            {
                using (var reader = File.OpenText($"{fullFileName}"))
                {
                    var line = reader.ReadLine();
                    while (line != null)
                    {
                        var number = double.Parse(line);
                        result.Add(number);
                        line = reader.ReadLine();
                    }
                }
            }
            return result;
        }
    }
}
