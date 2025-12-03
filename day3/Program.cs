using System.ComponentModel;
using System.Text.RegularExpressions;

public class BatteryBank
{


    // Convert IEnumerable to Array
    public string[] linesArray(System.Collections.Generic.IEnumerable<string> lines)
    {
        return lines.ToArray();
    }


    // Part 1 Solution
    public long Part1(string[] linesArray)
    {

        long totalJoltageSum = 0;

        for (int i = 0; i < linesArray.Length; i++)
        {
            string batteryLine = linesArray[i];

            int maxJoltage = 0;
            int maxJoltageIndex = -1;

            for (int j = 0; j < batteryLine.Length; j++)
            {
                char c = batteryLine[j];

                int joltage = (int)Char.GetNumericValue(c);


                if (joltage > maxJoltage)
                {
                    maxJoltage = joltage;

                    maxJoltageIndex = j;
                }

            }

            string leftOfMax = batteryLine.Substring(0, maxJoltageIndex);
            string rightOfMax = batteryLine.Substring(maxJoltageIndex + 1);


            string combinedMaxJoltageLeft = "";
            string combinedMaxJoltageRight = "";

            int combinedMaxJoltageLeftInt = 0;
            int combinedMaxJoltageRightInt = 0;

            int leftMaxJoltage = 0;

            if (leftOfMax.Length != 0)
            {
                for (int x = 0; x < leftOfMax.Length; x++)
                {
                    char c = leftOfMax[x];
                    int joltage = (int)Char.GetNumericValue(c);

                    if (joltage > leftMaxJoltage)
                    {
                        leftMaxJoltage = joltage;
                    }
                }

                combinedMaxJoltageLeft = leftMaxJoltage.ToString() + maxJoltage.ToString();
                combinedMaxJoltageLeftInt = Convert.ToInt32(combinedMaxJoltageLeft);
            }

            int rightMaxJoltage = 0;

            if (rightOfMax.Length != 0)
            {
                for (int y = 0; y < rightOfMax.Length; y++)
                {
                    char c = rightOfMax[y];
                    int joltage = (int)Char.GetNumericValue(c);

                    if (joltage > rightMaxJoltage)
                    {
                        rightMaxJoltage = joltage;
                    }
                }

                combinedMaxJoltageRight = maxJoltage.ToString() + rightMaxJoltage.ToString();
                combinedMaxJoltageRightInt = Convert.ToInt32(combinedMaxJoltageRight);
            }


            if (combinedMaxJoltageLeftInt > combinedMaxJoltageRightInt)
            {
                totalJoltageSum += combinedMaxJoltageLeftInt;

                Console.WriteLine("Left is greater: {0}", combinedMaxJoltageLeftInt);

                continue;
            }

            else if (combinedMaxJoltageRightInt > combinedMaxJoltageLeftInt)
            {
                totalJoltageSum += combinedMaxJoltageRightInt;

                Console.WriteLine("Right is greater: {0}", combinedMaxJoltageRightInt);

                continue;
            }


        }

        return totalJoltageSum;
    }

    //Part 2 Solution
    public long Part2(string[] linesArray)
    {
        long totalJoltageSum = 0;

        for (int i = 0; i < linesArray.Length; i++)
        {
            string batteryLine = linesArray[i];

            int[] joltageValues = new int[12];

            int maxVoltage = 0;

            for (int j = 0; j < batteryLine.Length; j++)
            {
                char c = batteryLine[j];

                int joltage = (int)Char.GetNumericValue(c);
                int nextJoltage = (int)Char.GetNumericValue(batteryLine[j + 1]);

                if (joltage > nextJoltage)
                {
                    maxVoltage = (int)Char.GetNumericValue(batteryLine[j]);
                }


            }



        }

    }
}
//Main
public partial class Program
{
    public static void Main(string[] args)
    {

        BatteryBank batteryBank = new BatteryBank();

        string[] linesArray = batteryBank.linesArray(File.ReadAllLines("C:/Users/jproctor/source/repos/aoc2025/day3/input.txt"));


        long part1Sum = batteryBank.Part1(linesArray);
        //long part2Sum = batteryBank.Part2(linesArray);


        Console.WriteLine("Sum of Output Joltage: {0}", part1Sum);
        //Console.WriteLine("Sum of Invalid IDs with any repeat: {0}", part2Sum);

    }
}
