using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PotterKata.src.Model
{
    /// <summary>
     // This class represents a set of books.
    /// </summary>
    internal class BookSet
    {
        //List that holds books.
        private readonly List<int> books = new List<int>();

        // An instance of the DiscountCatalog class that holds the discount information.
        private readonly DiscountCatalog discounts = new DiscountCatalog();

        //Adds book to set.
        public BookSet(int book)
        {
            books.Add(book);
        }

        //Calculate the TotalPrice of books list.
        public decimal Total => CalculateTotalPrice();

        private decimal CalculateTotalPrice()
        {
            return CalculatePrice(books);
        }

        //To check if book is in the list.
        public bool BookNotInSet(int book)
        {
            return !books.Contains(book);
        }

        //This adds book to set.
        public void AddBookToSet(int book)
        {
            books.Add(book);
        }

        //Calculates the TotalPrice with the book.
        public decimal TotalWith(int book)
        {
            return CalculatePrice(books.Concat(new[] { book }));
        }

        //Calculates the price after applying discount from the DiscountClass.
        private decimal CalculatePrice(IEnumerable<int> books)
        {

            return 8 * books.Count() * discounts.GetDiscount(books.Count());
        }

    }
}
