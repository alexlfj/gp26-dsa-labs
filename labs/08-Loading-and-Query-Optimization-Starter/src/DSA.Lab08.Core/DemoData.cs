using System.Collections.Generic;

namespace DSA.Lab08
{
    public static class DemoData
    {
        public static List<string> Lines(int count)
        {
            var xs = new List<string>(count);
            string[] regions = { "North", "South", "East", "West" };

            for (int i = 0; i < count; i++)
                xs.Add($"Q{i}|{regions[i%4]}|{1+(i%10)}");

            return xs;
        }
    }
}
