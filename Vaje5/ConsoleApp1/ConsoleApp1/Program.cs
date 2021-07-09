using System;
using System.Collections.Generic;
using System.Dynamic;
using System.Globalization;
//"Izjavljam, da sem nalogo opravil samostojno in da sem njen avtor. Zavedam se, da v primeru, če izjava prvega stavka ni resnična, kršim disciplinska pravila.
namespace ConsoleApp1
{
    class Program
    {
        static void Main(string[] args)
        {
            #region naloga1

            Random rnd = new Random();

            Registracija[] tablica = new Registracija[50];

            string[] obmocja = Enum.GetNames(typeof(Obmocja));
            
            
            
            for (int i = 0; i < 50; i++)
            {

                string x = "";

                for (int j = 0; j< 8; j++)
                {
                    int s = rnd.Next(1, 3);
                    if (s == 1)
                    {
                        x += rnd.Next(0, 10).ToString();
                    }
                    else
                    {
                        x += (char)rnd.Next(65, 91);
                    }

                }

                int pred = rnd.Next(0, 11);

                tablica[i] = new Registracija(obmocja[pred], x);
                //Console.WriteLine(tablica[i].ToString());
            }
            

            Mehurcki(tablica);
            foreach (var item in tablica)
            {
                Console.WriteLine(item.ToString());
            }
            Console.WriteLine("");
            string abc = Bisekcija(tablica, "KP");
            Console.WriteLine(abc);

            Console.WriteLine("");

            int enaNaprej = 0;
            int stevec = 0;
            int najvecji = 0;
            string najvec = "";
            foreach (var item in tablica)
            {
                enaNaprej++;
                try {
                    //Console.WriteLine(item.obmocje_r+" "+ tablica[enaNaprej].obmocje_r);

                    string b = item.obmocje_r;
                    string c = tablica[enaNaprej].obmocje_r;

                    if (b != c)
                    {
                        stevec++;
                        if (stevec >= najvecji)
                        {
                            najvecji = stevec;
                            najvec = item.obmocje_r;
                            stevec = 0;
                        }
                        else
                        {
                            stevec = 0;
                            continue;
                        }
                    }
                    else
                    {
                        stevec++;
                    }
                }
                catch(Exception ex)
                {
                    stevec++;
                    if (stevec > najvecji)
                    {
                        najvecji = stevec;
                        najvec = item.obmocje_r;
                        stevec = 0;
                    }
                } 
            }
            Console.WriteLine(najvec + " ima " + najvecji + " vnosov");


            #endregion

            #region naloga2
            ura ena = new ura(0, 10, 10);
            ura dva = new ura(5, 5, 15);

            ura test1 = ena + dva;
            ura test2 = ena - dva;
            bool test3 = ena == dva;
            Console.WriteLine(test1.ToString());
            Console.WriteLine(test2.ToString());
            Console.WriteLine(test3);


            #endregion

            Console.ReadKey();
        }

        #region naloga1
        static void Mehurcki(Registracija[] tabela)
        {
            // korak urejanja ponovimo tolikokrat, kot je elementov v tabeli
            for (int stevec = 0; stevec < tabela.Length; stevec++)
            {
                /* sprehodimo se čez celo tabelo in primerjamo sosednja
                   števila*/
                for (int par = 0; par < tabela.Length - 1; par++)
                {
                    // če je levi element večji od desnega, ju zamenjamo
                    if (tabela[par].obmocje_r.CompareTo(tabela[par + 1].obmocje_r) == 1)
                    {
                        Registracija temp = tabela[par + 1];
                        tabela[par + 1] = tabela[par];
                        tabela[par] = temp;
                    }
                }
            }
        }


        public static string Bisekcija(Registracija[] tab, string iskano)

        {

            int doKam = tab.Length - 1; // desna meja iskanja

            int odKje = 0; //kje začnemo iskati

            int sred;  // indeks sredine intervala bomo računali sproti

            while (odKje <= doKam) // dokler je še kaj podatkov za iskanje

            {

                sred = (odKje + doKam) / 2; // indeks sredine dela kjer iščemo

                if (tab[sred].obmocje_r.CompareTo(iskano) == -1)  //primerjava podatkov

                    odKje = sred + 1; // iščemo desno

                else

                    if (tab[sred].obmocje_r.CompareTo(iskano) == 1)

                    doKam = sred - 1; //nov desno rob intervala

                else // podatka sta enaka, torej je tab[sred] == iskano

                    return "Obstaja"; //metoda vrne true, kajti podatek je najden

            }

            return "Ne obstaja"; // podatek ni najden, metoda vrne false!

        }
        #endregion
    
    }

    #region naloga1
    public enum Obmocja {LJ, KR, KK, MB, MS, KP, GO, CE, SG, NM, PO};

    public class Registracija
    {
        private string obmocje;
        private string stevilka;

        public Registracija()
        {
            obmocje = "NN";
            stevilka = "00000";
        }
        public Registracija(string ob, string st)
        {
            if (st.Length >= 3 && st.Length <= 8)
            {
                obmocje = ob;
                stevilka = st;
            }
            else
            {
                obmocje = "NN";
                stevilka = "00000";
            }
        }
        public static string IzpisObmočij()
        {
            string izpis = "";
            for (Obmocja obm = Obmocja.LJ; obm <= Obmocja.PO; obm++)
            {
                izpis = izpis + obm + " ";
            }
            return izpis;


        }

        public override string ToString()
        {
            return obmocje + stevilka;
        }

        public string obmocje_r
        {
            get { return obmocje;}
        }
        #endregion

    }
    #region naloga2

    public class ura
    {
        private int sekunde;
        private int minute;
        private int ure;
        public DateTime cas;

        public ura(int ur, int min, int sec)
        {
            this.sekunde = sec;
            this.minute = min;
            this.ure = ur;
            string tm = ur.ToString() + ":" + min.ToString() + ":" + sec.ToString();

            cas = DateTime.Parse(tm);
            //Console.WriteLine(cas);
        }

        public override string ToString()
        {
            return ure.ToString() + "." + minute.ToString() + "." + sekunde.ToString();
        }

        public static ura operator +(ura pri1, ura pri2)
        {
            DateTime aaa;
            aaa = pri1.cas.AddHours(pri2.cas.Hour);
            aaa = aaa.AddMinutes(pri2.cas.Minute);
            aaa = aaa.AddSeconds(pri2.cas.Second);
            return new ura(aaa.Hour, aaa.Minute, aaa.Second);
        }

        public static ura operator- (ura pri1, ura pri2)
        {
            DateTime aaa;
            aaa = pri1.cas.AddHours(pri2.cas.Hour *-1);
            aaa = aaa.AddMinutes(pri2.cas.Minute * -1);
            aaa = aaa.AddSeconds(pri2.cas.Second * -1);
            return new ura(aaa.Hour, aaa.Minute, aaa.Second);

        }

        public static bool operator ==(ura pri1, ura pri2)
        {
            if (pri1.ure == pri2.ure && pri1.minute == pri2.minute && pri1.sekunde == pri2.sekunde)
            {
                return true;
            }
            else
            {
                return false;
            }
        }
        public static bool operator !=(ura pri1, ura pri2)
        {
            if (pri1.ure != pri2.ure && pri1.minute != pri2.minute && pri1.sekunde != pri2.sekunde)
            {
                return true;
            }
            else
            {
                return false;
            }
        }




    }

    
    #endregion
}
