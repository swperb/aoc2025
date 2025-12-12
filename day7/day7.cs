
using System;
using System.Linq;
using System.ComponentModel;
using System.Text.RegularExpressions;
using System.Reflection.Metadata.Ecma335;
using System.Text.Unicode;
using System.Security.Cryptography.X509Certificates;
using System.CodeDom.Compiler;
using System.Collections.Generic;

public class TachyonBeams
{


    // Convert IEnumerable to Array
    public string[] linesArray(System.Collections.Generic.IEnumerable<string> lines)
    {
        return lines.ToArray();
    }


    // Part 1 Solution
    public long Part1(string[] linesArray)
    {
        int manifoldIndex = 0;
        for (int i = 0; i < linesArray[0].Length; i++)
        {
            string currentChar = linesArray[0][i].ToString();

            if (currentChar == "S")
            {
                manifoldIndex = i;
                break;
            }
        }

        string[,] beamMap = new string[linesArray.Length, linesArray[0].Length];

        for (int i = 0; i < linesArray.Length; i++)
        {
            for (int j = 0; j < linesArray[i].Length; j++)
            {
                beamMap[i, j] = linesArray[i][j].ToString();
            }
        }

        beamMap[1, manifoldIndex] = "|";

        long beamSplits = 0;


        for (int x = 1; x < beamMap.GetLength(0); x++)
        {
            for (int y = 0; y < beamMap.GetLength(1); y++)
            {
                if (beamMap[x, y] == "|")
                {
                    if (x + 1 >= beamMap.GetLength(0))
                    {
                        continue;
                    }
                    if (beamMap[x + 1, y] == "^")
                    {

                        if (y - 1 < 0 || y + 1 >= beamMap.GetLength(0))
                        {
                            continue;
                        }

                        beamSplits++;

                        beamMap[x + 1, y - 1] = "|";
                        beamMap[x + 1, y + 1] = "|";
                    }

                    else
                    {
                        beamMap[x + 1, y] = "|";
                    }
                }
            }

        }


        return beamSplits;
    }

    //Part 2 Solution
    public long Part2(string[] linesArray)
    {

        int manifoldIndex = 0;
        for (int i = 0; i < linesArray[0].Length; i++)
        {
            string currentChar = linesArray[0][i].ToString();

            if (currentChar == "S")
            {
                manifoldIndex = i;
                break;
            }
        }

        string[,] beamMap = new string[linesArray.Length, linesArray[0].Length];

        for (int i = 0; i < linesArray.Length; i++)
        {
            for (int j = 0; j < linesArray[i].Length; j++)
            {
                beamMap[i, j] = linesArray[i][j].ToString();
            }
        }


        beamMap[1, manifoldIndex] = "|";


        for (int x = 1; x < beamMap.GetLength(0); x++)
        {
            for (int y = 0; y < beamMap.GetLength(1); y++)
            {
                if (beamMap[x, y] == "|")
                {
                    if (x + 1 >= beamMap.GetLength(0))
                    {
                        continue;
                    }
                    if (beamMap[x + 1, y] == "^")
                    {

                        if (y - 1 < 0 || y + 1 >= beamMap.GetLength(0))
                        {
                            continue;
                        }


                        beamMap[x + 1, y - 1] = "|";
                        beamMap[x + 1, y + 1] = "|";
                    }

                    else
                    {
                        beamMap[x + 1, y] = "|";
                    }
                }
            }

        }


        int nodeCount = 0;

        int[,] prevNode = new int[1, 2];

        Dictionary<int, int[]> nodeCoordinates = new Dictionary<int, int[]>();

        Dictionary<int, List<int[]>> nodePaths = new Dictionary<int, List<int[]>>();

        List<List<int>> adjacency = new List<List<int>>();

        int[,] leftBeam = new int[1, 2];
        int[,] rightBeam = new int[1, 2];

        for (int x = 2; x < beamMap.GetLength(0); x++)
        {
            for (int y = 0; y < beamMap.GetLength(1); y++)
            {

                if (beamMap[x, y] == "^")
                {
                    nodeCount++;

                    if (y - 1 > 0 && beamMap[x, y - 1] == "|")
                    {
                        Console.WriteLine("Node {0} has a beam to the left", nodeCount);

                    }

                    if (y + 1 < beamMap.GetLength(1) && beamMap[x, y + 1] == "|")
                    {
                        Console.WriteLine("Node {0} has a beam to the right", nodeCount);

                        continue;
                    }


                    Console.WriteLine("Node {0} has no beams", nodeCount);




                }

            }
        }


        foreach (var node in nodePaths)
        {
            foreach (var coord in node.Value)
            {
                Console.WriteLine("Node {0} contains coordinate ({1}, {2})", node.Key, coord[0], coord[1]);
            }
        }



        return 0;

    }
}
//Main
public partial class Program
{
    public static void Main(string[] args)
    {

        TachyonBeams tachyonBeams = new TachyonBeams();

        string[] linesArray = tachyonBeams.linesArray(File.ReadAllLines("C:/Users/jproctor/source/repos/aoc2025/day7/input2.txt"));

        long part1Sum = tachyonBeams.Part1(linesArray);
        long part2Sum = tachyonBeams.Part2(linesArray);


        Console.WriteLine("Sum of all beam splits: {0}", part1Sum);
        //Console.WriteLine("Sum of right-to-left column answers: {0}", part2Sum);

    }
}
