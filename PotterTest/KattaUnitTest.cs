using PotterKata.src.Services;

namespace PotterTest
{

    public class KattaUnitTest 
    {

        private readonly Calculator _calculator;
        public KattaUnitTest()
        {
            _calculator = new Calculator(); 
        }

       

       [Fact]
       public void No_books_in_the_cart()
        { 
          
            Assert.Equal(0, actual: _calculator.Price());
       }

        [Fact]
        public void One_book_is_in_the_cart_price_8()
        {
           
            Assert.Equal(8, actual: _calculator.Price(0));
        }

        [Fact]
        public void Two_same_book_is_in_the_cart_price_16()
        {
          
            Assert.Equal(8 * 2, actual: _calculator.Price(0,0));
        }

        [Fact]
        public void Three_same_book_is_in_the_cart_price_24()
        {
           
            Assert.Equal(8 * 3, actual: _calculator.Price(0, 0, 0));
        }

        [Fact]
        public void Two_different_book_should_give_discount_5_percent()
        {
           
            Assert.Equal((decimal)(8 * 2 * 0.95), actual: _calculator.Price(0,1));
        }

        [Fact]
        public void Three_different_book_should_give_discount_10_percent()
        {
          
            Assert.Equal((decimal)(8 * 3 * 0.9), actual: _calculator.Price(3, 1,4));
        }

        [Fact]
        public void Four_different_book_should_give_discount_20_percent()
        {
         
            Assert.Equal((decimal)(8 * 4 * 0.8), actual: _calculator.Price(3, 1, 4,2));
        }

        [Fact]
        public void Five_different_book_should_give_discount_25_percent()
        {
         
            Assert.Equal((decimal)(8 * 5 * 0.75), actual: _calculator.Price(3, 0,1, 4, 2));
        }

        [Fact]
        public void Two_same_book_and_one_different()
        {
           
            Assert.Equal((decimal)(8 +(8 * 2 * 0.95)), actual: _calculator.Price(0, 0, 1));
        }

        [Fact]
        //Here we created 2 sets of 4 to give max discount. -- 51.2
        //If we had created set of 5 and 3 we would have got less discount. -- 51.6
        public void Mix_and_match_of_books()
        {
           
            Assert.Equal((decimal)51.2, actual: _calculator.Price(0, 0, 1, 1, 2, 2, 3, 4));

           
        }

        [Fact]
        //5,4 and 2 same 1 different
        public void Multi_Book_Test()
        {
         
            Assert.Equal((decimal)78.8, actual: _calculator.Price(0, 0, 0, 1, 1, 2, 2, 2, 2, 3, 3, 4));
          
        }


    }
} 