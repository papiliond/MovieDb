using MovieDb.Controllers;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using MovieDb.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MovieDb.Controllers.Tests
{
    [TestClass()]
    public class MoviesControllerTests
    {
        [TestMethod()]
        public void MovieAverageRatingTest()
        {
            List<Rating> ratings = new List<Rating>();
            //sum=26, cnt=8, expected value=3.25
            ratings.Add(new Rating { Value = 1 });
            ratings.Add(new Rating { Value = 2 });
            ratings.Add(new Rating { Value = 3 });
            ratings.Add(new Rating { Value = 4 });
            ratings.Add(new Rating { Value = 5 });
            ratings.Add(new Rating { Value = 5 });
            ratings.Add(new Rating { Value = 4 });
            ratings.Add(new Rating { Value = 2 });

            MoviesController cont = new MoviesController();
            double result = cont.MovieAverageRatingLogic(ratings);

            Assert.AreEqual(3.25, result, "Result is not as expected. Result is: " + result);
        }

        [TestMethod()]
        public void MovieAverageRatingNegativeTest()
        {
            List<Rating> ratings = new List<Rating>();
            //sum=26, cnt=8, expected value=3.25
            ratings.Add(new Rating { Value = 1 });
            ratings.Add(new Rating { Value = 2 });
            ratings.Add(new Rating { Value = 3 });
            ratings.Add(new Rating { Value = 4 });
            ratings.Add(new Rating { Value = 5 });
            ratings.Add(new Rating { Value = 5 });
            ratings.Add(new Rating { Value = 4 });
            ratings.Add(new Rating { Value = 2 });

            MoviesController cont = new MoviesController();
            double result = cont.MovieAverageRatingLogic(ratings);

            Assert.AreNotEqual(3, result, "Result is not as expected. Result is: " + result);
        }

        [TestMethod()]
        public void getMovieRateTest()
        {
            List<int> ratings = new List<int>();
            //sum=26, cnt=8, expected value=3.25
            ratings.Add(1);
            ratings.Add(2);
            ratings.Add(3);
            ratings.Add(4);
            ratings.Add(5);
            ratings.Add(5);
            ratings.Add(4);
            ratings.Add(2);

            MoviesController cont = new MoviesController();
            double result = cont.getMovieRateLogic(ratings);

            Assert.AreEqual(3.25, result, "Result is not as expected. Result is: " + result);
        }

        [TestMethod()]
        public void getMovieRateNegativeTest()
        {
            List<int> ratings = new List<int>();
            //sum=26, cnt=8, expected value=3.25
            ratings.Add(1);
            ratings.Add(2);
            ratings.Add(3);
            ratings.Add(4);
            ratings.Add(5);
            ratings.Add(5);
            ratings.Add(4);
            ratings.Add(2);

            MoviesController cont = new MoviesController();
            double result = cont.getMovieRateLogic(ratings);

            Assert.AreNotEqual(3, result, "Result is not as expected. Result is: " + result);
        }

        [TestMethod()]
        public void TopLogicTest()
        {
            Movie m1 = new Movie() { Title = "Teszt film 1" };
            Movie m2 = new Movie() { Title = "Teszt film 2" };
            Movie m3 = new Movie() { Title = "Teszt film 3" };
            Movie m4 = new Movie() { Title = "Teszt film 4" };
            Movie m5 = new Movie() { Title = "Teszt film 5" };
            Movie m6 = new Movie() { Title = "Teszt film 6" };
            Movie m7 = new Movie() { Title = "Teszt film 7" };
            Movie m8 = new Movie() { Title = "Teszt film 8" };

            List<KeyValuePair<Movie, double>> dictionary = new List<KeyValuePair<Movie, double>>();
            dictionary.Add(new KeyValuePair<Movie, double>(m1, 3.75));
            dictionary.Add(new KeyValuePair<Movie, double>(m2, 3.85));
            dictionary.Add(new KeyValuePair<Movie, double>(m3, 3.95));
            dictionary.Add(new KeyValuePair<Movie, double>(m4, 3.15));
            dictionary.Add(new KeyValuePair<Movie, double>(m5, 3.25));
            dictionary.Add(new KeyValuePair<Movie, double>(m6, 3.35));
            dictionary.Add(new KeyValuePair<Movie, double>(m7, 3.45));
            dictionary.Add(new KeyValuePair<Movie, double>(m8, 3.55));

            MoviesController cont = new MoviesController();
            var result = cont.TopLogic(dictionary, 4);

            Assert.AreEqual(4, result.Count);

            Assert.AreSame(m3, result[0]);  // 3.95
            Assert.AreSame(m2, result[1]);  // 3.85
            Assert.AreSame(m1, result[2]);  // 3.75
            Assert.AreSame(m8, result[3]);  // 3.55
        }

        [TestMethod()]
        public void TopLogicNegativeTest()
        {
            Movie m1 = new Movie() { Title = "Teszt film 1" };
            Movie m2 = new Movie() { Title = "Teszt film 2" };
            Movie m3 = new Movie() { Title = "Teszt film 3" };
            Movie m4 = new Movie() { Title = "Teszt film 4" };
            Movie m5 = new Movie() { Title = "Teszt film 5" };
            Movie m6 = new Movie() { Title = "Teszt film 6" };
            Movie m7 = new Movie() { Title = "Teszt film 7" };
            Movie m8 = new Movie() { Title = "Teszt film 8" };

            List<KeyValuePair<Movie, double>> dictionary = new List<KeyValuePair<Movie, double>>();
            dictionary.Add(new KeyValuePair<Movie, double>(m1, 3.75));
            dictionary.Add(new KeyValuePair<Movie, double>(m2, 3.85));
            dictionary.Add(new KeyValuePair<Movie, double>(m3, 3.95));
            dictionary.Add(new KeyValuePair<Movie, double>(m4, 3.15));
            dictionary.Add(new KeyValuePair<Movie, double>(m5, 3.25));
            dictionary.Add(new KeyValuePair<Movie, double>(m6, 3.35));
            dictionary.Add(new KeyValuePair<Movie, double>(m7, 3.45));
            dictionary.Add(new KeyValuePair<Movie, double>(m8, 3.55));

            MoviesController cont = new MoviesController();
            var result = cont.TopLogic(dictionary, 4);

            Assert.AreNotEqual(3, result.Count);

            Assert.AreNotSame(m5, result[0]);  // 3.95
            Assert.AreNotSame(m3, result[1]);  // 3.85
            Assert.AreNotSame(m4, result[2]);  // 3.75
            Assert.AreNotSame(m7, result[3]);  // 3.55
        }
    }
}