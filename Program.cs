namespace LibraryManager
{
    struct Pass
    {
        public string username;
        public string password;
    }

    internal class Program
    {
        static int n = 0;
        static Pass[] pass = new Pass[10];

        static void Main(string[] args)
        {
            Console.WriteLine("Hello, World! \n");
            Console.WriteLine("Admin(1)/Student(2) Login: ");

            ConsoleKeyInfo key = Console.ReadKey(true);
            switch (key.Key)
            {
                case ConsoleKey.NumPad1:
                case ConsoleKey.D1:
                    //Admin admin = new Admin();
                    AdminLogin();
                    break;
                case ConsoleKey.NumPad2:
                case ConsoleKey.D2:
                    //Student student = new Student();
                    StudentLogin();
                    break;
            }
        }

        static void Load(string username, string password, string type)
        {
            StreamReader sr = new StreamReader(type+"logins.txt");

            while(!sr.EndOfStream)
            {
                string line = sr.ReadLine();
                string[] data = line.Split(" ");

                pass[n].username = data[0];
                pass[n].password = data[1];

                if (pass[n].username == username && pass[n].password == password)
                {
                    Console.WriteLine("Success " + type);
                    break;
                }
                n++;
            }
        }

        static void AdminLogin()
        {
            Console.Clear();
            Console.WriteLine("ADMIN LOGIN");

            Console.Write("Username: ");
            string username = Console.ReadLine();
            Console.Write("Password: ");
            string passoword = Console.ReadLine();

            Load(username, passoword, "admin");
        }

        static void StudentLogin()
        {
            Console.Clear();
            Console.WriteLine("ADMIN LOGIN");

            Console.Write("Username: ");
            string username = Console.ReadLine();
            Console.Write("Password: ");
            string passoword = Console.ReadLine();

            Load(username, passoword, "student");
        }
    }
}
