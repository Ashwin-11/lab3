# lab3
The details of Lab3 Results is discussed here

Questions:

How can you test your program without needing to manually go through all the dialogue in Shakespeare's plays?

Has writing this code multithreaded helped in any way? Show some numbers in your observations. If your answer is no, under what conditions can multithreading help?

Single Threading: The (Character, Word count) pairs obtained for Word counts just below and above 3000 are as follows:

Word Count:11653, Character:Ham  
Word Count:8538, Character:ANTONY  
Word Count:8376, Character:IAGO  
Word Count:6266, Character:OTHELLO  
Word Count:5761, Character:ROMEO  
Word Count:5452, Character:BRUTUS  
Word Count:5337, Character:MACBETH  
Word Count:5334, Character:PORTIA  
Word Count:4737, Character:CLEOPATRA  
Word Count:4474, Character:JULIET  
Word Count:4099, Character:King  
Word Count:4011, Character:CAESAR  
Word Count:3718, Character:CASSIUS  
Word Count:3610, Character:Bene  
Word Count:2963, Character:CAPULET  

As written, if a character in one play has the same name as a character in another -- e.g. King -- it will treat them as the same and artificially increase the word count. How can you modify your code to treat them as separate, but still store all characters in the single dictionary (you do not need to implement this... just think about how you would do it)?
