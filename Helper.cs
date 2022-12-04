using System.Text;

public static class AOCHelper
{
    private static readonly HttpClient client = new HttpClient();
    public static async Task<IEnumerable<string>> GetFile(string day, string year = "2022")
    {
        var session = File.ReadAllText("session.txt");

        var baseAddress = new Uri("https://adventofcode.com");
        using (var handler = new HttpClientHandler { UseCookies = false })
        using (var client = new HttpClient(handler) { BaseAddress = baseAddress })
        {
            var message = new HttpRequestMessage(HttpMethod.Get, $"/{year}/day/{day}/input");
            message.Headers.Add("Cookie", $"session={session};");
            var result = await client.SendAsync(message);
            result.EnsureSuccessStatusCode();
            return ReadLines(() => result.Content.ReadAsStream());
        }
    }

    public static IEnumerable<string> ReadLines(Func<Stream> streamProvider)
    {
        var lines = new List<string>();
        using (var stream = streamProvider())
        using (var reader = new StreamReader(stream))
        {
            string line;
            while ((line = reader.ReadLine()) != null)
            {
                lines.Add(line);
            }
        }
        return lines;
    }


}