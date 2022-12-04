// See https://aka.ms/new-console-template for more information
public class Day3 : IDay
{
    public async Task<string> Execute1()
    {
        int sum = 0;
        IEnumerable<string> lines = await AOCHelper.GetFile("3");
        foreach (var line in lines)
        {
            var first = line.Substring(0, line.Count() / 2);
            var second = line.Substring(line.Count() / 2);

            var duplicate = getIntRepresentation(first.ToList().Intersect(second.ToList()).First());
            sum += duplicate;
        }
        return sum.ToString();
    }

    public async Task<string> Execute2()
    {
        IEnumerable<string> lines = await AOCHelper.GetFile("3");
        int sum = 0;
        var enumerator = lines.GetEnumerator();
        while (enumerator.MoveNext())
        {
            var first = enumerator.Current.ToList();
            enumerator.MoveNext();
            var second = enumerator.Current;
            enumerator.MoveNext();
            var third = enumerator.Current;

            var duplicate = getIntRepresentation(first.Intersect(second).Intersect(third).First());
            sum += duplicate;
        }
        return sum.ToString();
    }

    private int getIntRepresentation(char c)
    {
        if (char.IsUpper(c))
        {
            return (int)c - 38;
        }
        else if (char.IsLower(c))
        {
            return (int)c - 96;
        }

        throw new ArgumentException();
    }
}

