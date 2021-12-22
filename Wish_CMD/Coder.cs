using System;
using System.IO;
using System.Text;

namespace Wish_CMD
{
    public class Aktti
    {
        



    }

    public class Data_Test
    {
        public string[,] data { get; private set; }
        static string path; //= @"D:\Dokumente\GitHub\Wish_CMD\Wish_CMD\Saves\Data.txt";

        public void manage(string path)
        {
           //this.path = path;
        }


        static string[] Buffer = File.ReadAllLines(path);
        



    }
}