namespace MovieRating.Tests

{
    public class Tests
    {
        [Test]
        public void Test()
        {
            // arrange
            var movie = new MovieInMemory("Lucy");
            movie.AddRating(1);
            movie.AddRating(2);
            movie.AddRating(2);
            movie.AddRating(2);
            movie.AddRating(3);

            // act
            var statistics = movie.GetStatistics();

            // assert
            Assert.AreEqual(2, statistics.Average);
            Assert.AreEqual(3, statistics.High);
            Assert.AreEqual(1, statistics.Low);
        }
    }
}