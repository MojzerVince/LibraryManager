using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LibraryManager
{
    internal class IBookHandler
    {
        List<Book> books = new List<Book>();

        public void BookLoad()
        {
            StreamReader sr = new StreamReader("books.txt");
            sr.ReadLine(); //kihagyja az 1. sort, amiben csak a format van
            while (!sr.EndOfStream)
            {
                string[] data = sr.ReadLine().Split("|");
                for (int i = 0; i < data.Length; i++)
                {
                    //Console.Write($"{data[i++]}|{data[i++]}|{data[i++]}|{data[i++]}|{data[i++]}|{data[i++]}\n");
                    Book b = new Book(int.Parse(data[i++]), data[i++], data[i++], data[i++], int.Parse(data[i++]), byte.Parse(data[i++]));
                    books.Add(b);
                }
            }
            sr.Close();
            Console.WriteLine("-------");
            //Console.OutputEncoding = Encoding.ASCII;
            foreach (Book b in books) Console.WriteLine(b.ToString());
        }

        protected void AddEntry()
        {

        }

        protected void RemoveEntry()
        {

        }
    }
}
