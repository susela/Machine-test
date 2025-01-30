using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using ConsoleAppLibv2025.Model;

namespace ConsoleAppLibv2025.Service
{
    public class Library : ILibrary
    {
        private Dictionary<string, Book> books = new Dictionary<string, Book>();
        private string GenerateUniqueISBN()
        {
            Random random = new Random();
            string isbn;

            do
            {
                // Generate the first 12 digits randomly
                string isbnWithoutChecksum = random.Next(100000000, int.MaxValue).ToString("000000000000");

                // Calculate the checksum digit for the ISBN-13
                int checksum = 0;
                for (int i = 0; i < 12; i++)
                {
                    int digit = int.Parse(isbnWithoutChecksum[i].ToString());
                    checksum += (i % 2 == 0) ? digit : digit * 3;
                }

                checksum = (10 - (checksum % 10)) % 10;

                // Combine the first 12 digits with the checksum digit
                isbn = isbnWithoutChecksum + checksum.ToString();

            } while (books.ContainsKey(isbn)); // Ensure the generated ISBN is unique

            return isbn;
        }


        public void ListAllBooks()
        {
            try
            {
                if (books.Count == 0)
                {
                    Console.ForegroundColor = ConsoleColor.Red;
                    Console.WriteLine("No books available");
                    Console.ResetColor();
                    return;
                }

                Console.ForegroundColor = ConsoleColor.Cyan;
                Console.WriteLine("\n-------------------------------------------------------------------------------");
                Console.WriteLine("|                              Library Management                           |");
                Console.WriteLine("--------------------------------------------------------------------------------");
                Console.WriteLine("| Title                     | Author       | ISBN          | Published Date |");
                Console.WriteLine("--------------------------------------------------------------------------------");
                Console.ResetColor();

                foreach (var book in books.Values)
                {
                    Console.ForegroundColor = ConsoleColor.Magenta;
                    Console.WriteLine($"| {book.Title,-25} | {book.Author,-12} | {book.ISBN,-13} | {book.PublishedDate.ToShortDateString(),-14} |");
                    Console.ResetColor();
                }

            }
            catch (Exception ex)
            {
                Console.WriteLine("Error listing books: " + ex.Message);
            }
        }

        public void AddBook(Book book)
        {
            try
            {
                
                if (string.IsNullOrEmpty(book.ISBN))
                {
                    book.ISBN = GenerateUniqueISBN();
                }
                if (!Regex.IsMatch(book.ISBN, "^\\d+$"))
                {
                    Console.ForegroundColor = ConsoleColor.Yellow;
                    throw new ArgumentException("Invalid ISBN. It must contain only numbers.");
                    Console.ResetColor();
                }
                if (books.ContainsKey(book.ISBN))
                {
                    Console.ForegroundColor = ConsoleColor.DarkBlue;
                    Console.WriteLine("Book with this ISBN already exists.");
                    Console.ResetColor();
                    return;
                }
                books[book.ISBN] = book;
                Console.ForegroundColor = ConsoleColor.Green;
                Console.WriteLine("Book added successfully.");
                Console.ResetColor();
            }
            catch (Exception ex)
            {
                Console.WriteLine("Error adding book: " + ex.Message);
            }
        }

        public void EditBook(string isbn)
        {
            try
            {
                if (!books.ContainsKey(isbn))
                {
                    Console.ForegroundColor = ConsoleColor.Red;
                    Console.WriteLine("Book not found.");
                    Console.ResetColor();
                    return;
                }
                Console.Write("Enter new Title: ");
                string title = Console.ReadLine();
                Console.Write("Enter new Author: ");
                string author = Console.ReadLine();
                books[isbn].Title = title;
                books[isbn].Author = author;
                Console.ForegroundColor = ConsoleColor.Green;
                Console.WriteLine("Book details updated successfully.");
                Console.ResetColor();
            }
            catch (Exception ex)
            {
                Console.WriteLine("Error editing book: " + ex.Message);
            }
        }

        public void RemoveBook(string isbn)
        {
            try
            {
                if (books.Remove(isbn))
                    Console.WriteLine("Book removed successfully.");
                else
                    Console.WriteLine("Book not found.");
            }
            catch (Exception ex)
            {
                Console.WriteLine("Error removing book: " + ex.Message);
            }
        }

        public void SearchByAuthor(string author)
        {
            try
            {
                var results = books.Values.Where(b => b.Author.Equals(author, StringComparison.OrdinalIgnoreCase)).ToList();
                if (results.Count == 0)
                    Console.WriteLine("No books found ");
                else
                    results.ForEach(book => Console.WriteLine(book));
            }
            catch (Exception ex)
            {
                Console.WriteLine("Error searching by author: " + ex.Message);
            }
        }

        public void SearchByTitle(string title)
        {
            try
            {
                var results = books.Values.Where(b => b.Title.Contains(title, StringComparison.OrdinalIgnoreCase)).ToList();
                if (results.Count == 0)
                    Console.WriteLine("No books found.");
                else
                    results.ForEach(book => Console.WriteLine(book));
            }
            catch (Exception ex)
            {
                Console.WriteLine("Error searching by title: " + ex.Message);
            }
        }
        
    }
}