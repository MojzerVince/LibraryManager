using ConsoleTables; //Konzolra való egyszerűbb kiíratás érdekében
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LibraryManager.Interface
{
    internal class IBookHandler
    {
        static List<Book> books = new List<Book>();

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

        protected void AddBook()
        {
            Console.Clear();
            Console.WriteLine("BOOK REGISTRATION");

            Console.Write("Book title: ");
            string title = Console.ReadLine();
            Console.Write("Book author: ");
            string author = Console.ReadLine();
            Console.Write("Release date (yyyy): ");
            string release = Console.ReadLine();
            Console.Write("Price: ");
            string price = Console.ReadLine();
            Console.Write("Quantity available: ");
            string quantity = Console.ReadLine();

            //-- automata id hozzárendelés
            StreamReader sr = new StreamReader("Data/books.txt");
            string line = "";
            //ha van már sor, akkor megnézi a legutolsót és annak az id-jához ad plusz 1-et
            while (!sr.EndOfStream) line = sr.ReadLine();
            //else line = ""; //ha nincs, akkor legyen az első sor üres, ez később if-ben hasznos
            sr.Close();
            int id;
            //ha már van sor, akkor kiszedő az utolsóból az id-t és hozzáad 1-et
            if (line != "") id = int.Parse(line.Substring(0, line.IndexOf("|"))) + 1;
            else id = 0; //ha nincs még sor, akkor automatán 0 lesz az id

            //Book példányosítás
            Book book = new Book(id, title, author, release, int.Parse(price), byte.Parse(quantity));
            books.Add(book); //példány hozzáadás a tanulókat tartalmazó listába
            ListUpdater();
        }

        protected void RemoveEntry()
        {

        }

        private void ListUpdater()
        {

        }
    }
}
