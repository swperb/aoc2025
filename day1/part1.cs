using System;
using System.Linq;



public class Combination
{

    public string[] linesArray(System.Collections.Generic.IEnumerable<string> lines)
    {
        return lines.ToArray();
    }

    public int Part1(int rawSum, int currentVal, int zeroSum, string[] linesArray)
    {
        for (int i = 0; i < linesArray.Length; i++)
        {

            string direction = linesArray[i].Substring(0, 1);

            int number = Convert.ToInt32(linesArray[i].Substring(1));

            int clicks = number % 100;

            if (direction == "L")
            {
                rawSum = currentVal - clicks;

                if (rawSum < 0)
                {
                    //99 or less

                    currentVal = rawSum + 100;


                    continue;
                }

                if (rawSum == 0)
                {
                    zeroSum += 1;


                }

                currentVal = rawSum;
            }


            if (direction == "R")
            {
                rawSum = currentVal + clicks;

                if (rawSum > 100)
                {
                    //0 or more

                    currentVal = rawSum - 100;


                    continue;
                }

                if (rawSum == 100)
                {
                    zeroSum += 1;

                    currentVal = 0;

                    continue;

                }

                currentVal = rawSum;
            }

        }

        return zeroSum;

    }


    public int Part2(int rawSum, int currentVal, int zeroSum, string[] linesArray)
    {

        for (int i = 0; i < linesArray.Length; i++)
        {

            string direction = linesArray[i].Substring(0, 1);

            int number = Convert.ToInt32(linesArray[i].Substring(1));


            int clicks = number % 100;

            int zeroDist;

            if (direction == "L")
            {

                rawSum = currentVal - clicks;

                if (rawSum < 0)
                {
                    //99 or less
                    //passes 0

                    zeroSum += 1;


                    currentVal = rawSum + 100;


                    continue;
                }

                if (rawSum == 0)
                {
                    zeroSum += 1;

                }

                currentVal = rawSum;
            }


            if (direction == "R")
            {
                rawSum = currentVal + clicks;

                if (rawSum > 100)
                {
                    //0 or more
                    //passes 0

                    zeroSum += 1;


                    currentVal = rawSum - 100;


                    continue;
                }

                if (rawSum == 100)
                {
                    zeroSum += 1;

                    currentVal = 0;

                    continue;

                }

                currentVal = rawSum;
            }

        }


        return zeroSum;

    }
}


public partial class Program
{
    public static void Main(string[] args)
    {

        Combination combination = new Combination();

        string[] linesArray = combination.linesArray(File.ReadLines("C:/Users/jproctor/source/repos/aoc2025/day1/input.txt"));

        int part1Sum = combination.Part1(0, 50, 0, linesArray);
        int part2Sum = combination.Part2(0, 50, 0, linesArray);


        Console.WriteLine("Part 1 Sum: {0}", part1Sum);
        Console.WriteLine("Part 2 Sum: {0}", part1Sum + part2Sum);
    }
}
