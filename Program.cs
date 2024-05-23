using System.Runtime.CompilerServices;

namespace LibraryManager
{
    struct Pass
    {
        public string username;
        public string password;
        public int id;
    }

    internal class Program
    {
        static int n = 0;
        static Pass[] pass = new Pass[50];
        //static List<Student> students = new List<Student>();

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
                    else if (opt == "2") StudentLogin(null);
                    else Console.WriteLine("An unexpected error occured!"); //leszarom a kivételkezelést
                    break;
                default:
                    Console.Clear();
                    Console.WriteLine($"Please choose from the options! You pressed: {key.Key}");
                    break;
            }
        }

        static void Load(string username, string password, string type, Student std=null)
        {
            StreamReader sr = new StreamReader("Data/"+type+"logins.txt");

            while(!sr.EndOfStream)
            {
                string line = sr.ReadLine();
                string[] data = line.Split("|");

                pass[n].username = data[0];
                pass[n].password = data[1];
                pass[n].id = int.Parse(data[2]);

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
                        if(std != null)
                            std.BookList();
                        else if(std == null)
                        {
                            string line2 = "999999999"; //kell ide ez a nagy szám, mert anélkül a Substring hibát dob, meg nem tud rendesen összehasonlítani
                            StreamReader sr2 = new StreamReader("Data/students.txt");
                            //addig megy amíg meg nem találja az id-hoz tartozó adatokat
                            while (pass[n].id != int.Parse(line2.Substring(0,1)))
                                line2 = sr2.ReadLine(); //elmenti hogy később tudjuk Substringelni
                            sr2.Close();
                            string[] data2 = line2.Split("|"); //adatfeldolgozás
                            
                            //Student példányosítás
                            Student std2 = new Student(int.Parse(data2[0]), data2[1], data2[2], data2[3], data2[4], data2[5], data2[6]);
                            std2.BookList();
                        }
                    }
                    break; //ha megtalálta, akkorne fusson tovább feleslegesen
                }
                else
                {
                    Console.WriteLine("Wrong username or password! Please try again!");
                    Thread.Sleep(2000);
                    if (type == "admin") AdminLogin();
                    else if(type == "student") StudentLogin(std);
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

        static void StudentLogin(Student std) //kéri paraméterként az std-t, hogy tovább tudja adni a Load()-ba
        {
            Console.Clear();
            Console.WriteLine("STUDENT LOGIN");

            Console.Write("Username: ");
            string username = Console.ReadLine();
            Console.Write("Password: ");
            string password = Console.ReadLine();

            Load(username, password, "student", std);
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
            sw.Write(password + "|");
            Console.Write("Student birth date (yyyy-mm-dd): ");
            string bdate = Console.ReadLine();
            Console.Write("Student contact: ");
            string contact = Console.ReadLine();

            //-- automata id hozzárendelés
            StreamReader sr = new StreamReader("Data/students.txt");
            string line = "";
            //ha van már sor, akkor megnézi a legutolsót és annak az id-jához ad plusz 1-et
            while (!sr.EndOfStream) line = sr.ReadLine();
            //else line = ""; //ha nincs, akkor legyen az első sor üres, ez később if-ben hasznos
            sr.Close();
            int id;
            //ha már van sor, akkor kiszedő az utolsóból az id-t és hozzáad 1-et
            if (line != "") id = int.Parse(line.Substring(0, line.IndexOf("|")))+1;
            else id = 0; //ha nincs még sor, akkor automatán 0 lesz az id
            sw.Write(id);
            sw.Close();

            //Student példányosítás
            Student std = new Student(id, name, email, number, password, bdate, contact);
            //students.Add(std); //példány hozzáadás a tanulókat tartalmazó listába
            StudentLogin(std); //regisztráció utáni bejelentkeztetés
        }
    }
}
