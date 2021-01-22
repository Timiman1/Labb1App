using System;
using System.Collections.Generic;
using System.Numerics;

namespace Labb1
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Please enter a string");
            string input = Console.ReadLine();
            char[] charArray = input.ToCharArray(); // Dela upp strängen i en char array för enkel genomsökning
            List<Substring> substringList = new List<Substring>(); // Lista att stoppa in alla lyckade delsträngar 
                                                                  // (struct Substring) och deras respektive StartIndex
            for (int i = 0; i < charArray.Length; i++)
            {
                // Om charArray[i] är en siffra så börjar vi söka igenom hela arrayen efter samma siffra
                if (char.IsDigit(charArray[i]) )
                {
                    for (int j = i + 1; j < charArray.Length; j++) 
                    { 
                        if (charArray[i] == charArray[j]) // Om samma siffra kunde hittas..
                        {
                            // så skapar vi en struct Substring av input-strängen som börjar och slutar på samma siffra och lägger till den i vår lista
                            substringList.Add(new Substring(text: input.Substring(i, j - i + 1), startIndex: i));
                            break; // Bryt ut ur inner-loopen
                        }
                        else if (!char.IsDigit(charArray[j]))
                        {
                            break; // Bryt ut ur inner-loopen om vi hittar en icke-siffra
                        }
                    }
                }
            }
            for (int i = 0; i < substringList.Count; i++)
            {
                for (int charIndex = 0; charIndex < charArray.Length; charIndex++)
                {
                    if (substringList[i].StartIndex != charIndex)
                    {
                        // Alla tecken som inte är markerade skrivs ut i blått
                        Console.ForegroundColor = ConsoleColor.Blue;
                        Console.Write(charArray[charIndex]);
                    }
                    else
                    {
                        // De markerade delsträngarna skrivs ut i rött
                        Console.ForegroundColor = ConsoleColor.Red;
                        Console.Write(substringList[i].Text);
                        charIndex += substringList[i].Text.Length - 1;
                    }
                }
                Console.WriteLine();
            }
            BigInteger sum = 0; // BigInteger eftersom summan kan bli väldigt stor
            foreach (var substr in substringList)
            {
                sum += BigInteger.Parse(substr.Text);
            }
            Console.ForegroundColor = ConsoleColor.Gray;
            Console.WriteLine();
            Console.WriteLine("Total = {0}", sum);
        }
    }
    public struct Substring
    {
        public string Text;
        public int StartIndex;
        public Substring(string text, int startIndex)
        {
            Text = text;
            StartIndex = startIndex;
        }
    }
}
