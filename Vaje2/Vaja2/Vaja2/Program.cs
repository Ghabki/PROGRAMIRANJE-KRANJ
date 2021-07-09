using System;
using System.IO;
using System.Net;
using System.Net.NetworkInformation;
using System.Runtime.InteropServices.WindowsRuntime;
using System.Threading.Tasks.Dataflow;
using System.Xml;
//Izjavljam, da sem nalogo opravil samostojno in da sem njen avtor. Zavedam se, da v primeru, če izjava prvega stavka ni resnična, kršim disciplinska pravila."
namespace Vaja2
{
    class Program
    {
        delegate string OperacijaNiz(string input); //napoved delegata
        delegate void OperacijaN(ref string imput);
        
        delegate int ZaporedjeUkazov(string[] tabelca);

        static void Main(string[] args)
        {
            #region naloga 1
            string b = "isjgba sjroig";
            Console.WriteLine(b.SkupnoSteviloZnakovBrezPresledkov());
            #endregion

            #region naloga 2
            string c = "abcd";
            Console.WriteLine(c.PrvaCrka());
            #endregion

            #region naloga 3
            String a = "AEiOu MNmnMNmnmn";
            OperacijaNiz oprecija = new OperacijaNiz(BrezSamoglasnikov);
            Console.WriteLine(oprecija(a));

            OperacijaNiz oprecija2 = new OperacijaNiz(OdstraniPresledke);
            Console.WriteLine(oprecija2(a));

            OperacijaNiz oprecija3 = new OperacijaNiz(SamaglasnikiNaKoncu);
            Console.WriteLine(oprecija3(a));

            OperacijaN ope = OdstraniPresledke1;
            ope += SamaglasnikiNaKoncu1;
            ope += BrezSamoglasnikov1;
            ope(ref a);
            Console.WriteLine(a);
            #endregion
            #region naloga 4
            Console.WriteLine("naloga  4");

            string[] tabla = File.ReadAllLines(@"..\..\..\Čete.txt");

            ZaporedjeUkazov UkazFile = new ZaporedjeUkazov(vrstice);
            Console.WriteLine(UkazFile(tabla));
            UkazFile += VsiZnaki;
            Console.WriteLine(UkazFile(tabla));
            UkazFile += countStevilke1;
            Console.WriteLine(UkazFile(tabla));
            UkazFile += stevke;
            Console.WriteLine(UkazFile(tabla));


            xmlConvert(tabla); 


            #endregion

        }
        #region naloga 3

        public static string BrezSamoglasnikov(string niz){

            niz = niz.Replace("a", "");
            niz = niz.Replace("e", "");
            niz = niz.Replace("i", "");
            niz = niz.Replace("o", "");
            niz = niz.Replace("u", "");
            niz = niz.Replace("A", "");
            niz = niz.Replace("E", "");
            niz = niz.Replace("I", "");
            niz = niz.Replace("O", "");
            niz = niz.Replace("U", "");
            return niz;






        }
        public static string OdstraniPresledke(string niz)
        {
            return niz.Replace(" ", "");
         


        }
        public static string SamaglasnikiNaKoncu(string niz)
        {
            int st = 0;
            string vrni = niz;
            foreach (var item in niz)
            {
                if (item.Equals('a') || item.Equals('e') || item.Equals('i') || item.Equals('o') || item.Equals('u') || item.Equals('A') || item.Equals('E') || item.Equals('I') || item.Equals('O') || item.Equals('U'))
                {
                    niz += item;
                }

            }
            return niz;

        }

        public static void BrezSamoglasnikov1(ref string niz)
        {

            niz = niz.Replace("a", "");
            niz = niz.Replace("e", "");
            niz = niz.Replace("i", "");
            niz = niz.Replace("o", "");
            niz = niz.Replace("u", "");
            niz = niz.Replace("A", "");
            niz = niz.Replace("E", "");
            niz = niz.Replace("I", "");
            niz = niz.Replace("O", "");
            niz = niz.Replace("U", "");






        }
        public static void OdstraniPresledke1(ref string niz)
        {
            niz =  niz.Replace(" ", "");



        }
        public static void SamaglasnikiNaKoncu1(ref string niz)
        {
            int st = 0;
            string vrni = niz;
            foreach (var item in niz)
            {
                if (item.Equals('a') || item.Equals('e') || item.Equals('i') || item.Equals('o') || item.Equals('u') || item.Equals('A') || item.Equals('E') || item.Equals('I') || item.Equals('O') || item.Equals('U'))
                {
                    niz += item;
                }

            }

        }

        #endregion


        #region naloga 4
        public static int vrstice (string [] tabla)
        {
            int a = 0;
            foreach (var item in tabla)
            {
                a++;
            }
            return a;


        }

        public static int VsiZnaki(string[] tabla)
        {
            int a = 0;
            foreach (var item in tabla)
            {
                a += item.Length;
                
            }
            return a;
        }

        public static int countStevilke1(string[] tabla)
        {
            int result1 = 0;
            foreach (var item in tabla)
            {
                result1 += item.Length - item.Replace("1", "").Length;
            }
            return result1;
        }

        public static int stevke (string[] tabla)
        {
            int stev = 0;
            foreach (var item in tabla)
            {
                string[] bruh = item.Split(",");
                foreach (var stevilka in bruh)
                {
                    stev += stevilka.Length;
                }

            }
            return stev;

        }

        public static void xmlConvert(string[] tabla)
        {
            XmlWriter writer = XmlWriter.Create("DatotekaXml", null);
            writer.WriteStartElement("LepNaslov");
            foreach (var item in tabla)
            {
                writer.WriteString(item);
            }
            writer.WriteEndElement();
            writer.Close();
        }

        #endregion

    }


    #region naloga 1 in 2
    public static class Razred
    {
        //naloga 1
        public static int SkupnoSteviloZnakovBrezPresledkov (this string niz)
        {
            int a = 0;
            foreach (var item in niz)
            {
                if (item == ' ')
                {
                    continue;
                }
                a++;
            }
            return a;
        }
//naloga 2
        public static char PrvaCrka (this string niz)
        {
            return niz[0];
        }


    }
}
    #endregion