using System;
using System.Collections.Generic;
using System.Numerics;

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
            char[] charArray = input.ToCharArray();
            int notImportant = 0;
            List<string> myList = new List<string>();
            for (int i = 0; i < charArray.Length; i++)
            {
                if (int.TryParse(charArray[i].ToString(), out notImportant)) // om i är en int
                {
                    for (int j = i + 1; j < charArray.Length; j++) // iterera tills samma int hittas
                    {
                        if (charArray[i] == charArray[j])
                        {
                            myList.Add("");
                            for (int k = i; k <= j; k++)
                            {
                                myList[myList.Count - 1] += charArray[k];
                            }
                            break;
                        }
                        else if (!int.TryParse(charArray[j].ToString(), out notImportant))
                        {
                            break;
                        }
                    }
                }
            }
            long sum = 0;
            foreach (var item in myList)
            {
                Console.WriteLine(item);
                sum += long.Parse(item);
            }
            Console.WriteLine();
            Console.WriteLine("Total = {0}", sum);

        }
    }
}
