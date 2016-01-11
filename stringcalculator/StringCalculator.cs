using System;
using System.Collections.Generic;
using System.Linq;

namespace Stringcalculator
{
    public class stringCalculator
    {
        private static long TOTAL;

        public static long Add(string csvText)
        {
            // Return 0 if the input is empty
            if (csvText == string.Empty)
            {
                return 0;
            }
            
            // Otherwise calculate the total if there are no negatives 
            var strings = Csv.Read(csvText).GetIndividualElements();
            GetNegatives(strings);

            // sum of te numbers
            TOTAL = 0;
            foreach (var str in strings) TOTAL += long.Parse(str);
            
            return TOTAL;
        }

        private static void GetNegatives(IEnumerable<string> elements)
        {
            var nums = new List<long>();
            foreach (var element in elements)
            // If negative
                if (long.Parse(element) < 0)
                {
                    nums.Add(long.Parse(element));
            }

            // There was a negative
            if (nums.Count() != 0)
            {
                throw new ArgumentException(string.Format("negatives not allowed: {0}", string.Join(", ", nums)));
            }
        }
    }
}