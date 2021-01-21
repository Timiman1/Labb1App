using System;
using System.Collections.Generic;

namespace Labb1
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Please enter a string");
            string input = Console.ReadLine();
            char[] charArray = input.ToCharArray(); // Dela upp strängen i en char array för enkel genomsökning
            int notImportant; // Någon int-variabel att sätta i out parametern för int.TryParse 
            List<string> stringList = new List<string>(); // Lista att stoppa alla lyckade delsträngar i
            for (int i = 0; i < charArray.Length; i++)
            {
                // Om charArray[i] är en int så börjar vi söka igenom hela arrayen efter en likadan int
                if (int.TryParse(charArray[i].ToString(), out notImportant)) 
                {
                    for (int j = i + 1; j < charArray.Length; j++) 
                    { 
                        if (charArray[i] == charArray[j]) // Om en likadan int kunde hittas..
                        {
                            // så skapar vi en en delsträng av input-strängen som börjar och slutar på samma siffra och lägger till den i vår lista
                            stringList.Add(input.Substring(i, j - i + 1));
                            break; // Bryt ut ur inner-loopen
                        }
                        else if (!int.TryParse(charArray[j].ToString(), out notImportant))
                        {
                            break; // Bryt ut ur inner-loopen om vi hittar en icke-int
                        }
                    }
                }
            }
            long sum = 0; // long eftersom summan kan bli väldigt stor
            foreach (var item in stringList)
            {
                Console.WriteLine(item);
                sum += long.Parse(item);
            }
            Console.WriteLine();
            Console.WriteLine("Total = {0}", sum);
        }
    }
}
