using System;
using System.Linq;



public class Combination
{


    // Convert IEnumerable to Array
    public string[] linesArray(System.Collections.Generic.IEnumerable<string> lines)
    {
        return lines.ToArray();
    }


    // Part 1 Solution
    public int Part1(int rawSum, int currentVal, int zeroSum, string[] linesArray)
    {

        //Loop through file lines
        for (int i = 0; i < linesArray.Length; i++)
        {

            //Get direction and number of clicks
            string direction = linesArray[i].Substring(0, 1);
            int number = Convert.ToInt32(linesArray[i].Substring(1));

            //Get clicks from partial rotation
            int clicks = number % 100;


            //Process Left and Right turns
            if (direction == "L")
            {
                //Calculate new position based on raw difference
                rawSum = currentVal - clicks;


                //If negative, you passed zero
                if (rawSum < 0)
                {
                    //99 or less
                    //Add 100 to get new value on lock
                    currentVal = rawSum + 100;


                    //next iteration
                    continue;
                }

                //Landed on zero exactly
                if (rawSum == 0)
                {
                    zeroSum += 1;

                }


                //Partial rotation did not pass 0
                currentVal = rawSum;
            }



            if (direction == "R")
            {
                rawSum = currentVal + clicks;


                //Passed 0
                if (rawSum > 100)
                {
                    //0 or more

                    //Subtract 100 to get new position
                    currentVal = rawSum - 100;


                    continue;
                }

                //Landed on zero exactly
                if (rawSum == 100)
                {


                    zeroSum += 1;

                    //100 sum, set to 0
                    currentVal = 0;

                    continue;

                }

                currentVal = rawSum;
            }

        }

        return zeroSum;

    }

    // Part 2 Solution
    public int Part2(int rawSum, int currentVal, int zeroSum, string[] linesArray)
    {

        //Same as Part 1, but count full rotations as well
        for (int i = 0; i < linesArray.Length; i++)
        {

            string direction = linesArray[i].Substring(0, 1);

            int number = Convert.ToInt32(linesArray[i].Substring(1));

            int clicks = number % 100;
            int fullRotations = number / 100;

            //Count full rotations
            zeroSum += fullRotations;

            if (direction == "L")
            {

                rawSum = currentVal - clicks;

                if (rawSum < 0)
                {
                    //99 or less

                    //If you started at zero, ignore one pass
                    if (currentVal == 0)
                    {
                        zeroSum -= 1; //adjust for starting at zero and going left
                    }

                    zeroSum += 1;

                    currentVal = rawSum + 100;


                    continue;
                }

                if (rawSum == 0)
                {

                    

                    zeroSum += 1;


                    currentVal = 0;



                    continue;

                }

                

                currentVal = rawSum;


            }


            if (direction == "R")
            {
                rawSum = currentVal + clicks;

                if (rawSum > 100)
                {
                    //0 or more

                    //If you started at zero, ignore one pass
                    if (currentVal == 0)
                    {
                        zeroSum -= 1; //adjust for starting at zero and going right
                    }

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

//Main
public partial class Program
{
    public static void Main(string[] args)
    {

        Combination combination = new Combination();

        string[] linesArray = combination.linesArray(File.ReadLines("C:/Users/jproctor/source/repos/aoc2025/day1/input.txt"));

        int part1Sum = combination.Part1(0, 50, 0, linesArray);
        int part2Sum = combination.Part2(0, 50, 0, linesArray);


        Console.WriteLine("Part 1 Sum: {0}", part1Sum);
        Console.WriteLine("Part 2 Sum: {0}", part2Sum);
    }
}