using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PotterKata.Solution
{
    internal class DiscountCatalog
    {
        /// <summary>
        /// //This stores the discount per book in a Dictionary.
        /// </summary>
        private readonly Dictionary<int, decimal> catalogue = new Dictionary<int, decimal>
        {
            {1, 0m},
            {2, 0.05m},
            {3, 0.1m},
            {4, 0.20m},
            {5, 0.25m}
        };

        /// <summary>
        /// Calculates the discount
        /// </summary>
        /// <param name="numberOfBooks"></param>
        /// <returns></returns>
        public decimal GetDiscount(int numberOfBooks)
        {
            return 1 - catalogue[numberOfBooks];
        }
    }
}
