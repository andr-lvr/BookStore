using System;
using System.Threading.Tasks;
using Bookstore.DAL;

namespace Bookstore.ConsoleApp
{
    class Program
    {
        private static async Task Main(string[] args)
        {
            using (var context = new BookstoreDbContext())
            {
                var bookRepository = new BookRepository(context);

                await AddSampleBooksAsync(bookRepository);
                await RetrieveAndUpdateBookAsync(bookRepository);
                await DeleteBookAsync(bookRepository);
                await DisplayAllBooksAsync(bookRepository);
            }
        }

        private static async Task AddSampleBooksAsync(IBookRepository bookRepository)
        {
            var book1 = new Book
            {
                Title = "The Great Gatsby",
                Author = "F. Scott Fitzgerald",
                Publisher = "Scribner",
                Pages = 180,
                Genre = "Classic",
                YearPublished = 1925,
                CostPrice = 5.00m,
                SellingPrice = 10.00m,
                IsSequel = false
            };

            var book2 = new Book
            {
                Title = "To Kill a Mockingbird",
                Author = "Harper Lee",
                Publisher = "J. B. Lippincott & Co.",
                Pages = 281,
                Genre = "Classic",
                YearPublished = 1960,
                CostPrice = 6.50m,
                SellingPrice = 12.00m,
                IsSequel = false
            };

            await bookRepository.AddBookAsync(book1);
            await bookRepository.AddBookAsync(book2);
        }

        private static async Task RetrieveAndUpdateBookAsync(IBookRepository bookRepository)
        {
            var book = await bookRepository.GetBookByIdAsync(1);
            if (book != null)
            {
                Console.WriteLine($"Retrieved Book: {book.Title} by {book.Author}");

                book.SellingPrice = 15.00m;
                await bookRepository.UpdateBookAsync(book);
            }
        }

        private static async Task DeleteBookAsync(IBookRepository bookRepository)
        {
            await bookRepository.DeleteBookAsync(2);
        }

        private static async Task DisplayAllBooksAsync(IBookRepository bookRepository)
        {
            var books = await bookRepository.GetAllBooksAsync();
            Console.WriteLine("All Books:");
            foreach (var book in books)
            {
                Console.WriteLine($"{book.Id} - {book.Title} by {book.Author}");
            }
        }
    }
}
