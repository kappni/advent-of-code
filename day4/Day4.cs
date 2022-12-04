// See https://aka.ms/new-console-template for more information
public class Day4 : IDay
{
    public async Task<string> Execute1()
    {
        IEnumerable<string> lines = await AOCHelper.GetFile("4");
        Console.WriteLine(lines.Count());
        int counter = 0;
        foreach (string line in lines)
        {
            Value[] values = Value.getValues(line);
            if (values[0].isContained(values[1]) || values[1].isContained(values[0])) counter++;
        }

        return counter.ToString();


    }

    public async Task<string> Execute2()
    {
        IEnumerable<string> lines = await AOCHelper.GetFile("4");
        Console.WriteLine(lines.Count());
        int counter = 0;
        foreach (string line in lines)
        {
            Value[] values = Value.getValues(line);
            if (values[0].isOverlapping(values[1]) || values[1].isOverlapping(values[0])) counter++;
        }

        return counter.ToString();


    }
}

public struct Value
{
    Value(string line)
    {
        string[] splitted = line.Split('-');
        try {
            min = Int16.Parse(splitted[0]);
            max = Int16.Parse(splitted[1]);
        } catch {
            min = 0;
            max=10;
        }
    }

    public int min;
    public int max;
    public static Value[] getValues(string line)
    {
        string[] ranges = line.Split(',');
        return new Value[] { new Value(ranges[0]), new Value(ranges[1]) };
    }
    public bool isContained(Value other)
    {
        bool isContained = other.min >= this.min && other.max <= this.max;
        //if (isContained) Console.WriteLine($"{other.ToString()} is contained by {this.ToString()}");
        return isContained;
    }

    public bool isOverlapping(Value other)
    {
        bool isOverlapping = (other.min >= this.min && other.min <= this.max) || (other.max <= this.max && other.max >= this.min);
        //if (isOverlapping) Console.WriteLine($"{other.ToString()} is overlapped by {this.ToString()}");
        return isOverlapping;
    }

    public override string ToString()
    {
        return $"{min}-{max}";
    }
}

