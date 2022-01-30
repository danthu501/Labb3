using Labb3.Models;
using System;
using System.Collections.Generic;
using System.Linq;

namespace Labb3
{
    class Program
    {
        static void Main(string[] args)
        {
            var context = new Labb2EContext();
            bool menybool = true;

            while (menybool)
            {

            
            Console.WriteLine("Hej Välkommen till Skolans system");
            Console.WriteLine();
            Console.WriteLine("Var god ange en siffra i menyn");
            Console.WriteLine();
            Console.WriteLine("[1] Hämta ut alla elver");
            Console.WriteLine("[2] Hämta ut alla elver i en viss klass");
            Console.WriteLine("[3] Lägg till ny personal");
          
            int UserInput;
            Int32.TryParse(Console.ReadLine(), out UserInput);


                switch (UserInput)
                {

                    case 1:
                        Console.WriteLine("Hämtar ut alla elver");

                    https://www.dotnetperls.com/sort
                        List<Elev> Test = new List<Elev>();

                        foreach (var item in context.Elev)
                        {
                            var Elever = new Elev()
                            {
                                Personnummer = item.Personnummer,
                                FörNamn = item.FörNamn,
                                EfterNamn = item.EfterNamn,
                                Klass = item.Klass
                            };
                            Test.Add(Elever);
                        }

                        Console.WriteLine();
                        Console.WriteLine("[1] Sortera alla elver i bokstavsordning efter förnamn, från a till ö.");
                        Console.WriteLine("[2] Sortera Alla elver från ö till a efter förnamn");
                        Console.WriteLine("[3] Sortera Alla elver från a till ö efter efternamn");
                        Console.WriteLine("[4] Sortera Alla elver från ö till a efter efternamn");
                        int OrderInput;
                        Int32.TryParse(Console.ReadLine(), out OrderInput);

                        switch (OrderInput)
                        {
                            case 1:

                                //Stolen from Aarkan1
                                Test.Sort((x, y) => x == null ? 1 : y == null ? -1 : x.FörNamn.CompareTo(y.FörNamn));
                                foreach (var item in Test)
                                {
                                    Console.WriteLine(item.FörNamn + " " + item.EfterNamn);
                                }

                                break;
                            case 2:
                                //Stolen from Aarkan1 but alterd so it order by rising insted of falling order.
                                Test.Sort((x, y) => x == null ? 1 : y == null ?-1 : y.FörNamn.CompareTo(x.FörNamn));
                                foreach (var item in Test)
                                {
                                    Console.WriteLine(item.FörNamn + " " + item.EfterNamn);
                                }

                                break;
                            case 3:
                                //Stolen from Aarkan1
                                Test.Sort((x, y) => x == null ? 1 : y == null ? -1 : x.EfterNamn.CompareTo(y.EfterNamn));
                                foreach (var item in Test)
                                {
                                    Console.WriteLine(item.FörNamn + " " + item.EfterNamn);
                                }
                               
                                break;
                            case 4:
                                //Stolen from Aarkan1 but alterd so it order by rising insted of falling order.
                                Test.Sort((x, y) => x == null ? 1 : y == null ? -1 : y.EfterNamn.CompareTo(x.EfterNamn));
                                foreach (var item in Test)
                                {
                                    Console.WriteLine(item.FörNamn + " " + item.EfterNamn);
                                }

                                break;
                        }

                        break;
                    case 2:

                        foreach (var item in context.Klass)
                        {
                            Console.WriteLine(item.KlassId + " " + item.KlassNamn);
                        }
                        Console.Write("Skriv in siffran på klassen som du vill se alla elver från:");
                        int Input;
                        Int32.TryParse(Console.ReadLine(), out Input);
                        foreach (var item in context.Elev)
                        {
                            if (item.Klass == Input)
                            {
                                Console.WriteLine(item.FörNamn + " " + item.EfterNamn);
                            }

                        }
                        
                        break;
                       

                    case 3:
                        Console.Write("Skriv förnamet på den anställd:");
                        string FirstNameInput = Console.ReadLine();
                        Console.Write("Skriv efternamnet på den anställda:");
                        string SecondnameInput = Console.ReadLine();
                        Console.Write("Skriv befattningen på den anställda:");
                        string BefattningInput = Console.ReadLine();
                        Anställda A1 = new Anställda();

                        A1.FörNamn = FirstNameInput;
                        A1.EfterNamn = SecondnameInput;
                        A1.Befattning = BefattningInput;

                        context.Add(A1);
                        context.SaveChanges();
                        break;

                    default:
                        Console.WriteLine("Var god ange en siffra mellan 1 och 3");
                        break;

                }
            }
        }
    }
}
