using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleAppLibv2025.Model
{
    public class Book
    {
        
        public string Title { get; set; }
        public string Author { get; set; }
        public string ISBN { get; set; }
        public DateTime PublishedDate { get; set; }

        public override string ToString()
        {
            return $" Title: {Title}, Author: {Author},ISBN: {ISBN}, Published Date: {PublishedDate.ToShortDateString()}";
        }
    }
}
