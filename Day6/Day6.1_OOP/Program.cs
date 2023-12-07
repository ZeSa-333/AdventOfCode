using System;
using System.IO;

public class Race
{
    private int time;
    private int distance;

    public Race(int _time, int _distance)
    {
        time = _time;
        distance = _distance;
    }

    public int HowOften()
    {
        int result = 0;

        for (int j = 0; j < time; j++)
        {
            int timeLeft = time - j;
            int myDistance = j * timeLeft;

            if (myDistance > distance)
            {
                result++;
            }
        }
        return result;
    }
}

public class MainClass
{

    public static void Main(string[] args)
    {
        if (args.Length >= 1)
        {
            string[] input = File.ReadAllLines(args[0]);
            //Console.WriteLine(input[0]);
            int[] time = Array.ConvertAll(input[0].Split(":   ")[1].Split("  ", StringSplitOptions.RemoveEmptyEntries), int.Parse);
            int[] distance = Array.ConvertAll(input[1].Split(":  ")[1].Split(" ", StringSplitOptions.RemoveEmptyEntries), int.Parse);

            int product = 1;
            for (int i = 0; i < time.Length; i++)
            {
                Race r = new Race(time[i], distance[i]);
                product *= r.HowOften();
            }
            Console.WriteLine(product);
        }
        else
        {
            Console.WriteLine("Please provide the puzzle file!");
        }
    }
}