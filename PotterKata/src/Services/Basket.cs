using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using PotterKata.src.Model;

namespace PotterKata.src.Services
{
    /// <summary    
    ///  // This class represents a basket of book sets.
    /// </summary>
    internal class Basket
    {
        //List that holds book set in the basket.
        private readonly List<BookSet> bookSets = new List<BookSet>();

        public Basket(params int[] books)
        {
            InitializeBasket(books);
        }

        /// <summary>
        /// Sort the basket as per the books selected.
        /// </summary>
        /// <param name="books"></param>
        public void InitializeBasket(params int[] books)
        {
            var sortedByOccurrence = books.GroupBy(b => b)
                                          .OrderByDescending(g => g.Count())
                                          .SelectMany(b => b);

            foreach (var b in sortedByOccurrence)
                AddToExistingSetOrCreateNewSet(b);
        }


        /// <summary>
        /// This method is where we get the set of books or create new.
        /// </summary>
        /// <param name="book"></param>
        private void AddToExistingSetOrCreateNewSet(int book)
        {
            if (bookSets.Any(s => s.BookNotInSet(book)))
                bookSets.Where(g => g.BookNotInSet(book))
                    .OrderBy(s => TotalWithNewBookInSet(s, book))
                    .First()
                    .AddBookToSet(book);
            else
                bookSets.Add(new BookSet(book));

        }

        // this calculates and returns the total price of the book sets in the basket.
        public decimal BasketTotal => CalculateTotal();

        private decimal CalculateTotal()
        {
            return bookSets.Sum(set => set.Total);
        }

        /// <summary>
        /// We calculate the total price with new book added to specified set subtract total
        /// price of all sets and then add total price of specified set with the book.
        /// </summary>
        /// <param name="set"></param>
        /// <param name="book"></param>
        /// <returns></returns>
        private decimal TotalWithNewBookInSet(BookSet set, int book)
        {
            return TotalWith(bookSets) - set.Total + set.TotalWith(book);
        }

        //Sum of the set passed.
        private decimal TotalWith(IEnumerable<BookSet> sets)
        {
            return sets.Sum(s => s.Total);
        }
    }
}
