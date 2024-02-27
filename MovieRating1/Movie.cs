namespace MovieRating
{
    public class Movie
    {
        public virtual string Title { get; set; }

        public Movie(string title)
        {
            this.Title = title;
        }
    }
}

