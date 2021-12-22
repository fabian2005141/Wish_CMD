using System;
using System.Threading.Tasks;
using System.Text;
using System.IO;

namespace Financen
{
    class Program
    {
        static string Old_Main_Path = @"C:\Users\Fabian\AppData\Roaming\MyData\save-old.dt";
        static string Mainpath = @"C:\Users\Fabian\AppData\Roaming\MyData\save.dt";
        static string Path_kostene = @"C:\Users\Fabian\AppData\Roaming\MyData\kosten.dt";
        static string Path_kleidung = @"C:\Users\Fabian\AppData\Roaming\MyData\Kleidung.dt";
        static string Path_freizeit = @"C:\Users\Fabian\AppData\Roaming\MyData\Freizeit.dt";
        static double euro;
        static double ausgaben;
        static double Kleidung;
        static double Freizeit;
        static double Speicher;
        
        static string übergabe = euro.ToString();

        static bool y = false;
        

        //static DateTime dt = DateTime.Now;

        


        public void Main()
        {

            Console.OutputEncoding = System.Text.Encoding.UTF8;
            Console.Clear();
            

            



            //Laden 
            update();



            //print
            print(euro, 1);

            //commands
            while (y == false) {
                input(Console.ReadLine());
                
            }
            


            //debug Funktionen
            Console.WriteLine("<----------------------------Debug_Funktionen ----------------------------->");
            rechner(75, 3);


            Console.ReadLine();
        }


        static void read(string path)
        {
            //Read €
            StreamReader reader = new StreamReader(path);
            var input = reader.ReadToEnd();
            reader.Close();
            double ausgabe = Convert.ToDouble(input);

            if (path == Mainpath)
            {
                euro = ausgabe;
                Speicher = Convert.ToDouble(input);

            } else if (path == Path_kleidung)
            {
                Kleidung = ausgabe;
                Speicher = Convert.ToDouble(input);

            } else if (path == Path_freizeit)
            {
                Freizeit = ausgabe;
               

            } else if (path == Path_kostene)
            {
                ausgaben = ausgabe;
                

            } else if (path == Old_Main_Path)
            {
                
                print(Convert.ToDouble(input), 0);
            }

            


        }


        static void print(Double gesamt, int x)
        {



            if (x == 1)
            {
                Console.Clear();
                Console.WriteLine("Kontostand\t\tKosten\t\tKleidung\t\tFreizeit");
                gesamt = Math.Round(gesamt, 2);
                euro = Math.Round(euro, 2);
                ausgaben = Math.Round(ausgaben, 2);
                Kleidung = Math.Round(Kleidung, 2);
                Freizeit = Math.Round(Freizeit, 2);
                Console.WriteLine(euro + "€\t\t\t" + ausgaben + "€\t\t" + Kleidung + "€\t\t\t" + Freizeit + "€");
            } else
            {
                Console.WriteLine(gesamt.ToString());
            }

            


        }

        static void input(string x)
        {
            if (x == "!sync")
            {
                update();
                

            } else if (x == "!exit")
            {
                y = true;
            }else if (x == "+")
            {
                add();
            }else if (x == "-")
            {
                remove();
            }else if (x == "!beta")
            {
                Beta();
            }
        }


        static void rechner(double eu, int durch)
        {

            // 30% rechner
            
            ausgaben = eu / durch;
            Kleidung = eu / durch;
            Freizeit = eu / durch;

            save(ausgaben.ToString(), Path_kostene);
            save(Kleidung.ToString(), Path_kleidung);
            save(Freizeit.ToString(), Path_freizeit);


            Console.WriteLine(euro);

            
        }




        static void spliter()
        {
            return;
        }


        static void save(string content, string path)
        {

            StreamWriter writer = new StreamWriter(path);
            writer.Write("");
            writer.Write(content);
            writer.Close();
        }


        static void update()
        {


            read(Mainpath);
            read(Path_kostene);
            read(Path_kleidung);
            read(Path_freizeit);


            double y = euro;

            rechner(y, 3);
            print(euro, 1);
              

            
        }

        static void Beta()
        {
            save("75", Old_Main_Path);
            read(Old_Main_Path);
        }





        static void neu()
        {




            return;
        }







        static void add()
        {
            int a;
            int b;
            int x;

            string add;
            Console.Clear();
            Console.WriteLine("<--------------------------- Hinzufügen-------------------------->");
            Console.WriteLine("##########\t\t   1 = Geld \t\t        ##########");
            Console.WriteLine("##########\t\t   2 = Ausgaben \t\t##########");
            Console.WriteLine("##########\t\t   3 = Kleidung \t\t##########");
            Console.WriteLine("##########\t\t   4 = Freizeit \t\t##########");
            Console.WriteLine("<---------------------------------------------------------------->");
            add = Console.ReadLine();

            if (add == "1")
            {
                Console.Clear();
                Console.WriteLine("Gib einen Betrag für 'Geld' ein !!!");
                Console.WriteLine("<---------------------------------------------------------------->");
                x = Convert.ToInt32(Console.ReadLine());
                a = Convert.ToInt32(euro);
                b = Convert.ToInt32(x);
                x = b + a;
                save(x.ToString(), Mainpath);
                update();
            }
            else if (add == "2")
            {
                Console.Clear();
                Console.WriteLine("Gib einen Betrag für die 'Ausgaben' ein !!!");
                Console.WriteLine("<---------------------------------------------------------------->");
                x = Convert.ToInt32(Console.ReadLine());
                a = Convert.ToInt32(ausgaben);
                b = Convert.ToInt32(x);
                x = b + a;
                save(x.ToString(), Path_kostene);
                update();
            }
            else if (add == "3")
            {
                Console.Clear();
                Console.WriteLine("Gib einen Betrag für 'Kleidung' ein !!!");
                Console.WriteLine("<---------------------------------------------------------------->");
                x = Convert.ToInt32(Console.ReadLine());
                a = Convert.ToInt32(Kleidung);
                b = Convert.ToInt32(x);
                x = b + a;
                save(x.ToString(), Path_kleidung);
                update();
            }
            else if (add == "4")
            {
                Console.Clear();
                Console.WriteLine("Gib einen Betrag für 'Freizeit' ein !!!");
                Console.WriteLine("<---------------------------------------------------------------->");
                x = Convert.ToInt32(Console.ReadLine());
                a = Convert.ToInt32(Freizeit);
                b = Convert.ToInt32(x);
                x = b + a;
                save(x.ToString(), Path_freizeit);
                update();
            }
            else
            {
                Console.Clear();
                Console.WriteLine("<---------------------------------------------------------------->");
                Console.WriteLine("Error 404 (fehler code 20334AB)");
                Console.WriteLine("<---------------------------------------------------------------->");
                Console.ReadKey();
                print(euro, 1);
            }



        }




        static void remove()
        {
            int a;
            int b;
            int x;

            string add;
            Console.Clear();
            Console.WriteLine("<--------------------------- Entfernen -------------------------->");
            Console.WriteLine("##########\t\t   1 = Geld \t\t        ##########");
            Console.WriteLine("##########\t\t   2 = Ausgaben \t\t##########");
            Console.WriteLine("##########\t\t   3 = Kleidung \t\t##########");
            Console.WriteLine("##########\t\t   4 = Freizeit \t\t##########");
            Console.WriteLine("<---------------------------------------------------------------->");
            add = Console.ReadLine();

            if (add == "1")
            {
                Console.Clear();
                Console.WriteLine("Gib einen Betrag für 'Geld' ein, den du entfernen möchtest !!!");
                Console.WriteLine("<---------------------------------------------------------------->");
                x = Convert.ToInt32(Console.ReadLine());
                a = Convert.ToInt32(euro);
                b = Convert.ToInt32(x);
                x = a - b;
                save(x.ToString(), Mainpath);
                update();
            }
            else if (add == "2")
            {
                Console.Clear();
                Console.WriteLine("Gib einen Betrag für die 'Ausgaben' ein, den du entfernen möchtest  !!!");
                Console.WriteLine("<---------------------------------------------------------------->");
                x = Convert.ToInt32(Console.ReadLine());
                a = Convert.ToInt32(ausgaben);
                b = Convert.ToInt32(x);
                x = a - b;
                save(x.ToString(), Path_kostene);
                update();
            }
            else if (add == "3")
            {
                Console.Clear();
                Console.WriteLine("Gib einen Betrag für 'Kleidung' ein, den du entfernen möchtest  !!!");
                Console.WriteLine("<---------------------------------------------------------------->");
                x = Convert.ToInt32(Console.ReadLine());
                a = Convert.ToInt32(Kleidung);
                b = Convert.ToInt32(x);
                x = a - b;
                save(x.ToString(), Path_kleidung);
                update();
            }
            else if (add == "4")
            {
                Console.Clear();
                Console.WriteLine("Gib einen Betrag für 'Freizeit' ein, den du entfernen möchtest  !!!");
                Console.WriteLine("Gib einen Betrag für 'Freizeit' ein, den du entfernen möchtest  !!!");
                Console.WriteLine("<---------------------------------------------------------------->");
                x = Convert.ToInt32(Console.ReadLine());
                a = Convert.ToInt32(Freizeit);
                b = Convert.ToInt32(x);
                x = a - b;
                save(x.ToString(), Path_freizeit);
                update();
            }
            else
            {
                Console.Clear();
                Console.WriteLine("<---------------------------------------------------------------->");
                Console.WriteLine("Error 404 (fehler code 20334AC)");
                Console.WriteLine("<---------------------------------------------------------------->");
                Console.ReadKey();
                print(euro, 1);
            }



        }





    }
}
