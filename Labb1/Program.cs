using System;
using System.Collections.Generic;

namespace Labb1
{
    class Program
    {
        //        Skapa en konsollapplikation som tar en textsträng(string) som argument.Den kan
        //också läsa in det via Console.ReadLine(), men det räcker med en hårdkodad
        //textsträng.
        //Textsträngen ska sedan sökas igenom efter alla delsträngar som är tal som börjar
        //och slutar på samma siffra, utan att start/slutsiffran, eller något annat tecken än
        //siffror förekommer där emellan.
        //ex. 3463 är ett korrekt sådant tal, men 34363 är det inte eftersom det finns
        //ytterligare en 3:a i talet, förutom start och slutsiffran. Strängar med bokstäver i
        //t.ex 95a9 är inte heller ett korrekta tal.
        static void Main(string[] args)
        {
            Console.WriteLine("Please enter a string");
            string input = Console.ReadLine();
            char[] charArray = input.ToCharArray(); // dela upp strängen i en char array för enkel genomsökning
            int notImportant = 0; // något värde att sätta i out parametern för int.TryParse 
            List<string> stringList = new List<string>();
            for (int i = 0; i < charArray.Length; i++)
            {
                // om charArray[i] är en int så börjar vi söka igenom hela strängen efter en likadan int
                if (int.TryParse(charArray[i].ToString(), out notImportant)) 
                {
                    for (int j = i + 1; j < charArray.Length; j++) 
                    {
                        if (charArray[i] == charArray[j]) // om en likadan int kunde hittas
                        {
                            stringList.Add("");
                            // vi skapar en sträng av alla chars mellan charArray[i] och charArray[j] som lägger till den i vår lista
                            for (int k = i; k <= j; k++) 
                            {
                                stringList[stringList.Count - 1] += charArray[k];
                            }
                            break; // bryt ut ur inner-loopen
                        }
                        else if (!int.TryParse(charArray[j].ToString(), out notImportant))
                        {
                            break; // bryt ut ur inner-loopen om vi hittar en icke-int
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
