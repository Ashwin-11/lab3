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
          Dictionary<string, int> wcountsMultiThread = new Dictionary<string, int>();
          Stopwatch SingleThreadTime = new Stopwatch();
          Stopwatch MultiThreadTime = new Stopwatch();

            // Dictionary<string, int> wcountsSingleThread = new Dictionary<string, int> { { "d", 1}, { "b", 55 }, { "a", 6 }, { "e", 33 } };
            // data\shakespeare_antony_cleopatra.txt

            var filenames = new List<string> {
                "C:/Users/ashwi/Documents/GitHub/lab3/data/shakespeare_antony_cleopatra.txt",
                "C:/Users/ashwi/Documents/GitHub/lab3/data/shakespeare_alls_well.txt",
                "C:/Users/ashwi/Documents/GitHub/lab3/data/shakespeare_hamlet.txt",
                "C:/Users/ashwi/Documents/GitHub/lab3/data/shakespeare_julius_caesar.txt",
                "C:/Users/ashwi/Documents/GitHub/lab3/data/shakespeare_king_lear.txt",
                "C:/Users/ashwi/Documents/GitHub/lab3/data/shakespeare_macbeth.txt",
                "C:/Users/ashwi/Documents/GitHub/lab3/data/shakespeare_merchant_of_venice.txt",
                "C:/Users/ashwi/Documents/GitHub/lab3/data/shakespeare_midsummer_nights_dream.txt",
                "C:/Users/ashwi/Documents/GitHub/lab3/data/shakespeare_much_ado.txt",
                "C:/Users/ashwi/Documents/GitHub/lab3/data/shakespeare_othello.txt",
                "C:/Users/ashwi/Documents/GitHub/lab3/data/shakespeare_romeo_and_juliet.txt",
                "C:/Users/ashwi/Documents/GitHub/lab3/data/shakespeare_as_you_like_it.txt",
                "C:/Users/ashwi/Documents/GitHub/lab3/data/shakespeare_comedy_of_errors.txt",
                "C:/Users/ashwi/Documents/GitHub/lab3/data/shakespeare_coriolanus.txt",
                "C:/Users/ashwi/Documents/GitHub/lab3/data/shakespeare_cymbeline.txt",
                "C:/Users/ashwi/Documents/GitHub/lab3/data/shakespeare_gentlemen_of_verona.txt",
                "C:/Users/ashwi/Documents/GitHub/lab3/data/shakespeare_king_henry_IV_first.txt",
                "C:/Users/ashwi/Documents/GitHub/lab3/data/shakespeare_king_henry_IV_second.txt",
                "C:/Users/ashwi/Documents/GitHub/lab3/data/shakespeare_king_henry_V.txt",
                "C:/Users/ashwi/Documents/GitHub/lab3/data/shakespeare_king_henry_VI_first.txt",
                "C:/Users/ashwi/Documents/GitHub/lab3/data/shakespeare_king_henry_VI_second.txt",
                "C:/Users/ashwi/Documents/GitHub/lab3/data/shakespeare_king_henry_VI_third.txt",
                "C:/Users/ashwi/Documents/GitHub/lab3/data/shakespeare_king_henry_VIII.txt",
                "C:/Users/ashwi/Documents/GitHub/lab3/data/shakespeare_king_john.txt",
                "C:/Users/ashwi/Documents/GitHub/lab3/data/shakespeare_king_lear.txt",
                "C:/Users/ashwi/Documents/GitHub/lab3/data/shakespeare_king_richard_II.txt",
                "C:/Users/ashwi/Documents/GitHub/lab3/data/shakespeare_king_richard_III.txt",
                "C:/Users/ashwi/Documents/GitHub/lab3/data/shakespeare_lovers_complaint.txt",
                "C:/Users/ashwi/Documents/GitHub/lab3/data/shakespeare_loves_labours_lost.txt",
                "C:/Users/ashwi/Documents/GitHub/lab3/data/shakespeare_sonnets.txt",
                "C:/Users/ashwi/Documents/GitHub/lab3/data/shakespeare_taming_of_the_shrew.txt",

           };

            //=============================================================
            // YOUR IMPLEMENTATION HERE TO COUNT WORDS IN SINGLE THREAD
            //=============================================================
            Console.WriteLine("----------------------------------SingleThread Starts!--------------------------------------");
            SingleThreadTime.Start();
            foreach (string filename in filenames)
            {
                HelperFunctions.CountCharacterWords(filename, mutex, wcountsSingleThread);
            }

            List<Tuple<int, string>> SingleThreadAnswer = new List<Tuple<int, string>>();
            SingleThreadAnswer=HelperFunctions.SortCharactersByWordcount(wcountsSingleThread);
            HelperFunctions.PrintListofTuples(SingleThreadAnswer);
            SingleThreadTime.Stop();

            Console.WriteLine("SingleThread RunTime: {0:00} min {1:00} sec {2:00} milisecond", SingleThreadTime.Elapsed.Minutes, SingleThreadTime.Elapsed.Seconds, SingleThreadTime.Elapsed.Milliseconds);
            Console.WriteLine("----------------------------------SingleThread is Done!--------------------------------------");
            Console.WriteLine("");
            //=============================================================
            // YOUR IMPLEMENTATION HERE TO COUNT WORDS IN MULTIPLE THREADS
            //=============================================================
            Console.WriteLine("----------------------------------MultiThread Starts!--------------------------------------");
            MultiThreadTime.Start();
            Thread[] threads_per_file = new Thread[filenames.Count]; //no of threads=no of data files
            int i = 0;
            foreach (string filename in filenames)
            {
                threads_per_file[i]= new Thread(() => HelperFunctions.CountCharacterWords(filename, mutex, wcountsMultiThread));   
                threads_per_file[i].Start();
                ++i;
            }

            for (int x = 0; x < filenames.Count; x++)
            {
                threads_per_file[x].Join();
            }

            List<Tuple<int, string>> MultiThreadAnswer = new List<Tuple<int, string>>();
            MultiThreadAnswer = HelperFunctions.SortCharactersByWordcount(wcountsMultiThread);
            HelperFunctions.PrintListofTuples(MultiThreadAnswer);
            MultiThreadTime.Stop();

            Console.WriteLine("Multithread RunTime: {0:00} min {1:00} sec {2:00} milisecond", MultiThreadTime.Elapsed.Minutes, MultiThreadTime.Elapsed.Seconds, MultiThreadTime.Elapsed.Milliseconds);
            Console.WriteLine( "----------------------------------MultiThread is Done!--------------------------------------");
           //return 0;
        }
    }
}
