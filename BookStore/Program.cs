using System;
using Bookstore.DAL;

namespace Bookstore.ConsoleApp
{
    class Program
    {
        static void Main(string[] args)
        {
            using (var context = new BookstoreDbContext())
            {
                var bookRepository = new BookRepository(context);

                // Add sample books
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
                bookRepository.AddBook(book1);

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
                bookRepository.AddBook(book2);

                // Retrieve a book by ID
                var retrievedBook = bookRepository.GetBookById(1);
                Console.WriteLine($"Retrieved Book: {retrievedBook.Title} by {retrievedBook.Author}");

                // Update a book
                retrievedBook.SellingPrice = 15.00m;
                bookRepository.UpdateBook(retrievedBook);

                // Delete a book
                bookRepository.DeleteBook(2);

                // Retrieve all books
                var books = bookRepository.GetAllBooks();
                Console.WriteLine("All Books:");
                foreach (var book in books)
                {
                    Console.WriteLine($"{book.Id} - {book.Title} by {book.Author}");
                }
            }
        }
    }
}
