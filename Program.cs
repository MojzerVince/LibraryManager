using System.Runtime.CompilerServices;

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
        static List<Student> students = new List<Student>();

        static void Main(string[] args)
        {
            Console.Write("Admin(1)/Student(2) Login: ");

            ConsoleKeyInfo key = Console.ReadKey(true);
            switch (key.Key)
            {
                case ConsoleKey.NumPad1:
                case ConsoleKey.D1:
                    AdminLogin();
                    break;
                case ConsoleKey.NumPad2:
                case ConsoleKey.D2:
                    Console.Clear();
                    Console.Write("Student profile registration(1) | Student login(2) ");
                    string opt = Console.ReadLine();
                    if (opt == "1") StudentReg();
                    else if (opt == "2") StudentLogin();
                    else Console.WriteLine("An unexpected error occured!"); //leszarom a kivételkezelést
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
                    if(type == "admin")
                    {
                        Admin admin = new Admin(username, password);
                        admin.DashBoard();
                    }
                    else if(type == "student")
                    {
                        //idk
                    }
                    break; //ha megtalálta, akkorne fusson tovább feleslegesen
                }
                n++;
            }
            sr.Close();
        }

        static void AdminLogin()
        {
            Console.Clear();
            Console.WriteLine("ADMIN LOGIN");

            Console.Write("Username: ");
            string username = Console.ReadLine();
            Console.Write("Password: ");
            string password = Console.ReadLine();

            Load(username, password, "admin");
        }

        static void StudentLogin()
        {
            Console.Clear();
            Console.WriteLine("STUDENT LOGIN");

            Console.Write("Username: ");
            string username = Console.ReadLine();
            Console.Write("Password: ");
            string password = Console.ReadLine();

            Load(username, password, "student");
        }

        static void StudentReg()
        {
            Console.Clear();
            Console.WriteLine("STUDENT REGISTRATION");

            StreamWriter sw = new StreamWriter("studentlogins.txt", true); //append

            Console.Write("Student name: ");
            string name = Console.ReadLine();
            sw.Write("\n" + name + " ");
            Console.Write("Student card number: ");
            int number = int.Parse(Console.ReadLine());
            Console.Write("Student email: ");
            string email = Console.ReadLine();
            Console.Write("Account password: ");
            string password = Console.ReadLine();
            sw.Write(password  + " ");
            Console.Write("Student birth date (yyyy-mm-dd): ");
            string bdate = Console.ReadLine();
            Console.Write("Student contact: ");
            string contact = Console.ReadLine();
            sw.Close();

            StreamReader sr = new StreamReader("students.txt");
            //string[] data;
            string line;
            if (sr.EndOfStream)
            {
                //data = sr.ReadLine().Split("|");
                line = sr.ReadLine();
            }
            else line = "";

            //int id = int.Parse(data[0]);
            int id;
            if (line == "") id = int.Parse(line.Substring(0, line.IndexOf("|")))+1;
            else id = 0;
            Student std = new Student(id, name, email, number, password, bdate, contact);
            students.Add(std);
            //StudentLogin();
        }
    }
}
