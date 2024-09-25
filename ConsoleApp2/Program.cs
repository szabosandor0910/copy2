using System;
using System.Collections.Generic;
using System.IO;

namespace feladat3
{
    // módosítok akármit
    class Program
    {
        static void Main(string[] args)
        {
            var fname = "people.csv";
            StreamReader f = new StreamReader(fname);
            string sor;
            List<string> sorok = new List<string>();
            while ((sor = f.ReadLine()) != null)
            {
                sorok.Add(sor);

            }
            f.Close();
            string legidosebb = Old(sorok);
            string legfiatalabb = Young(sorok);
            double atlageletkor = Atlag(sorok);
            atlageletkor = Math.Round(atlageletkor, 2);
            Console.WriteLine("Legfiatalabb személy:");
            Console.WriteLine(legfiatalabb);
            Console.WriteLine();
            Console.WriteLine("Legidősebb személy:");
            Console.WriteLine(legidosebb);
            Console.WriteLine();

            Console.WriteLine("A fájlban szereplő személyek átlagos életkora: " + atlageletkor);


        }

        public static string Old(List<string> sorok)
        {
            string name = "name";
            int maxeletkor = 0;
            for (var i = sorok.Count - 1; i >= 0; i--)
            {
                var darabol = sorok[i].Split(";");
                var kor = darabol[2].Split("-");
                if (int.Parse(kor[1]) >= maxeletkor)
                {
                    maxeletkor = int.Parse(kor[1]);
                    name = darabol[0] + " " + darabol[1];
                }
            }
            return $"{name}, {maxeletkor} éves";
        }
        public static string Young(List<string> sorok)
        {
            string name = "name";
            int min = 100;
            for (var i = sorok.Count - 1; i >= 0; i--)
            {
                var darabol = sorok[i].Split(";");
                var kor = darabol[2].Split("-");
                if (int.Parse(kor[1]) <= min)
                {
                    min = int.Parse(kor[1]);
                    name = darabol[0] + " " + darabol[1];
                }
            }
            return $"{name}, {min} éves";
        }
        public static double Atlag(List<string> sorok)
        {
            double osszeg = 0;
            double szama = 0;
            foreach (var item in sorok)
            {
                var darabol = item.Split(";");
                var kor = darabol[2].Split("-");
                osszeg += int.Parse(kor[1]);
                szama++;
            }
            double atlag = osszeg / szama;
            return atlag;
        }
    }
}
