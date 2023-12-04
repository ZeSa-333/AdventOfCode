using System;
using System.IO;

string[] cards = File.ReadAllLines("day.4.txt");

SanityCheck(cards);
int result = 0;

for (int i = 0; i < cards.Length; i++)
{

    string cardNum = cards[i].Split(":")[0];
    cards[i] = cards[i].Split(": ")[1];


    string[] winNumbers = cards[i].Split(" |")[0].Split(" ", StringSplitOptions.RemoveEmptyEntries);

    string[] inputNumbers = cards[i].Split("| ")[1].Split(" ", StringSplitOptions.RemoveEmptyEntries);


    int part = compareNumbers(winNumbers, inputNumbers, cards);
    result += part;

    Console.WriteLine($"{cardNum} points(per card) {part}");
    Console.WriteLine(result);
}



int compareNumbers(string[] winNumbers, string[] inputNumbers, string[] input)
{
    int matches = 0;
    int result = 0;
    foreach (string line in input)
    {
        matches = 0;
        for (int i = 0; i < winNumbers.Length; i++)
        {
            winNumbers[i] = winNumbers[i].Trim();
            for (int j = 0; j < inputNumbers.Length; j++)
            {
                inputNumbers[j] = inputNumbers[j].Trim();

                if (winNumbers[i] == inputNumbers[j])
                {
                    if (matches == 0)
                    {
                        matches++;
                    }
                    else if (string.IsNullOrEmpty(winNumbers[i]))
                    {
                        continue;
                    }
                    else if (matches > 0)
                    {
                        matches = matches * 2;
                    }
                }
            }
        }
    }

    result += matches;
    return result;
}




static void SanityCheck(string[] inputLines)
{
    //  int lastIndex = inputLines.Last();  -->not parsable
    Console.WriteLine($"{inputLines.Length} lines read,\n first entry is {inputLines[0]}\n last entry is " + inputLines.Last());
}