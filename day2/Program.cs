public class Combination
{


    // Convert IEnumerable to Array
    public string[] linesArray(System.Collections.Generic.IEnumerable<string> lines)
    {
        return lines.ToArray();
    }


    // Part 1 Solution
    public long Part1(string[] linesArray)
    {

        long invalidIDSum = 0;

        foreach (string line in linesArray)
        {
            string[] rangeItem = line.Split(',');

            foreach (string range in rangeItem)
            {
                string[] bounds = range.Split('-');

                long lowerBound = (long)Int64.Parse(bounds[0]);
                long upperBound = (long)Int64.Parse(bounds[1]);

                //int lowerBound = Convert.ToInt32(bounds[0]);
                //int upperBound = Convert.ToInt32(bounds[1]);

                for (long id = lowerBound; id <= upperBound; id++)
                {

                    string idString = id.ToString();

                    if (idString.Length % 2 != 0)
                    {
                        continue;
                    }

                    int mid = idString.Length / 2;



                    string firstHalf = idString.Substring(0, mid);
                    string secondHalf = idString.Substring(mid);



                    if (firstHalf == secondHalf)
                    {
                        invalidIDSum += id;
                    }


                }

            }
        }
        return invalidIDSum;
    }

    // Part 2 Solution
    public long Part2(string[] linesArray)
    {

        long invalidIDSum = 0;

        foreach (string line in linesArray)
        {
            string[] rangeItem = line.Split(',');

            foreach (string range in rangeItem)
            {
                string[] bounds = range.Split("-");

                long lowerBound = (long)Int64.Parse(bounds[0]);
                long upperBound = (long)Int64.Parse(bounds[1]);



                for (long id = lowerBound; id <= upperBound; id++)
                {
                    string idString = id.ToString();

                    string combinedString = idString + idString;

                    string removedChars = combinedString.Substring(1, combinedString.Length - 2);

                    string reversedRemovedChars = new string(removedChars.Reverse().ToArray());




                    if (idString.Length % 2 == 0)
                    {

                        for (int i = 1; i <= idString.Length / 2; i++)
                        {

                            //even divisors
                            if (idString.Length % i == 0)
                            {
                                string firstSegment = idString.Substring(0, i);

                                Console.WriteLine("First Segment: {0}", firstSegment);

                                int secondSegmentLength = i * 2;
                                string secondSegment = idString.Substring(i, firstSegment.Length);
                                Console.WriteLine("Second Segment: {0}", secondSegment);

                                if (firstSegment == secondSegment)
                                {
                                    invalidIDSum += id;
                                    Thread.Sleep(1); // Ensures unique timestamp for each Console.WriteLine call
                                    Console.WriteLine("ID with multiple repeats: {0}", id);
                                    break;
                                }
                            }
                        }

                        int mid = idString.Length / 2;



                        string firstHalf = idString.Substring(0, mid);
                        string secondHalf = idString.Substring(mid);



                        //if (firstHalf == secondHalf)
                        //{
                        //    invalidIDSum += id;

                        //    Thread.Sleep(1); // Ensures unique timestamp for each Console.WriteLine call
                        //    Console.WriteLine("ID with one repeat: {0}", id);


                        //    continue;
                        //}


                        //if (reversedRemovedChars.EndsWith(idString) && idString.Length > 2)
                        //{
                        //    invalidIDSum += id;

                        //    Thread.Sleep(1); // Ensures unique timestamp for each Console.WriteLine call
                        //    Console.WriteLine("ID with two repeats: {0}", id);
                        //}


                        continue;

                    }

                    

                    //if (removedChars.Contains(idString))
                    //{

                    //    Thread.Sleep(1); // Ensures unique timestamp for each Console.WriteLine call
                    //    Console.WriteLine("ID with two repeats: {0}", id);

                    //    invalidIDSum += id;


                    //}

                }
            }

           
        }
        return invalidIDSum;
    }
}
//Main
public partial class Program
{
    public static void Main(string[] args)
    {

        Combination combination = new Combination();

        string[] linesArray = combination.linesArray(File.ReadAllLines("C:/Users/jproctor/source/repos/aoc2025/day2/input2.txt"));


        long part1Sum = combination.Part1(linesArray);
        long part2Sum = combination.Part2(linesArray);


        Console.WriteLine("Sum of Invalid IDs: {0}", part1Sum);
        Console.WriteLine("Sum of Invalid IDs with any repeat: {0}", part2Sum);

    }
}
