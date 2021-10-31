using System;
using System.Collections.Generic;
namespace Lab3Q1
{
    public class WordCountTester
    {
        static void Main()
        {
          try {


                //=================================================
                // Implement your tests here. Check all the edge case scenarios.
                // Create a large list which iterates over WCTester
                //=================================================

                /*----------------------------------------------1 Word---------------------------------------------------------*/
                string line = "Ashwin";
                int startIdx = 0;
                int expectedResults = 1;
                WCTester(line, startIdx, expectedResults);

                line = "Ashwin ";
                startIdx = 0;
                expectedResults = 1;
                WCTester(line, startIdx, expectedResults);

                line = " Ashwin";
                startIdx = 0;
                expectedResults = 1;
                WCTester(line, startIdx, expectedResults);

                line = " Ashwin ";
                startIdx = 0;
                expectedResults = 1;
                WCTester(line, startIdx, expectedResults);

                line = "Ashwin";
                startIdx = 3;
                expectedResults = 1;
                WCTester(line, startIdx, expectedResults);

                /*----------------------------------------------2 Words---------------------------------------------------------*/
                line = "Ash win";
                startIdx = 0;
                expectedResults = 2;
                WCTester(line, startIdx, expectedResults);

                line = "Ash win ";
                startIdx = 0;
                expectedResults = 2;
                WCTester(line, startIdx, expectedResults);

                line = " Ash win";
                startIdx = 0;
                expectedResults = 2;
                WCTester(line, startIdx, expectedResults);

                line = " Ash win ";
                startIdx = 0;
                expectedResults = 2;
                WCTester(line, startIdx, expectedResults);

                line = "Ash win";
                startIdx = 2;
                expectedResults = 2;
                WCTester(line, startIdx, expectedResults);

                line = "Ash win";
                startIdx = 3;
                expectedResults = 1;
                WCTester(line, startIdx, expectedResults);

                /*----------------------------------------------3 Words---------------------------------------------------------*/
                line = "I am Ashwin";
                startIdx = 0;
                expectedResults = 3;
                WCTester(line, startIdx, expectedResults);

                line = "I am Ashwin ";
                startIdx = 0;
                expectedResults = 3;
                WCTester(line, startIdx, expectedResults);

                line = " I am Ashwin";
                startIdx = 0;
                expectedResults = 3;
                WCTester(line, startIdx, expectedResults);

                line = " I am Ashwin ";
                startIdx = 0;
                expectedResults = 3;
                WCTester(line, startIdx, expectedResults);

                line = "I am Ashwin";
                startIdx = 2;
                expectedResults = 2;
                WCTester(line, startIdx, expectedResults);

                line = "I am Ashwin";
                startIdx = 4;
                expectedResults = 1;
                WCTester(line, startIdx, expectedResults);

                line = "I am Ashwin";
                startIdx = 7;
                expectedResults = 1;
                WCTester(line, startIdx, expectedResults);

            } catch(UnitTestException e) {
              Console.WriteLine(e);
            }

        }


        /**
         * Tests word_count for the given line and starting index
         * @param line line in which to search for words
         * @param start_idx starting index in line to search for words
         * @param expected expected answer
         * @throws UnitTestException if the test fails
         */
          static void WCTester(string line, int start_idx, int expected) {

            //=================================================
            // Implement: comparison between the expected and
            // the actual word counter results
            //=================================================
            int result = HelperFunctions.WordCount(ref line, start_idx);
            

            if (result != expected) {
              throw new Lab3Q1.UnitTestException(ref line, start_idx, result, expected, String.Format("UnitTestFailed: result:{0} expected:{1}, line: {2} ,starting from index {3}", result, expected, line, start_idx));
            }

           }
    }
}
