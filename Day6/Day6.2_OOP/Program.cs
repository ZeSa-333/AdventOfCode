using System.Xml;

public class Race 
{
    long time;
    long distance;
    public Race(long _time, long _distance)
    {
        time = _time;
        distance = _distance;
    }

    public int countTimesBeat ()
    {
        int counter = 0;
        for (long i = 0; i < time; i++)
        {
            long timeLeft = time - i;

            if ((timeLeft * i) > distance)
            {
                counter++;
            }
        }
        return counter;
    }
}

public class MainClass{
public static void Main(string[] args)
{
    if(args.Length > 0){
    string[] input = File.ReadAllLines(args[0]);
    long time = long.Parse(input[0].Split(":")[1].Trim().Replace(" ", String.Empty));
    long distance = long.Parse(input[1].Split(":")[1].Trim().Replace(" ", String.Empty));

    Race race = new Race(time, distance);
    Console.WriteLine(race.countTimesBeat());
    }
    else if (args.Length == 0)
    {
        Console.WriteLine("Please enter a file name");
    }
}
}