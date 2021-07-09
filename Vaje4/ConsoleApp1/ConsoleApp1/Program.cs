using System;
using System.Collections.Generic;
using System.Diagnostics.Eventing.Reader;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
//"Izjavljam, da sem nalogo opravil samostojno in da sem njen avtor. Zavedam se, da v primeru, če izjava prvega stavka ni resnična, kršim disciplinska pravila."
namespace ConsoleApp1
{
    class Program
    {
        static void Main(string[] args)
        {
            #region naloga1
            string[] imena = { "gfd", "djgh", "gdkfd", "wrtz", "gfashtd", "jzrtj", "gfkuššššššššid", "ashfhdah", "dstgfd", "jzd"};
            string[] priimek = { "gfsjrd", "djjtzgh", "gdsjzkfd", "zrhjw", "gfassrzjhtd", "hghr", "gfkuszjid", "zrjr", "dstszgfd", "jjzd" };
            Random rnd = new Random();
            oseba[] osebe = new oseba[20];
            DateTime dt;
            DateTime ti = new DateTime(2020, 1, 1);

            //kreira tabele ter izpise starost oseb
            for (int i = 0; i < 20; i++)
            {
                int a = rnd.Next(0, 10);
                int b = rnd.Next(1900, 2020);
                dt = new DateTime(b, 1, 1);
                osebe[i] = new oseba(imena[a], priimek[a], dt, bruh(rnd));
                //Console.WriteLine(bruh(rnd));
                Console.WriteLine(osebe[i].starost(ti));
            }
            Console.WriteLine();

            // izprinta top 3 najstarejsi
            oseba ena = PoisciKTega(osebe, 1);
            oseba dva = PoisciKTega(osebe, 2);
            oseba tri = PoisciKTega(osebe, 3);

            Console.WriteLine(ena.starost(ti));
            Console.WriteLine(dva.starost(ti));
            Console.WriteLine(tri.starost(ti));

            Console.WriteLine();
            // po emšo
            oseba[] stiri = Vstavljanje(osebe);
            foreach (var item in stiri)
            {
                Console.WriteLine(item.S_emšo);
            }
            Console.WriteLine();
            //po starosti v datoteko
            if (File.Exists("datoteka.txt"))
            {
                File.Delete("datoteka.txt");
            }
            int st = 0;
            oseba[] pet = Vstavljanje_rojen(osebe);


            StreamWriter sw = File.CreateText("datoteka.txt");
            
            sw.WriteLine("New file created: {0}", DateTime.Now.ToString());
            foreach (var item in pet)
            {
                if (item.starost(ti) >= 18)
                {
                    Console.WriteLine(item.S_date);
                    sw.WriteLine(item.S_date);
                }
                else
                {
                    st++;
                }   
            }
            Console.WriteLine();

            Console.WriteLine("mlajsih od 18 je : " + st);
            sw.Close();
            Console.WriteLine();
            //priimki
            oseba[] sest = Vstavljanje_priimek(osebe);
            foreach (var item in sest)
            {
                Console.WriteLine(item.S_priimek);

            }


            Console.WriteLine();

            //bisekcija
            Console.WriteLine("vnesi leto v stevilki: ");
            int z = Convert.ToInt32(Console.ReadLine());
            Console.WriteLine("vnesi dan v stevilki: ");
            int j = Convert.ToInt32(Console.ReadLine());
            Console.WriteLine("vnesi mesec v stevilki: ");
            int k = Convert.ToInt32(Console.ReadLine());

            DateTime data = new DateTime(z, k, j);

            oseba lol = Bisekcija(pet, data);
            if (lol != null)
            {
                Console.WriteLine("najden  " + lol.ime + " " + lol.S_priimek + " " + lol.starost(ti));
            }
            else
            {
                Console.WriteLine("ni bil najden");
            }

            #endregion

            #region naloga2

            string mapa = @"C:\Fraps";  //ime mape, ki jo preiskujemo
            FileInfo[] Seznam = new FileInfo[0]; //tabela s podatki o datotekah je na začetku prazna
            //klic metode, ki ustvari in vrne seznam datotek določene mape in njenih podmap
            FileInfo[] Datoteke = UstvariSeznam(mapa, ref Seznam);


            UstvariSeznam(mapa, ref Seznam);



            // sort po imenu
            FileInfo[] PoImenih = Vstavljanje_ime(Datoteke);
            foreach (var item in PoImenih)
            {
                Console.WriteLine(item.Name);

            }
            Console.WriteLine();
            //sort po velikkosti
            FileInfo[] poDolžini = Vstavljanje_dolžina(Datoteke);
            foreach (var item in poDolžini)
            {
                Console.WriteLine(item.Length);
            }

            Console.WriteLine();
            //sort po koncnicah
            FileInfo[] Poextenzijah = Vstavljanje_extenzija(Datoteke);
            foreach (var item in Poextenzijah)
            {
                Console.WriteLine(item.Name);
            }

            Console.WriteLine();

            //samo ang črke
            foreach (var item in poDolžini)
            {
                int stev = 0;
                foreach (var item2 in item.Name)
                {
                    
                    if ((int)item2-'0' < 255)
                    {
                        continue;
                    }
                    else
                    {
                        stev++;
                    }
                    
                }
                if (stev==0)
                {
                    Console.WriteLine(item.Name + " " + item.Length);
                }




            }



            //bisekcija
            Console.WriteLine();

            FileInfo najdi = Bisekcija2(poDolžini, 100000);
            if (najdi == null)
            {
                Console.WriteLine("ne obstaja ");

            }
            else {
                Console.WriteLine("datoteka velika 100Kb je" + " " );
            }

            //k elementi, itak je na koncu tabele in to je zelo ne potrevno
            Console.WriteLine();

            FileInfo gg = PoisciKTegaa(poDolžini, 1);
            FileInfo ggg = PoisciKTegaa(poDolžini, 2);
            FileInfo gggg = PoisciKTegaa(poDolžini, 3);

            Console.WriteLine(gg.Name + " " + gg.Length);
            Console.WriteLine(ggg.Name + " " + ggg.Length);
            Console.WriteLine(gggg.Name + " " + gggg.Length);





            #endregion



            Console.ReadKey();
        }
        #region naloga1
        public static oseba PoisciKTega(oseba[] tab, int isci)
        {
            DateTime ti = new DateTime(2021,1,1);
            //metoda isce k-ti NAJMANJŠI element v tabeli in vrne razultat kot tab[k]: najmanjši element (isci=1) je tab[0], drugi najmanjši (isci=2) je tab[1]...
            int k = tab.Length - isci;
            if (tab == null || tab.Length <= k)
                throw new Exception("Napačni vhodni podatki: tabela ne obstaja, ali pa vsebije manj kot " + k + " elementov");
            int odKje = 0, doKam = tab.Length - 1;
            // if odKje == doKam -> našli smo k-ti element
            while (odKje < doKam)
            {
                int leviRob = odKje, desniRob = doKam;
                oseba sredina = tab[(leviRob + desniRob) / 2];
                // ponavljamo dokler se levi in desni rob intervala ne srečata
                while (leviRob < desniRob)
                {
                    if ((tab[leviRob].starost(ti)) >= sredina.starost(ti))
                    {
                        // večje vrednosti prestavljamo na konec tabele
                        oseba tmp = tab[desniRob];
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
                if (tab[leviRob].starost(ti) > sredina.starost(ti))
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

        public static oseba[] Vstavljanje(oseba[] tabela)
        {
            // korak urejanja ponavljamo tolikokrat, kot je elementov tabeli
            // neurejeni kaže na prvi element v neurejenem delu
            for (int neurejeni = 0; neurejeni < tabela.Length; neurejeni++)
            {
                // izberemo prvi element iz neurejenega dela
                oseba prvi = tabela[neurejeni];
                // poiščemo, kam v urejeni del ga vstavljamo
                // hkrati elemente premikamo v desno, da naredimo prostor
                int kam = neurejeni - 1;
                while ((kam >= 0) && (prvi.S_emšo < tabela[kam].S_emšo))
                {
                    tabela[kam + 1] = tabela[kam];
                    kam = kam - 1;
                }
                // vstavimo ga v urejeni del
                tabela[kam + 1] = prvi;
                // povečamo urejeni del za 1
            }
            return tabela;
        }

        public static oseba[] Vstavljanje_rojen(oseba[] tabela)
        {
            // korak urejanja ponavljamo tolikokrat, kot je elementov tabeli
            // neurejeni kaže na prvi element v neurejenem delu
            for (int neurejeni = 0; neurejeni < tabela.Length; neurejeni++)
            {
                // izberemo prvi element iz neurejenega dela
                oseba prvi = tabela[neurejeni];
                // poiščemo, kam v urejeni del ga vstavljamo
                // hkrati elemente premikamo v desno, da naredimo prostor
                int kam = neurejeni - 1;
                while ((kam >= 0) && (prvi.S_date < tabela[kam].S_date))
                {
                    tabela[kam + 1] = tabela[kam];
                    kam = kam - 1;
                }
                // vstavimo ga v urejeni del
                tabela[kam + 1] = prvi;
                // povečamo urejeni del za 1
            }
            return tabela;
        }

        static oseba[] Vstavljanje_priimek(oseba[] tabela)
        {
            // korak urejanja ponavljamo tolikokrat, kot je elementov tabeli
            // neurejeni kaže na prvi element v neurejenem delu
            for (int neurejeni = 0; neurejeni < tabela.Length; neurejeni++)
            {
                // izberemo prvi element iz neurejenega dela
                oseba prvi = tabela[neurejeni];
                // poiščemo, kam v urejeni del ga vstavljamo
                // hkrati elemente premikamo v desno, da naredimo prostor
                int kam = neurejeni - 1;
                while ((kam >= 0) && (tabela[kam].S_priimek.ToLower().CompareTo(prvi.S_priimek.ToLower()) != -1))
                {
                    tabela[kam + 1] = tabela[kam];
                    kam = kam - 1;
                }
                // vstavimo ga v urejeni del
                tabela[kam + 1] = prvi;
                // povečamo urejeni del za 1
            }
            return tabela;
        }

        public static oseba Bisekcija(oseba[] tab, DateTime iskano)
        {
            int doKam = tab.Length - 1; // desna meja iskanja 
            int odKje = 0; //kje začnemo iskati
            int sred;  // indeks sredine intervala bomo računali sproti
            while (odKje <= doKam) // dokler je še kaj podatkov za iskanje
            {
                sred = (odKje + doKam) / 2; // indeks sredine dela kjer iščemo
                if (tab[sred].DatumRojstva < iskano)  //primerjava podatkov
                    odKje = sred + 1; // iščemo desno
                else
                    if (tab[sred].DatumRojstva > iskano)
                    doKam = sred - 1; //nov desno rob intervala
                else // podatka sta enaka, torej je tab[sred] == iskano
                    return tab[sred]; //metoda vrne true, kajti podatek je najden
            }
            return null; // podatek ni najden, metoda vrne false!
        }

        public static long bruh(Random rndd)
        {
            string a = string.Empty;
            
            for (int i = 0; i < 12; i++)
            {
                string b = rndd.Next(0, 10).ToString();
                if (i == 0 && b.Equals("0"))
                {
                    b = "1";
                }
                a += b;
            }

            return long.Parse(a);
        }

        #endregion


        #region naloga2


        static FileInfo[] UstvariSeznam(string potDoMape, ref FileInfo[] Seznam)
        {
            if (Directory.Exists(potDoMape))
            {
                DirectoryInfo dir = new DirectoryInfo(potDoMape);
                foreach (FileInfo dat in dir.GetFiles())
                {
                    Array.Resize(ref Seznam, Seznam.Length + 1); //dimenzijo tabele povečamo za 1
                    Seznam[Seznam.Length - 1] = dat;
                }
                /*še datoteke v podmapah uporabimo rekurzivni klic*/
                foreach (string mapa in Directory.GetDirectories(potDoMape))
                    UstvariSeznam(mapa, ref Seznam);
            }
            return Seznam;
        }



        static FileInfo[] Vstavljanje_ime(FileInfo[] tabela)
        {
            // korak urejanja ponavljamo tolikokrat, kot je elementov tabeli
            // neurejeni kaže na prvi element v neurejenem delu
            for (int neurejeni = 0; neurejeni < tabela.Length; neurejeni++)
            {
                // izberemo prvi element iz neurejenega dela
                FileInfo prvi = tabela[neurejeni];
                // poiščemo, kam v urejeni del ga vstavljamo
                // hkrati elemente premikamo v desno, da naredimo prostor
                int kam = neurejeni - 1;
                while ((kam >= 0) && (tabela[kam].Name.ToLower().CompareTo(prvi.Name.ToLower()) !=-1))
                {
                    tabela[kam + 1] = tabela[kam];
                    kam = kam - 1;
                }
                // vstavimo ga v urejeni del
                tabela[kam + 1] = prvi;
                // povečamo urejeni del za 1
            }
            return tabela;
        }

        static FileInfo[] Vstavljanje_dolžina(FileInfo[] tabela)
        {
            // korak urejanja ponavljamo tolikokrat, kot je elementov tabeli
            // neurejeni kaže na prvi element v neurejenem delu
            for (int neurejeni = 0; neurejeni < tabela.Length; neurejeni++)
            {
                // izberemo prvi element iz neurejenega dela
                FileInfo prvi = tabela[neurejeni];
                // poiščemo, kam v urejeni del ga vstavljamo
                // hkrati elemente premikamo v desno, da naredimo prostor
                int kam = neurejeni - 1;
                while ((kam >= 0) && (prvi.Length < tabela[kam].Length))
                {
                    tabela[kam + 1] = tabela[kam];
                    kam = kam - 1;
                }
                // vstavimo ga v urejeni del
                tabela[kam + 1] = prvi;
                // povečamo urejeni del za 1
                
            }
            return tabela;

        }




        static FileInfo[] Vstavljanje_extenzija(FileInfo[] tabela)
        {
            // korak urejanja ponavljamo tolikokrat, kot je elementov tabeli
            // neurejeni kaže na prvi element v neurejenem delu
            for (int neurejeni = 0; neurejeni < tabela.Length; neurejeni++)
            {
                // izberemo prvi element iz neurejenega dela
                FileInfo prvi = tabela[neurejeni];
                // poiščemo, kam v urejeni del ga vstavljamo
                // hkrati elemente premikamo v desno, da naredimo prostor
                int kam = neurejeni - 1;

                while ((kam >= 0) && (tabela[kam].Extension.CompareTo(prvi.Extension) != -1))
                {
                    tabela[kam + 1] = tabela[kam];
                    kam = kam - 1;

                }
                tabela[kam + 1] = prvi;

            }




            // vstavimo ga v urejeni del

            // povečamo urejeni del za 1

            return tabela;
        }



        public static FileInfo Bisekcija2(FileInfo[] tab, long iskano)
        {
            int doKam = tab.Length - 1; // desna meja iskanja 
            int odKje = 0; //kje začnemo iskati
            int sred;  // indeks sredine intervala bomo računali sproti
            while (odKje <= doKam) // dokler je še kaj podatkov za iskanje
            {
                sred = (odKje + doKam) / 2; // indeks sredine dela kjer iščemo
                if (tab[sred].Length > iskano)  //primerjava podatkov
                    odKje = sred + 1; // iščemo desno
                else
                    if (tab[sred].Length < iskano)
                    doKam = sred - 1; //nov desno rob intervala
                else // podatka sta enaka, torej je tab[sred] == iskano
                    return tab[sred]; //metoda vrne true, kajti podatek je najden
            }
            return null; // podatek ni najden, metoda vrne false!
        }

        public static FileInfo PoisciKTegaa(FileInfo[] tab, int isci)
        { 
            int k = tab.Length - isci;
            if (tab == null || tab.Length <= k)
                throw new Exception("Napačni vhodni podatki: tabela ne obstaja, ali pa vsebije manj kot " + k + " elementov");
            int odKje = 0, doKam = tab.Length - 1;
            // if odKje == doKam -> našli smo k-ti element
            while (odKje < doKam)
            {
                int leviRob = odKje, desniRob = doKam;
                FileInfo sredina = tab[(leviRob + desniRob) / 2];
                // ponavljamo dokler se levi in desni rob intervala ne srečata
                while (leviRob < desniRob)
                {
                    if (tab[leviRob].Length >= sredina.Length)
                    {
                        // večje vrednosti prestavljamo na konec tabele
                        FileInfo tmp = tab[desniRob];
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
                if (tab[leviRob].Length > sredina.Length)
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


    }



    public class oseba
    {
        public string ime;
        string priimek;
        public DateTime DatumRojstva;
        long emšo;

        public oseba()
        {
            this.ime = "nedoločeno";
            this.priimek = "NN";
            this.DatumRojstva = default(DateTime);
            this.emšo = 0000000000000;
        }
        public oseba(string ime, string priimek, DateTime DatumRojstva, long emšo)
        {
            this.ime = ime;
            this.priimek = priimek;
            this.DatumRojstva = DatumRojstva;
            this.emšo = emšo;
        }
        public string S_ime
        {
            get { return ime; }
            set
            {
                if (value.Length < 3)
                {
                    ime = "Nezadostno število znakov";
                }
                else
                {
                    ime = value;
                }
            }

        }
        public string S_priimek
        {
            get { return priimek; }
            set
            {
                if (value.Length < 3)
                {
                    priimek = "Nezadostno število znakov";
                }
                else
                {
                    priimek = value;
                }
            }

        }
        public long S_emšo
        {
            get { return emšo; }
            set
            {
                if (!emšo.Equals(typeof(long)) || (emšo == null) || (emšo.ToString().Length != 13))
                {
                    Console.WriteLine("nepravilna emšo");
                }
                else
                {
                    emšo = value;
                }
            }
        }
        public DateTime S_date
        {
            get { return DatumRojstva; }
            set { DatumRojstva = value; }
        }
        public int starost (DateTime timm)
        {
            int age = timm.Year - DatumRojstva.Year;
            return age;        
        }
    }
}

