using System;

namespace DSA.Lab08
{
    public sealed class QuestParser
    {
        public int ParseCount { get; private set; }

        public QuestRecord Parse(string line)
        {
            ParseCount++;
            string[] p = line.Split('|');
            if (p.Length != 3)
                throw new FormatException("Expected id|region|difficulty");

            return new QuestRecord(p[0], p[1], int.Parse(p[2]));
        }
    }
}
