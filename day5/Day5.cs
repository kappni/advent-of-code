// See https://aka.ms/new-console-template for more information
using System.Text.RegularExpressions;
using static System.Linq.Enumerable;

public class Day5 : IDay
{
    public async Task<string> Execute1()
    {
        IEnumerable<string> lines = await AOCHelper.GetFile("5");
        var stack = new Stack(lines.Take(8));
        foreach(var line in lines.Skip(10)){
            stack.Move(line);
        }
        
        return stack.GetTopRow();
    }

    public async Task<string> Execute2()
    {
        IEnumerable<string> lines = await AOCHelper.GetFile("5");
        var stack = new Stack(lines.Take(8));
        foreach(var line in lines.Skip(10)){
            stack.Move(line, false);
        }
        
        return stack.GetTopRow();
    }
}

public class Stack
{
    List<List<char>> stacks = new();

    public Stack(IEnumerable<string> lines)
    {
        foreach (int i in Range(0, 9))
        {
            stacks.Add(new List<char>());
        }


        lines = lines.Reverse();
        foreach (var line in lines)
        {
            IEnumerable<char?> chars = splitAfter4Chars(line);
            foreach (int i in Range(0, 9))
            {
                if (chars.ElementAt(i).HasValue) stacks.ElementAt(i).Add(chars.ElementAt(i).Value);
            }
        }
    }

    private IEnumerable<char?> splitAfter4Chars(string line)
    {
        List<char?> chars = new();
        char? current = null;
        for (int i = 0; i < line.Count(); i++)
        {
            if (i > 0 && ((i % 4 == 0) || (line.Count() == (i + 1))))
            {
                chars.Add(current);
                current = null;
            }
            if (Char.IsLetter(line[i]))
            {
                current = line[i];
            }
        }
        return chars;
    }


    public void Move(string command, bool isOld = true) {
        IEnumerable<int> numbers = Regex.Split(command, @"\D+").Where(x => !String.IsNullOrWhiteSpace(x)).Select(x => int.Parse(x));
        List<char> elemetns = stacks.ElementAt(numbers.ElementAt(1)-1).GetRange(stacks.ElementAt(numbers.ElementAt(1)-1).Count() - numbers.ElementAt(0),numbers.ElementAt(0));
        if(isOld) elemetns.Reverse();
        stacks.ElementAt(numbers.ElementAt(1)-1).RemoveRange(stacks.ElementAt(numbers.ElementAt(1)-1).Count() - numbers.ElementAt(0),numbers.ElementAt(0));
        stacks.ElementAt(numbers.ElementAt(2)-1).AddRange(elemetns);
    }

    public string GetTopRow() {
        return new String(stacks.Select(x => x.Last()).ToArray());
    }
}
