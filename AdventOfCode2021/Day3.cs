// See https://aka.ms/new-console-template for more information
using System.ComponentModel;

public class Day3
{
    public Day3()
    {
        List<string> input = File.ReadAllLines("Input/03.txt").ToList();

        Part1(input);
        Part2(input);
    }

    private void Part2(List<string> input)
    {

        List<string> binaryGammaRateinput = input;
        List<string> binaryEpsilonRateinput = input;

        int[] binaryGammaRate = GetBinaryGammaRate(binaryGammaRateinput);
        int[] binaryEpsilonRate = GetBinaryEpsilonRate(binaryEpsilonRateinput);

        for (int i = 0; i < binaryGammaRate.Length; i++)
        {
            binaryGammaRateinput = binaryGammaRateinput.Where(x => int.Parse(x.Substring(i, 1)) == binaryGammaRate[i]).ToList();
            binaryGammaRate = GetBinaryGammaRate(binaryGammaRateinput);
            if (binaryGammaRateinput.Count == 1) break;
        }

        for (int i = 0; i < binaryEpsilonRate.Length; i++)
        {
            binaryEpsilonRateinput = binaryEpsilonRateinput.Where(x => int.Parse(x.Substring(i, 1)) == binaryEpsilonRate[i]).ToList();
            binaryEpsilonRate = GetBinaryEpsilonRate(binaryEpsilonRateinput);
            if (binaryEpsilonRateinput.Count == 1) break;
        }
        binaryEpsilonRate = GetBinaryGammaRate(binaryEpsilonRateinput);

        int gammaRate = binToDec(binaryGammaRate);

        int epsilonRate = binToDec(binaryEpsilonRate);

        int powerConsumption = gammaRate * epsilonRate;

        Console.WriteLine($"{powerConsumption}");


    }

    private int[] GetBinaryEpsilonRate(List<string> input)
    {
        int[] result = new int[12] { 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0 };
        //result = new int[5] { 0, 0, 0, 0, 0 };
        for (int i = 0; i < input.Count; i++)
        {
            char[]? line = input[i].ToCharArray();
            for (int j = 0; j < line.Length; j++)
            {
                char c = line[j];
                if (c == '1')
                    result[j]++;
                else if (c == '0')
                    result[j]--;
            }
        }

        for (int i = 0; i < result.Length; i++)
        {
            result[i] = result[i] < 0 ? 1 : 0;
        }

        return result;
    }

    private static void Part1(List<string> input)
    {
        int[] binaryGammaRate = GetBinaryGammaRate(input);

        int[] binaryEpsilonRate = InvertToBinary(binaryGammaRate);

        int gammaRate = binToDec(binaryGammaRate);

        int epsilonRate = binToDec(binaryEpsilonRate);

        int powerConsumption = gammaRate * epsilonRate;

        Console.WriteLine($"{powerConsumption}");
    }

    private static int[] GetBinaryGammaRate(List<string> input)
    {
        int[] result = new int[12] { 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0 };
        for (int i = 0; i < input.Count; i++)
        {
            char[]? line = input[i].ToCharArray();
            for (int j = 0; j < line.Length; j++)
            {
                char c = line[j];
                if (c == '1')
                    result[j]++;
                else if (c == '0')
                    result[j]--;

            }
        }

        for (int i = 0; i < result.Length; i++)
        {
            result[i] = result[i] >= 0 ? 1 : 0;
        }

        return result;
    }

    private static int[] InvertToBinary(int[] result)
    {
        int[] resultInverted = new int[12] { 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0 };
        for (int i = 0; i < result.Length; i++)
        {
            resultInverted[i] = (result[i] + 1) % 2;
        }

        return resultInverted;
    }

    private static int binToDec(int[] result)
    {
        int bin = 0;
        int multiplier = 1;
        for (int i = result.Length - 1; i >= 0; --i)
        {

            bin += (multiplier * result[i]);
            multiplier *= 2;
        }

        return bin;
    }
}
