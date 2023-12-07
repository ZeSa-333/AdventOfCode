string[] input = File.ReadAllLines("day.6.txt");
long time = long.Parse(input[0].Split(":")[1].Trim().Replace(" ", String.Empty));
long distance = long.Parse(input[1].Split(":")[1].Trim().Replace(" ", String.Empty));
long bigResult;
SanityCheck(input);

bigResult = HowOften(time, distance);
Console.WriteLine(bigResult);


//Method to calculate how often the boat beats the previous records
long HowOften (long time1, long distance1)
{
    long result = 0;
    long timeLeft;

        for(int j = 0; j < time1; j++){
            timeLeft = time1 -j;

            if(j * timeLeft > distance1){
                result ++;   
        }
    }
    return result;
}

static void SanityCheck(string[] inputLines)
{
    //  int lastIndex = inputLines.Last();  -->not parsable
    Console.WriteLine($"{inputLines.Length} lines read,\n first entry is {inputLines[0]}\n last entry is " + inputLines.Last());
}