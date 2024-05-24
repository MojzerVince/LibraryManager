using ConsoleTables; //Konzolra való egyszerűbb kiíratás érdekében
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LibraryManager.Interface
{
    internal interface IBookHandler
    {
        public void BookLoad();

        protected void Issue(int id);

        protected void AddBook();

        protected void RemoveEntry();

        protected void ListUpdater();
    }
}
