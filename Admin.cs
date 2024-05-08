using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using LibraryManager.Interface;

namespace LibraryManager
{
    internal class Admin : IBookHandler
    {
        private string username;
        private string password;

        public string Username { get => username; set => username = value; }
        public string Password { get => password; set => password = value; }

        public Admin(string usern, string passw) //konstruktor
        {
            Username = usern;
            Password = passw;
        }

        public void DashBoard()
        {
            Console.Clear();
            Console.BackgroundColor = ConsoleColor.White;
            Console.ForegroundColor = ConsoleColor.Black;
            Console.WriteLine("Admin Dashboard");
            Console.ResetColor();
            Console.WriteLine($"Welcome back, {username}!");
            Console.WriteLine("Options: Book list(1) Student list(2) Exit(0)");
            
            ConsoleKeyInfo key = Console.ReadKey();

            switch (key.Key)
            {
                case ConsoleKey.NumPad0:
                case ConsoleKey.D0:
                    Console.Clear();
                    Console.WriteLine("Exiting...");
                    break;
                case ConsoleKey.NumPad1:
                case ConsoleKey.D1:
                    BookList();
                    break;
                default:
                    Console.Clear();
                    DashBoard();
                    break;
            }
        }

        private void BookList()
        {
            Console.Clear();
            Console.WriteLine("Book List");
            BookLoad();
            Console.WriteLine("Options: Add book(1) Remove book(2)");
            ConsoleKeyInfo key = Console.ReadKey(true);
            switch (key.Key)
            {
                case ConsoleKey.NumPad1:
                case ConsoleKey.D1:
                    AddBook();
                    break;
                case ConsoleKey.NumPad2:
                case ConsoleKey.D2:
                    RemoveEntry();
                    break;
            }
        }
    }
}
