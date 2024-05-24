using ConsoleTables;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static System.Reflection.Metadata.BlobBuilder;

namespace LibraryManager.Interface
{
    internal class IStudentHandler
    {
        static List<Student> students = new List<Student>();

        public void StudentLoad()
        {
            StreamReader sr = new StreamReader("Data/students.txt");
            students.Clear(); //törli az eddigi bejegyzéseket, különben duplikálódnak
            while (!sr.EndOfStream)
            {
                string[] data = sr.ReadLine().Split("|");
                for (int i = 0; i < data.Length; i++)
                {
                    //Console.Write($"{data[i++]}|{data[i++]}|{data[i++]}|{data[i++]}|{data[i++]}|{data[i++]}\n");
                    Student s = new Student(int.Parse(data[i++]), data[i++], data[i++], data[i++], data[i++], data[i++], data[i++]);
                    students.Add(s);
                }
            }
            sr.Close();
            Console.WriteLine("-------");
            //Console.OutputEncoding = Encoding.ASCII;
            //foreach (Book b in books) Console.WriteLine(b.ToString());

            //táblázat létrehozása oszlopokkal
            var table = new ConsoleTable("ID", "Name", "Email", "Student Card Number", "Password", "Student Birth Date", "Student Contact")
                .Configure(o => o.EnableCount = false); //Kikapcsolja a Count-ot a kiíratás végéről
            //sorok hozzáadása a táblázathoz
            foreach (Student s in students) table.AddRow(s.Std_id, s.Std_name, s.Std_email, s.Std_no, s.Password, s.Std_bdate, s.Contact);
            Console.WriteLine(table.ToString()); //táblázat megjelenítése
        }
    }
}
