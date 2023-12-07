string[] input = File.ReadAllLines("day.6.txt");
string time = input[0].Split(":")[1].Trim();
string distance = input[1].Split(":")[1].Trim();
long bigResult;
SanityCheck(input);

//string TrimString = time.Trim();
time = time.Replace(" ", String.Empty);
distance = distance.Replace(" ", String.Empty);

long timeInt = long.Parse(time);
long distanceInt = long.Parse(distance);

bigResult = HowOften(timeInt, distanceInt);
Console.WriteLine(bigResult);


//Method to calculate how often the boat beats the previous records
long HowOften (long time1, long distance1)
{
    long result = 0;
    long myDistance = 0;
    long maxDistance = distance1;
    long timeLeft = 0;

        for(int j = 0; j <= time1; j++){
            timeLeft = time1;
            timeLeft -= j;
            if(timeLeft > 0 && timeLeft <= time1){
            myDistance = j * timeLeft;
            //Console.WriteLine($" distanz {myDistance}");

            if(myDistance > maxDistance){
                result ++;   
            }
            
        }
    }
    return result;
}

static void SanityCheck(string[] inputLines)
{
    //  int lastIndex = inputLines.Last();  -->not parsable
    Console.WriteLine($"{inputLines.Length} lines read,\n first entry is {inputLines[0]}\n last entry is " + inputLines.Last());
}