
using static MovieRating.MovieBase;

namespace MovieRating
{
    public interface IMovie
    {
        string Title { get; set; }

        event RatingAdded6Delegade Rating6;

        void AddRating(double rating);

        void AddRating(string rating);

        void ShowRatings();

        Statistics GetStatistics();

        void ShowStatistics();
    }

}

