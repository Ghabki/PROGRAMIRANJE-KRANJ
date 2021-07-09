using System;
using System.IO;
//"Izjavljam, da sem nalogo opravil samostojno in da sem njen avtor. Zavedam se, da v primeru, če izjava prvega stavka ni resnična, kršim disciplinska pravila.
namespace ConsoleApp1
{
    class Program
    {
        static void Main(string[] args)
        {
            #region naloga 1
            Ulomek lol = new Ulomek(1, 1);
            Ulomek lol1 = new Ulomek(1, 2);
            Ulomek lol2 = new Ulomek(1, 1);
            Ulomek lol3 = new Ulomek(12, 48);
            Ulomek lol4 = new Ulomek(15, 48);

            Ulomek negativenInNič = new Ulomek(-1, 0);

            Console.WriteLine("sestevanje lol in lol2 " + (lol + lol2));
            Console.WriteLine("odstevanje lol in lol3 " + (lol - lol3));
            Console.WriteLine("Množenje lol2 in lol4 " + lol3 * lol4);
            Console.WriteLine("toString = " + lol4.ToString());
            Console.WriteLine("vrednost = " + lol2.vrednost());
            Console.WriteLine("compare lol in lol2 " + lol.CompareTo(lol2));
            Console.WriteLine("compare lol in lol1 " + lol.CompareTo(lol1));
            lol4.Kranjšaj();
            Console.WriteLine("Kranjšanje lol4 =" + lol4.ToString());
            Console.WriteLine("vrednost lol4 = " + lol4.vrednost());
            Console.WriteLine("append v file .......");
            DodajNaDatoteko("test.txt", lol1);

            Console.WriteLine("preverjanje da ni imenovalec 0 in izpis negativnega števila (stevec mora biti -1 imenovalec pa 1  )" + negativenInNič.ToString());


            Console.WriteLine();



            Console.WriteLine("Kreiranje 20 ulomkov in iskanje najvecjega");

            Ulomek NajvečniUlomek = PoisciNajvecjega(NarediUlomke(20), 1);

            Console.WriteLine("Najvecji je =  " + NajvečniUlomek.ToString());
            Console.WriteLine();


            var tabelca = NarediUlomke(20);
            Ulomek najvecji = PoisciNajvecjega(tabelca, 1);
            foreach (var item in tabelca)
            {
                if (item.vrednost() == najvecji.vrednost())
                {
                    Console.WriteLine("Ulomek " + item.ToString() + "ima isto vrednost kot največjij" + najvecji.ToString() + "     Če je samo ena vrednost pomeni da je samo 1 najvecji v tabeli");
                }
            }

            Console.WriteLine();

            Ulomek začetni = new Ulomek(1, 1);
            Ulomek začetni2 = new Ulomek(1, 1);
            for (int i = 2; i < 17; i++)
            {
                začetni = začetni + new Ulomek(1, i);
                začetni2 = začetni2 * new Ulomek(1, i);
            }
            Console.WriteLine("seštevanje 1, 1/2, 1/3...1/15  " + začetni.ToString() + "  v stevilki pa je = " + začetni.vrednost());
            Console.WriteLine("množenje 1, 1/2, 1/3...1/15  " + začetni2.ToString() + "     v stevilki pa je = " + začetni2.vrednost());


            #endregion

            #region naloga4
            Console.WriteLine();

            string[] tabela1 = new string[] { "adf", "sfghj", "jfsa", "adfg", "jzj", "zjjtjj", "srwj", "aerth", "jzt", "kmtju"};
            int[] tabela2 = new int[] {1,2,3,4,5,6,7,8,9,10};
            long[] tabela3 = new long[] {21,22,23,24,25,26,27,28,29,30};

            Console.WriteLine("Naključni element = " + naključniElement(tabela1).ToString());
            Console.WriteLine("Najmansi element v tabeli =  "+ Najmanjsi(tabela2).ToString());

            Moja(ObrniTabelo(tabela3)); //obrne tabelo. Ftunkcija "MOJA" pa samo izpiše;






            #endregion
            Console.WriteLine();
            Console.ReadLine();
        }
        #region naloga 1
        public static void DodajNaDatoteko(string imeDatoteke, Ulomek U)
        {
            String pot = "./" + imeDatoteke + ".txt";
            using (StreamWriter sw = File.AppendText(pot))
            {
                sw.WriteLine(U.ToString());
            }


        }

        public static Ulomek[] NarediUlomke(int velikost)
        {
            Random rnd = new Random();

            Ulomek[] vrni = new Ulomek[velikost];


            for (int i = 0; i < 20; i++)
            {
                var zacasna = new Ulomek(rnd.Next(1, 11), rnd.Next(1, 11));
                Console.WriteLine(zacasna.ToString());//---------------------------------------------
                vrni[i] = zacasna;
            }
            return vrni;
        }


        public static Ulomek PoisciNajvecjega(Ulomek[] tab, int kateri)
        {
            //metoda isce k-ti NAJMANJŠI element v tabeli in vrne razultat kot tab[k]: najmanjši element (isci=1) je tab[0], drugi najmanjši (isci=2) je tab[1]...
            int k = tab.Length - kateri;
            if (tab == null || tab.Length <= k)
                throw new Exception("Napačni vhodni podatki: tabela ne obstaja, ali pa vsebije manj kot " + k + " elementov");
            int odKje = 0, doKam = tab.Length - 1;
            // if odKje == doKam -> našli smo k-ti element
            while (odKje < doKam)
            {
                int leviRob = odKje, desniRob = doKam;
                Ulomek sredina = tab[(leviRob + desniRob) / 2];
                // ponavljamo dokler se levi in desni rob intervala ne srečata
                while (leviRob < desniRob)
                {
                    if (tab[leviRob].vrednost() >= sredina.vrednost())
                    {
                        // večje vrednosti prestavljamo na konec tabele
                        Ulomek tmp = tab[desniRob];
                        tab[desniRob] = tab[leviRob];
                        tab[leviRob] = tmp;
                        desniRob--;
                    }
                    else
                    {
                        //vrednost je manjša od pivotne, zato jo preskočimo
                        leviRob++;
                    }
                }
                // če smo šli preko sredine, se pomaknemo za en element nazaj
                if (tab[leviRob].vrednost() > sredina.vrednost())
                    leviRob--;
                //indeks leviRob je na koncu prvih k elementov
                if (k <= leviRob)
                {
                    doKam = leviRob;
                }
                else
                {
                    odKje = leviRob + 1;
                }
            }
            return tab[k];
        }



        #endregion


        #region naloga2
        public static void Zamenjaj<T>(ref T leva, ref T desna) //dobi 2 vrednosti ki so referenčne kar pomeni da se spremenljivka ohrani tudi izven bloka te kode. t pa pomeni da lahko vnesemo kateri koli tip 
        {
            T zacasni = leva;   //shrani v začasno spremeljjivko z generičnim tipom
            leva = desna;       // "desno" shrani v "levo"
            desna = zacasni;    //"začasno shranjjeno "levo""pa shrani v "desno"
        }
        #endregion

        #region naloga3
        static void Izbiranje<T>(T[] tabela)where T:IComparable //-----------------------DODANA ČRKA T IN DODANA "WHERE T:ICOMPARABLE
        {
            // korak ponavljamo tolikokrat, kot je elementov v tabeli
            //spremenljivka neurejeni kaže na prvi element v neurejenem delu
            for (int neurejeni = 0; neurejeni < tabela.Length; neurejeni++)
            {
                // izberemo najmanjši element iz neurejenega dela
                int najmanjsiPozicija = neurejeni;
                // zapomnimo si tudi njegov položaj
                T najmanjsi = tabela[neurejeni];//------------------Sprememba iz int v T
                for (int i = neurejeni + 1; i < tabela.Length; i++)
                {
                    if (tabela[i].CompareTo(najmanjsi)==-1)//--------------------------CompareTo -1 pa pomeni da je leva stran manjsa od desne
                    {
                        najmanjsiPozicija = i;
                        najmanjsi = tabela[i];
                    }
                }
                /* zamenjamo prvi element v neurejenem delu z najmanjšim 
                   elementom iz neurejenega dela*/
                tabela[najmanjsiPozicija] = tabela[neurejeni];
                tabela[neurejeni] = najmanjsi;
            }
        }


        #endregion

        #region naloga4
        public static T naključniElement<T>(T[] tabela) {
            Random rand = new Random();

            int stevilo = rand.Next(0, 11);
            return tabela[stevilo];
        }

        public static T Najmanjsi<T>(T[] tabela)where T:IComparable {
            var najmanjsi = tabela[0];

            foreach (var item in tabela)
            {
                if (item.CompareTo(najmanjsi)<0)
                {
                    najmanjsi = item;
                }
            }
            return najmanjsi;
        }

        public static T[] ObrniTabelo<T>(T[] tabela) {
            Array.Reverse(tabela);
            return tabela;
        }

        public static void Moja<T>(T[] tabela) {
            foreach (var item in tabela)
            {
                Console.Write(item.ToString()+"  ");
            }
        }

        #endregion

        #region naloga1

        public abstract class UlomekAbs
        {
            public int stevec { get; set; }
            public int Imenovalec { get; set; }

            public UlomekAbs()
            {
                this.stevec = 1;
                this.Imenovalec = 1;
            }
            public UlomekAbs(int m, int n)
            {

                if (n < 0)
                {
                    this.stevec = m;
                    this.Imenovalec = n * -1;
                }
                else if (n == 0)
                {
                    this.stevec = m;
                    this.Imenovalec = 1;
                }
                else
                {
                    this.stevec = m;
                    this.Imenovalec = n;
                }
            }

        }
        public interface IVrednost
        {
            public double vrednost();
        }



        public class Ulomek : UlomekAbs, IComparable<Ulomek>, IVrednost
        {

            public Ulomek() : base() { }
            public Ulomek(int k, int l) : base(k, l) { }

            public override string ToString()
            {
                return stevec + "/" + Imenovalec;
            }

            public static Ulomek operator +(Ulomek a, Ulomek b)
            {
                int sa = a.stevec;
                int sb = b.stevec;

                int ia = a.Imenovalec;
                int ib = b.Imenovalec;
                int zac = a.Imenovalec;

                sa = sa * ib;
                ia = ia * ib;

                sb = sb * zac;

                return new Ulomek(sa + sb, ia);

            }

            public static Ulomek operator -(Ulomek a, Ulomek b)
            {
                int sa = a.stevec;
                int sb = b.stevec;

                int ia = a.Imenovalec;
                int ib = b.Imenovalec;
                int zac = a.Imenovalec;
                /*
                 sa/ia            sb/ib
                */
                sa = sa * ib;
                ia = ia * ib;
                sb = sb * zac;

                return new Ulomek(sa - sb, ia);


            }

            public static Ulomek operator *(Ulomek a, Ulomek b)
            {
                return new Ulomek(a.stevec * b.stevec, a.Imenovalec * b.Imenovalec);
            }

            public void Kranjšaj()
            {
                int a = stevec;
                int b = Imenovalec;

                int Remainder;

                while (b != 0)
                {
                    Remainder = a % b;
                    a = b;
                    b = Remainder;
                }
                //Console.WriteLine(a);
                if (stevec % a == 0 && Imenovalec % a == 0)
                {
                    stevec = stevec / a;
                    Imenovalec = Imenovalec / a;
                }
            }

            public double vrednost()
            {
                double rez = Convert.ToDouble(stevec) / Convert.ToDouble(Imenovalec);
                return rez;
            }

            public int CompareTo(Ulomek obj)
            {
                if (obj == null) return 1;
                Kranjšaj();
                obj.Kranjšaj();

                if (vrednost() == obj.vrednost())
                {
                    return 0;
                }
                else if (vrednost() > obj.vrednost())
                {
                    return 1;
                }
                else
                {
                    return -1;
                }

            }



        }
        #endregion
    }
}
