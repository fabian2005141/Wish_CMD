using System;
using System.Text;
using Financen;
using System.Security.Cryptography;


namespace Wish_CMD
{
    internal class commands
    {

        static MainClass MainClass = new MainClass();
        static prints prints = new prints();
        static commands Commands = new commands();
        static Program finance = new Program();
        static Data data_base = new Data(@"D:\Dokumente\Projekte\C#\Wish_CMD\Wish_CMD\Saves\Data.txt");
        static Register register = new Register();



        // ID's : 0 = Für jeden, 1 = für verwalter, 2 = nur für admin
        public object[,] befehle =
        {
            {2, "/exit", "exit"},
            {2, "/debug", "debug" },
            {1, "/mony", "mony" },
            {2, "/add user", "add"}
            
        };



        //task manager
        public void taskmanager(string befehle, string name)
        {
            switch (befehle)
            {
                case "exit":
                    exit();
                    break;
                
                case "debug":
                    debug(name);
                    break;
                
                case "add":
                    Add_user();
                    break;
                
                default:
                    return;
                    break;

            }


        }

        static void Add_user()
        {
            prints.Add_UI(0);
            Console.WriteLine("Gib den Namen des Benutzers ein:");
            string Username = Console.ReadLine();
            prints.Add_UI(0);
            Console.WriteLine("Gib Das Passwort des Benutzers ein:");
            string Pass = Console.ReadLine();
            prints.Add_UI(0);
            Console.WriteLine("Rechte : 0 = Gast, 2 = Verwalter, 3 = Admin");
            Console.WriteLine("Git die Rechte des Benutzers ein :");
            string id = Console.ReadLine();

            if (Username == null || Pass == null || id == null  || Username == "" || Pass == "" || id == "")
            {
                Console.Clear();
                Console.WriteLine("Add User Error !!");
                Console.ReadKey();
                return;
            }
            else
            {
                if (Convert.ToInt32(id) > 2)
                {
                    id = "2";
                }else if (Convert.ToInt32(id) < 0)
                {
                    id = "0";
                }


                // Helpo !!!
                //data_base.Add_data(string[])
                
                return;
            }

        }
        
        
        static void Verschlüsseln(int id,string Username,string input)
        {
            byte[] tmpSource;
            byte[] tmpHash;
            string sSourceData = input;
            //Create a byte array from source data.
            tmpSource = ASCIIEncoding.ASCII.GetBytes(sSourceData);
            tmpHash = new MD5CryptoServiceProvider().ComputeHash(tmpSource);
            string ByteArrayToString(byte[] arrInput)
            {
                int i;
                StringBuilder sOutput = new StringBuilder(arrInput.Length);
                for (i=0;i < arrInput.Length; i++)
                {
                    sOutput.Append(arrInput[i].ToString("X2"));
                }

                input = sOutput.ToString();
                string[] testdata = {id.ToString(), Username, input};
                data_base.Add_data(testdata);
                return sOutput.ToString();
            }
      
        }

        static void mony()
        {

        }

        static void exit()
        {
            Environment.Exit(0);
        }


        static void debug(string name)
        {
            Debugclass debug = new Debugclass();
            debug.test(name);

        }

        public class Debugclass
        {

            public void test(string name)
            {


                switch (name)
                {
                    case "Wolf":
                        prints.print("case 1", 0);
                        prints.print("case 1", 2);
                    break;

                    case "Fabian":
                        prints.print("case 2", 0);
                        prints.print("case 2", 2);
                    break;

                    default:
                        prints.print("defalt", 0);
                        prints.print("defalt", 2);
                    break;

                }
            }

        }

    }

    
}
