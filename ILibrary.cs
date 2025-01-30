using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ConsoleAppLibv2025.Model;

namespace ConsoleAppLibv2025.Service
{
    public interface ILibrary
    {
        void ListAllBooks();
        void AddBook(Book book);
        void EditBook(string isbn);
        void RemoveBook(string isbn);
        void SearchByAuthor(string author);
        void SearchByTitle(string title);
    }
}
