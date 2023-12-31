﻿using System.Xml.XPath;

string[] input = File.ReadAllLines("day.6.txt");
int[] time = Array.ConvertAll(input[0].Split(":   ")[1].Split("  ", StringSplitOptions.RemoveEmptyEntries), int.Parse);
int[] distance = Array.ConvertAll(input[1].Split(":  ")[1].Split(" ", StringSplitOptions.RemoveEmptyEntries), int.Parse);
int[] result = new int[time.Length];
SanityCheck(input);
result = HowOften(time, distance);
//Array.ForEach(result, Console.WriteLine);

Console.WriteLine(calcResult(result));

//Method to calculate how often the boat beats the previous records
int[] HowOften(int[] time1, int[] distance1)
{
    int[] result = new int[time1.Length];

    for (int i = 0; i < time.Length; i++)
    {

        for (int j = 0; j < time1[i]; j++)
        {
            int timeLeft = time1[i];
            timeLeft -= j;
            int myDistance = j * timeLeft;

            if (myDistance > distance1[i])
            {
                result[i]++;
            }

        }
    }
    return result;
}

//Method to sum up all the results to get the final one
int calcResult(int[] resultArray)
{
    int sum = resultArray[0];
    for (int i = 1; i < result.Length; i++)
    {
        sum = sum * resultArray[i];
    }
    return sum;
}

static void SanityCheck(string[] inputLines)
{
    //  int lastIndex = inputLines.Last();  -->not parsable
    Console.WriteLine($"{inputLines.Length} lines read,\n first entry is {inputLines[0]}\n last entry is " + inputLines.Last());
}