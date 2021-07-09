using System;
using System.Collections;
using System.ComponentModel.DataAnnotations;
using System.IO;
using System.Transactions;
//"Izjavljam, da sem nalogo opravil samostojno in da sem njen avtor. Zavedam se, da v primeru, če izjava prvega stavka ni resnična, kršim disciplinska pravila."
namespace Vaja_1
{
    class Program
    {
        static void Main(string[] args)
        {
            #region naloga 1
            string a = "abc";
            bool DaNe = a.Contains(value: "a");
            string b = a.Substring(startIndex: 0, length:2);
            int c = a.IndexOf(value: "b");
            int d = a.LastIndexOf(value: "c");
            int e = a.CompareTo(value: "abc");
            #endregion
            
            #region naloga 2
            Console.WriteLine(NajvecjiFile(@"G:\")); //vrne nic ker ja pac mapa nima datotek
                                                     //Console.WriteLine(NajvecjiFile(@"G:\Razno));// v to mapo sem dodal nekaj txt datotek ter najde najvecjo


            #endregion

            #region naloga 3
            Console.WriteLine(Izracun("*", 2, 2, 2, 2, 2, 2));
            Console.WriteLine(Izracun("+", 2, 2, 2, 2, 2, 2));
            Console.WriteLine(Izracun("p", 2, 2, 2, 2, 2, 2));

            #endregion

            #region naloga 4


            Console.WriteLine(Filem(@"..\..\..\FilmiInOcene.txt"));

            #endregion

            #region naloga 5
            //izpis je 
            //3
            //1
            //15

            /*
             main                           Func
             a = 1                          a:1  5 to se ne shrani
             b= 2 ni vec 2 ampak 15         b= 2  15     to se prenese ker je ref
                                            c= 3  to pa tako ali tako vrne
             
             
             
             */



            #endregion

            #region naloga 6
            Console.WriteLine(Zakodiraj("az"));
            Console.WriteLine(Odkodiraj("ed"));
            Console.WriteLine(Odkodiraj("e˙#$%&/(d"));
            #endregion
        }

        #region naloga 2
        public static string NajvecjiFile(string enota = @"D:\")
        {

            DirectoryInfo di = new DirectoryInfo(enota);
            FileInfo[] tab = di.GetFiles();
            if (tab.Length == 0)
            {
                return "";
            }

            long NajvecjaVrednost = 0;
            string NajFile = "";
            foreach (var item in tab)
            {
                if (item.Length > NajvecjaVrednost)
                {
                    NajvecjaVrednost = item.Length;
                    NajFile = item.Name;
                }
            }
            return NajFile+" "+NajvecjaVrednost.ToString();



        }


        #endregion
        
        #region naloga 3
        public static double Izracun (String opcija, params double[] stevilke)
        {
            double vrni = 1.0;
            double vrni2 = 0.0;
            switch (opcija){
                case "*":
                    foreach (var st in stevilke)
                    {
                        vrni *= st;
                    }
                    return vrni;
            }
            switch (opcija)
            {
                case "+":
                    foreach (var st in stevilke)
                    {
                        vrni2 += st;
                    }
                    return vrni2;
            }
            switch (opcija)
            {
                case "p":
                    int stevec = 0;
                    double zacasna = 0.0;
                    foreach (var st in stevilke)
                    {
                        stevec++;
                        zacasna += st;
                    }
                    return zacasna/stevec;
            }
            return 0;
        }
        #endregion

        #region naloga 4
        public static (string, string) Filem (string Datoteka)
        {
            double ocena = 0.0;
            string ime = "";

            int ogledi = 0;
            string ime2 = "";

            StreamReader read = new StreamReader(Datoteka);
            string line;
            while ((line = read.ReadLine()) != null)
            {
                String[] temp = line.Split(";");
                double a = Convert.ToDouble(temp[1]);
                
                if (a >ocena)
                {
                    ocena = a;
                    ime = temp[2];
                }

                int b = int.Parse(temp[3].Replace(".", ""));

                if (b > ogledi)
                {
                    ogledi = b;
                    ime2 = temp[2];
                }                
            }
            read.Close();
//            Console.WriteLine(ocena);
            return (ime, ime2);


        }


        #endregion

        #region naloga 6
        static string Odkodiraj(string niz)
        {

            string novStavek = "";
            for (int i = 0; i < niz.Length; i++)
            {
 
                if (niz[i] >= 'a' && niz[i] <= 'd' || niz[i] >= 'A' && niz[i] <= 'D')
                {
                    novStavek += (char)(niz[i] + 22);
                }
                else if (niz[i] >= 'e' && niz[i] <= 'z' || niz[i] >= 'E' && niz[i] <= 'Z')
                {
                    novStavek += (char)(niz[i] - 4);
                }
                else
                {
                    novStavek += niz[i];
                }
            }
                return novStavek;
        }   
            
        

        static string Zakodiraj(string niz)
        {
            string novStavek = "";
            for (int i = 0; i < niz.Length; i++)
            {
                if (niz[i] >= 'a' && niz[i] <= 'v' || niz[i] >= 'A' && niz[i] <= 'V')
                    novStavek += (char)(niz[i] + 4);
                else if (niz[i] >= 'w' && niz[i] <= 'z' || niz[i] >= 'W' && niz[i] <= 'Z')
                    novStavek += (char)(niz[i] - 22);
                else novStavek += niz[i];
            }
            return novStavek;
        }
        #endregion

    }
}
