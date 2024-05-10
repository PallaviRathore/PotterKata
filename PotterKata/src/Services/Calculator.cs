using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PotterKata.src.Services
{
    /// <summary>
    /// //This class calculates the price.We pass the books as list of integer.
    /// </summary>
    public class Calculator
    {
        public decimal Price(params int[] books)
        {
            var basket = new Basket(books);

            return basket.BasketTotal;
        }
    }
}
