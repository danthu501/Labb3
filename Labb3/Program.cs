using Labb3.Models;
using Microsoft.Data.SqlClient;
using System;
using System.Collections.Generic;
using System.Data;
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
            Console.WriteLine("[4] Hämta ut all personal");
          
            int UserInput;
            Int32.TryParse(Console.ReadLine(), out UserInput);


                switch (UserInput)
                {

                    case 1:
                        Console.WriteLine("Hämtar ut alla elver");
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

                                var Sort = from Elev in context.Elev
                                          orderby Elev.FörNamn 
                                          select Elev;

                                foreach (var item in Sort)
                                {
                                    Console.WriteLine(item.FörNamn+" "+item.EfterNamn);
                                }

                                break;
                            case 2:
                                var SortFND = from Elev in context.Elev
                                           orderby Elev.FörNamn descending
                                           select Elev;

                                foreach (var item in SortFND)
                                {
                                    Console.WriteLine(item.FörNamn + " " + item.EfterNamn);
                                }

                                break;

                            case 3:
                                var SortEN = from Elev in context.Elev
                                           orderby Elev.EfterNamn
                                             select Elev;

                                foreach (var item in SortEN)
                                {
                                    Console.WriteLine(item.FörNamn + " " + item.EfterNamn);
                                }

                                break;
                            
                            case 4:
                                var SortEND = from Elev in context.Elev
                                              orderby Elev.EfterNamn descending
                                              select Elev;

                                foreach (var item in SortEND)
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


                    case 4:
                        SqlConnection sqlCon1 = new SqlConnection(@"Data Source = DESKTOP-6TSF82P; Initial Catalog = Labb2E; Integrated Security = True");
                        SqlDataAdapter sqlda = new SqlDataAdapter(@"Select * from Anställda", sqlCon1);
                        DataTable dtbl = new DataTable();
                        sqlda.Fill(dtbl);

                        foreach (DataRow r in dtbl.Rows)
                        {
                            Console.Write(r["FörNamn"]+" ");
                            Console.Write(r["EfterNamn"]+" ");
                            Console.Write(r["Befattning"]);
                            Console.WriteLine();
                        }
                        Console.ReadKey();

                        break;
                    default:
                        Console.WriteLine("Var god ange en siffra mellan 1 och 4");
                        break;

                }
            }
        }
    }
}
