
using System.IO;
using System;

string inputTxt = "1.day.txt";
int[] _cordinatesList1 = new int[1];

{
    int index = 0;
    int index1 = 0;
    string input;

    using (StreamReader streamReader = new StreamReader(inputTxt))
    {
        input = streamReader.ReadToEnd();
    }

    string[] inputLines = input.Split("\r\n");
    SanityCheck(inputLines);


    int cordinateResult = 0;

    foreach (string line in inputLines)
    {
        string realLine = line;
        if (line.Contains("one"))
        {
            realLine = realLine.Replace("one", "o1e");
        }
        if (line.Contains("two"))
        {
            realLine = realLine.Replace("two", "t2w");
        }
        if (line.Contains("three"))
        {
            realLine = realLine.Replace("three", "t3e");
        }
        if (line.Contains("four"))
        {
            realLine = realLine.Replace("four", "f4r");
        }
        if (line.Contains("five"))
        {
            realLine = realLine.Replace("five", "f5e");
        }
        if (line.Contains("six"))
        {
            realLine = realLine.Replace("six", "s6x");
        }
        if (line.Contains("seven"))
        {
            realLine = realLine.Replace("seven", "s7n");
        }
        if (line.Contains("eight"))
        {
            realLine = realLine.Replace("eight", "e8t");
        }
        if (line.Contains("nine"))
        {
            realLine = realLine.Replace("nine", "n9e");
        }

        for (int i = 0; i < realLine.Length; i++)
        {
            if (char.IsDigit(realLine[i]))
            {
                index++;
            }
        }
        int[] _cordinatesList = new int[index];
        for (int j = 0; j < realLine.Length; j++)
        {
            if (char.IsDigit(realLine[j]))
            {
                _cordinatesList[index1] = int.Parse(realLine[j].ToString());
                index1++;
            }



        }
        //List.count();
        cordinateResult += (_cordinatesList[0] * 10) + _cordinatesList[^1];
        index = 0;
        index1 = 0;
        Console.WriteLine();
        Console.WriteLine($"{cordinateResult}");
    }
}

static void SanityCheck(string[] inputLines)
{
    //  int lastIndex = inputLines.Last();  -->not parsable
    Console.WriteLine($"{inputLines.Length} lines read, first entry is {inputLines[0]}, last entry is " + inputLines.Last());
}