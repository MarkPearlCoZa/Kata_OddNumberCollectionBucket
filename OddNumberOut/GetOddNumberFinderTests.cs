using System;
using System.Collections.Generic;
using NUnit.Framework;

namespace OddNumberOut
{
    [TestFixture]
    public class GetOddNumberFinderTests
    {
        private IEnumerable<IEnumerable<int>> EvenCollectionBucket
        {
            get
            {
                return new List<IEnumerable<int>>
                {
                    new List<int>{1, 1, 4, 4, 4, 4, 2, 2, 3, 3},
                    new List<int>{1, 1, 4, 4},
                    new List<int>{4, 4, 4, 4, 4, 4}
                };
            }
        }


        [Test]
        public void ShouldGetTheRightOddNumberWhenOnlyOneNumberExists()
        {
            var bagOfNumbers = new List<int> { 4, 4, 4, 4, 1, 2, 2 };
            var sut = new NumberCollectionFinder();
            var result = sut.FindOddNumberCollections(bagOfNumbers);

            Assert.That(result, Is.EqualTo(1));
        }

        [TestCaseSource("EvenCollectionBucket")]
        public void ShouldThrowExceptionIfNoOddCollectionsFound(IEnumerable<int> bagOfEvenNumberCollections)
        {            
            var sut = new NumberCollectionFinder();

            Assert.Throws<ApplicationException>(() =>
                {
                    sut.FindOddNumberCollections(bagOfEvenNumberCollections);
                });
        }        

        
        [Test]
        public void ShouldThrowExceptionIfMoreThanOneOddCollectionsFound()
        {
            var bagOfEvenNumberCollections = new List<int> { 1,1,1, 4, 4, 4, 4, 2, 2,3,3,3 };
            var sut = new NumberCollectionFinder();

            Assert.Throws<ApplicationException>(() =>
            {
                sut.FindOddNumberCollections(bagOfEvenNumberCollections);
            });
        }

    }
}
