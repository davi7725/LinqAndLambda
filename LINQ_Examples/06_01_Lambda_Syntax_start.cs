using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LINQ_Examples
{
    class Program
    {
        #region Class Definitions
        public class Customer
        {
            public string First { get; set; }
            public string Last { get; set; }
            public string State { get; set; }
            public double Price { get; set; }
            public string[] Purchases { get; set; }
        }

        public class Distributor
        {
            public string Name { get; set; }
            public string State { get; set; }
        }

        public class CustDist
        {
            public string custName { get; set; }
            public string distName { get; set; }
        }

        public class CustDistGroup
        {
            public string custName { get; set; }
            public IEnumerable<string> distName { get; set; }
        }
        #endregion

        #region Create data sources

        static List<Customer> customers = new List<Customer>
        {
            new Customer {First = "Cailin", Last = "Alford", State = "GA", Price = 930.00, Purchases = new string[] {"Panel 625", "Panel 200"}},
            new Customer {First = "Theodore", Last = "Brock", State = "AR", Price = 2100.00, Purchases = new string[] {"12V Li"}},
            new Customer {First = "Jerry", Last = "Gill", State = "MI", Price = 585.80, Purchases = new string[] {"Bulb 23W", "Panel 625"}},
            new Customer {First = "Owens", Last = "Howell", State = "GA", Price = 512.00, Purchases = new string[] {"Panel 200", "Panel 180"}},
            new Customer {First = "Adena", Last = "Jenkins", State = "OR", Price = 2267.80, Purchases = new string[] {"Bulb 23W", "12V Li", "Panel 180"}},
            new Customer {First = "Medge", Last = "Ratliff", State = "GA", Price = 1034.00, Purchases = new string[] {"Panel 625"}},
            new Customer {First = "Sydney", Last = "Bartlett", State = "OR", Price = 2105.00, Purchases = new string[] {"12V Li", "AA NiMH"}},
            new Customer {First = "Malik", Last = "Faulkner", State = "MI", Price = 167.80, Purchases = new string[] {"Bulb 23W", "Panel 180"}},
            new Customer {First = "Serena", Last = "Malone", State = "GA", Price = 512.00, Purchases = new string[] {"Panel 180", "Panel 200"}},
            new Customer {First = "Hadley", Last = "Sosa", State = "OR", Price = 590.20, Purchases = new string[] {"Panel 625", "Bulb 23W", "Bulb 9W"}},
            new Customer {First = "Nash", Last = "Vasquez", State = "OR", Price = 10.20, Purchases = new string[] {"Bulb 23W", "Bulb 9W"}},
            new Customer {First = "Joshua", Last = "Delaney", State = "WA", Price = 350.00, Purchases = new string[] {"Panel 200"}}
        };

        static List<Distributor> distributors = new List<Distributor>
        {
            new Distributor {Name = "Edgepulse", State = "UT"},
            new Distributor {Name = "Jabbersphere", State = "GA"},
            new Distributor {Name = "Quaxo", State = "FL"},
            new Distributor {Name = "Yakijo", State = "OR"},
            new Distributor {Name = "Scaboo", State = "GA"},
            new Distributor {Name = "Innojam", State = "WA"},
            new Distributor {Name = "Edgetag", State = "WA"},
            new Distributor {Name = "Leexo", State = "HI"},
            new Distributor {Name = "Abata", State = "OR"},
            new Distributor {Name = "Vidoo", State = "TX"}
        };

        static double[] exchange = { 0.89, 0.65, 120.29 };

        static double[] ExchangedPrices = {827.70, 604.50, 111869.70,
                                        1869.00, 1,365.00, 252609.00,
                                        521.36, 380.77, 70465.88,
                                        455.68, 332.80, 61588.48,
                                        2018.34, 1474.07, 272793.66,
                                        920.26, 672.10, 124379.86,
                                        1873.45, 1368.25, 253210.45,
                                        149.34, 109.07, 20184.66,
                                        455.68, 332.80, 61588.48,
                                        525.28, 383.63, 70995.16,
                                        9.08, 6.63, 1226.96,
                                        311.50, 227.50, 42101.50};

        static string[] Purchases = {  "Panel 625", "Panel 200",
                                    "12V Li",
                                    "Bulb 23W", "Panel 625",
                                    "Panel 200", "Panel 180",
                                    "Bulb 23W", "12V Li", "Panel 180",
                                    "Panel 625",
                                    "12V Li", "AA NiMH",
                                    "Bulb 23W", "Panel 180",
                                    "Panel 180", "Panel 200",
                                    "Panel 625", "Bulb 23W", "Bulb 9W",
                                    "Bulb 23W", "Bulb 9W",
                                    "Panel 200"
                                 };
        #endregion

        static void Main(string[] args)
        {

            //Where
            //Excersise1();

            //Select
            //Excersise2();

            //Take
            //Excersise3();

            //OrderBy
            //Excersise4();

            //GroupBy
            //Excersise5();

            //Accept
            //Excersise6();

            //Any
            //Excersise7();


            //Excersise1Lambda();
            //Excersise2Lambda();
            //Excersise4Lambda();
            Excersise5Lambda();

            Console.ReadKey();
        }

        private static void Excersise1()
        {
            IEnumerable<double> priceQuery =
                from e in ExchangedPrices
                where e <= 1000
                select e;

            IEnumerable<Customer> customerQuery =
                from c in customers
                where c.State == "GA"
                select c;


            foreach (double e in priceQuery)
            {
                Console.WriteLine("{0}", e.ToString());
            }

            foreach (Customer c in customerQuery)
            {
                Console.WriteLine("{0} - ", c.First);
                foreach (string s in c.Purchases)
                {
                    Console.WriteLine("\t {0}", s);
                }
            }

        }

        private static void Excersise2()
        {
            IEnumerable<string> firstNameQuery =
                from c in customers
                select c.First;

            IEnumerable<string> fullNameQuery =
                from c in customers
                select c.First + " " + c.Last;

            IEnumerable<string> stateAbbreviationQuery =
                from c in customers
                from d in distributors
                where c.State == d.State
                select c.State;


            foreach (string s in firstNameQuery)
            {
                Console.WriteLine("{0}", s);
            }

            foreach (string s in fullNameQuery)
            {
                Console.WriteLine("{0}", s);
            }

            foreach (string s in stateAbbreviationQuery)
            {
                Console.WriteLine("{0}", s);
            }

        }
        private static void Excersise3()
        {
            IEnumerable<Customer> firstThreeQuery =
                customers.Take(3);

            IEnumerable<Customer> firstThreeFromOregonQuery =
                customers.Where(c => c.State == "OR").Take(3);



            foreach (Customer c in firstThreeQuery)
            {
                Console.WriteLine("{0}", c.First);
            }

            foreach (Customer c in firstThreeFromOregonQuery)
            {
                
                Console.WriteLine("{0}", c.First);
            }

            

        }

        private static void Excersise4()
        {
            IEnumerable<Customer> orderByFirstNameQuery =
                from c in customers
                orderby c.First
                select c;

            IEnumerable<Customer> orderByLenghtOfFirstNameQuery =
                from c in customers
                orderby c.Last.Length
                select c;

            IEnumerable<Customer> orderByPriceDescQuery =
                from c in customers
                orderby c.Price descending
                select c;

            IEnumerable<Customer> orderByFNAndThenLNQuery =
                from c in customers
                orderby c.First.Length, c.Last
                select c;



            foreach (Customer c in orderByFirstNameQuery)
            {
                Console.WriteLine("{0}", c.First);
            }
            Console.WriteLine();
            foreach (Customer c in orderByLenghtOfFirstNameQuery)
            {

                Console.WriteLine("{0}", c.Last);
            }

            Console.WriteLine();
            foreach (Customer c in orderByPriceDescQuery)
            {

                Console.WriteLine("{0}", c.Price);
            }

            Console.WriteLine();
            foreach (Customer c in orderByFNAndThenLNQuery)
            {

                Console.WriteLine("{0}", c.First + " " + c.Last);
            }



        }
        private static void Excersise5()
        {
            IEnumerable<IGrouping<char, Customer>> groupByFirstLetterFNQuery =
                from c in customers
                group c by c.First[0];

            IEnumerable<IGrouping<string, Customer>> groupByStateQuery =
                from c in customers
                group c by c.State;


            foreach (IGrouping<char, Customer> fl in groupByFirstLetterFNQuery)
            {
                Console.WriteLine("{0}", fl.Key);
                foreach(Customer c in fl)
                {
                    Console.WriteLine("{0}", c.First);
                }
            }
            Console.WriteLine();
            foreach (IGrouping<string, Customer> state in groupByStateQuery)
            {
                Console.WriteLine("{0}", state.Key);
                foreach (Customer c in state)
                {
                    Console.WriteLine("{0}", c.First);
                }
            }
        }

        private static void Excersise6()
        {

            IEnumerable<char> FlFnQuery =
                from c in customers
                select c.First[0];


            IEnumerable<char> FlLnQuery =
                from c in customers
                select c.Last[0];

            IEnumerable<char> exceptFlFnDifferentFlLnQuery =
                FlFnQuery.Except(FlLnQuery);


            foreach (char c in exceptFlFnDifferentFlLnQuery)
            {
                Console.WriteLine("{0}", c);
            }
        }
        private static void Excersise7()
        {

            bool FnWithEdQuery =
                customers.Any(c=> c.First.Contains("ed"));

            Console.WriteLine("{0}", FnWithEdQuery);
        }

        private static void Excersise1Lambda()
        {
            IEnumerable<double> priceQuery =
                ExchangedPrices.Where(e => e <= 1000);

            IEnumerable<Customer> customerQuery =
                customers.Where(c => c.State == "GA");


            foreach (double e in priceQuery)
            {
                Console.WriteLine("{0}", e.ToString());
            }

            foreach (Customer c in customerQuery)
            {
                Console.WriteLine("{0} - ", c.First);
                foreach (string s in c.Purchases)
                {
                    Console.WriteLine("\t {0}", s);
                }
            }

        }

        private static void Excersise2Lambda()
        {
            IEnumerable<string> firstNameQuery =
                customers.Select(c => c.First);

            IEnumerable<string> fullNameQuery =
                customers.Select(c => c.First + " " + c.Last);

            IEnumerable<string> stateAbbreviationQuery =
                customers.SelectMany(c => distributors, (c, d) => new { c,d }).Where(x => x.c.State == x.d.State).Select(x => x.c.State);
                

            foreach (string s in firstNameQuery)
            {
                Console.WriteLine("{0}", s);
            }

            foreach (string s in fullNameQuery)
            {
                Console.WriteLine("{0}", s);
            }

            foreach (string s in stateAbbreviationQuery)
            {
                Console.WriteLine("{0}", s);
            }

        }

        private static void Excersise4Lambda()
        {
            IEnumerable<Customer> orderByFirstNameQuery =
                customers.OrderBy(c => c.First);

            IEnumerable<Customer> orderByLenghtOfFirstNameQuery =
                customers.OrderBy(c => c.Last.Length);

            IEnumerable<Customer> orderByPriceDescQuery =
                customers.OrderByDescending(c => c.Price);

            IEnumerable<Customer> orderByFNAndThenLNQuery =
                customers.OrderBy(c => c.Last).OrderBy(c => c.First.Length);



            foreach (Customer c in orderByFirstNameQuery)
            {
                Console.WriteLine("{0}", c.First);
            }
            Console.WriteLine();
            foreach (Customer c in orderByLenghtOfFirstNameQuery)
            {

                Console.WriteLine("{0}", c.Last);
            }

            Console.WriteLine();
            foreach (Customer c in orderByPriceDescQuery)
            {

                Console.WriteLine("{0}", c.Price);
            }

            Console.WriteLine();
            foreach (Customer c in orderByFNAndThenLNQuery)
            {

                Console.WriteLine("{0}", c.First + " " + c.Last);
            }



        }
        private static void Excersise5Lambda()
        {
            IEnumerable<IGrouping<char, Customer>> groupByFirstLetterFNQuery =
                customers.GroupBy(c => c.First[0]);

            IEnumerable<IGrouping<string, Customer>> groupByStateQuery =
                customers.GroupBy(c => c.State);


            foreach (IGrouping<char, Customer> fl in groupByFirstLetterFNQuery)
            {
                Console.WriteLine("{0}", fl.Key);
                foreach (Customer c in fl)
                {
                    Console.WriteLine("{0}", c.First);
                }
            }
            Console.WriteLine();
            foreach (IGrouping<string, Customer> state in groupByStateQuery)
            {
                Console.WriteLine("{0}", state.Key);
                foreach (Customer c in state)
                {
                    Console.WriteLine("{0}", c.First);
                }
            }
        }
    }
}
