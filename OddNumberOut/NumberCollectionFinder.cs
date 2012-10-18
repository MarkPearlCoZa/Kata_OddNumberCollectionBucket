using System;
using System.Collections.Generic;
using System.Linq;

namespace OddNumberOut
{
    public class NumberCollectionFinder
    {
        public int FindOddNumberCollections(IEnumerable<int> bagOfNumbers)
        {
            var oddCollections = GenerateHashOfOddNumberedCollections(bagOfNumbers);

            if (oddCollections.Count > 1) throw (new ApplicationException("More than one odd number of numbers"));
            if (oddCollections.Count == 0) throw (new ApplicationException("No odd number collections"));

            return oddCollections.First();
        }

        private HashSet<int> GenerateHashOfOddNumberedCollections(IEnumerable<int> bagOfNumbers)
        {
            var oddNumberCollections = new HashSet<int>();

            foreach (var item in bagOfNumbers)
            {
                if (oddNumberCollections.Contains(item))
                {
                    oddNumberCollections.Remove(item);
                }
                else
                {
                    oddNumberCollections.Add(item);
                }
            }
            return oddNumberCollections;
        }
    }
}