
using System;
using System.Linq;
using System.ComponentModel;
using System.Text.RegularExpressions;
using System.Reflection.Metadata.Ecma335;
using System.Text.Unicode;
using System.Security.Cryptography.X509Certificates;

public class MathHomework
{


    // Convert IEnumerable to Array
    public string[] linesArray(System.Collections.Generic.IEnumerable<string> lines)
    {
        return lines.ToArray();
    }


    // Part 1 Solution
    public long Part1(string[] linesArray)
    {

        int[,] mappedValueArray = new int[linesArray.Length - 1, linesArray[0].Length];
        string[,] mappedSymbolArray = new string[1, linesArray[^1].Length];

        int rows = linesArray.Length - 1;
        int cols = 0;

        for (int i = 0; i < linesArray.Length - 1; i++)
        {

            string[] currentValueArray = linesArray[i].ToString().Split(new char[0]).Where(s => !string.IsNullOrWhiteSpace(s)).ToArray();
            cols = currentValueArray.Length;


            for (int j = 0; j < cols; j++)
            {
                mappedValueArray[i, j] = Int32.Parse(currentValueArray[j]);
            }
        }

        


        string[] lastLineArray = linesArray[^1].ToString().Split(new char[0]).Where(s => !string.IsNullOrWhiteSpace(s)).ToArray();

        for (int i = 0; i < lastLineArray.Length; i++)
        {
            mappedSymbolArray[0, i] = lastLineArray[i];

        }


        long answerSum = 0;
        

        for (int i = 0; i < cols; i++)
        {

            long productSum = 1;

            for (int j = 0; j < rows; j++)
            {



                if (mappedSymbolArray[0, i] == "+")
                {
                    answerSum += mappedValueArray[j, i];
                }
                else if (mappedSymbolArray[0, i] == "*")
                {
                    productSum *= mappedValueArray[j, i];
                    
                }
            }

            if (productSum != 1)
            {
                answerSum += productSum;
            }

        }



        return answerSum;
    }

    //Part 2 Solution
    public long Part2(string[] linesArray)
    {


        string[,] twoDLinesArray = new string[linesArray.Length, linesArray[0].Length];


        for (int i = 0; i < linesArray.Length; i++)
        {
            for (int j = 0; j < linesArray[i].Length; j++)
            {
                twoDLinesArray[i, j] = linesArray[i][j].ToString();
            }
        }

        int rows = twoDLinesArray.GetLength(0);
        int cols = twoDLinesArray.GetLength(1);

        for (int i = 0; i < rows; i++)
        {
            for (int j = 0; j < cols / 2; j++)
            {
                string temp = twoDLinesArray[i, j];

                twoDLinesArray[i, j] = twoDLinesArray[i, cols - j - 1];

                twoDLinesArray[i, cols - j - 1] = temp;
            }

        }

        List<int> currentValues = new List<int>();

        long answerSum = 0;

        long addedSum = 0;
        long productSum = 1;

        //Loop through 2D array column-wise
        for (int i = 0; i < twoDLinesArray.GetLength(1); i++)
        {

            int spaceCount = 0;

            string currentColumn = "";
            string currentOperator = "";

            

            //Loop through each row in the current column
            for (int j = 0; j < twoDLinesArray.GetLength(0); j++)
            {
                if (twoDLinesArray[j, i] == " ")
                {
                    spaceCount++;
                    continue;
                }

                if (twoDLinesArray[j, i] == "+" || twoDLinesArray[j, i] == "*")
                {
                    currentOperator = twoDLinesArray[j, i];
                    continue;
                }

                

                currentColumn += twoDLinesArray[j, i];



            }

            if (currentColumn == "")
            {
                addedSum = 0;
                productSum = 1;
                currentValues.Clear();
                continue;
            }



            int currentVal = Int32.Parse(currentColumn);

            currentValues.Add(currentVal);







            if (currentOperator == "+")
            {
                foreach (int val in currentValues)
                {
                    addedSum += val;
                }

                answerSum += addedSum;
            }

            else if (currentOperator == "*")
            {
                foreach (int val in currentValues)
                {
                    productSum *= val;
                }

                answerSum += productSum;
            }


        }



        
        



        return answerSum;

    }
}
//Main
public partial class Program
{
    public static void Main(string[] args)
    {

        MathHomework mathHomework = new MathHomework();

        string[] linesArray = mathHomework.linesArray(File.ReadAllLines("C:/Users/jproctor/source/repos/aoc2025/day6/input.txt"));


        long part1Sum = mathHomework.Part1(linesArray);
        long part2Sum = mathHomework.Part2(linesArray);


        Console.WriteLine("Sum of all answers: {0}", part1Sum);
        Console.WriteLine("Sum of right-to-left column answers: {0}", part2Sum);

    }
}
