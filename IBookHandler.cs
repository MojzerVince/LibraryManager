using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LibraryManager
{
    internal class IBookHandler
    {

        public void BookLoad()
        {
            StreamReader sr = new StreamReader("books.txt");
            sr.ReadLine(); //kihagyja az 1. sort, amiben csak a format van
            while (!sr.EndOfStream)
            {
                string[] data = sr.ReadLine().Split("|");
                for (int i = 0; i < data.Length; i++)
                {
                    Console.Write($"{data[i++]}|{data[i++]}|{data[i++]}|{data[i++]}|{data[i++]}|{data[i++]}\n");
                }
            }
        }

        protected void AddEntry()
        {

        }

        protected void RemoveEntry()
        {

        }
    }
}
