﻿using System;
using System.Collections.Generic;
using System.Threading;
using System.Linq;


namespace Lab3Q1
{
    public class HelperFunctions
    {
        /**
         * Counts number of words, separated by spaces, in a line.
         * @param line string in which to count words
         * @param start_idx starting index to search for words
         * @return number of words in the line
         */
        public static int WordCount(ref string line, int start_idx)
        {
            // YOUR IMPLEMENTATION HERE
            int isSpace = 0; //out
            int isChar = 1;
            int state= isSpace;
            int count = 0;

            if (line[start_idx]==' ')
                state = isSpace;
            else
            {
                state = isChar;
                count = 1;
            }

            int i = start_idx;

            while (i < line.Length)
            {
                // Scan all characters one by one, if character is a separator, set the state as isSpace
                if (line[i] == ' ')
                    state = isSpace;
                // If next character is not a space and the state is isSpace(prev char was a space) , then set the state as isChar and increment word count
                else if (state == isSpace)
                {
                    state = isChar;
                    ++count;
                }
                ++i;
                }
            return count;
        }


        /**
        * Reads a file to count the number of words each actor speaks.
        *
        * @param filename file to open
        * @param mutex mutex for protected access to the shared wcounts map
        * @param wcounts a shared map from character -> word count
        */
        public static void CountCharacterWords(string filename, Mutex mutex, Dictionary<string, int> wcounts)
        {

            //===============================================
            //  IMPLEMENT THIS METHOD INCLUDING THREAD SAFETY
            //===============================================

             string line;  // for storing each line read from the file
             string character = "";  // empty character to start
             System.IO.StreamReader file = new System.IO.StreamReader(filename);

             while ((line = file.ReadLine()) != null)
             {
                //=================================================
                // YOUR JOB TO ADD WORD COUNT INFORMATION TO MAP
                //=================================================
                
                // Is the line a dialogueLine?
                if (IsDialogueLine(line,ref character) != -1)
                {
                    
                    int index = IsDialogueLine(line, ref character);  //If yes, get the index and the character name.

                    if (index > 0 && character != null) //if index > 0 and character not empty
                    {
                        
                        int wc=WordCount(ref line, index); //get the word counts
                        mutex.WaitOne(); //modifying dictionary should be done by one thread at a time
                        if (wcounts.ContainsKey(character)) //if the key exists, update the word counts
                        { 
                                wcounts[character] += wc;
                        }
                        else    //else add a new key-value to the dictionary
                        {
                            wcounts.Add(character, wc);
                        }
                        mutex.ReleaseMutex();

                        //    reset the character
                    }
                }
                
            }
            // Close the file
            file.Close();
        }



        /**
         * Checks if the line specifies a character's dialogue, returning
         * the index of the start of the dialogue.  If the
         * line specifies a new character is speaking, then extracts the
         * character's name.
         *
         * Assumptions: (doesn't have to be perfect)
         *     Line that starts with exactly two spaces has
         *       CHARACTER. <dialogue>
         *     Line that starts with exactly four spaces
         *       continues the dialogue of previous character
         *
         * @param line line to check
         * @param character extracted character name if new character,
         *        otherwise leaves character unmodified
         * @return index of start of dialogue if a dialogue line,
         *      -1 if not a dialogue line
         */
        static int IsDialogueLine(string line, ref string character)
        {

            // new character
            if (line.Length >= 3 && line[0] == ' '
                && line[1] == ' ' && line[2] != ' ')
            {
                // extract character name

                int start_idx = 2;
                int end_idx = 3;
                while (end_idx <= line.Length && line[end_idx - 1] != '.')
                {
                    ++end_idx;
                }

                // no name found
                if (end_idx >= line.Length)
                {
                    return 0;
                }

                // extract character's name
                character = line.Substring(start_idx, end_idx - start_idx - 1);
                return end_idx;
            }

            // previous character
            if (line.Length >= 5 && line[0] == ' '
                && line[1] == ' ' && line[2] == ' '
                && line[3] == ' ' && line[4] != ' ')
            {
                // continuation
                return 4;
            }

            return 0;
        }

        /**
         * Sorts characters in descending order by word count
         *
         * @param wcounts a map of character -> word count
         * @return sorted vector of {character, word count} pairs
         */
        public static List<Tuple<int, string>> SortCharactersByWordcount(Dictionary<string, int> wordcount)
        {
            // Implement sorting by word count here
            List<Tuple<int, string>> sortedByValueList= new List<Tuple<int, string>>();
            Tuple<int, string> temp;

            foreach (KeyValuePair<string,int> pairItem in wordcount)
            {
                temp = new Tuple<int, string>(pairItem.Value,pairItem.Key);
                sortedByValueList.Add(temp);
            }

            sortedByValueList.Sort((s1, s2) => s2.Item1.CompareTo(s1.Item1));

       //     PrintListofTuples(sortedByValueList);

            return sortedByValueList;
        }

        /**
         * Prints the List of Tuple<int, string>
         *
         * @param sortedList
         * @return Nothing
         */
        public static void PrintListofTuples(List<Tuple<int, string>> sortedList)
        {
            // Implement printing here
            foreach (Tuple<int, string> tuple in sortedList)
            {
                Console.WriteLine("Word Count:"+tuple.Item1 + ", Character:" + tuple.Item2);
            }
        }
    }
}
