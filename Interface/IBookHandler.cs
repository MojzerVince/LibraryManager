using ConsoleTables; //Konzolra való egyszerűbb kiíratás érdekében
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LibraryManager.Interface
{
    internal class IBookHandler : ConsoleTable
    {
        List<Book> books = new List<Book>();

        public void BookLoad()
        {
            StreamReader sr = new StreamReader("Data/books.txt");
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
            //foreach (Book b in books) Console.WriteLine(b.ToString());

            //táblázat létrehozása oszlopokkal
            var table = new ConsoleTable("ID", "Title", "Author", "Release Date", "Price", "Quantity Available")
                .Configure(o => o.EnableCount = false); //Kikapcsolja a Count-ot a kiíratás végéről
            //sorok hozzáadása a táblázathoz
            foreach (Book b in books) table.AddRow(b.Book_id, b.Title, b.Author, b.Rl_date, b.Price, b.Quant_avail);
            Console.WriteLine(table.ToString()); //táblázat megjelenítése
        }

        protected void AddEntry()
        {

        }

        protected void RemoveEntry()
        {

        }
    }
}
