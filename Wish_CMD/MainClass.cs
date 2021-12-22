using System;
using System.IO;


namespace Wish_CMD
{
    internal class MainClass
    {

        //classen aufruf
        
        static commands input = new commands();
        static  prints prints = new prints();
        static Register register = new Register();
        static MainClass mainClass = new MainClass();
   

        //####################################
        //#  Fertig:                         #
        //#  1. Register                     #
        //#  2. Commands                     #
        //#  3. Register Optisch Überarbeitet#
        //#                                  #
        //####################################
        //#  check list:                     #
        //#  1. Menu                         #
        //####################################



        

        public static void Main(string[] args)
        {
            register.login();
        }

        public void manage_task(int ID, string name)
        {

            MainClass main = new MainClass();
            prints.Menu(name);
            string input = Console.ReadLine();
            prüfer(input, ID, name);

        }


        public void Debuger(string content)
        {
            Console.WriteLine("----------Debug-------------");
            Console.WriteLine("Comments Hört dem chat zu!!");
            Console.WriteLine(content);
            
        }


        static void prüfer(string input, int ID, string name)
        {
            string na = name;
            MainClass main = new MainClass();
            commands command = new commands();
            prints.print("Prüfer", 0);
            prints.print("", 1);

            int list = command.befehle.GetLength(0);
            int i = 0;

            while (i < list)
            {
                if ((string)command.befehle[i, 1] == input && (int)command.befehle[i, 0] == Convert.ToInt32(ID))
                {

                    command.taskmanager((string)command.befehle[i, 2], name);


                }
                
                i++;
            } 
            prints.print("Du hast keine Bereichtgung für diesen Befehl !!", 0); 
            prints.print("", 1);
            main.manage_task(ID, na);
            
        }



    }

}
