using SkolaDBProjekt.Models;
using System;
using System.Linq;

namespace SkolaDBProjekt
{
    class Program
    {
        static void Main(string[] args)
        {
            using SkolaDbContext context = new SkolaDbContext();

            SchoolFunctions sf = new SchoolFunctions();


            ////TEST-------------------------------
            ///
            //var Klasser = from klass in context.Klass
            //              select klass;

            //var elever = from elev in context.Elev                        
            //             join Klass in context.Klass on elev.FkklassId equals Klass.KlassId
            //             select new { elev.Förnamn, elev.Efternamn, KlassNamn = Klass.KlassNamn, Personummer = elev.Personnummer, elev.Kön };

            //foreach (var el in elever)
            //{
            //    Console.WriteLine(el.Förnamn);
            //    Console.WriteLine(el.KlassNamn);

                //foreach (var item in el.Betyg)
                //{
                //    Console.WriteLine(item.SattBetyg);
                //}
            //}


            //////-----------------------------

            bool continueLoop = true;
            do
            {
                Console.Clear();
                Console.WriteLine("Vad vill du göra?" +
               "\n1. Lista alla elever." +
               "\n2. Lista alla elever i en specifik klass." +
               "\n3. Lägga till ny personal." +
               "\n4. Visa antal jobbande lärare per ämne/avdelning" +
               "\n5. Visa alla aktiva kurser" +
               "\n6. Avsluta programmet");



                string answer = Console.ReadLine();
                Console.Clear();

                switch (answer)
                {
                    case "1":

                        bool orderByStigande = true;
                        bool orderByFörnamn = true;

                        Console.WriteLine("Vad vill du sortera eleverna på?" +
                          "\n1. Förnamn." +
                          "\n2. Efternamn.");

                        string answer2 = Console.ReadLine();
                        Console.Clear();
                        if (answer2 == "1")
                        {
                            orderByFörnamn = true;
                            Console.WriteLine("Vill du sortera stigande eller fallande?" +
                                "\n1. Stigande." +
                                "\n2. Fallande.");

                            string answer3 = Console.ReadLine();
                            if (answer3 == "1")
                            {
                                orderByStigande = true;
                                sf.VisaAllaElever(context, orderByStigande, orderByFörnamn);
                            }
                            else if (answer3=="2")
                            {
                                orderByStigande = false;
                                sf.VisaAllaElever(context, orderByStigande, orderByFörnamn);
                            }
                            else { break; }

                        }
                        else if (answer2 == "2")
                        {
                            orderByFörnamn = false;
                            Console.WriteLine("Vill du sortera stigande eller fallande?" +
                                "\n1. Stigande." +
                                "\n2. Fallande.");

                            string answer3 = Console.ReadLine();
                            if (answer3 == "1")
                            {
                                orderByStigande = true;
                                sf.VisaAllaElever(context, orderByStigande, orderByFörnamn);
                            }
                            else if (answer3 == "2")
                            {
                                orderByStigande = false;
                                sf.VisaAllaElever(context, orderByStigande, orderByFörnamn);
                            }
                            else { break; }
                        }
                        else
                        {
                            break;
                        }
                        break;

                    case "2":
                        sf.VisaEleverIEnKlass(context);

                        break;
                    case "3":
                        sf.LäggTillNyPersonal(context);
                    break;
                    case "4":
                        sf.VisaLärarePerAvdelning(context);
                        break;
                    case "5":
                        sf.VisaAllaAktivaKuser(context);
                        break;

                    default:
                        break;
                }

            } while (continueLoop);















        }
    }
}
