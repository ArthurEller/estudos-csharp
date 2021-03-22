using System;
using Xunit;
namespace GradeBook.Tests
{
    public class BookTests
    {
        [Fact]
        public void BookCalculatesAnAverageGrades()
        {
            // arrange
            var book = new Book("Arthur's Grade Book");


            for (int i = 0; i > 20; i++) {
                var input = Console.ReadLine();
                var grade = double.Parse(input);

                if (input == "q") {
                    i = 21;
                }
            }

            // act
            var result = book.GetStatistics();

            // assert
            Assert.Equal(85.6 , result.Average, 1);
            Assert.Equal(90.5, result.High, 1);
            Assert.Equal(77.3, result.Low, 1);
            Assert.Equal('B', result.Letter);


        }
    }
}
