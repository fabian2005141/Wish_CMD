using System;
using System.Text;
using System.IO;


namespace Wish_CMD
{
    internal class Register
    {
        static Data data_base = new Data(@"D:\Dokumente\Projekte\C#\Wish_CMD\Wish_CMD\Saves\Data.txt");
        static MainClass mainClass = new MainClass();
        static prints prints = new prints();
        static Register register = new Register();
        static int pw_fail = 0;
        static bool i = true;

        //Id's: 0 = gast, 1 = verwaltung, 2 = admin
        public void login()
        {
            //mainClass.manage_task(2, "Fabian");
            if (pw_fail == 3)
            {
                Environment.Exit(0);
            }
            while (i == true)
            {
                Console.Clear();
                prints.print("Welcome User", 0);
                prints.print("Plese enter you name!", 0);
                prints.print("##############################", 0);
                string input = Console.ReadLine();
                if (input != "")
                {
                    string name = input;
                    i = false;
                    password(name);
                }
                else
                {
                    Console.Clear();
                    prints.print("input error, plese enter your name agan!!!", 0);
                    Console.ReadKey();
                }
            }
        }
        static void password(string name)
        {
            while (i == false)
            {
                Console.Clear();
                prints.print("Welcome" + " " + name, 0);
                prints.print("Plese enter your Password!!!", 0);
                prints.print("##############################", 0);
                string input = Console.ReadLine();
                if (input != "")
                {
                    i = true;
                    
                    prüfer(name, input);
                    
                }
            }
        }
        
        static void Verschlüsseln(string input, string name)
        {

        }

        static void prüfer(string name, string PW)
        {
            int rownumber = data_base.data.GetLength(0);
            for (int i = 0; i < rownumber; i++)
            {
                if (name == (string)data_base.data[i, 1] && PW == (string)data_base.data[i, 2])
                {
                    int ID = Convert.ToInt32(data_base.data[i, 0]);
                    Forwarding(ID, name);
                }
            }
            prints.print("", 1);
            prints.print("error", 0);
            pw_fail++;
            register.login();
        }

        static void Forwarding(int ID, string name)
        {
            mainClass.manage_task(ID, name);
        }
    }
    public class Data
    {
        public string[,] data { get; private set; }
        private string path;
        public Data(string path)
        {
            this.path = path;
            Read_data();
        }
        private void Read_data()
        {
            string [] buffer = File.ReadAllLines(path);
            data = new string[buffer.Length, 3];
            for (int i = 0; i < buffer.Length; i++)
            {
                string[] currentelement = buffer[i].Split(',');
                for (int j = 0; j < 3; j++)
                {
                    data[i, j] = currentelement[j];
                }
            }
        }
        public void Add_data(string[] data)
        {
            string formatetdata = "";
            for (int i = 0; i < data.Length; i++)
            {
                if (i < data.Length - 1)
                {
                    formatetdata += data[i] + ",";
                }
                else
                {
                    formatetdata += data[i];
                }
            }
            string [] oldformatet_data = new string [this.data.GetLength(0)];
            for (int i = 0; i < this.data.GetLength(0); i++)
            {
                for (int j = 0; j < this.data.GetLength(1); j++)
                {
                    if (j < this.data.GetLength(1) - 1)
                    {
                        oldformatet_data[i] += this.data[i, j] + ",";
                    }
                    else
                    {
                        oldformatet_data[i] += this.data[i, j];
                    }
                }
            }
            Console.WriteLine(formatetdata);
            string[] overwrite_data = new string[this.data.GetLength(0) + 1];
            for (int i = 0; i < overwrite_data.Length; i++)
            {
                if (i < overwrite_data.Length - 1)
                {
                    overwrite_data[i] = oldformatet_data[i];
                }
                else
                {
                    overwrite_data[i] = formatetdata;
                }
            }
            File.WriteAllLines(this.path, overwrite_data);
            Read_data();
        }
    }
}





