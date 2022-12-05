public class Day1 : IDay
{
    public async Task<string> Execute1()
    {
        IEnumerable<string> lines = await AOCHelper.GetFile("1");
        int max = 0;
        int current = 0;
        foreach(string line in lines) {
            if(string.IsNullOrEmpty(line)) {
                if(current > max) max = current;
                current = 0;
            } else {
                current += int.Parse(line);
            }
        }
        return max.ToString();
    }

    public async Task<string> Execute2()
    {
        IEnumerable<string> lines = await AOCHelper.GetFile("1");
        List<int> combined = new();
        int current = 0;
        foreach(string line in lines) {
            if(string.IsNullOrEmpty(line)) {
                combined.Add(current);
                current = 0;
            } else {
                current += int.Parse(line);
            }
        }
        int sum = combined.OrderByDescending(c => c).Take(3).Sum();
        return sum.ToString();
    }
}

