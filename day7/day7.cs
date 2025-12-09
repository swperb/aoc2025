
using System;
using System.Linq;
using System.ComponentModel;
using System.Text.RegularExpressions;
using System.Reflection.Metadata.Ecma335;
using System.Text.Unicode;
using System.Security.Cryptography.X509Certificates;
using System.CodeDom.Compiler;

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

        List<List<string>> beamPaths = new List<List<string>>();


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

    //DFS FUNCTION

    static void dfs (int node, int[] dest, List<List<int>> graph, bool[] visited, ref int count)
    {
        
        if (dest.Contains(node))
        {
            count++;
            return;
        }


        visited[node] = true;
        
        
        foreach (int neighbor in graph[node])
        {
            if (!visited[neighbor])
            {
                dfs(neighbor, dest, graph, visited, ref count);
            }
        }
        
        
        visited[node] = false;
    }

    static int countPaths(int n, int[][] edgeList, int source, int[] destination)
    {
        List<List<int>> graph = new List<List<int>>();
        
        for (int i = 0; i <= n; i++)
        {
            graph.Add(new List<int>());
        }

        foreach (int[] edge in edgeList)
        {
            int u = edge[0];
            int v = edge[1];
            graph[u].Add(v);
        }

        bool[] visited = new bool[n + 1];
        int count = 0;

        dfs(source, destination, graph, visited, ref count);

        return count;
    }

    //Part 2 Solution
    public long Part2(string[] linesArray)
    {
        string[,] beamTree = new string[linesArray.Length, linesArray[0].Length];

        for (int i = 0; i < linesArray.Length; i++)
        {
            for (int j = 0; j < linesArray[i].Length; j++)
            {
                beamTree[i, j] = linesArray[i][j].ToString();
            }
        }


        if (beamTree[0, beamTree.GetLength(1) / 2] == "S")
        {
            beamTree[0, beamTree.GetLength(1) / 2] = "1";
        }

        int nodeNum = 2;

        List<List<string>> beamPaths = new List<List<string>>();

        for (int i = 1; i < beamTree.GetLength(0); i++)
        {
            for (int j = 0; j < beamTree.GetLength(1); j++)
            {
                if (beamTree[i, j] == "^")
                {

                    if (i - 1 < 0 || j + 1 >= beamTree.GetLength(0))
                    {
                        continue;
                    }


                    beamPaths.Add(new List<string> { beamTree[i + 1, j - 1], beamTree[i, j] });

                    beamTree[i, j] = nodeNum.ToString();
                    nodeNum++;
                }



            }

        }

      

        List<int> destinationList = new List<int>();

        for (int i = 0; i < beamTree.GetLength(1); i++)
        {
            if (beamTree[beamTree.GetLength(0) - 2, i] != "|" && beamTree[beamTree.GetLength(0) - 2, i] != "." && beamTree[beamTree.GetLength(0) - 2, i] != "S")
            {
                destinationList.Add(Int32.Parse(beamTree[beamTree.GetLength(0) - 2, i]));
            }
        }

        int[] destination = destinationList.Distinct().ToArray();

        Console.WriteLine("Destinations: {0}", string.Join(", ", destination));

        //long pathSum = countPaths(nodeNum, *, 1, destination);


        return 0;

    }
}
//Main
public partial class Program
{
    public static void Main(string[] args)
    {

        TachyonBeams tachyonBeams = new TachyonBeams();

        string[] linesArray = tachyonBeams.linesArray(File.ReadAllLines("C:/Users/jproctor/source/repos/aoc2025/day7/input.txt"));

        long part1Sum = tachyonBeams.Part1(linesArray);
        long part2Sum = tachyonBeams.Part2(linesArray);


        Console.WriteLine("Sum of all beam splits: {0}", part1Sum);
        //Console.WriteLine("Sum of right-to-left column answers: {0}", part2Sum);

    }
}
