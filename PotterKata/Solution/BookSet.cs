using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PotterKata.Solution
{
    /// <summary>
    /// This class is the book set.
    /// </summary>
    internal class BookSet
    {
        private readonly List<int> books = new List<int>();
        private readonly DiscountCatalog discounts = new DiscountCatalog();

        public BookSet(int book)
        {
            books.Add(book);
        }


        public decimal Total => CalculateTotalPrice();

        private decimal CalculateTotalPrice()
        {
            return CalculatePrice(books);
        }


        public bool BookNotInSet(int book)
        {
            return !books.Contains(book);
        }

        public void AddBookToSet(int book)
        {
            books.Add(book);
        }

        public decimal TotalWith(int book)
        {
            return CalculatePrice(books.Concat(new[] { book }));
        }

        private decimal CalculatePrice(IEnumerable<int> books)
        {

            return 8 * books.Count() * (discounts.GetDiscount(books.Count()));
        }

    }
}
