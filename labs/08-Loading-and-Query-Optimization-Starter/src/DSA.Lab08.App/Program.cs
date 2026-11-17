using System;
using System.Diagnostics;
using DSA.Lab08;

internal static class Program
{
    private static void Main()
    {
        var lines = DemoData.Lines(20000);
        var parser = new QuestParser();
        var sw = Stopwatch.StartNew();
        var store = new PreparedQuestStore(lines, parser);
        sw.Stop();
        double prep = sw.Elapsed.TotalMilliseconds;

        sw.Restart();
        long sum = 0;
        for (int r = 0; r < 50; r++)
        {
            var q = store.FindById("Q15000");
            if (q != null)
                sum += q.Difficulty;
            sum += store.GetByRegion("North").Count;
        }
        sw.Stop();

        Console.WriteLine($"Preparation: {prep:F2} ms");
        Console.WriteLine($"Repeated queries: {sw.Elapsed.TotalMilliseconds:F2} ms");
        Console.WriteLine($"Parser calls total: {parser.ParseCount:n0}");
        Console.WriteLine($"Checksum: {sum}");
    }
}
