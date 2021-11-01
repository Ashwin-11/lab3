using System;
using System.Collections.Generic;
using System.Threading;
using System.Diagnostics;

namespace Lab3Q1
{
    class Program
    {
        static void Main(string[] args)
        {
          // map and mutex for thread safety
          Mutex mutex = new Mutex();
          Dictionary<string, int> wcountsSingleThread = new Dictionary<string, int>();

            // Dictionary<string, int> wcountsSingleThread = new Dictionary<string, int> { { "d", 1}, { "b", 55 }, { "a", 6 }, { "e", 33 } };
           // data\shakespeare_antony_cleopatra.txt

              var filenames = new List<string> {
                "C:/Users/ashwi/Documents/GitHub/lab3/data/shakespeare_antony_cleopatra.txt",
                "C:/Users/ashwi/Documents/GitHub/lab3/data/shakespeare_hamlet.txt",
                "C:/Users/ashwi/Documents/GitHub/lab3/data/shakespeare_julius_caesar.txt",
                "C:/Users/ashwi/Documents/GitHub/lab3/data/shakespeare_king_lear.txt",
                "C:/Users/ashwi/Documents/GitHub/lab3/data/shakespeare_macbeth.txt",
                "C:/Users/ashwi/Documents/GitHub/lab3/data/shakespeare_merchant_of_venice.txt",
                "C:/Users/ashwi/Documents/GitHub/lab3/data/shakespeare_midsummer_nights_dream.txt",
                "C:/Users/ashwi/Documents/GitHub/lab3/data/shakespeare_much_ado.txt",
                "C:/Users/ashwi/Documents/GitHub/lab3/data/shakespeare_othello.txt",
                "C:/Users/ashwi/Documents/GitHub/lab3/data/shakespeare_romeo_and_juliet.txt",
           };

            //=============================================================
            // YOUR IMPLEMENTATION HERE TO COUNT WORDS IN SINGLE THREAD
            //=============================================================

            foreach (string filename in filenames)
            {
                HelperFunctions.CountCharacterWords(filename, mutex, wcountsSingleThread);
            }

            List<Tuple<int, string>> SingleThreadAnswer = new List<Tuple<int, string>>();
            SingleThreadAnswer=HelperFunctions.SortCharactersByWordcount(wcountsSingleThread);
            HelperFunctions.PrintListofTuples(SingleThreadAnswer);


            Console.WriteLine( "SingleThread is Done!");
           //=============================================================
           // YOUR IMPLEMENTATION HERE TO COUNT WORDS IN MULTIPLE THREADS
           //=============================================================




           Console.WriteLine( "MultiThread is Done!");
           //return 0;
        }
    }
}
