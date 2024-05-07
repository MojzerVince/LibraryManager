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
                default:
                    Console.Clear();
                    Console.WriteLine($"Please choose from the options! You pressed: {key.Key}");
                    break;
            }
        }

        static void Load(string username, string password, string type)
        {
            StreamReader sr = new StreamReader("Data/"+type+"logins.txt");

            while(!sr.EndOfStream)
            {
                string line = sr.ReadLine();
                string[] data = line.Split("|");

                pass[n].username = data[0];
                pass[n].password = data[1];

                if (pass[n].username == username && pass[n].password == password)
                {
                    Console.WriteLine("Success " + type);
                    Thread.Sleep(500);
                    Console.WriteLine("Loading...");
                    Thread.Sleep(1500);
                    if (type == "admin")
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

            StreamWriter sw = new StreamWriter("Data/studentlogins.txt", true); //append

            Console.Write("Student name: ");
            string name = Console.ReadLine();
            sw.Write("\n" + name + "|");
            Console.Write("Student card number: ");
            string number = Console.ReadLine();
            Console.Write("Student email: ");
            string email = Console.ReadLine();
            Console.Write("Account password: ");
            string password = Console.ReadLine();
            sw.Write(password);
            Console.Write("Student birth date (yyyy-mm-dd): ");
            string bdate = Console.ReadLine();
            Console.Write("Student contact: ");
            string contact = Console.ReadLine();
            sw.Close();

            //-- automata id hozzárendelés
            StreamReader sr = new StreamReader("Data/students.txt");
            string line = "";
            //ha van már sor, akkor megnézi a legutolsót és annak az id-jához ad plusz 1-et
            while (!sr.EndOfStream) line = sr.ReadLine();
            //else line = ""; //ha nincs, akkor legyen az első sor üres, ez később if-ben hasznos
            Console.WriteLine("sor: " + line);
            sr.Close();
            int id;
            //ha már van sor, akkor kiszedő az utolsóból az id-t és hozzáad 1-et
            if (line != "") id = int.Parse(line.Substring(0, line.IndexOf("|")))+1;
            else id = 0; //ha nincs még sor, akkor automatán 0 lesz az id

            //Student példányosítás
            Student std = new Student(id, name, email, number, password, bdate, contact);
            students.Add(std); //példány hozzáadás a tanulókat tartalmazó listába
            StudentLogin(); //regisztráció utáni bejelentkeztetés
        }
    }
}
