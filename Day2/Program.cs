using System.IO;
using System;


string[] games = File.ReadAllLines("day.2.txt");


SanityCheck(games);

Console.WriteLine(result(games));


(int, int) result(string[] games)
{

    int result = 0;
    int result0 = 0;

    string searchStringRed = "red";
    string searchStringBlue = "blue";
    string searchStringGreen = "green";
    for (int i = 0; i < games.Length; i++)
    {
        games[i] = games[i].Replace(";", ",");
        string[] colors = games[i].Split(":")[1].Split(",");

        bool possible = true;
        int numRed = 0;
        int numBlue = 0;
        int numGreen = 0;
        foreach (string color in colors)
        {
            string number = "";
            int numberInt;

            for (int j = 0; j < color.Length; j++)
            {
                if (char.IsDigit(color[j]))
                {
                    number += color[j];
                }

            }
            //Console.WriteLine(number);   <--debug
            //Console.WriteLine(color);   <--debug
            numberInt = int.Parse(number);

            if (color.Contains(searchStringRed))
            {
                if (numberInt > 12)
                {
                    possible = false;
                }

                if (numberInt > numRed)
                {
                    numRed = numberInt;
                }

            }
            else if (color.Contains(searchStringGreen))
            {
                if (numberInt > 13)
                {
                    possible = false;
                }
                if (numberInt > numGreen)
                {
                    numGreen = numberInt;
                }
            }
            else if (color.Contains(searchStringBlue))
            {
                if (numberInt > 14)
                {
                    possible = false;
                }
                if (numberInt > numBlue)
                {
                    numBlue = numberInt;
                }
            }

        }
        if (possible)
        {
            result0 += i + 1;
        }
        result += numRed * numBlue * numGreen;

    }
    return (result0, result);
}


static void SanityCheck(string[] inputLines)
{
    //  int lastIndex = inputLines.Last();  -->not parsable
    Console.WriteLine($"{inputLines.Length} lines read,\n first entry is {inputLines[0]},\n last entry is " + inputLines.Last());
}