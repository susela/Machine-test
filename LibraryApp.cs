using System.Collections.Generic;
using ConsoleAppLibv2025.Model;
using ConsoleAppLibv2025.Service;

namespace ConsoleAppLibv2025
{
    internal class LibraryApp
    {
        static void Main(string[] args)
        {
            ILibrary library = new Library();
            while (true)
            {
                try
                {
                    Console.ForegroundColor = ConsoleColor.Yellow;
                    Console.WriteLine("\nLibrary Management System");
                    Console.WriteLine("1. List All Books");
                    Console.WriteLine("2. Add Book");
                    Console.WriteLine("3. Edit Book");
                    Console.WriteLine("4. Remove Book");
                    Console.WriteLine("5. Search by Author");
                    Console.WriteLine("6. Search by Title");
                    Console.WriteLine("7. Exit");
                    Console.WriteLine("-----------------------------");
                    Console.ResetColor();

                    Console.Write("Enter your choice: ");
                    string choice = Console.ReadLine();

                    switch (choice)
                    {
                        case "1":
                            library.ListAllBooks();
                            break;
                        case "2":
                            
                            Console.Write("Enter Title: ");
                            string title = Console.ReadLine();
                            Console.Write("Enter Author: ");
                            string author = Console.ReadLine();
                            
                            Console.Write("Enter Published Date (YYYY-MM-DD): ");
                            if (DateTime.TryParse(Console.ReadLine(), out DateTime date))
                                library.AddBook(new Book {  Title = title, Author = author, PublishedDate = date });
                            else
                                Console.WriteLine("Invalid Date Format.");
                            
                            break;
                        case "3":
                            Console.Write("Enter ISBN of book to edit: ");
                            library.EditBook(Console.ReadLine());
                            
                            break;
                        case "4":
                            Console.Write("Enter ISBN of book to remove: ");
                            library.RemoveBook(Console.ReadLine());
                            
                            break;
                        case "5":
                            Console.Write("Enter Author Name: ");
                            library.SearchByAuthor(Console.ReadLine());
                            break;
                        case "6":
                            Console.Write("Enter Book Title: ");
                            library.SearchByTitle(Console.ReadLine());
                            break;
                        case "7":
                            return;
                        default:
                            Console.WriteLine("Invalid choice. Please enter a number between 1-7.");
                            break;
                    }
                }
                catch (Exception ex)
                {
                    Console.WriteLine("An unexpected error occurred: " + ex.Message);
                }
            }
            Console.WriteLine("press any key to exit.......");
            Console.ReadKey();
        }
    }

}