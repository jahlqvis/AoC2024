using System.Runtime.InteropServices;

public class Day1
{
    private string filePath = "/Users/johanahlqvist/Source/AoC2024/AoC2024/Day1Input.txt";
    private string input = string.Empty;
    private List<int> left = new List<int>();
    private List<int> right = new List<int>();
    private List<int> difference = new List<int>();
    private int total;
    public bool GetInput()
    {
        try
        {
            input = File.ReadAllText(filePath);
            return true;
        }
        catch (IOException e)
        {
            Console.WriteLine($"An error occurred: {e.Message}");
            return false;
        }
    }
    public bool PutIntoLists()
    {
        string[] rows = input.Split(new[] { "\r\n", "\n" }, StringSplitOptions.None);
        
        foreach (string row in rows)
        {
            var parts = row.Split( new[] { ' ', '\t' }, StringSplitOptions.RemoveEmptyEntries);
            if (parts.Length >= 2 && int.TryParse(parts[0], out int number1) && int.TryParse(parts[1], out int number2))
            {
                left.Add(number1);
                right.Add(number2);
            }
            else
            {
                Console.WriteLine("The input string does not contain two valid numbers.");
                return false;
            }
        }

        Console.WriteLine($"{left.Count()} numbers added to left list");
        Console.WriteLine($"{right.Count()} numbers added to right list");
        return true;
    }
    public bool SortLists()
    {
        left.Sort();
        right.Sort();
        return true;
    }
    public bool GetDifferences()
    {
        if(left.Count != right.Count)
            return false;

        for(int i=0;i<left.Count;i++)
        {
            difference.Add(Math.Abs(left[i] - right[i]));
        }
        return true;
    }
    public int GetTotalDistance()
    {
        total = 0;
        foreach(var d in difference) total += d;
        return total;
    }
    public long GetSimilarityScore()
    {
        var dict = new Dictionary<int, int>();
        
        foreach(var l in left)
        {
            var counts = right.Count(n => n == l);
            dict.Add(l, counts);
        }

        long totalScore = 0;
        foreach(var d in dict)
        {
            totalScore += d.Key * d.Value;
        }

        return totalScore;
    }
}
