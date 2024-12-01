using System.Runtime.InteropServices;
using System.Text;

public class Day1
{
    private string filePath = "/Users/johanahlqvist/Source/AoC2024/AoC2024/Day1Input.txt";
    private string input = string.Empty;
    private List<int> left = new List<int>(1000);
    private List<int> right = new List<int>(1000);
    private List<int> difference = new List<int>();
    private int total;
    public bool GetInput()
    {
        try
        {
            var stringBuilder = new StringBuilder();
            using (var reader = new StreamReader(filePath))
            {
                string line;
                while ((line = reader.ReadLine())
                       != null)
                {
                    stringBuilder.AppendLine(line);
                }
            }

            string v = stringBuilder.ToString();
            input = v;
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
        using (var reader = new StringReader(input))
        {
            string row;
            while ((row = reader.ReadLine()) != null)
            {
                int firstSpace = row.IndexOf(' ');
                if (firstSpace > 0)
                {
                    string firstPart = row.Substring(0, firstSpace);
                    string secondPart = row.Substring(firstSpace + 1).Trim();

                    if (int.TryParse(firstPart, out int number1) && int.TryParse(secondPart, out int number2))
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
                else
                {
                    Console.WriteLine("Invalid input format.");
                    return false;
                }
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
        // Step 1: Create a dictionary to store the counts of elements in the `right` list
        var rightCounts = new Dictionary<int, int>();
        foreach (var r in right)
        {
            if (rightCounts.ContainsKey(r))
            {
                rightCounts[r]++;
            }
            else
            {
                rightCounts[r] = 1;
            }
        }

        // Step 2: Compute the similarity score using precomputed counts
        long totalScore = 0;
        foreach (var l in left)
        {
            if (rightCounts.TryGetValue(l, out int count))
            {
                totalScore += l * count;
            }
        }

        return totalScore;        
    }
}
