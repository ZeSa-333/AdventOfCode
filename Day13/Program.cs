using System;
using System.IO;
// viel erfolg morgen :)  
class Program
{

    static void Main(string[] args)
    {
        string[] input = File.ReadAllLines("day.13.txt");
        SanityCheck(input);
        long result = 0;
        List<List<string>> inputList = SplitByEmptyLines(input);

        foreach (List<string> mirror in inputList)
        {
            result += CalcResult(mirror) * 100;
            result += CalcResult(Transpose(mirror));
        }
        Console.WriteLine(result);
    }

    static int CalcResult(List<string> inputMirror)
    {
        int result = 0;
        bool theSame = false;
        int counter = 0;
        for (int i = 0; i < inputMirror.Count - 1; i++)
        {
            counter++;
            for (int j = 0; j < 50; j++)
            {
                if ((i - j) >= 0 && (i + 1 + j) < inputMirror.Count && inputMirror[i - j] == inputMirror[i + 1 + j])
                {
                    theSame = true;

                }
                else if ((i - j) >= 0 && (i + 1 + j) < inputMirror.Count && (inputMirror[i - j] != inputMirror[i + 1 + j]))
                {
                    theSame = false;
                    break;
                }
                else
                {
                    break;
                }
            }
            if (theSame) { result += counter; break; }
        }
        return result;
    }

    static List<List<string>> SplitByEmptyLines(string[] lines)
    {
        List<List<string>> result = new List<List<string>>();
        List<string> currentSublist = new List<string>();

        foreach (string line in lines)
        {
            if (string.IsNullOrWhiteSpace(line))
            {
                if (currentSublist.Count > 0)
                {
                    result.Add(currentSublist);
                    currentSublist = new List<string>();
                }
            }
            else
            {
                currentSublist.Add(line);
            }
        }
        if (currentSublist.Count > 0)
        {
            result.Add(currentSublist);
        }
        return result;
    }

    static List<string> Transpose(List<string> mirror)
    {
        List<string> tm = new List<string>();

        for (int i = 0; i < mirror[0].Length; i++)
        {
            string tRow = "";
            foreach (var item in mirror)
            {
                tRow += item[i];
            }
            tm.Add(tRow);
        }
        return tm;
    }

    static void SanityCheck(string[] inputLists)
    {
        Console.WriteLine($"{inputLists.Length} lines read,\n first entry is {inputLists[0]}\n last entry is " + inputLists.Last());
    }
}
