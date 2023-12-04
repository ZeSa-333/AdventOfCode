using System.IO;
using System;


string[] input = File.ReadAllLines("day.3.txt");


SanityCheck(input);


//Console.WriteLine(result(input));

List<int>[,] starNums = new List<int>[input.Length, input[0].Length];
for (int i = 0; i < input.Length; i++)
{
    for (int j = 0; j < input[i].Length; j++)
    {
        starNums[i, j] = new List<int>();
    }
}

for (int i = 0; i < input.Length; i++)
{
    string numStr = "";
    bool star = false;
    int iStar = 0, jStar = 0;
    for (int j = 0; j < input[i].Length; j++)
    {
        if (char.IsDigit(input[i][j]))
        {
            numStr += input[i][j];
            (bool _star, int _iStar, int _jStar) = isValid(i, j, input);
            if (_star)
            {
                star = true;
                iStar = _iStar;
                jStar = _jStar;
            }
        }
        else
        {
            if (star)
            {
                starNums[iStar, jStar].Add(int.Parse(numStr));
            }
            star = false;
            numStr = "";
        }
    }
    if (star)
    {
        starNums[iStar, jStar].Add(int.Parse(numStr));
    }
}

int result = 0;
foreach (List<int> numList in starNums)
{
    if (numList.Count == 2)
    {
        result += numList[0] * numList[1];
    }
}

Console.WriteLine(result);


(bool, int, int) isValid(int i, int j, string[] input)
{
    if (isStar(i + 1, j, input))
    {
        return (true, i + 1, j);
    }
    if (isStar(i - 1, j, input))
    {
        return (true, i - 1, j);
    }
    if (isStar(i, j + 1, input))
    {
        return (true, i, j + 1);
    }
    if (isStar(i, j - 1, input))
    {
        return (true, i, j - 1);
    }

    if (isStar(i + 1, j + 1, input))
    {
        return (true, i + 1, j + 1);
    }
    if (isStar(i - 1, j - 1, input))
    {
        return (true, i - 1, j - 1);
    }
    if (isStar(i + 1, j - 1, input))
    {
        return (true, i + 1, j - 1);
    }
    if (isStar(i - 1, j + 1, input))
    {
        return (true, i - 1, j + 1);
    }

    return (false, 0, 0);
    /*return isStar(i + 1, j, input) || isStar(i - 1, j, input) || 
        isStar(i, j + 1, input) || isStar(i, j - 1, input) ||
        isStar(i + 1, j + 1, input) || isStar(i - 1, j - 1, input) ||
        isStar(i + 1, j - 1, input) || isStar(i - 1, j + 1, input); */
}

bool isStar(int i, int j, string[] input)
{
    if (i < 0 || i >= input.Length)
    {
        return false;
    }
    if (j < 0 || j >= input[i].Length)
    {
        return false;
    }
    return input[i][j] == '*';
}


/*int result(string[] input)
{
    int result = 0;
    int index;

    for (int i = 0; i < input.Length; i++)
    {
        
    }
}*/


/*bool[] isvalid (string[] completeinput){

    foreach (string line in completeinput)
        {
            int index;
            for (int j = 0; j < line.Length; j++)
            {
                if (char.IsDigit(line[j]))
                {
                    index = j;
                    if (line[index] == '.' || char.IsDigit(line[index]))
                    {

                    }
                }
            }
        }
}*/


/*
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
return (result0);
}*/


static void SanityCheck(string[] inputLines)
{
    //  int lastIndex = inputLines.Last();  -->not parsable
    Console.WriteLine($"{inputLines.Length} lines read,\n first entry is {inputLines[0]}\n last entry is " + inputLines.Last());
}
