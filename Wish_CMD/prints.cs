using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Wish_CMD
{
    internal class prints
    {
        static prints Prints = new prints();
        public void print(string content, int mode)
        {
            Console.OutputEncoding = System.Text.Encoding.UTF8;
            if (mode == 0)
            {
                Console.WriteLine(content);
            }
            else if (mode == 1)
            {
                Console.Clear();
            }else if (mode == 2)
            {
                Console.ReadKey();
            }
            
        }
        public void Menu(string name)
        {
            Console.OutputEncoding = System.Text.Encoding.UTF8;
            Prints.print("", 1);
            Prints.print("Willkommen" + " " + name, 0);
            Prints.print("/help für alle Befehle:", 0);
            Prints.print("##############################", 0);   
        }

        public void Add_UI(int mode)
        {
            if (mode == 0)
            {
                Console.Clear();
                Console.WriteLine("#####################");
                Console.WriteLine("# Nutzer Hinzufügen #");
                Console.WriteLine("#####################");
            }
        }
    }
}
