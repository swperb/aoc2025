
using System;
using System.Linq;
using System.ComponentModel;
using System.Text.RegularExpressions;
using System.Reflection.Metadata.Ecma335;
using System.Text.Unicode;

public class FreshIngredients
{


    // Convert IEnumerable to Array
    public string[] linesArray(System.Collections.Generic.IEnumerable<string> lines)
    {
        return lines.ToArray();
    }


    // Part 1 Solution
    public long Part1(string[] linesArray)
    {

        int indexCounter = 0;
        int splitIndex = 0;

        foreach (string line in linesArray)
        {
            indexCounter++;

            if (line.Length == 0)
            {
                splitIndex = indexCounter;
            }

            
        }

        string[] ranges = linesArray.Take(splitIndex - 1).ToArray();
        string[] availableIDs = linesArray.Skip(splitIndex).ToArray();


        int freshIngredientSum = 0;

        for (int i = 0; i < ranges.Length; i++)
        {
            string[] splitRanges = ranges[i].Split('-');
            long rangeStart = Int64.Parse(splitRanges[0]);
            long rangeEnd = Int64.Parse(splitRanges[1]);
            for (int j = 0; j < availableIDs.Length; j++)
            {

                long currentID = Int64.Parse(availableIDs[j]);
                if (currentID >= rangeStart && currentID <= rangeEnd)
                {

                    availableIDs = availableIDs.Where((source, index) => index != j).ToArray();

                    j--;

                    freshIngredientSum++;
                }

            }


        }

        return freshIngredientSum;
    }

    //Part 2 Solution
    public long Part2(string[] linesArray)
    {

        int indexCounter = 0;
        int splitIndex = 0;

        foreach (string line in linesArray)
        {
            indexCounter++;

            if (line.Length == 0)
            {
                splitIndex = indexCounter;
            }


        }


        string[] ranges = linesArray.Take(splitIndex - 1).ToArray();

        List<long> freshIngredientIDs = new List<long>();

        long[,] minmaxRanges = new long[ranges.Length, 2];



        for (int i = 0; i < ranges.Length; i++)
        {
            string[] splitRanges = ranges[i].Split('-');
            long rangeStart = Int64.Parse(splitRanges[0]);
            long rangeEnd = Int64.Parse(splitRanges[1]);
            

            minmaxRanges[i, 0] = rangeStart;
            minmaxRanges[i, 1] = rangeEnd;


        }

        for (long i = 0; i < minmaxRanges.GetLength(0); i++)
        {
            for (long j = i + 1; j < minmaxRanges.GetLength(0); j++)
            {
                if (minmaxRanges[i, 0] > minmaxRanges[j, 0])
                {

                    for (long k = 0; k < 2; k++)
                    {
                        long temp = minmaxRanges[i, k];
                        minmaxRanges[i, k] = minmaxRanges[j, k];
                        minmaxRanges[j, k] = temp;
                    }
                }

                else if (minmaxRanges[i, 0] == minmaxRanges[j, 0])
                {

                    if (minmaxRanges[i, 1] > minmaxRanges[j, 1])
                    {
                        for (long k = 0; k < 2; k++)
                        {
                            long temp = minmaxRanges[i, k];
                            minmaxRanges[i, k] = minmaxRanges[j, k];
                            minmaxRanges[j, k] = temp;
                        }
                    }

                }
            }
        }

        for (int x = 0; x < minmaxRanges.GetLength(0); x++)
        {
            Console.WriteLine("Sorted Range {0}: {1}-{2}", x, minmaxRanges[x, 0], minmaxRanges[x, 1]);
        }



        long[,] truncatedRanges = new long[minmaxRanges.GetLength(0), 2];


        for (int x = 0; x < minmaxRanges.GetLength(0); x++)
        {

            //if next range overlaps current range, merge them

            bool maxRangeFound = false;
            if (x + 1 < minmaxRanges.GetLength(0))
            {
                if (minmaxRanges[x + 1, 0] <= minmaxRanges[x, 1])
                {

                    int originalX = x;

                    while (!maxRangeFound)
                    {
                        if (x + 1 < minmaxRanges.GetLength(0) && minmaxRanges[x + 1, 0] <= minmaxRanges[x, 1])
                        {
                            truncatedRanges[originalX, 0] = minmaxRanges[originalX, 0];
                            truncatedRanges[originalX, 1] = minmaxRanges[x + 1, 1];
                            x++;

                            Console.WriteLine("Merging ranges into: {0}-{1}", truncatedRanges[originalX, 0], truncatedRanges[originalX, 1]);
                        }
                        else
                        {

                            Console.WriteLine("Final merged range: {0}-{1}", truncatedRanges[originalX, 0], truncatedRanges[originalX, 1]);
                            maxRangeFound = true;
                            continue;
                        }
                    }


                }

                else
                {
                    truncatedRanges[x, 0] = minmaxRanges[x, 0];
                    truncatedRanges[x, 1] = minmaxRanges[x, 1];

                }


            }

            else
            {
                break;
            }


        }

        long rangeSum = 0;

        for (long i = 0; i < truncatedRanges.GetLength(0); i++)
        {
            if (truncatedRanges[i, 0] == 0 && truncatedRanges[i, 1] == 0)
            {
                continue;
            }

            

            long rangeLength = truncatedRanges[i, 1] - truncatedRanges[i, 0] + 1;

            Console.WriteLine("Range: {0}-{1}, Range Length: {2}", truncatedRanges[i, 0], truncatedRanges[i, 1], rangeLength);

            rangeSum += rangeLength;
        }


        return rangeSum;
        
    }
}                              
//Main
public partial class Program
{
    public static void Main(string[] args)
    {

        FreshIngredients freshIngredients = new FreshIngredients();

        string[] linesArray = freshIngredients.linesArray(File.ReadAllLines("C:/Users/jproctor/source/repos/aoc2025/day5/input.txt"));


        long part1Sum = freshIngredients.Part1(linesArray);
        long part2Sum = freshIngredients.Part2(linesArray);


        Console.WriteLine("Sum of Fresh Ingredient IDs: {0}", part1Sum);
        Console.WriteLine("Sum of Unique Fresh Ingredient IDs: {0}", part2Sum);

    }
}
