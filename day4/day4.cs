
using System;
using System.Linq;
using System.ComponentModel;
using System.Text.RegularExpressions;
using System.Reflection.Metadata.Ecma335;

public class GiftFinder
{


    // Convert IEnumerable to Array
    public string[] linesArray(System.Collections.Generic.IEnumerable<string> lines)
    {
        return lines.ToArray();
    }


    // Part 1 Solution
    public long Part1(string[] linesArray)
    {

        string[,] giftPositions = new string[linesArray.Length, linesArray[0].Length];

        int accessibleGifts = 0;

        // Populate 2D Array
        for (int i = 0; i < linesArray.Length; i++)
        {
            string giftLine = linesArray[i];
            for (int j = 0; j < giftLine.Length; j++)
            {
                giftPositions[i, j] = giftLine[j].ToString();
            }
        }

        //Loop through 2D Array and find adjacent nodes

        for (int x = 0; x < giftPositions.GetLength(0); x++)
        {
            for (int y = 0; y < giftPositions.GetLength(1); y++)
            {
                int surroundingGiftsSum = 0;

                string currentGift = giftPositions[x, y];

                if (currentGift == ".")
                {
                    continue;
                }

                //Right Boundary Check
                if (y + 1 < giftPositions.GetLength(1))
                {

                    //Check Right
                    if (giftPositions[x, y + 1] == "@")
                    {

                        surroundingGiftsSum++;
                    }
                }
                //Down Right Boundary Check
                if (x + 1 < giftPositions.GetLength(0) && y + 1 < giftPositions.GetLength(1))
                {
                    //Check Down Right
                    if (giftPositions[x + 1, y + 1] == "@")
                    {

                        surroundingGiftsSum++;
                    }
                }
                //Down Boundary Check
                if (x + 1 < giftPositions.GetLength(0))
                {
                    //Check Down
                    if (giftPositions[x + 1, y] == "@")
                    {

                        surroundingGiftsSum++;
                    }
                }
                //Down Left Boundary Check
                if (x + 1 < giftPositions.GetLength(0) && y - 1 >= 0)
                {

                    //Check Down Left
                    if (giftPositions[x + 1, y - 1] == "@")
                    {

                        surroundingGiftsSum++;
                    }
                }
                //Left Boundary Check
                if (y - 1 >= 0)
                {

                    //Check Left
                    if (giftPositions[x, y - 1] == "@")
                    {

                        surroundingGiftsSum++;
                    }
                }
                //Up Left Boundary Check
                if (x - 1 >= 0 && y - 1 >= 0)
                {
                    //Check Up Left
                    if (giftPositions[x - 1, y - 1] == "@")
                    {

                        surroundingGiftsSum++;
                    }
                }
                //Up Boundary Check
                if (x - 1 >= 0)
                {
                    //Check Up
                    if (giftPositions[x - 1, y] == "@")
                    {

                        surroundingGiftsSum++;
                    }
                }
                //Up Right Boundary Check
                if (x - 1 >= 0 && y + 1 < giftPositions.GetLength(1))
                {
                    //Check Up Right
                    if (giftPositions[x - 1, y + 1] == "@")
                    {

                        surroundingGiftsSum++;
                    }
                }



                if (surroundingGiftsSum < 4)
                {

                    accessibleGifts++;
                }
            }
        }

        return accessibleGifts;
    }

    //Part 2 Solution
    public long Part2(string[] linesArray)
    {

        string[,] giftPositions = new string[linesArray.Length, linesArray[0].Length];
        string[,] removedPositions = new string[linesArray.Length, linesArray[0].Length];

        int accessibleGifts = 0;
        int removedGifts = 0;

        // Populate 2D Array
        for (int i = 0; i < linesArray.Length; i++)
        {
            string giftLine = linesArray[i];
            for (int j = 0; j < giftLine.Length; j++)
            {
                giftPositions[i, j] = giftLine[j].ToString();
            }
        }


        bool doneSearching = false;

        //Loop through 2D Array and find adjacent nodes

        while (!doneSearching) 
        {

            for (int x = 0; x < giftPositions.GetLength(0); x++)
            {
                for (int y = 0; y < giftPositions.GetLength(1); y++)
                {
                    int surroundingGiftsSum = 0;

                    string currentGift = giftPositions[x, y];

                    if (currentGift == ".")
                    {
                        continue;
                    }


                    //Right Boundary Check
                    if (y + 1 < giftPositions.GetLength(1))
                    {

                        //Check Right
                        if (giftPositions[x, y + 1] == "@")
                        {

                            surroundingGiftsSum++;
                        }
                    }
                    //Down Right Boundary Check
                    if (x + 1 < giftPositions.GetLength(0) && y + 1 < giftPositions.GetLength(1))
                    {
                        //Check Down Right
                        if (giftPositions[x + 1, y + 1] == "@")
                        {

                            surroundingGiftsSum++;
                        }
                    }
                    //Down Boundary Check
                    if (x + 1 < giftPositions.GetLength(0))
                    {
                        //Check Down
                        if (giftPositions[x + 1, y] == "@")
                        {

                            surroundingGiftsSum++;
                        }
                    }
                    //Down Left Boundary Check
                    if (x + 1 < giftPositions.GetLength(0) && y - 1 >= 0)
                    {

                        //Check Down Left
                        if (giftPositions[x + 1, y - 1] == "@")
                        {

                            surroundingGiftsSum++;
                        }
                    }
                    //Left Boundary Check
                    if (y - 1 >= 0)
                    {

                        //Check Left
                        if (giftPositions[x, y - 1] == "@")
                        {

                            surroundingGiftsSum++;
                        }
                    }
                    //Up Left Boundary Check
                    if (x - 1 >= 0 && y - 1 >= 0)
                    {
                        //Check Up Left
                        if (giftPositions[x - 1, y - 1] == "@")
                        {

                            surroundingGiftsSum++;
                        }
                    }
                    //Up Boundary Check
                    if (x - 1 >= 0)
                    {
                        //Check Up
                        if (giftPositions[x - 1, y] == "@")
                        {

                            surroundingGiftsSum++;
                        }
                    }
                    //Up Right Boundary Check
                    if (x - 1 >= 0 && y + 1 < giftPositions.GetLength(1))
                    {
                        //Check Up Right
                        if (giftPositions[x - 1, y + 1] == "@")
                        {

                            surroundingGiftsSum++;
                        }
                    }



                    if (surroundingGiftsSum < 4)
                    {
                        removedPositions[x, y] = "x";

                        accessibleGifts++;
                    }
                }


            }


            for (int i = 0; i < removedPositions.GetLength(0); i++)
            {
                for (int j = 0; j < removedPositions.GetLength(1); j++)
                {


                    if (giftPositions[i, j] == "x")
                    {

                        removedPositions[i, j] = ".";
                    }

                    if (removedPositions[i, j] == "x")
                    {

                        removedGifts++;

                        giftPositions[i, j] = "x";
                    }


                }
            }

            if (removedPositions.Cast<string>().All(pos => pos != "x"))
            {
                doneSearching = true;
            }
        }


        return removedGifts;

    }
}
//Main
public partial class Program
{
    public static void Main(string[] args)
    {

        GiftFinder giftFinder = new GiftFinder();

        string[] linesArray = giftFinder.linesArray(File.ReadAllLines("C:/Users/jproctor/source/repos/aoc2025/day4/input.txt"));


        long part1Sum = giftFinder.Part1(linesArray);
        long part2Sum = giftFinder.Part2(linesArray);


        Console.WriteLine("Sum of Accessible Gifts: {0}", part1Sum);
        Console.WriteLine("Sum of Removed Gifts: {0}", part2Sum);

    }
}
