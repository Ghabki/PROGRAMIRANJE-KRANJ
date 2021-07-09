using System;
using System.Collections.Generic;
//"Izjavljam, da sem nalogo opravil samostojno in da sem njen avtor. Zavedam se, da v primeru, če izjava prvega stavka ni resnična, kršim disciplinska pravila."
namespace ConsoleApp1
{
    class Program
    {



        static void Main(string[] args)
        {


            #region Naloga1
            Stack<int> sklad = new Stack<int>();
            Stack<char> sklad2 = new Stack<char>();
            Stack<string> sklad3 = new Stack<string>();

            //T[] arr = new T[];

            sklad.Push(1); sklad.Push(2); sklad.Push(3); sklad.Push(4); sklad.Push(5); sklad.Push(6); sklad.Push(7); sklad.Push(8); sklad.Push(9); sklad.Push(10);

            sklad2.Push('a'); sklad2.Push('b'); sklad2.Push('c'); sklad2.Push('d'); sklad2.Push('e'); sklad2.Push('f'); sklad2.Push('g'); sklad2.Push('h'); sklad2.Push('i'); sklad2.Push('j');

            sklad3.Push("a"); sklad3.Push("b"); sklad3.Push("c"); sklad3.Push("d"); sklad3.Push("e"); sklad3.Push("f"); sklad3.Push("g"); sklad3.Push("h"); sklad3.Push("i"); sklad3.Push("j");




            Console.WriteLine("dodati na konec");

            DodajNaDno(ref sklad, 1);
            foreach (var item in sklad)
            {
                Console.WriteLine(item);
            }
            Console.WriteLine("");

            DodajNaDno(ref sklad2, 'b');
            foreach (var item in sklad2)
            {
                Console.WriteLine(item);
            }
            Console.WriteLine("");

            DodajNaDno(ref sklad3, "D");
            foreach (var item in sklad3)
            {
                Console.WriteLine(item);
            }
            Console.WriteLine("");



            Console.WriteLine("Odstraniti večje od");

            OdstraniVecje(ref sklad, 2);
            foreach (var item in sklad)
            {
                Console.WriteLine(item);
            }
            Console.WriteLine("");

            OdstraniVecje(ref sklad2, 'b');
            foreach (var item in sklad2)
            {
                Console.WriteLine(item);
            }

            Console.WriteLine("");

            OdstraniVecje(ref sklad3, "b");
            foreach (var item in sklad3)
            {
                Console.WriteLine(item);
            }
            Console.WriteLine("");


            Console.WriteLine("V array");
            int[] a = PrepisVTabelo(sklad);
            char[] b = PrepisVTabelo(sklad2);
            string[] c = PrepisVTabelo(sklad3);
            foreach (var item in a)
            {
                Console.WriteLine(item);

            }
            Console.WriteLine("");

            foreach (var item in b)
            {
                Console.WriteLine(item);

            }
            Console.WriteLine("");

            foreach (var item in c)
            {
                Console.WriteLine(item);

            }
            Console.WriteLine("");


            #endregion

            #region Naloga2
            string ime = "";
            double cas;

            Random rnd2 = new Random();
            List<Dokument> Dokumenti = new List<Dokument>();
            List<Dokument> Dokumenti2 = new List<Dokument>();
            List<Dokument> tabela = new List<Dokument>();


            for (int j = 0; j < 100; j++)
            {
                for (var k = 0; k < 5; k++)
                {
                    ime += ((char)(rnd2.Next(65, 91))).ToString();
                }

                cas = Math.Round(rnd2.NextDouble() * 100, 2);
                Console.WriteLine(ime + cas);
                Dokumenti.Add(new Dokument(ime , cas));
                tabela.Add(new Dokument(ime, cas));
                ime = "";
            }
            Console.WriteLine("");
            Console.WriteLine("Originalna");

            foreach (var item in Dokumenti)
            {
                Console.WriteLine(item.CasObdelave);
            }

            Console.WriteLine("");

            UrediDokumente(ref Dokumenti, ref Dokumenti2);

            Console.WriteLine("Cas obdelave za list 1 torej list v kateremu so manjse stevilke");
            

            foreach (var item in Dokumenti)
            {
                Console.WriteLine(item.CasObdelave);
            }


            GeneričnaZbirka<Dokument> abc = new GeneričnaZbirka<Dokument>();

            foreach (var item in tabela)
            {
                abc.Add(item);
            }
            abc.IzpisZbirke();

            abc.QS();



            abc.IzpisZbirke();
            //QuickSort(abc);
            


            #endregion

            #region Naloga3
            Random rng = new Random();


            Queue<int> que = new Queue<int>();
            Queue<int> temp = new Queue<int>();
            Queue<int> temp2 = new Queue<int>();


            int random_int;
            int i = 0;
            while (i < 100)
            {
                random_int = rng.Next(-100, 101);
                if (!que.Contains(random_int))
                {
                    que.Enqueue(random_int);
                    i++;
                }
            }




            //soda
            int stev = 0;

            int povprecje = 0;
            foreach (var item in que)
            {
                povprecje += item;
                if (Math.Abs(item) % 2 == 0)
                {
                    stev++;
                }
            }

            Console.WriteLine("V queue je toliko sodih števil: " + stev);
            Console.WriteLine("");


            //izpis
            Izpisi(que);
            Console.WriteLine("");
            Console.WriteLine("");


            //Povprečje
            Console.WriteLine("Povprečje je: " + povprecje / 100);
            Console.WriteLine("");

            // odstrani liha
            int prev;
            while (que.Count != 0)
            {
                prev = que.Dequeue();
                if (prev < 0)
                {
                    while (true)
                    {
                        random_int = rng.Next(-100, 101);
                        if (!temp.Contains(random_int))
                        {
                            temp.Enqueue(random_int);
                            break;
                        }
                    }
                }
                else
                {
                    temp.Enqueue(prev);
                }
            }
            que = temp;

            Izpisi(que);// za primerjat ce so negativna se spremenila in pozitivna ohranla

            Console.WriteLine("");
            Console.WriteLine("");

            //
            while (que.Count != 0)
            {
                prev = que.Dequeue();
                if ((Math.Abs(prev) % 2 == 0))
                {
                    temp2.Enqueue(prev);
                }
            }
            que = temp2;
            Izpisi(que);
            #endregion

            Console.ReadKey();
        }
        //public static void QuickSort(GeneričnaZbirka<Dokument> tabela, int i, int j)
        //{
        //    if (i < j)
        //    {
        //        /*tabelo razdelimo na dva dela: levi del tabele sestavljajo elementi, ki so manjši od pivotnega, desni del pa elementi, ki so večji od pivotnega*/
        //        int pivotIndeks = Premeci(tabela, i, j);
        //        //rekurzivni klic za preurejanje leve strani tabele
        //        QuickSort(tabela, i, pivotIndeks - 1);//urejamo levi del
        //                                              //rekurzivni klic za preurejanje desne strani tabele
        //        QuickSort(tabela, pivotIndeks + 1, j);//urejamo desni del
        //    }
        //}

        //static int Premeci(GeneričnaZbirka<Dokument> tabela, int i, int j)
        //{
        //    Dokument pivot = tabela[i];
        //    int levi = i;
        //    int desni = j;
        //    while (levi < desni)
        //    {
        //        //ponastavimo indeks levega dela tabele
        //        while (levi < desni && tabela[levi].CasObdelave <= pivot.CasObdelave)
        //            levi = levi + 1;
        //        //ponastavimo indeks desnega dela tabele
        //        while (levi < desni && tabela[desni].CasObdelave> pivot.CasObdelave)
        //            desni = desni - 1;
        //        if (levi < desni) //zamenjamo elementa med seboj
        //        {
        //            Dokument t = tabela[levi];
        //            tabela[levi] = tabela[desni];
        //            tabela[desni] = t;
        //        }
        //    }
        //    //če je element na levem robu večji od pivotnega
        //    if (tabela[levi].CasObdelave > pivot.CasObdelave)
        //        levi = levi - 1; //indeks pivotnega elementa zmanjšamo za 1
        //                         //element na levem robu postavimo na novo mesto
        //    tabela[i] = tabela[levi];s
        //    tabela[levi] = pivot;//pivotni element postavimo na levi rob
        //    return levi;
        //}

        #region naloga3
        public static void Izpisi(Queue<int> k)
        {
            foreach (var item in k)
            {
                Console.Write(item + " ; ");
            }
        }

        static T[] PrepisVTabelo<T>(Queue<T> Vrsta)
        {
            return Vrsta.ToArray();
        }
        #endregion

        #region naloga1
        static void DodajNaDno<T>(ref Stack<T> sklad, T podatek)
        {
            Stack<T> temp = new Stack<T>();

            foreach (var item in sklad)
            {
                temp.Push(item);
            }
            temp.Push(podatek);

            sklad = temp;
            
            


        }

        static void OdstraniVecje<T>(ref Stack<T> sklad, T podatek) where T : IComparable
        {
            Stack<T> temp = new Stack<T>();
            foreach (var item in sklad)
            {
                if (item.CompareTo(podatek)<=0)
                {
                    temp.Push(item);
                }
            }
            sklad = temp;


        }

        static T[] PrepisVTabelo<T>(Stack<T> sklad)
        {

            List<T> retu = new List<T>();
            foreach (var item in sklad)
            {
                retu.Add(item);
            }

            return retu.ToArray();
        }
        #endregion

        #region naloga2
        public static void UrediDokumente(ref List<Dokument> SeznamDokumentov, ref List<Dokument> Seznam2)
        {
            double e = 0;
            List<Dokument> kaj = new List<Dokument>();

            foreach (var item in SeznamDokumentov)
            {
                e += item.CasObdelave;
            }
            e = Math.Round(e / SeznamDokumentov.Count,2) ;
            
            Console.WriteLine("");
            Console.WriteLine("Povprecni cas obdelave v dokumentih "+e);
            Console.WriteLine("");

            foreach (var item in SeznamDokumentov)
            {
                if (item.CasObdelave>=e)
                {
                    Seznam2.Add(item);
                }
                else
                {
                    kaj.Add(item);
                }
            }
            SeznamDokumentov = kaj;
        }



        
            #endregion

        }


    #region Naloga2
    public class Dokument:IComparable
    {
        public string Naziv { get; set; }  //naziv dokumenta (npr "Prošnja"
        public double CasObdelave { get; set; }  //čas obdelave v minutah (npr. 3.23)
        public Dokument(string naz, double cas)
        {
            Naziv = naz; CasObdelave = cas;
        }

        public int CompareTo(Object obj)
        {
            Dokument dok = obj as Dokument;
            if (CasObdelave > dok.CasObdelave)
            {
                return 1;
            }
            else if (CasObdelave < dok.CasObdelave)
            {
                return -1;
            }
            else
            {
                return 0;
            }
        }
        public override string ToString()
        {
            return Naziv + " " + CasObdelave;
        }

    }

    public class GeneričnaZbirka<T>
    {
        T[] elementi;  //tabelarično polje
        
        private int velikost;   //polje hrani trenutno število podatkov v tabeli    
        public GeneričnaZbirka(int n = 0)  //konstruktor
        { elementi = new T[n]; velikost = n; }//začetna dimenzija tabele/zbirke  
        public T this[int indeks]   //indeksiranje 
        {
            get { return elementi[indeks]; } //dostop do posameznih polj
            set { elementi[indeks] = value; }  //prirejanje vrednostim poljem
        }
        //napišimo property, s katerim pridobimo atribut velikost
        public int Velikost
        {
            get { return velikost; }
        }

        //še get metoda za prodobivanje polja velikost
        public int VrneVelikost()
        {
            return velikost;
        }

        public void OdstraniVse()
        {
            elementi = new T[0];
            velikost = 0;
        }
        public void Add(T podatek)  //metoda za dodajanje novega elementa 
        {
            Array.Resize(ref elementi, elementi.Length + 1);
            elementi[velikost] = podatek;  //podatek zapišemo v prvo prosto celico
            velikost = velikost + 1; //število zasedenih celic
        }
        //generična metoda za brisanje celice z določenim indeksom
        public void Brisanje(int indeksCelice)
        {
            if (velikost == 0)
                Console.WriteLine("Zbirka je prazna, brisanje NI možno!");
            //celico brišemo le, če je njen indeks manjši od dimenzije zbirke  
            // if (indeksCelice < elementi.Length && indeksCelice >= 0)
            else if (indeksCelice < elementi.Length)
            {
                T[] zacasna = new T[elementi.Length - 1];
                int j = 0;
                for (int i = 0; i < elementi.Length; i++)
                {
                    if (i != indeksCelice)
                    {
                        zacasna[j] = elementi[i];
                        j++;
                    }
                }
                elementi = zacasna;
                velikost = velikost - 1;//zmanjšamo velikost zbirke
            }
            else Console.WriteLine("Brisanje NI možno, ker indeks št "+indeksCelice+" NE obstaja!"); 
            }
        //generična metoda za izpis poljubne zbirke
        public void IzpisZbirke()
        {
            if (velikost == 0)
                Console.WriteLine("Zbirka je prazna!");
            else
            {
                Console.WriteLine("Izpis ZBIRKE: ");
                for (int i = 0; i < elementi.Length; i++)
                    Console.WriteLine(elementi[i].ToString() + " ");
                Console.WriteLine();
            }
        }

        public void QS()
        {
            QuickSort(elementi, 0, elementi.Length-1);
            
        }

        void QuickSort(T[] tabela, int i, int j)
        {
            if (i < j)
            {
                /*tabelo razdelimo na dva dela: levi del tabele sestavljajo elementi, ki so manjši od pivotnega, desni del pa elementi, ki so večji od pivotnega*/
                int pivotIndeks = Premeci(tabela, i, j);
                //rekurzivni klic za preurejanje leve strani tabele
                QuickSort(tabela, i, pivotIndeks - 1);//urejamo levi del
                                                      //rekurzivni klic za preurejanje desne strani tabele
                QuickSort(tabela, pivotIndeks + 1, j);//urejamo desni del
            }
        }


        //lahko bi drugače implementiral, vendar je tudi tako ok
        private int Premeci(T[] tabela, int i, int j)
        {
            Dokument[] abj = tabela as Dokument[];
            Dokument pivot = abj[i];
            int levi = i;
            int desni = j;
            while (levi < desni)
            {
                //ponastavimo indeks levega dela tabele
                while (levi < desni && abj[levi].CasObdelave <= pivot.CasObdelave)
                    levi = levi + 1;
                //ponastavimo indeks desnega dela tabele
                while (levi < desni && abj[desni].CasObdelave > pivot.CasObdelave)
                    desni = desni - 1;
                if (levi < desni) //zamenjamo elementa med seboj
                {
                    Dokument t = abj[levi];
                    abj[levi] = abj[desni];
                    abj[desni] = t;
                }
            }
            //če je element na levem robu večji od pivotnega
            if (abj[levi].CasObdelave > pivot.CasObdelave)
                levi = levi - 1; //indeks pivotnega elementa zmanjšamo za 1
                                 //element na levem robu postavimo na novo mesto
            abj[i] = abj[levi];
            abj[levi] = pivot;//pivotni element postavimo na levi rob
            return levi;
        }


    }
}



#endregion






























