using SkolaDBProjekt.Models;
using System;
using System.Collections.Generic;
using System.Text;
using System.Linq;

namespace SkolaDBProjekt.Models
{

    public class SchoolFunctions
    {

        public void VisaAllaElever(SkolaDbContext context, bool orderByStigande = true, bool orderByFörnamn = true)
        {
            Console.Clear();
            if (orderByStigande & orderByFörnamn)
            {
                var Elever = from elev in context.Elev
                             join klass in context.Klass on elev.FkklassId equals klass.KlassId
                             orderby elev.Förnamn ascending
                             select new { elev.Förnamn, elev.Efternamn, Klass = klass.KlassNamn, Personummer = elev.Personnummer, elev.Kön };

                foreach (var i in Elever)
                {
                    Console.WriteLine($"Förnamn: {i.Förnamn} \nEfternamn: {i.Efternamn} \nKlass: {i.Klass} \nPersonnummer: {i.Personummer} \nKön: {i.Kön}\n");
                }
                Console.ReadKey();
            }
            else if (orderByStigande & orderByFörnamn == false)
            {
                var Elever = from elev in context.Elev
                             join klass in context.Klass on elev.FkklassId equals klass.KlassId
                             orderby elev.Efternamn ascending
                             select new { elev.Förnamn, elev.Efternamn, Klass = klass.KlassNamn, Personummer = elev.Personnummer, elev.Kön };

                foreach (var i in Elever)
                {
                    Console.WriteLine($"Förnamn: {i.Förnamn} \nEfternamn: {i.Efternamn} \nKlass: {i.Klass} \nPersonnummer: {i.Personummer} \nKön: {i.Kön}\n");
                }
                Console.ReadKey();
            }
            else if (orderByStigande == false & orderByFörnamn)
            {
                var Elever = from elev in context.Elev
                             join klass in context.Klass on elev.FkklassId equals klass.KlassId
                             orderby elev.Förnamn descending
                             select new { elev.Förnamn, elev.Efternamn, Klass = klass.KlassNamn, Personummer = elev.Personnummer, elev.Kön };

                foreach (var i in Elever)
                {
                    Console.WriteLine($"Förnamn: {i.Förnamn} \nEfternamn: {i.Efternamn} \nKlass: {i.Klass} \nPersonnummer: {i.Personummer} \nKön: {i.Kön}\n");
                }
                Console.ReadKey();
            }
            else
            {
                var Elever = from elev in context.Elev
                             join klass in context.Klass on elev.FkklassId equals klass.KlassId
                             orderby elev.Efternamn descending
                             select new { elev.Förnamn, elev.Efternamn, Klass = klass.KlassNamn, Personummer = elev.Personnummer, elev.Kön };

                foreach (var i in Elever)
                {
                    Console.WriteLine($"Förnamn: {i.Förnamn} \nEfternamn: {i.Efternamn} \nKlass: {i.Klass} \nPersonnummer: {i.Personummer} \nKön: {i.Kön}\n");
                }
                Console.ReadKey();
            }


        }

        public void VisaEleverIEnKlass(SkolaDbContext context)
        {
            var Klasser = from klass in context.Klass
                          select klass;
            Console.Clear();
            Console.WriteLine("Klasserna som är registrerade:");


            foreach (var klass in Klasser)
            {
                Console.WriteLine(klass.KlassNamn);
            }

            Console.WriteLine("\nSkriv vilken klass du vill visa eleverna ifrån.");

            string classAnswer = Console.ReadLine().ToUpper();

            if (Klasser.Any(x => x.KlassNamn == classAnswer))
            {
                var elever = from elev in context.Elev
                             where elev.Fkklass.KlassNamn == classAnswer
                             select elev;

                Console.Clear();


                Console.WriteLine("Elever i " + classAnswer + "\n");
                foreach (var i in elever)
                {
                    Console.WriteLine($"Förnamn: {i.Förnamn} \nEfternamn: {i.Efternamn} \nPersonnummer: {i.Personnummer} \nKön: {i.Kön}\n");
                }
            }
            else
            {
                Console.WriteLine("Klassen du skrev in hittades ej.");
            }

            Console.ReadKey();
        }
        public void VisaLärarePerAvdelning(SkolaDbContext context)
        {
            var lärarePerÄmne = from kurs in context.Kurs
                                join lärareKurs in context.LärareKurs on kurs.KursId equals lärareKurs.FkkursId
                                join lärare in context.Personal on lärareKurs.FkpersonalId equals lärare.PersonalId
                                select new { kurs = kurs.Ämne, lärarId = lärare.PersonalId };

            var lärarePerÄmneDistinct = lärarePerÄmne.Distinct();

            Dictionary<string, int> lärarePerÄmneCount = new Dictionary<string, int>();

            foreach (var item in lärarePerÄmneDistinct)
            {
                if (lärarePerÄmneCount.ContainsKey(item.kurs))
                {
                    lärarePerÄmneCount[item.kurs]++;
                }
                else
                {
                    lärarePerÄmneCount.Add(item.kurs, 1);
                }
            }

            Console.Clear();
            Console.WriteLine("Antal lärare per ämne:\n");
            foreach (var ämne in lärarePerÄmneCount)
            {
                Console.WriteLine($"{ämne.Key}: {ämne.Value}");
            }
            Console.ReadKey();

        }
        public void VisaAllaAktivaKuser(SkolaDbContext context)
        {
            var kurser = from kurs in context.Kurs
                         join lärareKurs in context.LärareKurs on kurs.KursId equals lärareKurs.FkkursId
                         join lärare in context.Personal on lärareKurs.FkpersonalId equals lärare.PersonalId
                         where kurs.Startdatum < DateTime.Today & kurs.Slutdatum > DateTime.Today
                         select new { kurs.KursId, kurs.Ämne, LärareFNamn = lärare.Förnamn, LärareENamn = lärare.Efternamn, lärare.PersonalId, StartDatum = kurs.Startdatum, SlutDatum = kurs.Slutdatum };


            Dictionary<int, List<Personal>> lärarePerKurs = new Dictionary<int, List<Personal>>();
            
            foreach (var k in kurser)
            {
                if (lärarePerKurs.ContainsKey(k.KursId))
                {
                    lärarePerKurs[k.KursId].Add(new Personal { PersonalId = k.PersonalId, Förnamn = k.LärareFNamn, Efternamn = k.LärareENamn });
                }
                else
                {
                    lärarePerKurs.Add(k.KursId, new List<Personal> { new Personal { PersonalId = k.PersonalId, Förnamn = k.LärareFNamn, Efternamn = k.LärareENamn } });
                }
            }
            Console.WriteLine("Alla aktiva kurser: \n");
            foreach (var k in kurser)
            {
                if(lärarePerKurs[k.KursId][0].PersonalId == k.PersonalId)
                {
                    Console.Write($"KursId: {k.KursId}" +
                        $"\nÄmne: {k.Ämne}" +
                        $"\nStartdatum: {k.StartDatum.Value.ToShortDateString()}" +
                        $"\nSlutdatum: {k.SlutDatum.Value.ToShortDateString()}" +
                        $"\nLärare:");

                        int count = 0;
                        foreach (var l in lärarePerKurs[k.KursId])
                        {
                            count++;
                            Console.Write(" " + l.Förnamn + " " + l.Efternamn);
                            if (count < lärarePerKurs[k.KursId].Count())
                            {
                                Console.Write(",");
                            }
                        }
                    Console.WriteLine("\n");
                    
                }
            }
            Console.ReadKey();



        }
        public void LäggTillNyPersonal(SkolaDbContext context)
        {
            var personal = from person in context.Personal
                           select person;
            int highestId = personal.Max(x => x.PersonalId);

            Personal nyPerson = new Personal
            {
                PersonalId = ++highestId
            };

            Console.Clear();
            Console.WriteLine("Vilket förnamn har den nyanställda?");
            nyPerson.Förnamn = Console.ReadLine();

            Console.WriteLine("\nVilket efternamn har den nyanstälda?");
            nyPerson.Efternamn = Console.ReadLine();

            Console.WriteLine("\nVilket befattning har den nyanställda?");
            nyPerson.Befattning = Console.ReadLine();

            Console.WriteLine("\nVilket datum början den nyanställda arbeta? (YYYY-MM-DD)");
            nyPerson.AnställningsDatum = DateTime.Parse(Console.ReadLine());

            Console.WriteLine("\nVilken månadslön har den nyanställda?");
            nyPerson.Månadslön = Decimal.Parse(Console.ReadLine());




            context.Personal.Add(nyPerson);
            context.SaveChanges();
        }


    }
}
