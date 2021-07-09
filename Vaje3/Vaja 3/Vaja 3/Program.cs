using System;
using System.ComponentModel.DataAnnotations.Schema;
using System.Diagnostics;
//"Izjavljam, da sem nalogo opravil samostojno in da sem njen avtor. Zavedam se, da v primeru, če izjava prvega stavka ni resnična, kršim disciplinska pravila."


namespace Vaja_3
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Hello World!");
            #region naloga 1
            MinusEna(5);

            #endregion

            #region naloga 2
            Pretvori(123, 7);
            #endregion


            #region naloga 4
            int b = 1;
            Hanoi(16, "a", "b", "c",ref b);
            Console.WriteLine("Število premikov je: "+ (b-1));
            #endregion



            #region naloga 5
            Random rnd = new Random();

            Console.WriteLine();

            Console.Write("Vnesi stevilko 0 za tabelo veliko 10000 in 1 za 100000: ");
            int SteviloTabela = Convert.ToInt32(Console.ReadLine());

            if (SteviloTabela==0)
            {
                double[] tebleca = new double[10000];
                for (int i = 0; i < 10000; i++)
                {
                    double test = Math.Round(rnd.NextDouble() * (-100000.00 - 100000.00) + 100000.00, 2);
                    tebleca[i] = test;
                }
                Console.WriteLine("Boubble sort" + "(" + 10000 + ") ----worst case--> " + Mehurcki(ref tebleca) + "ms  ------best case--> " + Mehurcki(ref tebleca) + "ms");





                double[] tebleca2 = new double[10000];
                for (int i = 0; i < 10000; i++)
                {
                    double test = Math.Round(rnd.NextDouble() * (-100000.00 - 100000.00) + 100000.00, 2);
                    tebleca2[i] = test;
                }

                Console.WriteLine("Coctail sort" + "(" + 10000 + ") ----worst case--> " + CocktailSort(ref tebleca2) + "ms  ------best case--> " + CocktailSort(ref tebleca2) + "ms");

            }
            else
            {
                double[] tebleca = new double[100000];
                for (int i = 0; i < 100000; i++)
                {
                    double test = Math.Round(rnd.NextDouble() * (-100000.00 - 100000.00) + 100000.00, 2);
                    tebleca[i] = test;
                }
                Console.WriteLine("Boubble sort" + "(" + 100000 + ") ----worst case--> " + Mehurcki(ref tebleca) + "ms  ------best case--> " + Mehurcki(ref tebleca) + "ms");





                double[] tebleca2 = new double[100000];
                for (int i = 0; i < 100000; i++)
                {
                    double test = Math.Round(rnd.NextDouble() * (-100000.00 - 100000.00) + 100000.00, 2);
                    tebleca2[i] = test;
                }

                Console.WriteLine("Coctail sort" + "(" + 100000 + ") ----worst case--> " + CocktailSort(ref tebleca2) + "ms  ------best case--> " + CocktailSort(ref tebleca2) + "ms");

            }

            #endregion








            Console.ReadKey();
        }

        #region naloga 1
        /*Program izpiše od stevilke ki jo vnesemo do števila 1 z premikom 1 (izpis npr za 5 =     5 4 3 2 1)*/
        /*izpis     vrednost
            5           5-1
            4           4-1
            3           3-1
            2           2-1 
            1           1-1
            Konec
         */
        public static void MinusEna (int a)
        {
            for (int i = a; i > 0; i--)
            {
                Console.WriteLine(i);
            }
        }
        #endregion

        #region naloga 2
        //izpis bo 234      (2 3 4)
        /*
         * stevilo      n
            123/7       7
            7/2         7
            2/Zaokroži na 0 in gre nazaj

            na zaslon napiše 234 čeprav je za vsako posebaj rezultat 2 3 4
            123%7 = 2
            17%7 = 3
            2%7 = 4
        */




        static void Pretvori(int stevilo, int n)
        {
            if (stevilo > 0)
            {
                Console.WriteLine(stevilo);

                Pretvori(stevilo / n, n);
                Console.WriteLine(stevilo % n);
            }
        }
        #endregion

        #region naloga 3

        /*metoda rekurzivno sešteje vsa števila med dvema steviloma 
         npr ce poklicemo z 1,4  nam vrne rezultat 10
         1+2+3+4
        sum(na zečetku/nakoncu)     n       m
        1/3                         1       4
        3/6                         2       4   
        6/10                        3       4
        -n>4konec                   4       4       4
         */

        /*V program vnesemo 2 števili n je začetno število m pa končno
         naloga zahteva da vrne zmnožek vseh vmesnih števil
        v if stavku mora biti napisana primerjava
        v returnu pa kako shrani in poklice novo metodo
         */
        /*
         
        public static int Seštevanje(int n, int m)
        {
            int sum = n;
            if (..........) //n<m
            {
                n++;
                return sum ......;  //+= Seštevanje(n, m)
            }
            return sum;
        }
        */
        #endregion

        #region naloga 4
        public static void Hanoi(int n, string st1, string st2, string st3, ref int b) //30
        {
            
            if (n == 1)
            {
                Console.WriteLine("Preloži z " + st1 + " na " + st3 + " "+b);//Izpis premika obroča
                b++;
            }
            else
            {
                Hanoi(n - 1, st1, st3, st2, ref b);
                Console.WriteLine("Preloži z " + st1 + " na " + st3+" "+b); //Izpis premika obroča
                b++;
                Hanoi(n - 1, st2, st1, st3,ref b);
                
            }
        }

        #endregion

        #region naloga 5

        public static double Mehurcki(ref double[] tabela)
        {

            Stopwatch sw = new Stopwatch();

            sw.Start();
            // korak urejanja ponovimo tolikokrat, kot je elementov v tabeli
            for (int stevec = 0; stevec < tabela.Length; stevec++)
            {
                /* sprehodimo se čez celo tabelo in primerjamo sosednja
                   števila*/
                for (int par = 0; par < tabela.Length - 1; par++)
                {
                    // če je levi element večji od desnega, ju zamenjamo
                    if (tabela[par] > tabela[par + 1])
                    {
                        double temp = tabela[par + 1];
                        tabela[par + 1] = tabela[par];
                        tabela[par] = temp;
                    }
                }
            }
            sw.Stop();
            return sw.ElapsedMilliseconds;

        }


        public static double CocktailSort(ref double[] tabela)
        {
            Stopwatch sw = new Stopwatch();
            sw.Start();

            for (int k = tabela.Length - 1; k > 0; k--)
            {
                //spremenljivka "zamenjava" opredeljuje smer preiskovanja
                bool zamenjava = false;
                for (int i = k; i > 0; i--)
                    if (tabela[i] < tabela[i - 1])
                    {
                        // tabelo obdelujemo od spodaj navzgor
                        double temp = tabela[i];
                        tabela[i] = tabela[i - 1];
                        tabela[i - 1] = temp;
                        zamenjava = true;
                    }

                for (int i = 0; i < k; i++)
                    if (tabela[i] > tabela[i + 1])
                    {
                        // tabelo obdelujemo od zgoraj navzdol
                        double temp = tabela[i];
                        tabela[i] = tabela[i + 1];
                        tabela[i + 1] = temp;
                        zamenjava = true;
                    }

                if (!zamenjava)
                    break;
            }
            sw.Stop();
            return sw.ElapsedMilliseconds;
        }



        #endregion

    }





}
