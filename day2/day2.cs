using System.Text.RegularExpressions;

public class InvalidID
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


                //!!!!!!!!!!!!!!!!!!!!!THIS SOLUTION WORKS !!!!!!!!!!!!!!!!!!!!!!
                for (long id = lowerBound; id <= upperBound; id++)
                {


                    Regex regex = new Regex(@"^(.+)\1+$");

                    MatchCollection matches = regex.Matches(id.ToString());

                    if (matches.Count > 0)
                    {
                        invalidIDSum += id;
                    }


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

        InvalidID invalidID = new InvalidID();

        string[] linesArray = invalidID.linesArray(File.ReadAllLines("C:/Users/jproctor/source/repos/aoc2025/day2/input.txt"));


        long part1Sum = invalidID.Part1(linesArray);
        long part2Sum = invalidID.Part2(linesArray);


        Console.WriteLine("Sum of Invalid IDs: {0}", part1Sum);
        Console.WriteLine("Sum of Invalid IDs with any repeat: {0}", part2Sum);

    }
}
